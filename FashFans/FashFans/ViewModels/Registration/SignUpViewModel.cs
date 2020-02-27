using FashFans.Exceptions;
using FashFans.Models.Args.Authentication;
using FashFans.Models.Identities;
using FashFans.Services.Cancrellation;
using FashFans.Services.Identity;
using FashFans.ViewModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.Registration {
    public sealed class SignUpViewModel : ContentPageBaseViewModel {

        private readonly IIdentityService _identityService;

        private readonly ICancellationService _cancellationService;

        bool _isAgree;
        public bool IsAgree {
            get { return _isAgree; }
            set { SetProperty(ref _isAgree, value); }
        }

        string _fullName;
        public string FullName {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
        }

        string _password;
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _email;
        public string Email {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public ICommand SignInCommand => new Command(async () => {
            await NavigationService.NavigateToAsync<SignInViewModel>();
            await NavigationService.RemoveLastFromBackStackAsync();
        });

        public ICommand SignUpCommand => new Command(() => OnSignUp());

        /// <summary>
        ///     ctor().
        /// </summary>
        public SignUpViewModel(IIdentityService identityService, ICancellationService cancellationService) {
            _identityService = identityService;

            _cancellationService = cancellationService;
        }

        public override void Dispose() {
            base.Dispose();

            _cancellationService.Cancel();
        }

        public override Task InitializeAsync(object navigationData) {
            return base.InitializeAsync(navigationData);
        }

        private async void OnSignUp() {
            if(IsAgree) {
                if(Validate()) {
                    Guid busyKey = Guid.NewGuid();
                    SetBusy(busyKey, true);

                    SignUpArgs signUpArgs = new SignUpArgs {
                        Email = Email,
                        FullName = FullName,
                        Password = Password
                    };

                    try {
                        bool signUpResult = await _identityService.SignUpAsync(signUpArgs, _cancellationService.GetToken());
                        if(signUpResult) {
                            await NavigationService.InitializeAsync();
                        } else {
                            Debugger.Break();
                        }
                    }
                    catch(Exception ex) {
                        try {
                            HttpRequestResultException httpRequestResultException = JsonConvert.DeserializeObject<HttpRequestResultException>(ex.Message);
                            if(httpRequestResultException != null) {
                                Debug.WriteLine($"ERROR:{httpRequestResultException.Message}");
                                await DialogService.ShowAlertAsync(httpRequestResultException.Message, "Error", "OK");
                            }
                        }
                        catch(Exception) { }

                        Debug.WriteLine($"ERROR:{ex.Message}");
                        Debugger.Break();
                    }
                    SetBusy(busyKey, false);
                } else {
                    await DialogService.ShowAlertAsync("Fields required", "Sign up info", "OK");
                }
            } else {
                await DialogService.ShowAlertAsync("Need agree to terms!", "Info", "OK");
            }
        }

        private bool Validate() {
            bool isValid = !string.IsNullOrEmpty(FullName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email);

            return isValid;
        }
    }
}

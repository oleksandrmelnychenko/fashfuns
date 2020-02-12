using FashFans.Exceptions;
using FashFans.Helpers;
using FashFans.Models.Args.Authentication;
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
    public sealed class SignInViewModel : ContentPageBaseViewModel {

        private readonly IIdentityService _identityService;

        private readonly ICancellationService _cancellationService;

        string _email;
        public string Email {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _password;
        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        bool _isRemember;
        public bool IsRemember {
            get { return _isRemember; }
            set { SetProperty(ref _isRemember, value); }
        }

        public ICommand ForgotCommand => new Command(async () => {
            //await NavigationService.NavigateToAsync<SignInViewModel>();
        });

        public ICommand SignInCommand => new Command(() => OnSignIn());

        /// <summary>
        ///     ctor().
        /// </summary>
        public SignInViewModel(IIdentityService identityService, ICancellationService cancellationService) {
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

        private async void OnSignIn() {
            if (Valdate()) {
                Guid busyKey = Guid.NewGuid();
                SetBusy(busyKey, true);

                SignInArgs signInArgs = new SignInArgs {
                    Email = Email,
                    Password = Password
                };

                try {
                    bool signInResult = await _identityService.SignInAsync(signInArgs, _cancellationService.GetToken());

                    if (signInResult) {
                        await NavigationService.InitializeAsync();
                        BaseSingleton<GlobalSetting>.Instance.UserProfile.IsAuth = IsRemember;
                        BaseSingleton<GlobalSetting>.Instance.UserProfile.SaveChanges();
                    } else {
                        await DialogService.ShowAlertAsync("In developing", "ERROR", "OK");
                    }
                }
                catch (HttpRequestExceptionEx ex) {
                    var tt = JsonConvert.DeserializeObject<HttpRequestResultException>(ex.Message);
                    Debug.WriteLine($"ERROR:{tt.Message}");
                    Debugger.Break();
                    SetBusy(busyKey, false);
                    await DialogService.ShowAlertAsync(tt.Message, "ERROR", "OK");
                }
                catch (Exception ex) {
                    SetBusy(busyKey, false);
                    Debug.WriteLine($"ERROR:{ex.Message}");
                    Debugger.Break();
                }
                SetBusy(busyKey, false);
            } else {
                await DialogService.ShowAlertAsync("Fields required", "Sign in info", "OK");
            }

        }

        private bool Valdate() {
            bool isValid = !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

            return isValid;
        }
    }
}

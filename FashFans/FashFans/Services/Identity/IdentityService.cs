using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FashFans.Exceptions;
using FashFans.Helpers;
using FashFans.Models.Args.Authentication;
using FashFans.Models.Identities;
using FashFans.Services.Navigation;
using FashFans.Services.RequestProvider;
using Xamarin.Forms;

namespace FashFans.Services.Identity {
    public sealed class IdentityService : IIdentityService {

        private readonly IRequestProvider _requestProvider;

        private readonly INavigationService _navigationService;

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="requestProvider"></param>
        public IdentityService(IRequestProvider requestProvider, INavigationService navigationService) {
            _requestProvider = requestProvider;
            _navigationService = navigationService;
        }


        public async Task<bool> SignInAsync(SignInArgs signInArgsArgs, CancellationToken cancellationToken = default(CancellationToken)) =>
            await Task.Run(async () => {
                bool isSuccess = default(bool);
                AuthenticationResult authenticationResult = null;

                string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.IdentityEndpoints.SignInEndPoint;

                try {
                    authenticationResult = await _requestProvider.PostAsync<AuthenticationResult, SignInArgs>(url, signInArgsArgs);

                    if (authenticationResult != null && authenticationResult.Data != null) {
                        SetupProfileAsync(authenticationResult.Data);
                        isSuccess = true;
                    }
                }
                catch (ConnectivityException ex) {
                    throw ex;
                }
                catch (HttpRequestExceptionEx ex) {
                    throw ex;
                }
                catch (Exception ex) {
                    Debug.WriteLine($"ERROR:{ex.Message}");
                    Debugger.Break();
                }

                return isSuccess;
            }, cancellationToken);

        public async Task<bool> SignUpAsync(SignUpArgs signUpArgs, CancellationToken cancellationToken = default(CancellationToken)) =>
           await Task.Run(async () => {
               bool isSuccess = default(bool);
               AuthenticationResult authenticationResult = null;

               string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.IdentityEndpoints.SignUpEndPoint;

               try {
                   authenticationResult = await _requestProvider.PostAsync<AuthenticationResult, SignUpArgs>(url, signUpArgs);

                   if (authenticationResult != null) {
                       SetupProfileAsync(authenticationResult.Data);
                       isSuccess = true;
                   }
               }
               catch (ConnectivityException ex) {
                   throw ex;
               }
               catch (HttpRequestExceptionEx ex) {
                   throw ex;
               }
               catch (Exception ex) {
                   Debug.WriteLine($"ERROR:{ex.Message}");
                   Debugger.Break();
               }

               return isSuccess;
           }, cancellationToken);

        public async Task LogOutAsync() {
            try {
                BaseSingleton<GlobalSetting>.Instance.UserProfile.ClearUserProfile();
                BaseSingleton<GlobalSetting>.Instance.UserProfile.SaveChanges();


                await _navigationService.InitializeAsync();
                Device.BeginInvokeOnMainThread(() => {
                });
            }
            catch (Exception ex) {
                Debugger.Break();
                Debug.WriteLine($"ERROR:{ex.Message}");
                throw;
            }
        }


        private void SetupProfileAsync(User user) {
            try {
                BaseSingleton<GlobalSetting>.Instance.UserProfile.Id = user.Id;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.AccesToken = user.Token;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.RefreshToken = string.Empty;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.IsAuth = true;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.Email = user.Email;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.UserName = user.Name;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.AvatarUrl = string.Empty;
                BaseSingleton<GlobalSetting>.Instance.UserProfile.IsAdministrator = user.IsAdministrator;

                BaseSingleton<GlobalSetting>.Instance.UserProfile.SaveChanges();
            }
            catch (Exception ex) {
                Debug.WriteLine($"ERROR:{ex.Message}");
                Debugger.Break();
            }
        }
    }
}

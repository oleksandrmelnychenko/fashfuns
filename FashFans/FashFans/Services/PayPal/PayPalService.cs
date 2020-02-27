using FashFans.Exceptions;
using FashFans.Helpers;
using FashFans.Models.Args.PayPal;
using FashFans.Models.PayPal;
using FashFans.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace FashFans.Services.PayPal {
    public sealed class PayPalService : IPayPalService {

        private const string CLIENT_ID = "Act90tyvdDzV-XMi4zfxlIx-eEdRCA1eagJta0aLhFJQdh9TZ4WU8tfLyCL_ajNfjbZiN4cvjPwXpjym";

        private const string SECRET = "EIGbPhDNe4AzkCJt1N9wtfm1nRv22xhI2zhJyJMJm4aMEg3ef2PuV4gqEm2OdpT2OwBiFQOjMusu1elz";

        private readonly IRequestProvider _requestProvider;

        private readonly PayPalAppCredentionals _payPalAppCredentionals;

        public PayPalService(IRequestProvider requestProvider) {
            _requestProvider = requestProvider;

            _payPalAppCredentionals = new PayPalAppCredentionals {
                UserName = CLIENT_ID,
                Password = SECRET
            };
        }

        public async Task<PayPalTokenArgs> GetAccessTokenAsync(CancellationToken cancellationToken = default) =>
            await Task.Run(async () => {
                PayPalTokenArgs payPalTokenArgs = default;

                string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.PayPalEndpoints.PayPalAccessTokenEndPoint;

                try {
                    payPalTokenArgs = await _requestProvider.PostFormUrlEncodedAsync<PayPalTokenArgs>(url, _payPalAppCredentionals);
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
                return payPalTokenArgs;
            }, cancellationToken);


        public async Task<WebExperienceProfile> CreateWebExperienceProfileAsync(WebProfileInfo createWebProfileInfo, CancellationToken cancellationToken = default) =>
            await Task.Run(async () => {
                WebExperienceProfile webExperienceProfile = default;

                string accessToken = BaseSingleton<GlobalSetting>.Instance.UserProfile.PayPalTokenArgs.AccessToken;

                string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.PayPalEndpoints.CreateWebExperienceProfileEndPoint;

                try {
                    webExperienceProfile = await _requestProvider.PostAsync<WebExperienceProfile, WebProfileInfo>(url, createWebProfileInfo, accessToken);
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
                return webExperienceProfile;
            }, cancellationToken);

        public async Task<WebExperienceProfile> GetWebExperienceProfileByIdAsync(string id, CancellationToken cancellationToken = default) =>
            await Task.Run(async () => {
                WebExperienceProfile webExperienceProfile = default;

                string accessToken = BaseSingleton<GlobalSetting>.Instance.UserProfile.PayPalTokenArgs.AccessToken;

                string url = string.Format(BaseSingleton<GlobalSetting>.Instance.RestEndpoints.PayPalEndpoints.GetWebExperienceProfileByIdEndPoint, id);

                try {
                    webExperienceProfile = await _requestProvider.GetAsync<WebExperienceProfile>(url, accessToken);
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

                return webExperienceProfile;
            }, cancellationToken);

        public async Task<List<WebExperienceProfile>> GetWebExperienceProfilesAsync(CancellationToken cancellationToken = default) =>
            await Task.Run(async () => {
                List<WebExperienceProfile> webExperienceProfiles = default;

                string accessToken = BaseSingleton<GlobalSetting>.Instance.UserProfile.PayPalTokenArgs.AccessToken;

                string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.PayPalEndpoints.GetWebExperienceProfilesEndPoint;

                try {
                    webExperienceProfiles = await _requestProvider.GetAsync<List<WebExperienceProfile>>(url, accessToken);
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

                return webExperienceProfiles;
            }, cancellationToken);
    }
}

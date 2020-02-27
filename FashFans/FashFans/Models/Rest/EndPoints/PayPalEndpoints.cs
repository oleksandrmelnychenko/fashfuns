using System;
using System.Collections.Generic;
using System.Text;

namespace FashFans.Models.Rest.EndPoints {
    public class PayPalEndpoints {

        private const string PAYPAL_TOKEN_API_KEY = "v1/oauth2/token";

        private const string CREATE_WEB_EXPERIENCE_PROFILE_API_KEY = "v1/payment-experience/web-profiles";

        private const string GET_WEB_EXPERIENCE_PROFILE_BY_ID_API_KEY = "v1/payment-experience/web-profiles/{0}";

        private const string GET_WEB_EXPERIENCE_PROFILES_API_KEY = "v1/payment-experience/web-profiles";

        string _baseEndpoint;
        public string BaseEndpoint {
            get { return _baseEndpoint; }
            set {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }

        public string PayPalAccessTokenEndPoint { get; private set; }

        public string CreateWebExperienceProfileEndPoint { get; private set; }

        public string GetWebExperienceProfileByIdEndPoint { get; private set; }

        public string GetWebExperienceProfilesEndPoint { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="defaultEndPoint"></param>
        public PayPalEndpoints(string defaultEndPoint) {
            BaseEndpoint = defaultEndPoint;
        }

        private void UpdateEndpoint(string baseEndpoint) {
            PayPalAccessTokenEndPoint = $"{baseEndpoint}/{PAYPAL_TOKEN_API_KEY}";
            GetWebExperienceProfilesEndPoint = $"{baseEndpoint}/{GET_WEB_EXPERIENCE_PROFILES_API_KEY}";
            CreateWebExperienceProfileEndPoint = $"{baseEndpoint}/{CREATE_WEB_EXPERIENCE_PROFILE_API_KEY}";
            GetWebExperienceProfileByIdEndPoint = $"{baseEndpoint}/{GET_WEB_EXPERIENCE_PROFILE_BY_ID_API_KEY}";
        }
    }
}

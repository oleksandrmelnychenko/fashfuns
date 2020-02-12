namespace FashFans.Models.Rest.EndPoints {
    public class IdentityEndpoints {

        private const string SIGNIN_API_KEY = "api/v1/identity/signin";

        private const string SIGNUP_API_KEY = "api/v1/identity/signup";

        string _baseEndpoint;
        public string BaseEndpoint {
            get { return _baseEndpoint; }
            set {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }

        public string SignUpEndPoint { get; private set; }

        public string SignInEndPoint { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="defaultEndPoint"></param>
        public IdentityEndpoints(string defaultEndPoint) {
            BaseEndpoint = defaultEndPoint;
        }

        private void UpdateEndpoint(string baseEndpoint) {
            SignUpEndPoint = $"{baseEndpoint}/{SIGNUP_API_KEY}";
            SignInEndPoint = $"{baseEndpoint}/{SIGNIN_API_KEY}";
        }
    }
}

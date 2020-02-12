namespace FashFans.Models.Rest.EndPoints {
    public sealed class RestEndpoints {

        public const string DEFAULT_ENDPOINT = "http://31.128.79.4:12613"; // Release

        /// <summary>
        /// Identity endpoints.
        /// </summary>
        public IdentityEndpoints IdentityEndpoints { get; set; } = new IdentityEndpoints(DEFAULT_ENDPOINT);
        /// <summary>
        /// Shopping endpoints.
        /// </summary>
        public ShoppingEndPoints ShoppingEndPoints { get; set; } = new ShoppingEndPoints(DEFAULT_ENDPOINT);
    }
}

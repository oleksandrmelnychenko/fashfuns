namespace FashFans.Models.Rest.EndPoints {
    public sealed class RestEndpoints {

        public const string DEFAULT_ENDPOINT = "http://31.128.79.4:12613"; // Release

        public const string SANDBOX_PAYPAL_ENDPOINT = "https://api.sandbox.paypal.com";

        public const string LIVE_PAYPAL_ENDPOINT = "https://api.paypal.com";

        public IdentityEndpoints IdentityEndpoints { get; set; } = new IdentityEndpoints(DEFAULT_ENDPOINT);
       
        public ShoppingEndPoints ShoppingEndPoints { get; set; } = new ShoppingEndPoints(DEFAULT_ENDPOINT);

        public PayPalEndpoints PayPalEndpoints { get; set; } = new PayPalEndpoints(SANDBOX_PAYPAL_ENDPOINT);
    }
}

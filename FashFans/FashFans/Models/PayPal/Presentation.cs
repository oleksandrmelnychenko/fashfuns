using Newtonsoft.Json;

namespace FashFans.Models.PayPal {
    public    class Presentation {
        [JsonProperty("logo_image")]
        public string LogoImage { get; set; }
    }
}

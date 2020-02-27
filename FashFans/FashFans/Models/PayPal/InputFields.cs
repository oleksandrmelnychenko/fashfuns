using Newtonsoft.Json;

namespace FashFans.Models.PayPal {
    public class InputFields {
        [JsonProperty("no_shipping")]
        public long NoShipping { get; set; }

        [JsonProperty("address_override")]
        public long AddressOverride { get; set; }
    }
}

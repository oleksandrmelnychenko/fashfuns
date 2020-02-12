using Newtonsoft.Json;

namespace FashFans.Models.Identities {
    public class ShoppingCartInfo {
        [JsonProperty("ItemTotal")]
        public long ItemTotal { get; set; }

        [JsonProperty("Shipping")]
        public long Shipping { get; set; }

        [JsonProperty("OrderTotal")]
        public long OrderTotal { get; set; }

        [JsonProperty("OrderItems")]
        public object[] OrderItems { get; set; }
    }
}

using Newtonsoft.Json;

namespace FashFans.Models.Identities {
    public class ShoppingCartInfo {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("ProductCount")]
        public long ProductCount { get; set; }

        [JsonProperty("TotalPrice")]
        public double TotalPrice { get; set; }

        [JsonProperty("Shipping")]
        public long Shipping { get; set; }

        [JsonProperty("OrderTotalPrice")]
        public double OrderTotalPrice { get; set; }

        [JsonProperty("OrderItems")]
        public OrderItem[] OrderItems { get; set; }
    }
}

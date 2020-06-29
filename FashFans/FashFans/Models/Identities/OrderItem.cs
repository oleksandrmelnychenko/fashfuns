using Newtonsoft.Json;
using System;

namespace FashFans.Models.Identities {
    public class OrderItem {
        [JsonProperty("ProductId")]
        public long ProductId { get; set; }

        [JsonProperty("Product")]
        public Product Product { get; set; }

        [JsonProperty("Qty")]
        public long Qty { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("Created")]
        public DateTime? Created { get; set; }

        [JsonProperty("LastModified")]
        public DateTime? LastModified { get; set; }
    }
}

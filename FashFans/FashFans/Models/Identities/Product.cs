using Newtonsoft.Json;
using System;

namespace FashFans.Models.Identities {
    public class Product {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Rate")]
        public long Rate { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("ProductCategoryId")]
        public long ProductCategoryId { get; set; }

        [JsonProperty("ProductCategory")]
        public ProductCategory ProductCategory { get; set; }

        [JsonProperty("ImageSource")]
        public string ImageSource { get; set; }

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

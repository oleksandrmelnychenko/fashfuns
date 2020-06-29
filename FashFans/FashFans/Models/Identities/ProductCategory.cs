using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashFans.Models.Identities {
    public class ProductCategory {
        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Products")]
        public Product[] Products { get; set; }

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

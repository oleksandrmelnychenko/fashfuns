using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashFans.Models.Identities {
    public class User {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("CanUserResetExpiredPassword")]
        public bool CanUserResetExpiredPassword { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("IsAdministrator")]
        public bool IsAdministrator { get; set; }

        [JsonProperty("IsPasswordExpired")]
        public bool IsPasswordExpired { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PasswordExpiresAt")]
        public DateTime PasswordExpiresAt { get; set; }

        [JsonProperty("PasswordExpiresAtTicks")]
        public string PasswordExpiresAtTicks { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("TokenExpiresAt")]
        public DateTime TokenExpiresAt { get; set; }

        [JsonProperty("TokenExpiresAtTicks")]
        public string TokenExpiresAtTicks { get; set; }
    }
}

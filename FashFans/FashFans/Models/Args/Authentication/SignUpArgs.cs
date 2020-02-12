using Newtonsoft.Json;

namespace FashFans.Models.Args.Authentication {
    public class SignUpArgs {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}

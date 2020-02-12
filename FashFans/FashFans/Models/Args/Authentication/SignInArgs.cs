using Newtonsoft.Json;

namespace FashFans.Models.Args.Authentication {
    public class SignInArgs {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }       
    }
}

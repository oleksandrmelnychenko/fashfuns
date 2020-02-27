using Newtonsoft.Json;

namespace FashFans.Models.PayPal {
    public class WebProfileInfo {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("presentation")]
        public Presentation Presentation { get; set; }

        [JsonProperty("input_fields")]
        public InputFields InputFields { get; set; }

        [JsonProperty("flow_config")]
        public FlowConfig FlowConfig { get; set; }
    }
}

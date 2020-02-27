using Newtonsoft.Json;

namespace FashFans.Models.PayPal {
    public  class WebExperienceProfile {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("temporary")]
        public bool Temporary { get; set; }

        [JsonProperty("flow_config")]
        public FlowConfig FlowConfig { get; set; }

        [JsonProperty("input_fields")]
        public InputFields InputFields { get; set; }

        [JsonProperty("presentation")]
        public Presentation Presentation { get; set; }
    }
}

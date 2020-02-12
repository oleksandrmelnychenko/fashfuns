using Newtonsoft.Json;

namespace FashFans.Models.Identities {
    public abstract class BaseResponse<TData> {
        [JsonProperty("StatusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Body")]
        public abstract TData Data { get; set; }
    }
}

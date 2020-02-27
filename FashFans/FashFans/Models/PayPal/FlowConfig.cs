using Newtonsoft.Json;
using System;

namespace FashFans.Models.PayPal {
    public class FlowConfig {
        [JsonProperty("landing_page_type")]
        public string LandingPageType { get; set; }

        [JsonProperty("bank_txn_pending_url")]
        public string BankTxnPendingUrl { get; set; }
    }
}

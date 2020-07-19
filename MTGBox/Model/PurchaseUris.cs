using Newtonsoft.Json;
using System;

namespace MTGBox.Model
{
    class PurchaseUris
    {
        [JsonProperty("tcgplayer")]
        public String Tcgplayer { get; set; }

        [JsonProperty("cardmarket")]
        public String Cardmarket { get; set; }

        [JsonProperty("cardhoarder")]
        public String Cardhoarder { get; set; }
    }
}

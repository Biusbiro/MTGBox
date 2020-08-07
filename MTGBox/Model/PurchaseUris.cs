using Newtonsoft.Json;
using System;

namespace MTGBox.Model
{
    public class PurchaseUris
    {
        public Int32 Id { get; set; }

        [JsonProperty("tcgplayer")]
        public String Tcgplayer { get; set; }

        [JsonProperty("cardmarket")]
        public String Cardmarket { get; set; }

        [JsonProperty("cardhoarder")]
        public String Cardhoarder { get; set; }
    }
}

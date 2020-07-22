using Newtonsoft.Json;
using System;

namespace MTGBox.Model
{
    public class Prices
    {
        [JsonProperty("usd")]
        public String Usd { get; set; }

        [JsonProperty("usd_foil")]
        public String UsdFoil { get; set; }

        [JsonProperty("eur")]
        public String Eur { get; set; }

        [JsonProperty("tix")]
        public String Tix { get; set; }
    }
}

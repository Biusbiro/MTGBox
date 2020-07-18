using Newtonsoft.Json;

namespace MTGBox.Model
{
    class Prices
    {
        [JsonProperty("usd")]
        public string Usd { get; set; }

        [JsonProperty("usd_foil")]
        public string UsdFoil { get; set; }

        [JsonProperty("eur")]
        public string Eur { get; set; }

        [JsonProperty("tix")]
        public string Tix { get; set; }
    }
}

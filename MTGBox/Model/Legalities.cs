using Newtonsoft.Json;
using System;

namespace MTGBox.Model
{
    public class Legalities
    {
        [JsonProperty("standard")]
        public String Standard { get; set; }

        [JsonProperty("future")]
        public String Future { get; set; }

        [JsonProperty("historic")]
        public String Historic { get; set; }

        [JsonProperty("pioneer")]
        public String Pioneer { get; set; }

        [JsonProperty("modern")]
        public String Modern { get; set; }

        [JsonProperty("legacy")]
        public String Legacy { get; set; }

        [JsonProperty("pauper")]
        public String Pauper { get; set; }

        [JsonProperty("vintage")]
        public String Vintage { get; set; }

        [JsonProperty("penny")]
        public String Penny { get; set; }

        [JsonProperty("commander")]
        public String Commander { get; set; }

        [JsonProperty("brawl")]
        public String Brawl { get; set; }

        [JsonProperty("duel")]
        public String Duel { get; set; }

        [JsonProperty("oldschool")]
        public String Oldschool { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace MTGBox.Model
{
    public class RelatedUris
    {
        [JsonProperty("gatherer")]
        public String Gatherer { get; set; }

        [JsonProperty("tcgplayer_decks")]
        public String TcgplayerDecks { get; set; }

        [JsonProperty("edhrec")]
        public String Edhrec { get; set; }

        [JsonProperty("mtgtop8")]
        public String Mtgtop8 { get; set; }
    }
}

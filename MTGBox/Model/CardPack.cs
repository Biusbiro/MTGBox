using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.Model
{
    public class CardPack
    {
        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("total_cards")]
        public Int32 TotalCards { get; set; }

        [JsonProperty("has_more")]
        public Boolean HasMore { get; set; }

        [JsonProperty("next_page")]
        public String NextPage { get; set; }

        [JsonProperty("data")]
        public List<Card> Cards { get; set; }
    }
}

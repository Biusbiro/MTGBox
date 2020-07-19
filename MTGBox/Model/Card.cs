using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MTGBox.Model
{
    class Card
    {
        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("oracle_id")]
        public String OracleId { get; set; }

        [JsonProperty("mtgo_id")]
        public Int32 MtgoId { get; set; }

        [JsonProperty("mtgo_foil_id")]
        public Int32 MtgoFoilId { get; set; }

        [JsonProperty("tcgplayer_id")]
        public Int32 TcgplayerId { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("lang")]
        public String Lang { get; set; }

        [JsonProperty("released_at")]
        public String ReleasedAt { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public String ScryfallUri { get; set; }

        [JsonProperty("layout")]
        public String Layout { get; set; }

        [JsonProperty("highres_image")]
        public bool HighresImage { get; set; }

        [JsonProperty("mana_cost")]
        public String ManaCost { get; set; }

        [JsonProperty("cmc")]
        public String Cmc { get; set; }

        [JsonProperty("type_line")]
        public String TypeLine { get; set; }

        [JsonProperty("reserved")]
        public bool Reserved { get; set; }

        [JsonProperty("foil")]
        public bool Foil { get; set; }

        [JsonProperty("nonfoil")]
        public bool Nonfoil { get; set; }

        [JsonProperty("oversized")]
        public bool Oversized { get; set; }

        [JsonProperty("promo")]
        public bool Promo { get; set; }

        [JsonProperty("reprint")]
        public bool Reprint { get; set; }

        [JsonProperty("variation")]
        public bool Variation { get; set; }

        [JsonProperty("set")]
        public String Set { get; set; }

        [JsonProperty("set_name")]
        public String SetName { get; set; }

        [JsonProperty("set_type")]
        public String SetType { get; set; }

        [JsonProperty("set_uri")]
        public String SetUri { get; set; }

        [JsonProperty("set_search_uri")]
        public String SetSearchUri { get; set; }

        [JsonProperty("scryfall_set_uri")]
        public String ScryfallSetUri { get; set; }

        [JsonProperty("rulings_uri")]
        public String RulingsUri { get; set; }

        [JsonProperty("oracle_text")]
        public String OracleText { get; set; }

        [JsonProperty("prints_search_uri")]
        public String PrintsSearchUri { get; set; }

        [JsonProperty("collector_number")]
        public String CollectorNumber { get; set; }

        [JsonProperty("digital")]
        public bool Digital { get; set; }

        [JsonProperty("rarity")]
        public String Rarity { get; set; }

        [JsonProperty("flavor_text")]
        public String FlavorText { get; set; }

        [JsonProperty("card_back_id")]
        public String CardBackId { get; set; }

        [JsonProperty("artist")]
        public String Artist { get; set; }

        [JsonProperty("illustration_id")]
        public String IllustrationId { get; set; }

        [JsonProperty("border_color")]
        public String BorderColor { get; set; }

        [JsonProperty("frame")]
        public String Frame { get; set; }

        [JsonProperty("full_art")]
        public bool FullArt { get; set; }

        [JsonProperty("textless")]
        public bool Textless { get; set; }

        [JsonProperty("booster")]
        public bool Booster { get; set; }

        [JsonProperty("story_spotlight")]
        public bool StorySpotlight { get; set; }

        [JsonProperty("edhrec_rank")]
        public Int32 EdhrecRank { get; set; }

        [JsonProperty("multiverse_ids")]
        public List<Int32> MultiverseIds { get; set; }

        [JsonProperty("image_uris")]
        public ImageUris ImageUris { get; set; }

        [JsonProperty("colors")]
        public List<String> Colors { get; set; }

        [JsonProperty("color_identity")]
        public List<String> ColorIdentity { get; set; }

        [JsonProperty("keywords")]
        public List<String> Keywords { get; set; }

        [JsonProperty("legalities")]
        public Legalities Legalities { get; set; }

        [JsonProperty("games")]
        public List<String> Games { get; set; }

        [JsonProperty("artist_ids")]
        public List<String> ArtistIds { get; set; }

        [JsonProperty("prices")]
        public Prices Prices { get; set; }

        [JsonProperty("related_uris")]
        public RelatedUris RelatedUris { get; set; }

        [JsonProperty("purchase_uris")]
        public PurchaseUris PurchaseUris { get; set; }
    }
}

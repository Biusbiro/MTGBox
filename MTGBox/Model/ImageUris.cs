using Newtonsoft.Json;
using System;

namespace MTGBox.Model
{
    public class ImageUris
    {
        [JsonProperty("small")]
        public String Small { get; set; }

        [JsonProperty("normal")]
        public String Normal { get; set; }

        [JsonProperty("large")]
        public String Large { get; set; }

        [JsonProperty("png")]
        public String Png { get; set; }

        [JsonProperty("art_crop")]
        public String ArtCrop { get; set; }

        [JsonProperty("border_crop")]
        public String BorderCrop { get; set; }
    }
}

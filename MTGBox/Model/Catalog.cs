using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.Model
{
    public class Catalog
    {
        [JsonProperty("object")]
        public String Object { get; set; }

        [JsonProperty("uri")]
        public String Uri { get; set; }

        [JsonProperty("total_values")]
        public Int32 TotalValues { get; set; }

        [JsonProperty("data")]
        public List<String> Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapi.Model
{
    public class ChuckSearchResponse
    {
        public int total { get; set; }
        public List<ChuckSearchResponseResult> result { get; set; }

    }

    public class ChuckSearchResponseResult
    {
        public List<string> categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}

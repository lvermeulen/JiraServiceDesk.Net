using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Common
{
    public class PagedResults<T>
    {
        [JsonProperty("_expands")]
        public List<string> Expands { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        public int Size { get; set; }
        public bool IsLastPage { get; set; }
        public List<T> Values { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Common
{
    public abstract class PagedResultsBase : WithLinks
    {
        [JsonProperty("_expands")]
        public List<string> Expands { get; set; }
        public int Size { get; set; }
        public bool IsLastPage { get; set; }
        public int Start { get; set; }
    }
}
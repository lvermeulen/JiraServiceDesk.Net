using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Common
{
    public abstract class WithLinks
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}

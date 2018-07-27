using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace JiraServiceDesk.Net.Models.Common
{
    public class AvatarUrls
    {
        [JsonProperty("48x48")]
        public string _48x48 { get; set; }
        [JsonProperty("24x24")]
        public string _24x24 { get; set; }
        [JsonProperty("16x16")]
        public string _16x16 { get; set; }
        [JsonProperty("32x32")]
        public string _32x32 { get; set; }
    }
}
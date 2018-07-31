using JiraServiceDesk.Net.Models.Common;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Request
{
    public class Comment : WithLinks
    {
        public string Id { get; set; }
        public string Body { get; set; }
        [JsonProperty("public")]
        public bool IsPublic { get; set; }
        public User Author { get; set; }
        public JiraServiceDeskDate Created { get; set; }
    }
}
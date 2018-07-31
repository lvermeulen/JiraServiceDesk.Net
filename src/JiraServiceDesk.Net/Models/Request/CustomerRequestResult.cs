using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Request
{
    public class CustomerRequestResult : WithLinks
    {
        [JsonProperty("_expands")]
        public List<string> Expands { get; set; }
        public string IssueId { get; set; }
        public string IssueKey { get; set; }
        public string RequestTypeId { get; set; }
        public string ServiceDeskId { get; set; }
        public JiraServiceDeskDate CreatedDate { get; set; }
        public User Reporter { get; set; }
        public List<RequestFieldValue> RequestFieldValues { get; set; }
        public CurrentStatus CurrentStatus { get; set; }
    }
}

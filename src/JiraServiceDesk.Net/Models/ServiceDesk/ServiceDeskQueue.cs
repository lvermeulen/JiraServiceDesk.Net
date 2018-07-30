using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class ServiceDeskQueue : WithLinks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Jql { get; set; }
        public List<string> Fields { get; set; }
        public int IssueCount { get; set; }
    }
}

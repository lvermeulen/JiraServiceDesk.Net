using System;

namespace JiraServiceDesk.Net.Models.Common
{
    public class JiraServiceDeskDate
    {
        public DateTime? Iso8601 { get; set; }
        public DateTime? Jira { get; set; }
        public string Friendly { get; set; }
        public long EpochMillis { get; set; }
    }
}

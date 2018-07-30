using System;

namespace JiraServiceDesk.Net.Models.Info
{
    public class BuildDate
    {
        public DateTime? Iso8601 { get; set; }
        public DateTime? Jira { get; set; }
        public string Friendly { get; set; }
        public long EpochMillis { get; set; }
    }
}
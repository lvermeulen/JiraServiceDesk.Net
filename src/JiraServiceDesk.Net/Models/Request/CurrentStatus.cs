using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class CurrentStatus
    {
        public string Status { get; set; }
        public JiraServiceDeskDate StatusDate { get; set; }
    }
}
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class CustomerRequestStatus
    {
        public string Status { get; set; }
        public JiraServiceDeskDate StatusDate { get; set; }
    }
}

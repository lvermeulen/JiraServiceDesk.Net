using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class Approval
    {
        public User Approver { get; set; }
        public string ApproverDecision { get; set; }
    }
}
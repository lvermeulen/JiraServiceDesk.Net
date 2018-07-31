namespace JiraServiceDesk.Net.Models.Request
{
    public class Approval
    {
        public Approver Approver { get; set; }
        public string ApproverDecision { get; set; }
    }
}
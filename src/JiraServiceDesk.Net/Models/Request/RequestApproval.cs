using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class RequestApproval : WithLinks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FinalDecision { get; set; }
        public bool CanAnswerApproval { get; set; }
        public List<Approval> Approvers { get; set; }
        public JiraServiceDeskDate CreatedDate { get; set; }
        public JiraServiceDeskDate CompletedDate { get; set; }
    }
}

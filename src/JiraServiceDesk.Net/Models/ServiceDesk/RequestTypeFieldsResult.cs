using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class RequestTypeFieldsResult
    {
        public List<RequestTypeField> RequestTypeFields { get; set; }
        public bool CanRaiseOnBehalfOf { get; set; }
        public bool CanAddRequestParticipants { get; set; }
    }
}

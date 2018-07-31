using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.Request
{
    public class CustomerRequest
    {
        public string ServiceDeskId { get; set; }
        public string RequestTypeId { get; set; }
        public RequestFieldValues RequestFieldValues { get; set; }
        public string RaiseOnBehalfOf { get; set; }
        public List<string> RequestParticipants { get; set; }
    }
}

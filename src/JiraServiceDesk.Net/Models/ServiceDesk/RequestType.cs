using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class RequestType : WithLinks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HelpText { get; set; }
        public string ServiceDeskId { get; set; }
        public List<string> GroupIds { get; set; }
        public Icon Icon { get; set; }
    }
}

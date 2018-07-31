using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class Sla : WithLinks
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<CompletedCycle> CompletedCycles { get; set; }
        public OngoingCycle OngoingCycle { get; set; }
    }
}

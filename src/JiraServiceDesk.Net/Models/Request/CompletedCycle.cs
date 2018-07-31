using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class CompletedCycle : Cycle
    {
        public JiraServiceDeskDate StopTime { get; set; }
    }
}
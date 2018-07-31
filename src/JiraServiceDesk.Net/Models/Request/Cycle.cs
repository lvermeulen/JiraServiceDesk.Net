using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public abstract class Cycle
    {
        public JiraServiceDeskDate StartTime { get; set; }
        public bool Breached { get; set; }
        public Duration GoalDuration { get; set; }
        public Duration ElapsedTime { get; set; }
        public Duration RemainingTime { get; set; }
    }
}
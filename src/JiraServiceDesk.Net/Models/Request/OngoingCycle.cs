namespace JiraServiceDesk.Net.Models.Request
{
    public class OngoingCycle : Cycle
    {
        public bool Paused { get; set; }
        public bool WithinCalendarHours { get; set; }
    }
}
using System;

namespace JiraServiceDesk.Net.Models.Request
{
    [Flags]
    public enum Expand
    {
        None = 0,
        ServiceDesk = 1,
        RequestType = 2,
        Participant = 4,
        Sla = 8,
        Status = 16
    }
}

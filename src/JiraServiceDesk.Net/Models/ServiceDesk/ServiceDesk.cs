using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class ServiceDesk : WithLinks
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectKey { get; set; }
    }
}

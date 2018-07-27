using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Organization
{
    public class Organization : WithLinks
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Info
{
    public class ServiceDeskInfo : WithLinks
    {
        public string Version { get; set; }
        public string PlatformVersion { get; set; }
        public JiraServiceDeskDate BuildDate { get; set; }
        public string BuildChangeSet { get; set; }
        public bool IsLicensedForUse { get; set; }
    }
}

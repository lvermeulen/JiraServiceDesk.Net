using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Customer
{
    public class Customer : WithLinks
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
    }
}

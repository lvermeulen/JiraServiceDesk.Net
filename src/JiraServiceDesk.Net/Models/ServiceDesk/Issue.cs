namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class Issue
    {
        public string Id { get; set; }
        public string Self { get; set; }
        public string Key { get; set; }
        public Fields Fields { get; set; }
    }
}

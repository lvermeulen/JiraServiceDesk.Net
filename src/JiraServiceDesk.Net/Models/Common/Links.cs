namespace JiraServiceDesk.Net.Models.Common
{
    public class Links
    {
        public string Base { get; set; }
        public string Context { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public string JiraRest { get; set; }
        public AvatarUrls AvatarUrls { get; set; }
        public AvatarUrls IconUrls { get; set; }
        public string Self { get; set; }
    }
}
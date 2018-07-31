using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class Attachment : WithLinks
    {
        public string Filename { get; set; }
        public User Author { get; set; }
        public JiraServiceDeskDate Created { get; set; }
        public int Size { get; set; }
        public string MimeType { get; set; }
    }
}
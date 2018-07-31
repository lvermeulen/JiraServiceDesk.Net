using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class RenderedValue
    {
        public string Self { get; set; }
        public string Id { get; set; }
        public string FileName { get; set; }
        public User Author { get; set; }
        public string Created { get; set; }
        public string Size { get; set; }
        public string MimeType { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Value { get; set; }
    }
}
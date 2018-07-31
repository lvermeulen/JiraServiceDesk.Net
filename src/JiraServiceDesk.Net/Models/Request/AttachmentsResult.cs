using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.Request
{
    public class AttachmentsResult
    {
        public Comment Comment { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}

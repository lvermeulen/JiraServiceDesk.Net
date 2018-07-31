using System;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class Fields
    {
        public string Summary { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Created { get; set; }
        public User Reporter { get; set; }
    }
}
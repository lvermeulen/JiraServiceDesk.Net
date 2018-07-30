using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class ValidValue
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public List<object> Children { get; set; }
    }
}
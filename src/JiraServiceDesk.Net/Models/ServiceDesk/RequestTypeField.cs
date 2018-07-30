using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.ServiceDesk
{
    public class RequestTypeField
    {
        public string FieldId { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public List<ValidValue> ValidValues { get; set; }
        public JiraSchema JiraSchema { get; set; }
    }
}
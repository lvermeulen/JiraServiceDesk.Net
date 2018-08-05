using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Request
{
    public class RequestFieldValue
    {
        public string FieldId { get; set; }
        public string Label { get; set; }
        [JsonConverter(typeof(FieldValueConverter))]
        public List<FieldValue> Value { get; set; }
        [JsonConverter(typeof(FieldValueConverter))]
        public List<FieldValue> RenderedValue { get; set; }
    }
}
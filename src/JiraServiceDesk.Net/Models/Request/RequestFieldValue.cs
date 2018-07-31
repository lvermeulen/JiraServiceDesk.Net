using System.Collections.Generic;
using JiraServiceDesk.Net.Models.Common;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net.Models.Request
{
    public class RequestFieldValue
    {
        public string FieldId { get; set; }
        public string Label { get; set; }
        [JsonConverter(typeof(StringOrStringArrayConverter))]
        public List<string> Value { get; set; }
        public List<RenderedValue> RenderedValue { get; set; }
    }
}
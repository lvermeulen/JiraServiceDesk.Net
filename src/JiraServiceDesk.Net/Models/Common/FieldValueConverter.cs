using System;
using System.Collections.Generic;
using System.Linq;
using JiraServiceDesk.Net.Models.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JiraServiceDesk.Net.Models.Common
{
    public class FieldValueConverter : JsonConverter
    {
        private static readonly List<Type> s_types = new List<Type> { typeof(FieldValue), typeof(IEnumerable<FieldValue>) };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var item = JToken.Load(reader);
                return new List<FieldValue> { new FieldValue { Value = item.Value<string>() } };
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                var item = JArray.Load(reader);
                return new List<FieldValue>(item.Select(x => JsonConvert.DeserializeObject<FieldValue>(x.ToString())));
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                var item = JObject.Load(reader);
                return new List<FieldValue> { JsonConvert.DeserializeObject<FieldValue>(item.ToString()) };
            }

            return null;
        }

        public override bool CanConvert(Type objectType) => s_types.Contains(objectType);
    }
}

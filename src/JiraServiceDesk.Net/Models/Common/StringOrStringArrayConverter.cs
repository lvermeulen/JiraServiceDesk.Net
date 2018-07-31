using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JiraServiceDesk.Net.Models.Common
{
    public class StringOrStringArrayConverter : JsonConverter
    {
        private static readonly List<Type> s_types = new List<Type> { typeof(string), typeof(IEnumerable<string>) };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var item = JToken.Load(reader);
                return new List<string>(Enumerable.Repeat(item.Value<string>(), 1));
            }

            if (reader.TokenType == JsonToken.StartArray)
            {
                var item = JArray.Load(reader);
                return new List<string>(item.Select(x => x.ToString()));
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                var item = JObject.Load(reader);
                return new List<string>(Enumerable.Repeat(item.ToString(), 1));
            }

            return null;
        }

        public override bool CanConvert(Type objectType) => s_types.Contains(objectType);
    }
}

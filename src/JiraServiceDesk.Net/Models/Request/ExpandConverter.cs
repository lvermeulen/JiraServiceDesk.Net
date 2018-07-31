using System;
using System.Collections.Generic;
using System.Linq;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class ExpandConverter : JsonEnumConverter<Expand>
    {
        private static readonly Dictionary<Expand, string> s_stringByExpand = new Dictionary<Expand, string>
        {
            [Expand.ServiceDesk] = "serviceDesk",
            [Expand.RequestType] = "requestType",
            [Expand.Participant] = "participant",
            [Expand.Sla] = "sla",
            [Expand.Status] = "status"
        };

        public static string NullableValueToString(Expand? value)
        {
            return value.HasValue
                ? ValueToString(value.Value)
                : null;
        }

        public static string ValueToString(Expand value)
        {
            var results = new List<string>();

            if (value.HasFlag(Expand.ServiceDesk))
            {
                results.Add(s_stringByExpand[Expand.ServiceDesk]);
            }
            if (value.HasFlag(Expand.RequestType))
            {
                results.Add(s_stringByExpand[Expand.RequestType]);
            }
            if (value.HasFlag(Expand.Participant))
            {
                results.Add(s_stringByExpand[Expand.Participant]);
            }
            if (value.HasFlag(Expand.Sla))
            {
                results.Add(s_stringByExpand[Expand.Sla]);
            }
            if (value.HasFlag(Expand.Status))
            {
                results.Add(s_stringByExpand[Expand.Status]);
            }

            return string.Join(",", results);
        }

        public override string ConvertToString(Expand value) => ValueToString(value);

        private Expand StringToValue(string s)
        {
            var pair = s_stringByExpand.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<RequestOwnership, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown expand: {s}");
            }

            return pair.Key;
        }

        public override Expand ConvertFromString(string s)
        {
            var result = Expand.None;

            var pieces = s.Split(new [] { ",", ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string piece in pieces)
            {
                var flag = StringToValue(piece);
                if (flag == Expand.ServiceDesk)
                {
                    result |= Expand.ServiceDesk;
                }
                if (flag == Expand.RequestType)
                {
                    result |= Expand.RequestType;
                }
                if (flag == Expand.Participant)
                {
                    result |= Expand.Participant;
                }
                if (flag == Expand.Sla)
                {
                    result |= Expand.Sla;
                }
                if (flag == Expand.Status)
                {
                    result |= Expand.Status;
                }
            }

            return result;
        }
    }
}

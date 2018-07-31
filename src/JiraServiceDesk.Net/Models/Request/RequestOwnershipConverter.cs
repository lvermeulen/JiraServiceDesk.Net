using System;
using System.Collections.Generic;
using System.Linq;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class RequestOwnershipConverter : JsonEnumConverter<RequestOwnership>
    {
        private static readonly Dictionary<RequestOwnership, string> s_stringByRequestOwnership = new Dictionary<RequestOwnership, string>
        {
            [RequestOwnership.OwnedRequests] = "OWNED_REQUESTS",
            [RequestOwnership.ParticipatedRequests] = "PARTICIPATED_REQUESTS",
            [RequestOwnership.AllRequests] = "ALL_REQUESTS"
        };

        public static string NullableValueToString(RequestOwnership? value)
        {
            return value.HasValue
                ? ValueToString(value.Value)
                : null;
        }

        public static string ValueToString(RequestOwnership value)
        {
            if (!s_stringByRequestOwnership.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown request ownership: {value}");
            }

            return result;
        }

        public override string ConvertToString(RequestOwnership value) => ValueToString(value);

        public override RequestOwnership ConvertFromString(string s)
        {
            var pair = s_stringByRequestOwnership.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<RequestOwnership, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown request ownership: {s}");
            }

            return pair.Key;
        }
    }
}

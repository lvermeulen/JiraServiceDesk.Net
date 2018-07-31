using System;
using System.Collections.Generic;
using System.Linq;
using JiraServiceDesk.Net.Models.Common;

namespace JiraServiceDesk.Net.Models.Request
{
    public class RequestStatusConverter : JsonEnumConverter<RequestStatus>
    {
        private static readonly Dictionary<RequestStatus, string> s_stringByRequestStatus = new Dictionary<RequestStatus, string>
        {
            [RequestStatus.ClosedRequests] = "CLOSED_REQUESTS",
            [RequestStatus.OpenRequests] = "OPEN_REQUESTS",
            [RequestStatus.AllRequests] = "ALL_REQUESTS"
        };

        public static string NullableValueToString(RequestStatus? value)
        {
            return value.HasValue
                ? ValueToString(value.Value)
                : null;
        }

        public static string ValueToString(RequestStatus value)
        {
            if (!s_stringByRequestStatus.TryGetValue(value, out string result))
            {
                throw new ArgumentException($"Unknown request status: {value}");
            }

            return result;
        }

        public override string ConvertToString(RequestStatus value) => ValueToString(value);

        public override RequestStatus ConvertFromString(string s)
        {
            var pair = s_stringByRequestStatus.FirstOrDefault(kvp => kvp.Value.Equals(s, StringComparison.OrdinalIgnoreCase));
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (EqualityComparer<KeyValuePair<RequestOwnership, string>>.Default.Equals(pair))
            {
                throw new ArgumentException($"Unknown request status: {s}");
            }

            return pair.Key;
        }
    }
}

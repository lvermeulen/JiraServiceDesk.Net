using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using JiraServiceDesk.Net.Models.Common;
using JiraServiceDesk.Net.Models.Request;

namespace JiraServiceDesk.Net
{
    public partial class JiraServiceDeskClient
    {
        private IFlurlRequest GetRequestUrl() => GetBaseUrl()
            .AppendPathSegment("/request");

        private IFlurlRequest GetRequestUrl(string path) => GetRequestUrl()
            .AppendPathSegment(path);

        public async Task<CustomerRequestResult> CreateCustomerRequestAsync(CustomerRequest customerRequest)
        {
            var response = await GetRequestUrl()
                .PostJsonAsync(customerRequest)
                .ConfigureAwait(false);

            return await HandleResponseAsync<CustomerRequestResult>(response).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CustomerRequestResult>> GetCustomerRequestsAsync(string searchTerm = null,
            RequestOwnership? requestOwnership = null,
            RequestStatus? requestStatus = null,
            int? serviceDeskId = null,
            int? requestTypeId = null,
            Expand? expand = null,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["searchTerm"] = searchTerm,
                ["requestOwnership"] = RequestOwnershipConverter.NullableValueToString(requestOwnership),
                ["requestStatus"] = RequestStatusConverter.NullableValueToString(requestStatus),
                ["serviceDeskId"] = serviceDeskId,
                ["requestTypeId"] = requestTypeId,
                ["expand"] = ExpandConverter.NullableValueToString(expand),
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl()
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<CustomerRequestResult>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<CustomerRequestResult> GetCustomerRequestByIdOrKeyAsync(string issueIdOrKey, Expand? expand = null)
        {
            return await GetRequestUrl(issueIdOrKey)
                .SetQueryParam("expand", ExpandConverter.NullableValueToString(expand))
                .GetJsonAsync<CustomerRequestResult>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<RequestApproval>> GetRequestApprovalsAsync(string issueIdOrKey,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl($"/{issueIdOrKey}/approval")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<RequestApproval>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<RequestApproval> GetRequestApprovalByIdAsync(string issueIdOrKey, string approvalId)
        {
            return await GetRequestUrl($"/{issueIdOrKey}/approval/{approvalId}")
                .GetJsonAsync<RequestApproval>()
                .ConfigureAwait(false);
        }

        public async Task<bool> AnswerRequestApprovalAsync(string issueIdOrKey, string approvalId)
        {
            var data = new
            {
                decision = "approve"
            };

            var response = await GetRequestUrl($"/{issueIdOrKey}/approval/{approvalId}")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }

        public async Task<AttachmentsResult> CreateRequestAttachmentAsync(string issueIdOrKey, 
            IEnumerable<string> attachmentIds, bool isPublic, string additionalComment = null)
        {
            var data = new
            {
                temporaryAttachmentIds = attachmentIds,
                @public = isPublic,
                additionalComment = new
                {
                    body = additionalComment
                }
            };

            var response = await GetRequestUrl($"/{issueIdOrKey}/attachment")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<AttachmentsResult>(response).ConfigureAwait(false);
        }

        public async Task<Comment> CreateRequestCommentAsync(string issueIdOrKey, string body, bool isPublic)
        {
            var data = new
            {
                body,
                @public = isPublic
            };

            var response = await GetRequestUrl($"/{issueIdOrKey}/comment")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<Comment>(response).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Comment>> GetRequestCommentsAsync(string issueIdOrKey,
            bool? isPublic = null,
            bool? isInternal = null,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["public"] = isPublic,
                ["internal"] = isInternal,
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl($"/{issueIdOrKey}/comment")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<Comment>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<Comment> GetRequestCommentByIdAsync(string issueIdOrKey, string commentId)
        {
            return await GetRequestUrl($"/{issueIdOrKey}/comment/{commentId}")
                .GetJsonAsync<Comment>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> GetRequestParticipantsAsync(string issueIdOrKey,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl($"/{issueIdOrKey}/participant")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<User>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<PagedResults<User>> AddRequestParticipantsAsync(string issueIdOrKey, IEnumerable<string> userNames)
        {
            var data = new
            {
                usernames = userNames
            };

            var response = await GetRequestUrl($"/{issueIdOrKey}/participant")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<PagedResults<User>>(response).ConfigureAwait(false);
        }

        public async Task<PagedResults<User>> RemoveRequestParticipantsAsync(string issueIdOrKey, IEnumerable<string> userNames)
        {
            var data = new
            {
                usernames = userNames
            };

            var response = await GetRequestUrl($"/{issueIdOrKey}/participant")
                .SendJsonAsync(HttpMethod.Delete, data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<PagedResults<User>>(response).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Sla>> GetRequestSlaInformationAsync(string issueIdOrKey,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl($"/{issueIdOrKey}/sla")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<Sla>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<Sla> GetRequestSlaInformationByIdAsync(string issueIdOrKey, string slaMetricId)
        {
            return await GetRequestUrl($"/{issueIdOrKey}/sla/{slaMetricId}")
                .GetJsonAsync<Sla>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<CustomerRequestStatus>> GetRequestStatusAsync(string issueIdOrKey,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl($"/{issueIdOrKey}/status")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<CustomerRequestStatus>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<CustomerRequestTransition>> GetRequestCustomerTransitionsAsync(string issueIdOrKey,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetRequestUrl($"/{issueIdOrKey}/transition")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<CustomerRequestTransition>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<bool> PerformCustomerTransitionAsync(string issueIdOrKey, int transitionId, string additionalComment = null)
        {
            var data = new
            {
                id = transitionId,
                additionalComment = new
                {
                    body = additionalComment
                }
            };

            var response = await GetRequestUrl($"/{issueIdOrKey}/transition")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }
    }
}

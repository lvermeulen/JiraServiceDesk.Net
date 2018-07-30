using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using JiraServiceDesk.Net.Models.Common;
using JiraServiceDesk.Net.Models.Organization;
using JiraServiceDesk.Net.Models.ServiceDesk;
using Newtonsoft.Json;

namespace JiraServiceDesk.Net
{
    public partial class JiraServiceDeskClient
    {
        private IFlurlRequest GetServiceDeskUrl() => GetBaseUrl()
            .AppendPathSegment("/servicedesk");

        private IFlurlRequest GetServiceDeskUrl(string path) => GetServiceDeskUrl()
            .AppendPathSegment(path);

        public async Task<IEnumerable<ServiceDesk>> GetServiceDesksAsync(int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetServiceDeskUrl()
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<ServiceDesk>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<ServiceDesk> GetServiceDeskByIdAsync(string serviceDeskId)
        {
            return await GetServiceDeskUrl(serviceDeskId)
                .GetJsonAsync<ServiceDesk>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TemporaryAttachment>> AttachTemporaryFileToServiceDeskAsync(string serviceDeskId, string filePath)
        {
            var response = await GetServiceDeskUrl(serviceDeskId)
                .PostMultipartAsync(content => content.AddFile(Path.GetFileName(filePath), Path.GetDirectoryName(filePath)))
                .ConfigureAwait(false);

            return await HandleResponseAsync<IEnumerable<TemporaryAttachment>>(response, s => JsonConvert.DeserializeObject<TemporaryAttachmentsResult>(s).TemporaryAttachments).ConfigureAwait(false);
        }

        public async Task<PagedResults<OrganizationUser>> AddCustomersToServiceDeskAsync(string serviceDeskId, IEnumerable<string> userNames)
        {
            var data = new
            {
                usernames = userNames
            };

            var response = await GetServiceDeskUrl(serviceDeskId)
                .AppendPathSegment("/customer")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<PagedResults<OrganizationUser>>(response).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Organization>> GetServiceDeskOrganizationsAsync(string serviceDeskId, 
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
                    await GetServiceDeskUrl(serviceDeskId)
                        .AppendPathSegment("/organization")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<Organization>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<bool> AddServiceDeskOrganizationAsync(string serviceDeskId, int organizationId)
        {
            var data = new
            {
                organizationId
            };

            var response = await GetServiceDeskUrl(serviceDeskId)
                .AppendPathSegment("/organization")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }

        public async Task<bool> RemoveServiceDeskOrganizationAsync(string serviceDeskId, int organizationId)
        {
            var data = new
            {
                organizationId
            };

            var response = await GetServiceDeskUrl(serviceDeskId)
                .AppendPathSegment("/organization")
                .SendJsonAsync(HttpMethod.Delete, data)
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ServiceDeskQueue>> GetServiceDeskQueuesAsync(string serviceDeskId, bool? includeCount = false,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["includeCount"] = includeCount,
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetServiceDeskUrl(serviceDeskId)
                        .AppendPathSegment("/queue")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<ServiceDeskQueue>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Issue>> GetServiceDeskQueueIssuesAsync(string serviceDeskId, string queueId,
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
                    await GetServiceDeskUrl(serviceDeskId)
                        .AppendPathSegment($"/queue/{queueId}/issue")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<Issue>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<RequestType>> GetServiceDeskRequestTypesAsync(string serviceDeskId, int? groupId = null,
            int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["groupId"] = groupId,
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetServiceDeskUrl(serviceDeskId)
                        .AppendPathSegment("/requesttype")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<RequestType>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<RequestType> CreateServiceDeskRequestTypeAsync(string serviceDeskId, string issueTypeId,
            string name,
            string description,
            string helpText)
        {
            var data = new
            {
                issueTypeId,
                name,
                description,
                helpText
            };

            var response = await GetServiceDeskUrl(serviceDeskId)
                .AppendPathSegment("/requesttype")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<RequestType>(response).ConfigureAwait(false);
        }

        public async Task<RequestType> GetServiceDeskRequestTypeByIdAsync(string serviceDeskId, string requestTypeId)
        {
            return await GetServiceDeskUrl(serviceDeskId)
                .AppendPathSegment($"/requesttype/{requestTypeId}")
                .GetJsonAsync<RequestType>()
                .ConfigureAwait(false);
        }

        public async Task<RequestTypeFieldsResult> GetServiceDeskRequestTypeFieldsAsync(string serviceDeskId, string requestTypeId)
        {
            return await GetServiceDeskUrl(serviceDeskId)
                .AppendPathSegment($"/requesttype/{requestTypeId}/field")
                .GetJsonAsync<RequestTypeFieldsResult>()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<RequestTypeGroup>> GetServiceDeskRequestTypeGroupsAsync(string serviceDeskId,
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
                    await GetServiceDeskUrl(serviceDeskId)
                        .AppendPathSegment("/requesttypegroup")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<RequestTypeGroup>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }
    }
}

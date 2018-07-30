using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using JiraServiceDesk.Net.Models.Common;
using JiraServiceDesk.Net.Models.Organization;

namespace JiraServiceDesk.Net
{
    public partial class JiraServiceDeskClient
    {
        private IFlurlRequest GetOrganizationUrl() => GetBaseUrl()
            .AppendPathSegment("/organization");

        private IFlurlRequest GetOrganizationUrl(string path) => GetOrganizationUrl()
            .AppendPathSegment(path);

        public async Task<IEnumerable<Organization>> GetOrganizationsAsync(int? maxPages = null,
            int? limit = null,
            int? start = null)
        {
            var queryParamValues = new Dictionary<string, object>
            {
                ["limit"] = limit,
                ["start"] = start
            };

            return await GetPagedResultsAsync(maxPages, queryParamValues, async qpv =>
                    await GetOrganizationUrl()
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<Organization>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<Organization> CreateOrganizationAsync(string name)
        {
            var data = new
            {
                name
            };

            var response = await GetOrganizationUrl()
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<Organization>(response).ConfigureAwait(false);
        }

        public async Task<Organization> GetOrganizationAsync(string id)
        {
            return await GetOrganizationUrl(id)
                .GetJsonAsync<Organization>()
                .ConfigureAwait(false);
        }

        public async Task<bool> DeleteOrganizationAsync(string id)
        {
            var response = await GetOrganizationUrl($"/{id}")
                .DeleteAsync()
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }

        public async Task<IEnumerable<OrganizationUser>> GetUsersInOrganizationAsync(string id,
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
                    await GetOrganizationUrl($"/{id}/user")
                        .SetQueryParams(qpv)
                        .GetJsonAsync<PagedResults<OrganizationUser>>()
                        .ConfigureAwait(false))
                .ConfigureAwait(false);
        }

        public async Task<PagedResults<OrganizationUser>> AddUsersToOrganizationAsync(string id, IEnumerable<string> userNames)
        {
            var data = new
            {
                usernames = userNames
            };

            var response = await GetOrganizationUrl($"/{id}/user")
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<PagedResults<OrganizationUser>>(response).ConfigureAwait(false);
        }

        public async Task<bool> RemoveUsersFromOrganizationAsync(string id)
        {
            var response = await GetOrganizationUrl($"/{id}/user")
                .DeleteAsync()
                .ConfigureAwait(false);

            return await HandleResponseAsync(response).ConfigureAwait(false);
        }
    }
}

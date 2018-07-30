using System.Threading.Tasks;
using Flurl.Http;
using JiraServiceDesk.Net.Models.Info;

namespace JiraServiceDesk.Net
{
    public partial class JiraServiceDeskClient
    {
        private IFlurlRequest GetInfoUrl() => GetBaseUrl()
            .AppendPathSegment("/info");

        public async Task<ServiceDeskInfo> GetServiceDeskInfoAsync()
        {
            return await GetInfoUrl()
                .GetJsonAsync<ServiceDeskInfo>()
                .ConfigureAwait(false);
        }
    }
}

using System.Threading.Tasks;
using Flurl.Http;
using JiraServiceDesk.Net.Models.Queues;

namespace JiraServiceDesk.Net
{
    public partial class JiraServiceDeskClient
    {
        private IFlurlRequest GetQueuesUrl() => GetBaseUrl()
            .AppendPathSegment("/queues");

        private IFlurlRequest GetQueuesUrl(string path) => GetQueuesUrl()
            .AppendPathSegment(path);

        public async Task<QueueSettings> GetQueueSettingsAsync(string projectKey)
        {
            return await GetQueuesUrl(projectKey)
                .GetJsonAsync<QueueSettings>()
                .ConfigureAwait(false);
        }

        private async Task PutBoolAsync(IFlurlRequest url, bool value)
        {
            await url
                .WithHeader("Content-Type", "application/json")
                .PutJsonAsync(value)
                .ConfigureAwait(false);
        }

        public async Task UseCachedQueueCountAsync(bool value, string projectKey = null)
        {
            var url = projectKey != null
                    ? GetQueuesUrl($"/{projectKey}/cache-count")
                    : GetQueuesUrl("/cache-count");

            await PutBoolAsync(url, value);
        }

        public async Task IncludeQueueCountAsync(bool value, string projectKey = null)
        {
            var url = projectKey != null
                    ? GetQueuesUrl($"/{projectKey}/include-count")
                    : GetQueuesUrl("/include-count");

            await PutBoolAsync(url, value);
        }
    }
}

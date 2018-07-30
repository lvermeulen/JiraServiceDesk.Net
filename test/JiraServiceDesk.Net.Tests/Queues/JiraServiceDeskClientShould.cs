using System.Threading.Tasks;
using Xunit;

namespace JiraServiceDesk.Net.Tests
{
    public partial class JiraServiceDeskClientShould
    {
        [Theory]
        [InlineData("EPSHELP")]
        public async Task GetQueueSettingsAsync(string projectKey)
        {
            var result = await _client.GetQueueSettingsAsync(projectKey).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("EPSHELP")]
        public async Task UseCachedQueueCount(string projectKey)
        {
            await _client.UseCachedQueueCountAsync(true, projectKey);
            var settings = await _client.GetQueueSettingsAsync(projectKey).ConfigureAwait(false);
            Assert.True(settings.QueueCount.UseCachedQueueCount);
        }
    }
}

using System.Threading.Tasks;
using Xunit;

namespace JiraServiceDesk.Net.Tests
{
    public partial class JiraServiceDeskClientShould
    {
        [Fact]
        public async Task GetServiceDesksAsync()
        {
            var results = await _client.GetServiceDesksAsync().ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Theory]
        [InlineData("47")]
        public async Task GetServiceDeskByIdAsync(string serviceDeskId)
        {
            var result = await _client.GetServiceDeskByIdAsync(serviceDeskId).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("47")]
        public async Task GetServiceDeskOrganizationsAsync(string serviceDeskId)
        {
            var results = await _client.GetServiceDeskOrganizationsAsync(serviceDeskId).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Theory]
        [InlineData("47")]
        public async Task GetServiceDeskQueuesAsync(string serviceDeskId)
        {
            var results = await _client.GetServiceDeskQueuesAsync(serviceDeskId).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Theory]
        [InlineData("47", "532")]
        public async Task GetServiceDeskQueueIssuesAsync(string serviceDeskId, string queueId)
        {
            var results = await _client.GetServiceDeskQueueIssuesAsync(serviceDeskId, queueId).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Theory]
        [InlineData("47")]
        public async Task GetServiceDeskRequestTypesAsync(string serviceDeskId)
        {
            var results = await _client.GetServiceDeskRequestTypesAsync(serviceDeskId).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Theory]
        [InlineData("47", "584")]
        public async Task GetServiceDeskRequestTypeByIdAsync(string serviceDeskId, string requestTypeId)
        {
            var result = await _client.GetServiceDeskRequestTypeByIdAsync(serviceDeskId, requestTypeId).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("47", "584")]
        public async Task GetServiceDeskRequestTypeFieldsAsync(string serviceDeskId, string requestTypeId)
        {
            var result = await _client.GetServiceDeskRequestTypeFieldsAsync(serviceDeskId, requestTypeId).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("47")]
        public async Task GetServiceDeskRequestTypeGroupsAsync(string serviceDeskId)
        {
            var results = await _client.GetServiceDeskRequestTypeGroupsAsync(serviceDeskId).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }
    }
}

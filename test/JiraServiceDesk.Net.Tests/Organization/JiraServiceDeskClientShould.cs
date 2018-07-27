using System;
using System.Threading.Tasks;
using Xunit;

namespace JiraServiceDesk.Net.Tests
{
    public partial class JiraServiceDeskClientShould
    {
        [Fact]
        public async Task GetOrganizationsAsync()
        {
            var results = await _client.GetOrganizationsAsync(maxPages: 2, limit: 3).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task CreateAndDeleteOrganizationAsync()
        {
            string name = nameof(CreateAndDeleteOrganizationAsync) + DateTime.UtcNow;

            var result = await _client.CreateOrganizationAsync(name).ConfigureAwait(false);
            Assert.NotNull(result);

            bool success = await _client.DeleteOrganizationAsync(result.Id).ConfigureAwait(false);
            Assert.True(success);
        }

        [Theory]
        [InlineData("1")]
        public async Task GetOrganizationAsync(string id)
        {
            var result = await _client.GetOrganizationAsync(id).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("1")]
        public async Task GetUsersInOrganizationAsync(string id)
        {
            var results = await _client.GetUsersInOrganizationAsync(id).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }
    }
}

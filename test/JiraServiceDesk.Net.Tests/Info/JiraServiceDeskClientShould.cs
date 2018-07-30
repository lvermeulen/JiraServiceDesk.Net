using System.Threading.Tasks;
using Xunit;

namespace JiraServiceDesk.Net.Tests
{
    public partial class JiraServiceDeskClientShould
    {
        [Fact]
        public async Task GetServiceDeskInfoAsync()
        {
            var result = await _client.GetServiceDeskInfoAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}

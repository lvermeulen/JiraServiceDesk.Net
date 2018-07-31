using System.Linq;
using System.Threading.Tasks;
using JiraServiceDesk.Net.Models.Request;
using Xunit;

namespace JiraServiceDesk.Net.Tests
{
    public partial class JiraServiceDeskClientShould
    {
        [Fact]
        public async Task GetCustomerRequestsAsync()
        {
            var results = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task GetCustomerRequestByIdOrKeyAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var result = await _client.GetCustomerRequestByIdOrKeyAsync(requests.FirstOrDefault()?.IssueKey).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetRequestApprovalsAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var results = await _client.GetRequestApprovalsAsync(requests.FirstOrDefault()?.IssueKey);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task GetRequestCommentsAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var results = await _client.GetRequestCommentsAsync(requests.FirstOrDefault()?.IssueKey).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task GetRequestParticipantsAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var results = await _client.GetRequestParticipantsAsync(requests.FirstOrDefault()?.IssueKey).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task GetRequestSlaInformationAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var results = await _client.GetRequestSlaInformationAsync(requests.FirstOrDefault()?.IssueKey).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task GetRequestStatusAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var results = await _client.GetRequestStatusAsync(requests.FirstOrDefault()?.IssueKey).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }

        [Fact]
        public async Task GetRequestCustomerTransitionsAsync()
        {
            var requests = await _client.GetCustomerRequestsAsync(requestOwnership: RequestOwnership.AllRequests, requestStatus: RequestStatus.AllRequests).ConfigureAwait(false);
            var results = await _client.GetRequestCustomerTransitionsAsync(requests.FirstOrDefault()?.IssueKey).ConfigureAwait(false);
            Assert.NotEmpty(results);
        }
    }
}

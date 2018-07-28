using System.Threading.Tasks;
using Flurl.Http;
using JiraServiceDesk.Net.Models.Customer;

namespace JiraServiceDesk.Net
{
    public partial class JiraServiceDeskClient
    {
        private IFlurlRequest GetCustomerUrl() => GetBaseUrl()
            .AppendPathSegment("/customer");

        public async Task<Customer> CreateCustomerAsync(string email, string fullName)
        {
            var data = new
            {
                email,
                fullName
            };

            var response = await GetCustomerUrl()
                .PostJsonAsync(data)
                .ConfigureAwait(false);

            return await HandleResponseAsync<Customer>(response).ConfigureAwait(false);
        }
    }
}

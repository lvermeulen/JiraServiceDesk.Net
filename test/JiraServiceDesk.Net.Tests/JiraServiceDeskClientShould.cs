using System.IO;
using Microsoft.Extensions.Configuration;

namespace JiraServiceDesk.Net.Tests
{
    public partial class JiraServiceDeskClientShould
    {
        private readonly JiraServiceDeskClient _client;

        public JiraServiceDeskClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _client = new JiraServiceDeskClient(configuration["url"], configuration["username"], configuration["password"]);
        }
    }
}

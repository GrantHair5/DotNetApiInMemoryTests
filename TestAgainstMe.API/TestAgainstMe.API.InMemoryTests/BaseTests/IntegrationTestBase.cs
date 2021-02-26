using System.Net.Http;
using TestAgainstMe.API.InMemoryTests.Factory;
using Xunit;

namespace TestAgainstMe.API.InMemoryTests.BaseTests
{
    public class IntegrationTestBase : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory Factory;
        protected readonly HttpClient Client;

        public IntegrationTestBase(ApiWebApplicationFactory fixture)
        {
            Factory = fixture;
            Client = Factory.CreateClient();
        }
    }
}
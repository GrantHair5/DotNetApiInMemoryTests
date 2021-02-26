using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TestAgainstMe.API.InMemoryTests
{
    public class FruitApiShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient Client { get; }

        public FruitApiShould(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Return_Basket_Contents()
        {
            var response = await Client.GetAsync("/api/Fruit/Basket");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
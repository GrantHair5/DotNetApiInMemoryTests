using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using TestAgainstMe.API.InMemoryTests.Factory;
using TestAgainstMe.API.Models;
using Xunit;

namespace TestAgainstMe.API.InMemoryTests
{
    public class FruitApiShould : IClassFixture<ApiWebApplicationFactory>
    {
        private HttpClient Client { get; }

        public FruitApiShould(ApiWebApplicationFactory fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Return_Basket_Contents()
        {
            var response = await Client.GetAsync("/api/Fruit/Basket");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var basket = JsonConvert.DeserializeObject<IEnumerable<Fruit>>(await response.Content.ReadAsStringAsync());
            basket.Should().HaveCount(2);
        }
    }
}
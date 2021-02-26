using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TestAgainstMe.API.Data;
using TestAgainstMe.API.Data.Implementation;
using TestAgainstMe.API.InMemoryTests.BaseTests;
using TestAgainstMe.API.InMemoryTests.Factory;
using TestAgainstMe.API.Models;
using Xunit;

namespace TestAgainstMe.API.InMemoryTests
{
    public class FruitApiShould : IntegrationTestBase
    {
        public FruitApiShould(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Return_Two_Fruits_From_Stubbed_Basket()
        {
            var response = await Client.GetAsync("/api/Fruit/Basket");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var basket = JsonConvert.DeserializeObject<IEnumerable<Fruit>>(await response.Content.ReadAsStringAsync());
            basket.Should().HaveCount(2);
        }

        [Fact]
        public async Task Return_Four_Fruits_From_Real_Basket_Overriden_By_With_Web_Host_Builder()
        {
            // WithWebHostBuilder will allow us to override the base Client with any new services that we require.
            var client = Factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<IFruitBasket, FruitBasket>();
                });
            }).CreateClient();

            var response = await client.GetAsync("/api/Fruit/Basket");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var basket = JsonConvert.DeserializeObject<IEnumerable<Fruit>>(await response.Content.ReadAsStringAsync());
            basket.Should().HaveCount(4);
        }

        [Fact]
        public async Task Get_Red_Apple_From_Basket()
        {
            var response = await Client.GetAsync("/api/Fruit?id=58E68249-A9F5-49E9-90A1-38421F056268");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var fruit = JsonConvert.DeserializeObject<Fruit>(await response.Content.ReadAsStringAsync());

            fruit.Name.Should().Be("Apple");
        }

        [Fact]
        public async Task Get_All_Apples_From_Basket()
        {
            var response = await Client.GetAsync("/api/Fruit/FruitsInBasket?nameOfFruit=Apple");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var basket = JsonConvert.DeserializeObject<IEnumerable<Fruit>>(await response.Content.ReadAsStringAsync());
            basket.Should().HaveCount(1);
        }
    }
}
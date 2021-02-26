using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using TestAgainstMe.API.Data;
using TestAgainstMe.API.InMemoryTests.Stubs;

namespace TestAgainstMe.API.InMemoryTests.Factory
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IFruitBasket, StubbedFruitBasket>();
            });
        }
    }
}
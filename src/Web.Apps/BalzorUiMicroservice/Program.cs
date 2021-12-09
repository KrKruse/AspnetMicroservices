using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using BalzorUiMicroservice.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;

namespace BalzorUiMicroservice
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["http://localhost:8010"]));
            builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
            builder.Services.AddHttpClient<IOrderingService, OrderingService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));

            builder.Services.AddScoped<ICatalogService, CatalogService>();

            builder.Services.AddScoped<ICatalogService, CatalogService>();

            await builder.Build().RunAsync();
        }
    }
}

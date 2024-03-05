using BlazorAppVS.Services;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorAppVS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var apiUrl = builder.Configuration.GetValue<string>("apiUrl");
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService , CategoryService>();

            await builder.Build().RunAsync();
        }
    }
}

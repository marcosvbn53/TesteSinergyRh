using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TesteSinergyRHDev.Client;
using TesteSinergyRHDev.Client.ServiceClient;
using TesteSinergyRHDev.Client.ServiceClient.Interfaces;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddHttpClient<ICatalogoService, CatalogoService>(cliente 
            => cliente.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

        builder.Services.AddHttpClient<IPedidoService, PedidoService>(cliente 
            => cliente.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


        await builder.Build().RunAsync();
    }
}
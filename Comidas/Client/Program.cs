using Comidas.Client;
using Comidas.Client.Repositorios;
using Comidas.Client.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Comidas.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorComidas.Client 
{ 
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ServiciosSingleton>();
            services.AddTransient<ServiciosTrancient>();
            services.AddScoped<IRepositorio,Repositorio>();
            services.AddScoped<IMostrarMensajes,MostrarMensajes>();
            services.AddApiAuthorization();
            services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionPrueba>();
        }
    }


}


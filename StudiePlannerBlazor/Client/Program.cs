using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudiePlannerBlazor.Client.DataService;
using StudiePlannerBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlannerBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("StudiePlannerBlazor.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("StudiePlannerBlazor.ServerAPI"));

            Uri uri = new Uri("https://localhost:44314");
            builder.Services.AddHttpClient<IDataService<TaskModel>, TaskDataService>(client =>
            {
                client.BaseAddress = uri;
            });
            builder.Services.AddHttpClient<IDataService<CalenderModel>, CalenderDataService>(client =>
            {
                client.BaseAddress = uri;
            });
            builder.Services.AddHttpClient<IDataService<AppointmentModel>, AppointmentDataService>(client =>
            {
                client.BaseAddress = uri;
            });

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}

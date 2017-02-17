using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;



public class Startup
{
	public void Configure(IApplicationBuilder app)
	{
		app.UseDefaultFiles();
		app.UseStaticFiles();
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Values}/{action=Index}/{id?}");
        });
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();

        const string envName = "VCAP_SERVICES";
        var settings = Environment.GetEnvironmentVariable(envName);
        if (settings != null) {
            var jSettings = JObject.Parse(settings);
            var weatherCreds = jSettings["weatherinsights"][0]["credentials"];
            WeatherService.Url = weatherCreds["url"].ToString();
        }
        

 
    }

    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

        var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseConfiguration(config)
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
        host.Run();
    }
}

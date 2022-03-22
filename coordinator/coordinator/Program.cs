using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace coordinator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 _ = config.AddJsonFile($"appsettings.local.json", false, true);
                 _ = config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true);
             })
                 .ConfigureWebHostDefaults(webBuilder => _ = webBuilder.UseStartup<Startup>());
    }
}

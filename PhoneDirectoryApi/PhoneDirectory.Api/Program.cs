using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneDirectory.Data.Persistence.Context;

namespace PhoneDirectoryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //using (var context = scope.ServiceProvider.GetService<PhoneBookContext>())
            //{
            //    context.Database.EnsureCreated();
            //}

            //host.Run();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

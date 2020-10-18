namespace Moonpig.PostOffice.Api
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSerilog((hc, lc) => lc.ConfigureSerilog(hc, Configuration, services));
                    webBuilder.UseStartup<Startup>();
                });

        //public static LoggerConfiguration ConfigureSerilog(this LoggerConfiguration loggerConfiguration,
        //                                                        WebHostBuilderContext hostingContext,
        //                                                        IConfiguration configuration,
        //                                                        IServiceCollection sc)
        //{
        //        loggerConfiguration
        //          .ReadFrom.Configuration(configuration);
            
        //    return loggerConfiguration
        //            .Enrich.FromLogContext();
        //}

    }

}

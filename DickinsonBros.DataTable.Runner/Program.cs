using DickinsonBros.DataTable.Runner.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DickinsonBros.DataTable.Abstractions;
using DickinsonBros.DataTable.Extensions;

namespace DickinsonBros.DataTable.Runner
{
    class Program
    {
        IConfiguration _configuration;
        async static Task Main()
        {
            await new Program().DoMain();
        }
        async Task DoMain()
        {
            try
            {
                using var applicationLifetime = new Services.ApplicationLifetime();
                var services = InitializeDependencyInjection();
                ConfigureServices(services, applicationLifetime);
                using var provider = services.BuildServiceProvider();
                var dataTableService = provider.GetRequiredService<IDataTableService>();

                var valueTypesSample = new MixedSample
                {
                    Bool = true,
                    Byte = 1,
                    Char = 'a',
                    DateTime = new System.DateTime(2000, 1, 1),
                    Decimal = 1.1m,
                    Double = 1.2,
                    Float = 1.3f,
                    Guid = new Guid("757ca30a-32d3-4d28-aef8-6dc4eddb900f"),
                    Int = 2,
                    Long = 3,
                    SByte = 4,
                    Short = 5,
                    TimeSpan = new TimeSpan(1, 0, 0),
                    UInt = 6,
                    ULong = 7,
                    UShort = 8,
                    ByteArray = new byte[5] {1, 0, 1, 0, 1},
                    Enum = EnumSample.Blue,
                    String = "SampleString"
                };

                var mixedSample = new List<MixedSample>
                {
                    valueTypesSample
                };

                var anonymousSample = new List<string>
                {
                    "FirstString",
                    "SecondString"
                };

                var mixedDataTable = dataTableService.ToDataTable(mixedSample, "MixedTable");
                var anonymousDataTable = dataTableService.ToDataTable(anonymousSample, "AnonymousTable");

                applicationLifetime.StopApplication();

                await Task.CompletedTask.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("End...");
                Console.ReadKey();
            }
             
        }

        private void ConfigureServices(IServiceCollection services, Services.ApplicationLifetime applicationLifetime)
        {
            services.AddOptions();
            services.AddLogging(cfg => cfg.AddConsole());

            //Add MemoryCatche
            services.AddMemoryCache();

            //Add ApplicationLifetime
            services.AddSingleton<IApplicationLifetime>(applicationLifetime);

            //Add DataTable
            services.AddDataTableService();
        }

        IServiceCollection InitializeDependencyInjection()
        {
            var aspnetCoreEnvironment = Environment.GetEnvironmentVariable("BUILD_CONFIGURATION");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{aspnetCoreEnvironment}.json", true);
            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddSingleton(_configuration);
            return services;
        }
    }
}

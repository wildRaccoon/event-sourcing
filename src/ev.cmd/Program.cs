using AutoMapper;
using ev.lib.domain.app.services.tracking;
using ev.lib.domain.interfaces;
using ev.lib.persistence.services.DataRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ev.cmd
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((ctx, sc) =>
                {
                    sc.AddSingleton<IHostedService, ConsoleHostService>();

                    sc.Scan(s =>
                        s.FromAssemblyOf<ITrackingService>()
                            .AddClasses(x => x.Where(f => f.Name.Contains("Service")))
                            .AsImplementedInterfaces()
                            .WithSingletonLifetime());

                    sc.Scan(s =>
                        s.FromAssemblyOf<ITrackingService>()
                            .AddClasses(x => x.Where(f => !f.Name.Contains("Service")))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime());

                    var assembly = Assembly.GetAssembly(typeof(ITrackingService));

                    var types = (from t in assembly.GetTypes()
                                 where t.GetCustomAttribute<AutoMapAttribute>() != null
                                 select (data: t, app: t.GetCustomAttribute<AutoMapAttribute>().SourceType)
                                 ).ToList();

                    types.ForEach(pair =>
                    {
                        var datarepo = typeof(IDataRepository<,>).MakeGenericType(pair.app, pair.data);
                        var repo = typeof(IRepository<>).MakeGenericType(pair.app);

                        sc.AddSingleton(repo, sp => sp.GetService(datarepo));
                    });

                    sc.Configure<MongoClientSettings>(opt => {
                        opt.MinConnectionPoolSize = 1;
                        opt.MaxConnectionPoolSize = 25;
                        opt.Server = new MongoServerAddress("localhost");
                    });

                    sc.AddSingleton<IMongoDatabase>(sp => new MongoClient(sp.GetService<IOptions<MongoClientSettings>>().Value).GetDatabase("evdb"));
                })
                .ConfigureLogging((ctx, log) =>
                {
                    log.AddConsole(cfg =>
                    {
                        cfg.DisableColors = false;
                    });
                    log.SetMinimumLevel(LogLevel.Trace);
                });

            await hostBuilder.RunConsoleAsync();
        }
    }
}

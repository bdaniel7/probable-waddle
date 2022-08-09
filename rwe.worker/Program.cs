using rwe.common;
using rwe.worker;

IHost host = Host.CreateDefaultBuilder(args)
                 .ConfigureServices(services => {
	                                    services.AddHostedService<RweWorker>();
	                                    services.AddHttpClient<WindparkClient>();
	                                    services.AddScoped<WindparkClient>();
                                    })
                 .Build();

await host.RunAsync();

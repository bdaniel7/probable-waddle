using rwe.worker;

IHost host = Host.CreateDefaultBuilder(args)
                 .ConfigureServices(services => {
	                                    services.AddHostedService<RweWorker>();
                                    })
                 .Build();

await host.RunAsync();

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults()
	.ConfigureServices(sc =>
	{
		sc.AddGraphQLFunction();
	})
	.Build();

host.Run();

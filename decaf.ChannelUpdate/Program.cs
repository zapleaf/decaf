using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using decaf.Infrastructure.Extension;
using decaf.Application.Extensions;

//var baseUrl = Environment.GetEnvironmentVariable("BaseUrl") ?? throw new InvalidOperationException("BaseUrl not configured");
//var adminEmail = Environment.GetEnvironmentVariable("AdminEmail") ?? throw new InvalidOperationException("AdminEmail not configured");

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        // Add infrastructure services (including DbContext)
        services.AddInfrastructure(context.Configuration);

        // Add application services (including MediatR)
        services.AddApplication();
    })
    .Build();

await host.RunAsync();
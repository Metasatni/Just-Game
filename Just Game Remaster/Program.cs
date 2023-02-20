using Just_Game_Remaster;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder().Build();

await host.RunAsync();

IHostBuilder CreateHostBuilder() {
    return Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices);
}

void ConfigureServices(IServiceCollection services) {
    services.AddHostedService<Startup>();
    services.AddSingleton<GameObjects>();
}

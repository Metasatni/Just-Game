using Just_Game_Remaster.Engine;
using Microsoft.Extensions.Hosting;

namespace Just_Game_Remaster;

internal class Startup : BackgroundService {

    public Startup(IServiceProvider serviceProvider) {

        ServiceProvider.Initialize(serviceProvider);

    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken) {
        while (true) {
            Map map = new Map();
            Game game = new Game();
            game.Start();
        }
    }

}

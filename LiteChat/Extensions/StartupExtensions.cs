using Microsoft.Extensions.Hosting;

namespace LiteChat.Extensions;

public static class StartupExtensions
{
    public static void AddOrleansHost(this IHostBuilder host)
    {
        host.UseOrleans(siloBuilder => siloBuilder.UseLocalhostClustering());
    }
}


using Microsoft.EntityFrameworkCore;
using BlueCube.Identity.Data;

namespace BlueCube.Identity.Services;

public class MigrationService(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        await using var db = scope.ServiceProvider.GetRequiredService<BlueCubeIdentityDbContext>();

        var migrations = await db.Database.GetPendingMigrationsAsync(cancellationToken);

        if (migrations.Any())
        {
            await db.Database.MigrateAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;        
}
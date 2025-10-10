using eAgenda.Infraestrutura.Orm;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.WebApp.Config;

public static class DatabaseConfig
{
    public static void ApplyMigrations(this IHost app)
    {
        var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.Migrate();
    }
}
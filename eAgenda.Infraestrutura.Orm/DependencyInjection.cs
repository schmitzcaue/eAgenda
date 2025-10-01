using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAgenda.Infraestrutura.Orm;

public static class DependencyInjection
{
    public static IServiceCollection AddCamadaInfraestruturaEmOrm(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            var connectionString = configuration["SQL_CONNECTION_STRING"];

            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IRepositorioContato, RepositorioContatoEmOrm>();

        return services;
    }
}
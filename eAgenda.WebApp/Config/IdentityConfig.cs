using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.Infraestrutura.Orm;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace eAgenda.WebApp.Config;

public static class IdentityConfig
{
    public static void AddIdentityProviderConfig(this IServiceCollection services)
    {
        services.AddScoped<ITenantProvider, IdentityTenantProvider>();
        services.AddIdentity<Usuario, Cargo>(options =>
        {
            //requisitos de senha
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/autenticacao/login";
            options.AccessDeniedPath = "/";
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "AspNetCore.Cookies";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });
    }
}
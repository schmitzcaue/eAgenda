using eAgenda.Infraestrutura.Orm;
using eAgenda.WebApp.Config;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCamadaInfraestruturaEmOrm(builder.Configuration);

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.ApplyMigrations();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Erro");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

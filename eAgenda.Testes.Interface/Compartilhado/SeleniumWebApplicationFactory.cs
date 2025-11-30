using System;
using eAgenda.Infraestrutura.Orm;
using eAgenda.WebApp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eAgenda.Testes.Interface.Compartilhado;

public class SeleniumWebApplicationFactory : WebApplicationFactory<Program>
{
    private IHost? hostKestrel;
    public string UrlKestrel { get; private set; } = string.Empty;

    public IServiceProvider Servicos
    {
        get
        {
            if (hostKestrel is null)
                throw new InvalidOperationException("Servidor não iniciado");

            return hostKestrel.Services;
        }
    }

    public SeleniumWebApplicationFactory()
    {
        _ = CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            services
                .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("eAgendaTesteDb"));
        });
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        IHost hostTeste = null;

        try
        {
            hostTeste = builder.Build();

            builder.ConfigureWebHost(webHostBuilder =>
            {
                webHostBuilder.UseKestrel();
                webHostBuilder.UseUrls("http://127.0.0.1:0");
            });

            hostKestrel = builder.Build();
            hostKestrel.Start();

            var servidor = hostKestrel.Services.GetRequiredService<IServer>();
            var enderecosDoServidor = servidor.Features.Get<IServerAddressesFeature>();

            if (enderecosDoServidor is null)
                throw new InvalidOperationException("Não foi possível obter a URL do servidor");

            UrlKestrel = enderecosDoServidor.Addresses.Last();

            hostTeste.Start();

            return hostTeste;
        }
        catch
        {
            hostKestrel?.Dispose();
            hostTeste?.Dispose();

            throw;
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (disposing)
            hostKestrel?.Dispose();
    }
}
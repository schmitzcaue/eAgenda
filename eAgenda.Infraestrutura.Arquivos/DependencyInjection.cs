using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrutura.Arquivos.Compartilhado;
using eAgenda.Infraestrutura.Arquivos.ModuloCategoria;
using eAgenda.Infraestrutura.Arquivos.ModuloCompromisso;
using eAgenda.Infraestrutura.Arquivos.ModuloContato;
using eAgenda.Infraestrutura.Arquivos.ModuloDespesa;
using eAgenda.Infraestrutura.Arquivos.ModuloTarefa;
using Microsoft.Extensions.DependencyInjection;

namespace eAgenda.Infraestrutura.Arquivos;

public static class DependencyInjection
{
    public static IServiceCollection AddCamadaInfraestruturaEmArquivo(this IServiceCollection services)
    {
        services.AddScoped(_ => new ContextoDados(true));

        services.AddScoped<IRepositorioContato, RepositorioContatoEmArquivo>();
        services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmArquivo>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmArquivo>();
        services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmArquivo>();

        return services;
    }
}

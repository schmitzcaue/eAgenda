using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;
using eAgenda.Infraestrutura.Orm.ModuloTarefa;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm;

public static class AppDbContextFactory
{
    public static AppDbContext CriarDbContext(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString, options => options.EnableRetryOnFailure(3));

        return new AppDbContext(builder.Options);
    }
}

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Compromisso> Compromissos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<ItemTarefa> ItensTarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCompromissoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCategoriaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorDespesaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorTarefaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorItemTarefaEmOrm());

        base.OnModelCreating(modelBuilder);
    }
}
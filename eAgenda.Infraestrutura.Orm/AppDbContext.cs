using eAgenda.Dominio.ModuloAutenticacao;
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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

public class AppDbContext(DbContextOptions options, ITenantProvider? tenantProvider = null) : IdentityDbContext<Usuario, Cargo, Guid>(options)
{
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Compromisso> Compromissos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<ItemTarefa> ItensTarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (tenantProvider is not null)
        {
            modelBuilder.Entity<Contato>()
                .HasQueryFilter(x => x.UsuarioId == tenantProvider.UsuarioId);

            modelBuilder.Entity<Compromisso>()
                .HasQueryFilter(x => x.UsuarioId == tenantProvider.UsuarioId);

            modelBuilder.Entity<Categoria>()
                .HasQueryFilter(x => x.UsuarioId == tenantProvider.UsuarioId);

            modelBuilder.Entity<Despesa>()
                .HasQueryFilter(x => x.UsuarioId == tenantProvider.UsuarioId);

            modelBuilder.Entity<Tarefa>()
                .HasQueryFilter(x => x.UsuarioId == tenantProvider.UsuarioId);

            modelBuilder.Entity<ItemTarefa>()
                .HasQueryFilter(x => x.Tarefa.UsuarioId == tenantProvider.UsuarioId);
        }


        modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCompromissoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCategoriaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorDespesaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorTarefaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorItemTarefaEmOrm());

        base.OnModelCreating(modelBuilder);
    }
}
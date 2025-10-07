using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;

namespace eAgenda.Infraestrutura.Orm;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Compromisso> Compromissos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Despesa> Despesas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCompromissoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCategoriaEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorDespesaEmOrm());


        base.OnModelCreating(modelBuilder);
    }
}
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Compromisso> Compromissos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());
        modelBuilder.ApplyConfiguration(new MapeadorCompromissoEmOrm());

        base.OnModelCreating(modelBuilder);
    }
}
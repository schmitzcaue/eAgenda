using eAgenda.Dominio.ModuloContato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.Infraestrutura.Orm.ModuloContato;

public class MapeadorContatoEmOrm : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("TBContato");

        builder.HasKey(x => x.Id);

        // NOME VARCHAR(100) NOT NULL
        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        // TELEFONE VARCHAR(20) NOT NULL
        builder.Property(x => x.Telefone)
            .HasMaxLength(20)
            .IsRequired();

        // EMAIL VARCHAR(100) NOT NULL
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();

        // EMPRESA VARCHAR(100) NULL
        builder.Property(x => x.Empresa)
            .HasMaxLength(100)
            .IsRequired(false);

        // CARGO  VARCHAR(100) NOT NULL
        builder.Property(x => x.Cargo)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Ignore(x => x.Compromissos);
    }
}
using Microsoft.AspNetCore.Identity;

namespace eAgenda.Dominio.ModuloAutenticacao;

public class Cargo : IdentityRole<Guid>
{
    public Cargo()
    {
        Id = Guid.NewGuid();
    }
}
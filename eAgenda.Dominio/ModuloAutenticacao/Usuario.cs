using Microsoft.AspNetCore.Identity;

namespace eAgenda.Dominio.ModuloAutenticacao;

public class Usuario : IdentityUser<Guid>
{
    public Usuario()
    {
        Id = Guid.NewGuid();
        EmailConfirmed = true;
    }
}
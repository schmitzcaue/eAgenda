using eAgenda.Dominio.ModuloAutenticacao;
using System.Security.Claims;

namespace eAgenda.WebApp.Config;

public class IdentityTenantProvider(IHttpContextAccessor contextAcessor) : ITenantProvider
{
    public Guid? UsuarioId
    {
        get
        {
            // Tenta obter o ID do usuário requisitante
            var claim = contextAcessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

            return claim is not null ? Guid.Parse(claim.Value) : null;
        }
    }
}
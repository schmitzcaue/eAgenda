using eAgenda.Dominio.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloCompromisso;

public class RepositorioCompromissoEmOrm : IRepositorioCompromisso
{
    private readonly AppDbContext context;
    private readonly DbSet<Compromisso> registros;

    public RepositorioCompromissoEmOrm(AppDbContext context)
    {
        this.context = context;

        registros = context.Compromissos;
    }

    public void CadastrarRegistro(Compromisso novoRegistro)
    {
        registros.Add(novoRegistro);

        context.SaveChanges();
    }

    public bool EditarRegistro(Guid idRegistro, Compromisso registroEditado)
    {
        var registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null)
            return false;

        registroSelecionado.AtualizarRegistro(registroEditado);

        context.SaveChanges();

        return true;
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        var registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null)
            return false;

        registros.Remove(registroSelecionado);

        context.SaveChanges();

        return true;
    }

    public Compromisso? SelecionarRegistroPorId(Guid idRegistro)
    {
        return registros.Include(c => c.Contato).FirstOrDefault(x => x.Id == idRegistro);
    }

    public List<Compromisso> SelecionarRegistros()
    {
        return registros.Include(c => c.Contato).ToList();
    }
}
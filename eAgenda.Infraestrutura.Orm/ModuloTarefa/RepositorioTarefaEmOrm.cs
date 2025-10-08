using eAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;

namespace eAgenda.Infraestrutura.Orm.ModuloTarefa;

public class RepositorioTarefaEmOrm : IRepositorioTarefa
{
    private readonly AppDbContext context;
    private readonly DbSet<Tarefa> registros;

    public RepositorioTarefaEmOrm(AppDbContext context)
    {
        this.context = context;
        registros = context.Tarefas;
    }

    public void CadastrarRegistro(Tarefa tarefa)
    {
        registros.Add(tarefa);

        context.SaveChanges();
    }

    public bool EditarRegistro(Guid idTarefa, Tarefa tarefaEditada)
    {
        var registroSelecionado = SelecionarRegistroPorId(idTarefa);

        if (registroSelecionado is null)
            return false;

        registroSelecionado.AtualizarRegistro(tarefaEditada);

        context.SaveChanges();

        return true;
    }

    public bool ExcluirRegistro(Guid idTarefa)
    {
        var registroSelecionado = SelecionarRegistroPorId(idTarefa);

        if (registroSelecionado is null)
            return false;

        registros.Remove(registroSelecionado);

        context.SaveChanges();

        return true;
    }

    public Tarefa? SelecionarRegistroPorId(Guid idTarefa)
    {
        return registros
            .Include(x => x.Itens)
            .FirstOrDefault(x => x.Id == idTarefa);
    }

    public List<Tarefa> SelecionarRegistros()
    {
        return registros
            .Include(x => x.Itens)
            .ToList();
    }
    public List<Tarefa> SelecionarTarefasConcluidas()
    {
        return registros
            .Include(x => x.Itens)
            .Where(x => x.Concluida)
            .ToList();
    }

    public List<Tarefa> SelecionarTarefasPendentes()
    {
        return registros
            .Include(x => x.Itens)
            .Where(x => !x.Concluida)
            .ToList();
    }
}
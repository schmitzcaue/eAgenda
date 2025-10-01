using eAgenda.Dominio.ModuloTarefa;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models;

public abstract class FormularioTarefaViewModel
{
    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    [MinLength(2, ErrorMessage = "O campo \"Título\" precisa conter ao menos 2 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Título\" precisa conter no máximo 100 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo \"Prioridade\" é obrigatório.")]
    public PrioridadeTarefa Prioridade { get; set; }
}

public class CadastrarTarefaViewModel : FormularioTarefaViewModel
{
    public CadastrarTarefaViewModel() { }

    public CadastrarTarefaViewModel(string titulo, PrioridadeTarefa prioridade)
    {
        Titulo = titulo;
        Prioridade = prioridade;
    }
}

public class EditarTarefaViewModel : FormularioTarefaViewModel
{
    public Guid Id { get; set; }

    public EditarTarefaViewModel() { }

    public EditarTarefaViewModel(Guid id, string titulo, PrioridadeTarefa prioridade)
    {
        Id = id;
        Titulo = titulo;
        Prioridade = prioridade;
    }
}

public class ExcluirTarefaViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }

    public ExcluirTarefaViewModel(Guid id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}

public class VisualizarTarefasViewModel
{
    public List<DetalhesTarefaViewModel> Registros { get; set; }

    public VisualizarTarefasViewModel(List<Tarefa> tarefas)
    {
        Registros = tarefas.Select(x => new DetalhesTarefaViewModel(
            x.Id,
            x.Titulo,
            x.Prioridade,
            x.DataCriacao,
            x.DataConclusao,
            x.Concluida,
            x.PercentualConcluido
        )).ToList();
    }
}

public class DetalhesTarefaViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public PrioridadeTarefa Prioridade { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
    public bool Concluida { get; set; }
    public decimal PercentualConcluido { get; set; }

    public DetalhesTarefaViewModel(
        Guid id,
        string titulo,
        PrioridadeTarefa prioridade,
        DateTime dataCriacao,
        DateTime? dataConclusao,
        bool concluida,
        decimal percentualConcluido
    )
    {
        Id = id;
        Titulo = titulo;
        Prioridade = prioridade;
        DataCriacao = dataCriacao;
        DataConclusao = dataConclusao;
        Concluida = concluida;
        PercentualConcluido = percentualConcluido;
    }
}

public class GerenciarItensViewModel
{
    public DetalhesTarefaViewModel Tarefa { get; set; }
    public List<ItemTarefaViewModel> Itens { get; set; }

    public GerenciarItensViewModel() { }

    public GerenciarItensViewModel(Tarefa tarefa) : this()
    {
        Tarefa = new DetalhesTarefaViewModel(
            tarefa.Id,
            tarefa.Titulo,
            tarefa.Prioridade,
            tarefa.DataCriacao,
            tarefa.DataConclusao,
            tarefa.Concluida,
            tarefa.PercentualConcluido
        );

        Itens = tarefa.Itens
            .Select(x => new ItemTarefaViewModel(x.Id, x.Titulo, x.Concluido))
            .ToList();
    }
}

public class ItemTarefaViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public bool Concluido { get; set; }

    public ItemTarefaViewModel(Guid id, string titulo, bool concluido)
    {
        Id = id;
        Titulo = titulo;
        Concluido = concluido;
    }
}
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models;

public class FormularioDespesaViewModel
{
    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    [MinLength(2, ErrorMessage = "O campo \"Descrição\" precisa conter ao menos 2 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Descrição\" precisa conter no máximo 100 caracteres.")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O campo \"Data de Ocorrência\" é obrigatório.")]
    public DateTime DataOcorrencia { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O campo \"Valor\" é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O campo \"Valor\" deve conter um valor numérico positivo.")]
    public decimal Valor { get; set; } = 0.0m;

    [Required(ErrorMessage = "O campo \"Forma de Pagamento\" é obrigatório.")]
    public FormaPagamento FormaPagamento { get; set; }

    [Required(ErrorMessage = "O campo \"Categorias Selecionadas\" é necessita de ao menos um valor preenchido.")]
    public List<Guid>? CategoriasSelecionadas { get; set; }

    public List<SelectListItem>? CategoriasDisponiveis { get; set; }
}

public class CadastrarDespesaViewModel : FormularioDespesaViewModel
{
    public CadastrarDespesaViewModel()
    {
        CategoriasSelecionadas = new List<Guid>();
        CategoriasDisponiveis = new List<SelectListItem>();
    }

    public CadastrarDespesaViewModel(List<Categoria> categoriasDisponiveis) : this()
    {
        CategoriasDisponiveis = categoriasDisponiveis
            .Select(x => new SelectListItem(x.Titulo, x.Id.ToString()))
            .ToList();
    }
}

public class EditarDespesaViewModel : FormularioDespesaViewModel
{
    public Guid Id { get; set; }

    public EditarDespesaViewModel()
    {
        CategoriasSelecionadas = new List<Guid>();
        CategoriasDisponiveis = new List<SelectListItem>();
    }

    public EditarDespesaViewModel(
        Guid id,
        string descricao,
        decimal valor,
        DateTime dataOcorrencia,
        FormaPagamento formaPagamento,
        List<Categoria> categoriasSelecionadas,
        List<Categoria> categoriasDisponiveis
    ) : this()
    {
        Id = id;
        Descricao = descricao;
        DataOcorrencia = dataOcorrencia;
        Valor = valor;
        FormaPagamento = formaPagamento;

        foreach (var cs in categoriasSelecionadas)
            CategoriasSelecionadas?.Add(cs.Id);

        CategoriasDisponiveis = categoriasDisponiveis
            .Select(x => new SelectListItem(x.Titulo, x.Id.ToString()))
            .ToList();
    }
}

public class ExcluirDespesaViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }

    public ExcluirDespesaViewModel(Guid id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }
}

public class VisualizarDespesasViewModel
{
    public List<DetalhesDespesaViewModel> Registros { get; set; }

    public VisualizarDespesasViewModel(List<Despesa> despesas)
    {
        Registros = despesas.Select(x => new DetalhesDespesaViewModel(
            x.Id,
            x.Descricao,
            x.Valor,
            x.DataOcorencia,
            x.FormaPagamento,
            x.Categorias
        )).ToList();
    }
}

public class DetalhesDespesaViewModel
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataOcorrencia { get; set; }
    public decimal Valor { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    public List<string> Categorias { get; set; }

    public DetalhesDespesaViewModel(
        Guid id,
        string descricao,
        decimal valor,
        DateTime dataOcorrencia,
        FormaPagamento formaPagamento,
        List<Categoria> categorias
    )
    {
        Id = id;
        Descricao = descricao;
        Valor = valor;
        DataOcorrencia = dataOcorrencia;
        FormaPagamento = formaPagamento;

        Categorias = categorias
            .Select(x => x.Titulo)
            .ToList();
    }
}
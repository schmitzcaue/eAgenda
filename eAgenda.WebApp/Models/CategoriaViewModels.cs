using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models;

public class FormularioCategoriaViewModel
{
    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    [MinLength(2, ErrorMessage = "O campo \"Título\" precisa conter ao menos 2 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Título\" precisa conter no máximo 100 caracteres.")]
    public string? Titulo { get; set; }
}

public class CadastrarCategoriaViewModel : FormularioCategoriaViewModel
{
    public CadastrarCategoriaViewModel() { }

    public CadastrarCategoriaViewModel(string titulo) : this()
    {
        Titulo = titulo;
    }
}

public class EditarCategoriaViewModel : FormularioCategoriaViewModel
{
    public Guid Id { get; set; }

    public EditarCategoriaViewModel() { }

    public EditarCategoriaViewModel(Guid id, string titulo) : this()
    {
        Id = id;
        Titulo = titulo;
    }
}

public class ExcluirCategoriaViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }

    public ExcluirCategoriaViewModel(Guid id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}

public class VisualizarCategoriasViewModel
{
    public List<DetalhesCategoriaViewModel> Registros { get; set; }

    public VisualizarCategoriasViewModel(List<Categoria> categorias)
    {
        Registros = categorias.Select(x => new DetalhesCategoriaViewModel(
            x.Id,
            x.Titulo,
            x.Despesas
        )).ToList();
    }
}

public class DetalhesCategoriaViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public List<DetalhesDespesaViewModel> Despesas { get; set; }
    public decimal TotalDespesas { get; set; }

    public DetalhesCategoriaViewModel(Guid id, string titulo, List<Despesa> despesas)
    {
        Id = id;
        Titulo = titulo;

        Despesas = despesas.Select(x => new DetalhesDespesaViewModel(
            x.Id,
            x.Descricao,
            x.Valor,
            x.DataOcorencia,
            x.FormaPagamento,
            x.Categorias
        )).ToList();

        TotalDespesas = despesas.Sum(x => x.Valor);
    }
}
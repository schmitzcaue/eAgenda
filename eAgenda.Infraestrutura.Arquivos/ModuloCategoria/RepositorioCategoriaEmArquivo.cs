using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace eAgenda.Infraestrutura.Arquivos.ModuloCategoria;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorioCategoria
{
    public RepositorioCategoriaEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Categoria> ObterRegistros()
    {
        return contexto.Categorias;
    }
}

using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace eAgenda.Infraestrutura.Arquivos.ModuloContato;
public class RepositorioContatoEmArquivo : RepositorioBaseEmArquivo<Contato>, IRepositorioContato
{
    public RepositorioContatoEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Contato> ObterRegistros()
    {
        return contexto.Contatos;
    }
}

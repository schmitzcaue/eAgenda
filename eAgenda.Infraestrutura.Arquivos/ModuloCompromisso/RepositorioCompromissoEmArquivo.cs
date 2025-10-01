using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Infraestrutura.Arquivos.Compartilhado;

namespace eAgenda.Infraestrutura.Arquivos.ModuloCompromisso;

public class RepositorioCompromissoEmArquivo : RepositorioBaseEmArquivo<Compromisso>, IRepositorioCompromisso
{
    public RepositorioCompromissoEmArquivo(ContextoDados contexto) : base(contexto) { }

    protected override List<Compromisso> ObterRegistros()
    {
        return contexto.Compromissos;
    }
}

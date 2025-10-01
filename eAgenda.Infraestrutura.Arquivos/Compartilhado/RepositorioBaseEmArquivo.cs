using eAgenda.Dominio.Compartilhado;

namespace eAgenda.Infraestrutura.Arquivos.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
{
    protected ContextoDados contexto;
    protected List<T> registros = new List<T>();

    protected RepositorioBaseEmArquivo(ContextoDados contexto)
    {
        this.contexto = contexto;

        registros = ObterRegistros();
    }

    protected abstract List<T> ObterRegistros();

    public void CadastrarRegistro(T novoRegistro)
    {
        registros.Add(novoRegistro);

        contexto.Salvar();
    }

    public bool EditarRegistro(Guid idRegistro, T registroEditado)
    {
        T? registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null)
            return false;

        registroSelecionado.AtualizarRegistro(registroEditado);

        contexto.Salvar();

        return true;
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        T? registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null)
            return false;

        registros.Remove(registroSelecionado);

        contexto.Salvar();

        return true;
    }

    public List<T> SelecionarRegistros()
    {
        return registros;
    }

    public T? SelecionarRegistroPorId(Guid idRegistro)
    {
        return registros.Find((x) => x.Id.Equals(idRegistro));
    }
}

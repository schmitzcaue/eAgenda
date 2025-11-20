using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloCategoria;
using eAgenda.Infraestrutura.Orm.ModuloCompromisso;
using eAgenda.Infraestrutura.Orm.ModuloContato;
using eAgenda.Infraestrutura.Orm.ModuloDespesa;
using eAgenda.Infraestrutura.Orm.ModuloTarefa;
using System.Reflection;

namespace eAgenda.Testes.Integracao.Compartilhado;

[TestClass]
public abstract class TestFixture
{
    private AppDbContext? dbContext;

    protected RepositorioContatoEmOrm? repositorioContato;
    protected RepositorioCompromissoEmOrm? repositorioCompromisso;
    protected RepositorioCategoriaEmOrm? repositorioCategoria;
    protected RepositorioDespesaEmOrm? repositorioDespesa;
    protected RepositorioTarefaEmOrm? repositorioTarefa;

    [TestInitialize]
    public void ConfigurarTestes()
    {
        Assembly assembly = typeof(TestFixture).Assembly;

        dbContext = AppDbContextFactory.CriarDbContext();
        dbContext.Database.EnsureCreated();

        dbContext.Tarefas.RemoveRange(dbContext.Tarefas);
        dbContext.Despesas.RemoveRange(dbContext.Despesas);
        dbContext.Categorias.RemoveRange(dbContext.Categorias);
        dbContext.Compromissos.RemoveRange(dbContext.Compromissos);
        dbContext.Contatos.RemoveRange(dbContext.Contatos);

        dbContext.SaveChanges();

        repositorioContato = new RepositorioContatoEmOrm(dbContext);
        repositorioCompromisso = new RepositorioCompromissoEmOrm(dbContext);
        repositorioCategoria = new RepositorioCategoriaEmOrm(dbContext);
        repositorioDespesa = new RepositorioDespesaEmOrm(dbContext);
        repositorioTarefa = new RepositorioTarefaEmOrm(dbContext);
    }
}
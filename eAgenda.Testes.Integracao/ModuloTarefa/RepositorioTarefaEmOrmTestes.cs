using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloTarefa;

[TestClass]
[TestCategory("Testes de Integração de Tarefa")]
public class RepositorioTarefaEmOrmTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        // Arranjo
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        // Ação
        repositorioTarefa?.CadastrarRegistro(tarefa);

        // Asserção
        Tarefa? tarefaSelecionada = repositorioTarefa?.SelecionarRegistroPorId(tarefa.Id);

        Assert.AreEqual(tarefa, tarefaSelecionada);
    }

    [TestMethod]
    public void Deve_EditarRegistro_ComSucesso()
    {
        // Arranjo
        Tarefa tarefaOriginal = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        repositorioTarefa?.CadastrarRegistro(tarefaOriginal);

        Tarefa tarefaEditada = new Tarefa("Lavar o carro", PrioridadeTarefa.Normal);

        // Ação
        bool? registroEditado = repositorioTarefa?.EditarRegistro(tarefaOriginal.Id, tarefaEditada);

        // Asserção
        Tarefa? tarefaSelecionada = repositorioTarefa?.SelecionarRegistroPorId(tarefaOriginal.Id);

        Assert.IsTrue(registroEditado);
        Assert.AreEqual(tarefaOriginal, tarefaSelecionada);
    }

    [TestMethod]
    public void Deve_ExcluirRegistro_ComSucesso()
    {
        // Arranjo
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        repositorioTarefa?.CadastrarRegistro(tarefa);

        // Ação
        bool? registroExcluido = repositorioTarefa?.ExcluirRegistro(tarefa.Id);

        // Asserção
        Tarefa? tarefaSelecionada = repositorioTarefa?.SelecionarRegistroPorId(tarefa.Id);

        Assert.IsTrue(registroExcluido);
        Assert.IsNull(tarefaSelecionada);
    }

    [TestMethod]
    public void Deve_SelecionarTarefasConcluidas_ComSucesso()
    {
        // Arranjo
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);
        Tarefa tarefa2 = new Tarefa("Lavar o carro", PrioridadeTarefa.Normal);
        Tarefa tarefa3 = new Tarefa("Lavar a casa", PrioridadeTarefa.Baixa);

        tarefa2.Concluir();

        repositorioTarefa?.CadastrarRegistro(tarefa);
        repositorioTarefa?.CadastrarRegistro(tarefa2);
        repositorioTarefa?.CadastrarRegistro(tarefa3);

        // Ação
        List<Tarefa>? tarefasSelecionadas = repositorioTarefa?.SelecionarTarefasConcluidas();

        // Asserção
        List<Tarefa> tarefasOriginais = [tarefa, tarefa2, tarefa3];

        Assert.IsTrue(tarefasSelecionadas?.All(t => t.Concluida));
        CollectionAssert.AreNotEqual(tarefasOriginais, tarefasSelecionadas);
    }

    [TestMethod]
    public void Deve_SelecionarTarefasPendentes_ComSucesso()
    {
        // Arranjo
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);
        Tarefa tarefa2 = new Tarefa("Lavar o carro", PrioridadeTarefa.Normal);
        Tarefa tarefa3 = new Tarefa("Lavar a casa", PrioridadeTarefa.Baixa);

        tarefa2.Concluir();

        repositorioTarefa?.CadastrarRegistro(tarefa);
        repositorioTarefa?.CadastrarRegistro(tarefa2);
        repositorioTarefa?.CadastrarRegistro(tarefa3);

        // Ação
        List<Tarefa>? tarefasSelecionadas = repositorioTarefa?.SelecionarTarefasPendentes();

        // Asserção
        List<Tarefa> tarefasOriginais = [tarefa, tarefa2, tarefa3];

        Assert.IsTrue(tarefasSelecionadas?.All(t => !t.Concluida));
        CollectionAssert.AreNotEqual(tarefasOriginais, tarefasSelecionadas);
    }
}
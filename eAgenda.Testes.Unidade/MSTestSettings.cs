using eAgenda.Dominio.ModuloTarefa;

namespace eAgenda.Testes.Unidade.ModuloTarefa;

[TestClass]
[TestCategory("Testes de Unidade de Tarefa")]
public sealed class TarefaTests
{
    [TestMethod]
    public void Deve_Concluir_Tarefa_Corretamente()
    {
        // Arranjo
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        // Ação
        tarefa.Concluir();

        // Asserção
        Assert.IsTrue(tarefa.Concluida);
        Assert.IsNotNull(tarefa.DataConclusao);
    }

    [TestMethod]
    public void Deve_Marcar_Tarefa_ComoPendente_Corretamente()
    {
        // Arranjo
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        tarefa.Concluir();

        // Ação
        tarefa.MarcarPendente();

        // Asserção
        Assert.IsFalse(tarefa.Concluida);
        Assert.IsNull(tarefa.DataConclusao);
    }

    [TestMethod]
    public void Deve_AdicionarItem_Na_Tarefa_Corretamente()
    {
        // Arranjo 
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        tarefa.Concluir();

        // Ação
        tarefa.AdicionarItem("Comprar shampoo e matacura");

        // Asserção
        Assert.AreEqual(1, tarefa.Itens.Count);
        Assert.IsFalse(tarefa.Concluida);
        Assert.IsNull(tarefa.DataConclusao);
    }

    [TestMethod]
    public void Deve_RemoverItem_Da_Tarefa_Corretamente()
    {
        // Arranjo 
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        tarefa.Concluir();

        var itemTarefa = tarefa.AdicionarItem("Comprar shampoo e matacura");

        // Ação
        tarefa.RemoverItem(itemTarefa);

        // Asserção
        Assert.AreEqual(0, tarefa.Itens.Count);
        Assert.IsFalse(tarefa.Concluida);
        Assert.IsNull(tarefa.DataConclusao);
    }

    [TestMethod]
    public void Deve_AtualizarPorcentagem_Da_Tarefa_Corretamente()
    {
        // Arranjo 
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        var itemTarefa = tarefa.AdicionarItem("Comprar shampoo e matacura");

        // Ação
        tarefa.ConcluirItem(itemTarefa);

        // Asserção
        Assert.AreEqual(100m, tarefa.PercentualConcluido);
    }

    [TestMethod]
    public void Deve_AtualizarPorcentagem_Da_Tarefa_ComMultiplos_Itens_Corretamente()
    {
        // Arranjo 
        Tarefa tarefa = new Tarefa("Lavar o cachorro", PrioridadeTarefa.Alta);

        var itemTarefa = tarefa.AdicionarItem("Comprar shampoo e matacura");
        var itemTarefa2 = tarefa.AdicionarItem("Pegar a coleira do cachorro");

        // Ação
        tarefa.ConcluirItem(itemTarefa);

        // Asserção
        Assert.AreEqual(50m, tarefa.PercentualConcluido);
    }
}
using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Testes.Integracao.Compartilhado;
using FizzWare.NBuilder;

namespace eAgenda.Testes.Integracao.ModuloDespesa;

[TestClass]
[TestCategory("Testes de Integração de Despesa")]
public class RepositorioDespesaEmOrmTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        // Arrange - Arranjo
        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        Categoria categoria = Builder<Categoria>
            .CreateNew()
            .Build();

        despesa.RegistarCategoria(categoria);

        // Act - Ação
        repositorioDespesa?.CadastrarRegistro(despesa);

        // Assert - Asserção
        Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.AreEqual(despesa, despesaSelecionada);
    }

    [TestMethod]
    public void Deve_EditarRegistro_ComSucesso()
    {
        // Arrange - Arranjo
        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        Categoria categoria = Builder<Categoria>
            .CreateNew()
            .Build();

        despesa.RegistarCategoria(categoria);

        repositorioDespesa?.CadastrarRegistro(despesa);

        Despesa despesaEditada = new Despesa(
            "Steam",
            40.30m,
            DateTime.Now,
            FormaPagamento.Pix
        );

        // Act - Ação
        bool? registroEditado = repositorioDespesa?.EditarRegistro(despesa.Id, despesaEditada);

        // Assert - Asserção
        Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.IsTrue(registroEditado);
        Assert.AreEqual(despesa, despesaSelecionada);
    }

    [TestMethod]
    public void Deve_ExcluirRegistro_ComSucesso()
    {
        // Arrange - Arranjo
        Despesa despesa = new Despesa(
            "Compras",
            190.33m,
            DateTime.Now,
            FormaPagamento.Credito
        );

        Categoria categoria = Builder<Categoria>
            .CreateNew()
            .Build();

        despesa.RegistarCategoria(categoria);

        repositorioDespesa?.CadastrarRegistro(despesa);

        // Act - Ação
        bool? registroExcluido = repositorioDespesa?.ExcluirRegistro(despesa.Id);

        // Assert - Asserção
        Despesa? despesaSelecionada = repositorioDespesa?.SelecionarRegistroPorId(despesa.Id);

        Assert.IsTrue(registroExcluido);
        Assert.IsNull(despesaSelecionada);
    }
}
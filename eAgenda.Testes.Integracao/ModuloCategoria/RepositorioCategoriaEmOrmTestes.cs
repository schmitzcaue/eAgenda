using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloCategoria;

[TestClass]
[TestCategory("Testes de Integração de Categoria")]
public class RepositorioCategoriaEmOrmTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        // Arranjo
        Categoria categoria = new Categoria("Mercado");

        // Ação
        repositorioCategoria?.CadastrarRegistro(categoria);

        // Asserção
        Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

        Assert.AreEqual(categoria, categoriaSelecionada);
    }

    [TestMethod]
    public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
    {
        // Arranjo
        Categoria categoria = new Categoria("Mercado");

        repositorioCategoria?.CadastrarRegistro(categoria);

        // Ação
        Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(Guid.NewGuid());

        // Asserção
        Assert.AreNotEqual(categoria, categoriaSelecionada);
    }

    [TestMethod]
    public void Deve_EditarRegistro_ComSucesso()
    {
        // Arranjo
        Categoria categoriaOriginal = new Categoria("Mercado");

        repositorioCategoria?.CadastrarRegistro(categoriaOriginal);

        Categoria categoriaEditada = new Categoria("Lazer");

        // Ação
        bool? registroEditado = repositorioCategoria?.EditarRegistro(categoriaOriginal.Id, categoriaEditada);

        // Asserção
        Categoria? categoriaSelecionado = repositorioCategoria?.SelecionarRegistroPorId(categoriaOriginal.Id);

        Assert.IsTrue(registroEditado);
        Assert.AreEqual(categoriaOriginal, categoriaSelecionado);
    }

    [TestMethod]
    public void Deve_ExcluirRegistro_ComSucesso()
    {
        // Arranjo
        Categoria categoria = new Categoria("Mercado");

        repositorioCategoria?.CadastrarRegistro(categoria);

        // Ação
        bool? registroExcluido = repositorioCategoria?.ExcluirRegistro(categoria.Id);

        // Asserção
        Categoria? categoriaSelecionada = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

        Assert.IsTrue(registroExcluido);
        Assert.IsNull(categoriaSelecionada);
    }
}
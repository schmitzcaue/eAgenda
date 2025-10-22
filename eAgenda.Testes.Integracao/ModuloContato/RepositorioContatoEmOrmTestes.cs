using eAgenda.Dominio.ModuloContato;
using eAgenda.Testes.Integracao.Compartilhado;


namespace eAgenda.Testes.Integracao.ModuloContato;

[TestClass]
[TestCategory("Testes de Integração de Contato")]
public sealed class RepositorioContatoEmOrmTestes : TestFixture
{

    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        // Arranjo
        Contato contato = new Contato(
            "Juninho Testes",
            "(49) 98533-3334",
            "testes@academiadoprogramador.net",
            "Academia do Programador",
            "Testador"
        );

        // Ação
        repositorioContato?.CadastrarRegistro(contato);

        Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contato.Id);

        // Asserção
        Assert.AreEqual(contato, contatoSelecionado);
    }

    [TestMethod]
    public void Deve_RetornarNulo_Ao_SelecionarRegistroPorId_ComIdErrado()
    {
        // Arranjo
        Contato contato = new Contato(
            "Juninho Testes 2",
            "(49) 98533-3334",
            "testes@academiadoprogramador.net",
            "Academia do Programador",
            "Testador"
        );

        repositorioContato?.CadastrarRegistro(contato);

        // Ação
        Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(Guid.NewGuid());

        // Asserção
        Assert.AreNotEqual(contato, contatoSelecionado);
    }

    [TestMethod]
    public void Deve_EditarRegistro_ComSucesso()
    {
        // Arranjo
        Contato contatoOriginal = new Contato(
            "Juninho Testes",
            "(49) 98533-3334",
            "testes@academiadoprogramador.net",
            "Academia do Programador",
            "Testador"
        );

        repositorioContato?.CadastrarRegistro(contatoOriginal);

        Contato contatoEditado = new Contato(
            "Pedrinho do Código",
            "(49) 99452-5234",
            "pedrinho_codigos@academiadoprogramador.net",
            "Academia do Programador",
            "Desenvolvedor"
        );

        // Ação
        bool? registroEditado = repositorioContato?.EditarRegistro(contatoOriginal.Id, contatoEditado);

        // Asserção
        Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contatoOriginal.Id);

        Assert.IsTrue(registroEditado);
        Assert.AreEqual(contatoOriginal, contatoSelecionado);
    }

    [TestMethod]
    public void Deve_ExcluirRegistro_ComSucesso()
    {
        // Arranjo
        Contato contatoOriginal = new Contato(
            "Juninho Testes",
            "(49) 98533-3334",
            "testes@academiadoprogramador.net",
            "Academia do Programador",
            "Testador"
        );

        repositorioContato?.CadastrarRegistro(contatoOriginal);

        // Ação
        bool? registroExcluido = repositorioContato?.ExcluirRegistro(contatoOriginal.Id);

        // Asserção
        Contato? contatoSelecionado = repositorioContato?.SelecionarRegistroPorId(contatoOriginal.Id);

        Assert.IsTrue(registroExcluido);
        Assert.IsNull(contatoSelecionado);
    }
}
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infraestrutura.Orm;
using eAgenda.Infraestrutura.Orm.ModuloContato;

namespace eAgenda.Testes.Integracao.ModuloContato;

[TestClass]
public sealed class RepositorioContatoEmOrmTestes
{
    private static readonly AppDbContext dbContext = AppDbContextFactory.CriarDbContext
        ("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaDB;Integrated Security=True"

);
    private static RepositorioContatoEmOrm repositorioContato = new RepositorioContatoEmOrm(dbContext);

    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        Contato contato = new Contato(
            "Juninho Testes 2",
            "(49) 98533-3334",
            "testes@academiadoprogramador.net",
            "Academia do Programador",
            "Testador"
        );

        repositorioContato.CadastrarRegistro(contato);

        Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(contato.Id);

        // Asserção
        Assert.AreEqual(contato, contatoSelecionado);
    }

    [TestMethod]
    public void Deve_RetornarNulo_Ao_SelecionarRegistroPoId_ComIdErrado()
    {
        Contato contato = new Contato(
            "Juninho Testes 2",
            "(49) 98533-3334",
            "testes@academiadoprogramador.net",
            "Academia do Programador",
            "Testador"
        );

        repositorioContato.CadastrarRegistro(contato);

        Contato? contatoSelecionado = repositorioContato.SelecionarRegistroPorId(Guid.NewGuid());

        // Asserção
        Assert.AreNotEqual(contato, contatoSelecionado);
    }
}
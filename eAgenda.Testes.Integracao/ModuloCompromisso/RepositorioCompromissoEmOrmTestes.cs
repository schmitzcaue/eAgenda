using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Testes.Integracao.Compartilhado;
using FizzWare.NBuilder;

namespace eAgenda.Testes.Integracao.ModuloCompromisso;

[TestClass]
[TestCategory("Testes de Integração de Compromisso")]
public class RepositorioCompromissoEmOrmTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarRegistro_ComSucesso()
    {
        // Arrange - Arranjo
        TimeSpan horaInicio = DateTime.Now.TimeOfDay;
        TimeSpan horaTermino = horaInicio.Add(TimeSpan.FromHours(2));

        Compromisso compromisso = new Compromisso(
            "Reunião",
            DateTime.Now,
            horaInicio,
            horaTermino,
            TipoCompromisso.Remoto,
            "discord.com",
            null,
            null
        );

        // Act - Ação
        repositorioCompromisso?.CadastrarRegistro(compromisso);

        // Assert - Asserção
        Compromisso? compromissoSelecionado = repositorioCompromisso?.SelecionarRegistroPorId(compromisso.Id);

        Assert.AreEqual(compromisso, compromissoSelecionado);
    }

    [TestMethod]
    public void Deve_CadastrarRegistro_ComContato_ComSucesso()
    {
        // Arrange - Arranjo
        Contato contato = Builder<Contato>
            .CreateNew()
            .With(c => c.Id = Guid.NewGuid())
            .With(c => c.Nome = "Juninho Testes")
            .Build();

        TimeSpan horaInicio = DateTime.Now.TimeOfDay;
        TimeSpan horaTermino = horaInicio.Add(TimeSpan.FromHours(2));

        Compromisso compromisso = new Compromisso(
            "Reunião",
            DateTime.Now,
            horaInicio,
            horaTermino,
            TipoCompromisso.Remoto,
            "discord.com",
            null,
            contato
        );

        // Act - Ação
        repositorioCompromisso?.CadastrarRegistro(compromisso);

        // Assert - Asserção
        Compromisso? compromissoSelecionado = repositorioCompromisso?.SelecionarRegistroPorId(compromisso.Id);

        Assert.AreEqual(compromisso, compromissoSelecionado);
    }
}
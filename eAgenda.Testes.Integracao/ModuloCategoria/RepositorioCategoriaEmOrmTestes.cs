using eAgenda.Dominio.ModuloCategoria;
using eAgenda.Testes.Integracao.Compartilhado;

namespace eAgenda.Testes.Integracao.ModuloCategoria
{
    [TestClass]
    [TestCategory("Testes de Integração de Categoria")]
    public class RepositorioCategoriaEmOrmTestes : TestFixture
    {
        public void Deve_CadastrarRegistro_ComSucesso()
        {
            // Arrange - Arranjo

            Categoria categoria = new Categoria(
                "Tomar remedio"
            );

            // Act - Ação
            repositorioCategoria?.CadastrarRegistro(categoria);

            // Assert - Asserção
            Categoria? categoriaSelecionado = repositorioCategoria?.SelecionarRegistroPorId(categoria.Id);

            Assert.AreEqual(categoria, categoriaSelecionado);
        }
    }
}

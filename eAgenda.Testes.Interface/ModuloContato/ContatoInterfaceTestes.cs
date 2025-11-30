using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;

namespace eAgenda.Testes.Interface.ModuloContato;

    [TestClass]
[TestCategory("Testes de Interface de Contato")]
public class ContatoInterfaceTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        // Ação
        CadastrarContatoPadrao();

        // Asserção
        webDriverWait?.Until(d => d.Title.Contains("Visualização de Contatos"));
        webDriverWait?.Until(d => d.PageSource.Contains("Oscar Lima"));
    }

    [TestMethod]
    public void Deve_EditarContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarContatoPadrao();
        EsperarPorElemento(By.CssSelector("a[data-se=btnEditar]"))
           .Click();

        // Ação
        EsperarPorElemento(By.CssSelector("input[data-se=inputNome]"))
           .SendKeys(" Editado");

        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        // Asserção
        webDriverWait?.Until(d => d.Title.Contains("Visualização de Contatos"));
        webDriverWait?.Until(d => d.PageSource.Contains("Oscar Lima Editado"));
    }

    [TestMethod]
    public void Deve_ExcluirContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarContatoPadrao();

        EsperarPorElemento(By.CssSelector("a[data-se=btnExcluir]"))
            .Click();

        // Ação
        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        // Asserção
        webDriverWait?.Until(d => d.Title.Contains("Visualização de Contatos"));
        webDriverWait?.Until(d => !d.PageSource.Contains("Oscar Lima"));
    }

    public static void CadastrarContatoPadrao()
    {
        NavegarPara("/contatos/cadastrar");

        EsperarPorElemento(By.CssSelector("input[data-se=inputNome]"))
            .SendKeys("Oscar Lima");

        EsperarPorElemento(By.CssSelector("input[data-se=inputTelefone]"))
            .SendKeys("(49) 98888-2222");

        EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("oscar25lima@hotmail.com");


        EsperarPorElemento(By.CssSelector("input[data-se=inputEmpresa]"))
            .SendKeys("TurboAuto");


        EsperarPorElemento(By.CssSelector("input[data-se=inputCargo]"))
            .SendKeys("Mecânico");


        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();
    }
}
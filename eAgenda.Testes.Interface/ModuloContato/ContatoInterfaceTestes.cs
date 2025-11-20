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

        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "contatos", "cadastrar"));

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Oscar Lima");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 98888-2222");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("oscar25lima@hotmail.com");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("TurboAuto");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Mecânico");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Contatos"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("Oscar Lima"));
    }

    [TestMethod]
    public void Deve_EditarContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "contatos", "cadastrar"));

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Oscar Lima");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 98888-2222");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("oscar25lima@hotmail.com");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("TurboAuto");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Mecânico");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("a[data-se=btnEditar]")))
            .Click();

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys(" Editado");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Contatos"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("Oscar Lima Editado"));
    }

    [TestMethod]
    public void Deve_ExcluirContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "contatos", "cadastrar"));

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputNome]"))).SendKeys("Oscar Lima");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputTelefone]"))).SendKeys("(49) 98888-2222");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("oscar25lima@hotmail.com");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmpresa]"))).SendKeys("TurboAuto");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputCargo]"))).SendKeys("Mecânico");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("a[data-se=btnExcluir]")))
            .Click();

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Contatos"));

        webDriverWait?
            .Until(d => !d.PageSource.Contains("Oscar Lima"));
    }
}
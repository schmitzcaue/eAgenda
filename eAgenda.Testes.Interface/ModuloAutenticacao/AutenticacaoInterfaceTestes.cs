using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace eAgenda.Testes.Interface.ModuloAutenticacao;

[TestClass]
[TestCategory("Testes de Interface de Autenticação")]
public sealed class AutenticacaoInterfaceTestes : TestFixture
{
    [TestMethod]
    public void Deve_Registrar_Usuario_Corretamente()
    {
        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("teste@gmail.com");

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("Teste@123");

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputConfirmarSenha]"))
            .SendKeys("Teste@123");

        webDriver?
            .FindElement(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        Assert.IsTrue(webDriver?.PageSource.Contains("Página Inicial"));
        Assert.IsTrue(webDriver?.PageSource.Contains("teste@gmail.com"));
    }

    [TestMethod]
    public void Deve_Autenticar_Usuario_Corretamente()
    {
        // Arranjo
        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("teste@gmail.com");

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("Teste@123");

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputConfirmarSenha]"))
            .SendKeys("Teste@123");

        webDriver?
            .FindElement(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "login"));

        // Ação
        webDriver?
           .FindElement(By.CssSelector("input[data-se=inputEmail]"))
           .SendKeys("teste@gmail.com");

        webDriver?
            .FindElement(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("Teste@123");

        webDriver?
            .FindElement(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        // Asserção
        Assert.IsTrue(webDriver?.PageSource.Contains("Página Inicial"));
        Assert.IsTrue(webDriver?.PageSource.Contains("teste@gmail.com"));
    }
}
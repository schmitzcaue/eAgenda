using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;

namespace eAgenda.Testes.Interface.ModuloAutenticacao;

[TestClass]
[TestCategory("Testes de Interface de Autenticação")]
public sealed class CompromissoInterfaceTestes : TestFixture
{
    [TestMethod]
    public void Deve_Registrar_Usuario_Corretamente()
    {
        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));


        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]")))
            .SendKeys("teste@gmail.com");

        webDriverWait?
             .Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]")))
             .SendKeys("Teste@123");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputConfirmarSenha]")))
            .SendKeys("Teste@123");

        webDriverWait?
           .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]")))
           .Click();

        webDriverWait?
            .Until(d => d.PageSource.Contains("Página Inicial"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("teste@gmail.com"));
    }

        [TestMethod]
    public void Deve_Autenticar_Usuario_Corretamente()
    {
        // Arranjo
        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]")))
            .SendKeys("teste@gmail.com");

        webDriverWait?
           .Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]")))
           .SendKeys("SenhaSuperForteTeste@536");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputConfirmarSenha]")))
            .SendKeys("SenhaSuperForteTeste@536");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]")))
            .Click();

        webDriverWait?
           .Until(d => d.Title.Contains("Página Inicial"));


        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "login"));

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]"))).SendKeys("teste@gmail.com");


        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]"))).SendKeys("SenhaSuperForteTeste@536");


        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        webDriverWait?
           .Until(d => d.Title.Contains("Página Inicial"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("teste@gmail.com"));
    }
}
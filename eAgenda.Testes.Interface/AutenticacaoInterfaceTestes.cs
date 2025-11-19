using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Edge;

namespace eAgenda.Testes.Interface;

[TestClass]
[TestCategory("Testes de Interface de Autenticação")]
public sealed class AutenticacaoInterfaceTestes
{
    private static WebDriver? webDriver;
    private string enderecoBase = "https://localhost:9001";

    [AssemblyCleanup]
    public static void LimparAmbiente()
    {
        if (webDriver is null) return;

        webDriver.Quit();
        webDriver.Dispose();
    }

    [TestMethod]
    public void Deve_Registrar_Usuario_Corretamente()
    {
        webDriver = new EdgeDriver();

        webDriver.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

        webDriver
            .FindElement(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("teste@gmail.com");

        webDriver
            .FindElement(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("Teste@123");

        webDriver
            .FindElement(By.CssSelector("input[data-se=inputConfirmarSenha]"))
            .SendKeys("Teste@123");

        new Actions(webDriver)
                .ScrollToElement(webDriver
            .FindElement(By.CssSelector("button[data-se=btnConfirmar]")))
                .Perform();
        webDriver
            .FindElement(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        Assert.IsTrue(webDriver.PageSource.Contains("Página Inicial"));
    }

    [TestMethod]
    public void Deve_Autenticar_Usuario_Corretamente()
    {
        webDriver = new EdgeDriver();

        webDriver.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "login"));

        webDriver
           .FindElement(By.CssSelector("input[data-se=inputEmail]"))
           .SendKeys("teste@gmail.com");

        webDriver
            .FindElement(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("Teste@123");

        webDriver
            .FindElement(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        Assert.IsTrue(webDriver.PageSource.Contains("teste@gmail.com"));
    }
}
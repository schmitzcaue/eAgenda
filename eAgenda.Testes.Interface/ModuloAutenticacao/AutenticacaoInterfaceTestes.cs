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
        // Arranjo
        NavegarPara("/autenticacao/registro");

        // Ação
        EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("teste@gmail.com");

        EsperarPorElemento(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("SenhaSuperForteTeste@5912");

        EsperarPorElemento(By.CssSelector("input[data-se=inputConfirmarSenha]"))
            .SendKeys("SenhaSuperForteTeste@5912");

        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]"))
           .Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Página Inicial"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("teste@gmail.com"));
    }

        [TestMethod]
    public void Deve_Autenticar_Usuario_Corretamente()
    {
        // Arranjo
        NavegarPara("/autenticacao/registro");

        EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("teste@gmail.com");

        EsperarPorElemento(By.CssSelector("input[data-se=inputSenha]"))
           .SendKeys("SenhaSuperForteTeste@5912");


        EsperarPorElemento(By.CssSelector("input[data-se=inputConfirmarSenha]"))
            .SendKeys("SenhaSuperForteTeste@5912");


        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]"))

            .Click();

        webDriverWait?
           .Until(d => d.Title.Contains("Página Inicial"));

        NavegarPara("/autenticacao/login");

        // Ação
        EsperarPorElemento(By.CssSelector("input[data-se=inputEmail]"))
            .SendKeys("teste@gmail.com");

        EsperarPorElemento(By.CssSelector("input[data-se=inputSenha]"))
            .SendKeys("SenhaSuperForteTeste@5912");

        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]"))
            .Click();

        // Asserção
        webDriverWait?
           .Until(d => d.Title.Contains("Página Inicial"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("teste@gmail.com"));
    }
}
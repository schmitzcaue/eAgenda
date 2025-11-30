using eAgenda.Testes.Interface.Compartilhado;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace eAgenda.Testes.Interface.ModuloCompromisso;

[TestClass]
[TestCategory("Testes de Interface de Compromisso")]
public class CompromissoInterfaceTestes : TestFixture
{
    [TestMethod]
    public void Deve_CadastrarCompromisso_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "compromissos", "cadastrar"));

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Reunião de Trabalho");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/12/2025");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("09:00");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("10:00");

        var inputTipo = webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

        var selectInputTipo = new SelectElement(inputTipo!);
        selectInputTipo.SelectByText("Presencial");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputLocal]"))).SendKeys("MidiLages");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Compromissos"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("Reunião de Trabalho"));
    }

    [TestMethod]
    public void Deve_CadastrarCompromisso_ComContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarContato();

        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "compromissos", "cadastrar"));

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Reunião de Trabalho");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/12/2025");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("09:00");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("10:00");

        var inputTipo = webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

        var selectInputTipo = new SelectElement(inputTipo!);
        selectInputTipo.SelectByText("Presencial");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputLocal]"))).SendKeys("MidiLages");

        var inputContatoId = webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("select[data-se=inputContatoId]")));

        var selectInputContatoId = new SelectElement(inputContatoId!);
        selectInputContatoId.SelectByText("Oscar Lima");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Compromissos"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("Reunião de Trabalho"));
    }

    [TestMethod]
    public void Deve_EditarCompromisso_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarCompromisso();

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("a[data-se=btnEditar]")))
            .Click();

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys(" Editada");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Compromissos"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("Reunião de Trabalho Editada"));
    }

    [TestMethod]
    public void Deve_ExcluirCompromisso_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarCompromisso();

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("a[data-se=btnExcluir]")))
            .Click();

        // Ação
        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();

        // Asserção
        webDriverWait?
            .Until(d => d.Title.Contains("Visualização de Compromissos"));

        webDriverWait?
            .Until(d => !d.PageSource.Contains("Reunião de Trabalho"));
    }

    private void CadastrarCompromisso()
    {
        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "compromissos", "cadastrar"));

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputAssunto]"))).SendKeys("Reunião de Trabalho");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputData]"))).SendKeys("22/12/2025");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraInicio]"))).SendKeys("09:00");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputHoraTermino]"))).SendKeys("10:00");

        var inputTipo = webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("select[data-se=inputTipo]")));

        var selectInputTipo = new SelectElement(inputTipo!);
        selectInputTipo.SelectByText("Presencial");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputLocal]"))).SendKeys("MidiLages");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]"))).Click();
    }

    private void CadastrarContato()
    {
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
    }
}
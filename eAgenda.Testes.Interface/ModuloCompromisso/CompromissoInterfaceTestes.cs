using eAgenda.Testes.Interface.Compartilhado;
using eAgenda.Testes.Interface.ModuloContato;
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

        // Ação
        CadastrarCompromissoPadrao();

        // Asserção
        webDriverWait!.Until(d => d.Title.Contains("Visualização de Compromissos"));
        webDriverWait!.Until(d => d.PageSource.Contains("Reunião de Trabalho"));
    }

    [TestMethod]
    public void Deve_CadastrarCompromisso_ComContato_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        ContatoInterfaceTestes.CadastrarContatoPadrao();


        webDriverWait!.Until(d => d.Title.Contains("Visualização de Contatos"));
        webDriverWait!.Until(d => d.PageSource.Contains("Oscar Lima"));

        NavegarPara("/compromissos/cadastrar");

        // Ação
        PreencherCamposBasicosDeCompromisso();

        // Seleciona o contato
        var selectContato = new SelectElement(
            EsperarPorElemento(By.CssSelector("select[data-se=inputContatoId]"))
        );
        selectContato.SelectByText("Oscar Lima");

        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]")).Click();

        // Asserção
        webDriverWait!.Until(d => d.Title.Contains("Visualização de Compromissos"));
        webDriverWait!.Until(d => d.PageSource.Contains("Reunião de Trabalho"));
    }

    [TestMethod]
    public void Deve_EditarCompromisso_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarCompromissoPadrao();

        EsperarPorElemento(By.CssSelector("a[data-se=btnEditar]")).Click();

        // Ação
        EsperarPorElemento(By.CssSelector("input[data-se=inputAssunto]"))
           .SendKeys(" Editada");

        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]")).Click();

        // Asserção
        webDriverWait!.Until(d => d.Title.Contains("Visualização de Compromissos"));
        webDriverWait!.Until(d => d.PageSource.Contains("Reunião de Trabalho Editada"));
    }

    [TestMethod]
    public void Deve_ExcluirCompromisso_Corretamente()
    {
        // Arranjo
        RegistrarEAutenticarUsuario();

        CadastrarCompromissoPadrao();

        EsperarPorElemento(By.CssSelector("a[data-se=btnExcluir]")).Click();

        // Ação
        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]")).Click();

        // Asserção
        webDriverWait!.Until(d => d.Title.Contains("Visualização de Compromissos"));
        webDriverWait!.Until(d => !d.PageSource.Contains("Reunião de Trabalho"));
    }

    public static void CadastrarCompromissoPadrao()
    {
        NavegarPara("/compromissos/cadastrar");

        PreencherCamposBasicosDeCompromisso();

        EsperarPorElemento(By.CssSelector("button[data-se=btnConfirmar]")).Click();
    }

    public static void PreencherCamposBasicosDeCompromisso()
    {
        EsperarPorElemento(By.CssSelector("input[data-se=inputAssunto]"))
           .SendKeys("Reunião de Trabalho");

        EsperarPorElemento(By.CssSelector("input[data-se=inputData]"))
            .SendKeys("22/12/2025");

        EsperarPorElemento(By.CssSelector("input[data-se=inputHoraInicio]"))
            .SendKeys("09:00");

        EsperarPorElemento(By.CssSelector("input[data-se=inputHoraTermino]"))
            .SendKeys("10:00");

        var selectTipo = new SelectElement(
            EsperarPorElemento(By.CssSelector("select[data-se=inputTipo]"))
        );

        selectTipo.SelectByText("Presencial");


        EsperarPorElemento(By.CssSelector("input[data-se=inputLocal]"))
            .SendKeys("MidiLages");
    }
}
using eAgenda.Infraestrutura.Orm;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace eAgenda.Testes.Interface.Compartilhado;

[TestClass]
public abstract class TestFixture
{
    protected static WebDriver? webDriver;
    protected static WebDriverWait? webDriverWait;
    protected static AppDbContext? dbContext;
    protected static string enderecoBase = "https://localhost:9001";

    [AssemblyInitialize]
    public static void ConfigurarTestFixture(TestContext testContext)
    {
        dbContext = AppDbContextFactory.CriarDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=eAgendaBackendTestDb;Integrated Security=True");

        webDriver = new ChromeDriver();
    }

    [AssemblyCleanup]
    public static void LimparAmbiente()
    {
        if (webDriver is null || dbContext is null) return;

        webDriver.Quit();
        webDriver.Dispose();

        dbContext.Database.EnsureDeleted();
    }

    [TestInitialize]
    public void InicializarTeste()
    {
        if (dbContext is null || webDriver is null) return;

        dbContext.Database.EnsureCreated();

        dbContext.Tarefas.RemoveRange(dbContext.Tarefas);
        dbContext.Despesas.RemoveRange(dbContext.Despesas);
        dbContext.Categorias.RemoveRange(dbContext.Categorias);
        dbContext.Compromissos.RemoveRange(dbContext.Compromissos);
        dbContext.Contatos.RemoveRange(dbContext.Contatos);

        // Tabelas do ASP.NET Identity
        dbContext.UserClaims.RemoveRange(dbContext.UserClaims);
        dbContext.UserTokens.RemoveRange(dbContext.UserTokens);
        dbContext.UserLogins.RemoveRange(dbContext.UserLogins);
        dbContext.UserRoles.RemoveRange(dbContext.UserRoles);
        dbContext.Users.RemoveRange(dbContext.Users);

        dbContext.SaveChanges();

        webDriver.Manage().Cookies.DeleteAllCookies();


        webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
    }
    protected void RegistrarEAutenticarUsuario()
    {
        webDriver?.Navigate().GoToUrl(Path.Combine(enderecoBase, "autenticacao", "registro"));

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputEmail]")))
            .SendKeys("teste@gmail.com");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputSenha]")))
            .SendKeys("SenhaSuperForteTeste@5912");

        webDriverWait?
            .Until(d => d.FindElement(By.CssSelector("input[data-se=inputConfirmarSenha]")))
            .SendKeys("SenhaSuperForteTeste@5912");

        webDriverWait?
           .Until(d => d.FindElement(By.CssSelector("button[data-se=btnConfirmar]")))
           .Click();

        webDriverWait?
            .Until(d => d.PageSource.Contains("Página Inicial"));

        webDriverWait?
            .Until(d => d.PageSource.Contains("teste@gmail.com"));
    }
}
using eAgenda.Dominio.ModuloCompromisso;
using eAgenda.Dominio.ModuloContato;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eAgenda.WebApp.Controllers;

[Route("compromissos")]
public class CompromissoController : Controller
{
    private readonly IRepositorioCompromisso repositorioCompromisso;
    private readonly IRepositorioContato repositorioContato;

    public CompromissoController(
        IRepositorioCompromisso repositorioCompromisso,
        IRepositorioContato repositorioContato
    )
    {
        this.repositorioCompromisso = repositorioCompromisso;
        this.repositorioContato = repositorioContato;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = repositorioCompromisso.SelecionarRegistros();

        var visualizarVM = new VisualizarCompromissosViewModel(registros);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var contatosDisponiveis = repositorioContato.SelecionarRegistros();

        var cadastrarVM = new CadastrarCompromissoViewModel(contatosDisponiveis);

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarCompromissoViewModel cadastrarVM)
    {
        var contatosDisponiveis = repositorioContato.SelecionarRegistros();

        if (!ModelState.IsValid)
        {
            foreach (var cd in contatosDisponiveis)
            {
                var selecionarVM = new SelectListItem(cd.Nome, cd.Id.ToString());

                cadastrarVM.ContatosDisponiveis?.Add(selecionarVM);
            }

            return View(cadastrarVM);
        }

        var contatoSelecionado = contatosDisponiveis.Find(x => x.Id.Equals(cadastrarVM.ContatoId));

        var compromisso = new Compromisso(
            cadastrarVM.Assunto,
            cadastrarVM.Data,
            cadastrarVM.HoraInicio,
            cadastrarVM.HoraTermino,
            cadastrarVM.Tipo,
            cadastrarVM.Local,
            cadastrarVM.Link,
            contatoSelecionado
        );

        repositorioCompromisso.CadastrarRegistro(compromisso);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var contatosDisponiveis = repositorioContato.SelecionarRegistros();

        var registroSelecionado = repositorioCompromisso.SelecionarRegistroPorId(id);

        if (registroSelecionado is null)
            return RedirectToAction(nameof(Index));

        var editarVM = new EditarCompromissoViewModel(
            id,
            registroSelecionado.Assunto,
            registroSelecionado.Data,
            registroSelecionado.HoraInicio,
            registroSelecionado.HoraTermino,
            registroSelecionado.Tipo,
            registroSelecionado.Local,
            registroSelecionado.Link,
            registroSelecionado.Contato?.Id,
            contatosDisponiveis
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(Guid id, EditarCompromissoViewModel editarVM)
    {
        var contatosDisponiveis = repositorioContato.SelecionarRegistros();

        if (!ModelState.IsValid)
        {
            foreach (var cd in contatosDisponiveis)
            {
                var selecionarVM = new SelectListItem(cd.Nome, cd.Id.ToString());

                editarVM.ContatosDisponiveis?.Add(selecionarVM);
            }

            return View(editarVM);
        }

        var contatoSelecionado = contatosDisponiveis.Find(x => x.Id.Equals(editarVM.ContatoId));

        var compromissoEditado = new Compromisso(
            editarVM.Assunto,
            editarVM.Data,
            editarVM.HoraInicio,
            editarVM.HoraTermino,
            editarVM.Tipo,
            editarVM.Local,
            editarVM.Link,
            contatoSelecionado
        );

        repositorioCompromisso.EditarRegistro(id, compromissoEditado);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioCompromisso.SelecionarRegistroPorId(id);

        if (registroSelecionado is null)
            return RedirectToAction(nameof(Index));

        var excluirVM = new ExcluirCompromissoViewModel(registroSelecionado.Id, registroSelecionado.Assunto);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        var registroSelecionado = repositorioCompromisso.SelecionarRegistroPorId(id);

        if (registroSelecionado is null)
            return RedirectToAction(nameof(Index));

        repositorioCompromisso.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }
}
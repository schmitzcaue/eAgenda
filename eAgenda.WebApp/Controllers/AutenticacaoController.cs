using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eAgenda.WebApp.Controllers;

[Route("autenticacao")]
public class AutenticacaoController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : Controller
{
    [HttpGet("registro")]
    public IActionResult Registro()
    {
        var registroVm = new RegistroViewModel();

        return View(registroVm);
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registro(RegistroViewModel registroVm)
    {
        Usuario usuario = new Usuario
        {
            UserName = registroVm.Email,
            Email = registroVm.Email,
        };

        IdentityResult? usuarioResult = await userManager.CreateAsync(usuario, registroVm.ConfirmarSenha);

        if (!usuarioResult.Succeeded)
        {
            var erros = usuarioResult.Errors.Select(err =>
            {
                return err.Code switch
                {
                    "DuplicateUserName" => "Já existe um usuário com esse nome.",
                    "DuplicateEmail" => "Já existe um usuário com esse e-mail.",
                    "PasswordTooShort" => "A senha é muito curta.",
                    "PasswordRequiresNonAlphanumeric" => "A senha deve conter pelo menos um caractere especial.",
                    "PasswordRequiresDigit" => "A senha deve conter pelo menos um número.",
                    "PasswordRequiresUpper" => "A senha deve conter pelo menos uma letra maiúscula.",
                    "PasswordRequiresLower" => "A senha deve conter pelo menos uma letra minúscula.",
                    _ => err.Description
                };
            }).ToList();

            return View(registroVm);
        }

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = null)
    {
        var loginvM = new LoginViewModel();

        ViewData["ReturnUrl"] = returnUrl;

        return View(loginvM);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel loginVm, string? returnUrl = null)
    {
        Microsoft.AspNetCore.Identity.SignInResult resultadoLogin = await signInManager.PasswordSignInAsync(
            loginVm.Email,
            loginVm.Senha,
            isPersistent: true,
            lockoutOnFailure: false
        );

        if (!resultadoLogin.Succeeded)
            return View(loginVm);

        if (Url.IsLocalUrl(returnUrl))
            return LocalRedirect(returnUrl);

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction(nameof(Login));
    }
}
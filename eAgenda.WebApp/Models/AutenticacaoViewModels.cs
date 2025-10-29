using System.ComponentModel.DataAnnotations;

namespace eAgenda.WebApp.Models;

public class RegistroViewModel
{
    [Required(ErrorMessage = "O campo \"Email\" é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" precisa ser um endereço de email válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"Senha\" é obrigatório.")]
    public string Senha { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"Confirmação da Senha\" é obrigatório.")]
    [Compare(nameof(Senha), ErrorMessage = "O campo \"Confirmação da Senha\" não é igual à senha.")]
    //Compare com o campo Senha
    public string ConfirmarSenha { get; set; } = string.Empty;
}

public class LoginViewModel
{
    [Required(ErrorMessage = "O campo \"Email\" é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo \"Email\" precisa ser um endereço de email válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"Senha\" é obrigatório.")]
    public string Senha { get; set; } = string.Empty;
}
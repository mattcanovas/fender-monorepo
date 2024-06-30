using System.ComponentModel;

namespace Fender.App.Model;

public class User
{
    [DisplayName("Identificador de registro")]
    public int Id { get; set; }
    [DisplayName("Nome")]
    public string? FirstName { get; set; }
    [DisplayName("Sobrenome")]
    public string? LastName { get; set; }
    [DisplayName("Usuário")]
    public string? Username { get; set; }
    [DisplayName("Senha")]
    public string? Password { get; set; }
}
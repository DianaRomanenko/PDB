
using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class UserModel
{
    [Key]
    public string Login { get; set; }
    public string HashedPassword { get; set; }
    public string Role { get; set; }

    public UserModel(string login, string hashedPassword, string role)
    {
        Login = login;
        HashedPassword = hashedPassword;
        Role = role;
    }
}
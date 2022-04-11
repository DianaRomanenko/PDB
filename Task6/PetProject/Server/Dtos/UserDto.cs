using Server.Models;

namespace Server.Dtos;

public class UserDto
{
    public string Login { get; private set; }
    public string Role { get; private set; }

    public UserDto(UserModel userModel)
    {
        Login = userModel.Login;
        Role = userModel.Role;
    }
}
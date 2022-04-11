using Server.Dtos;
using Server.Services;

namespace Server.Controllers;

public static class AuthController
{
    private static void GetAuthData(out string login, out string password)
    {
        Console.Write("Введите логин: ");
        login = Console.ReadLine()!;
        
        Console.Write("Введите пароль: ");
        password = Console.ReadLine()!;
    }
    
    public static void Register(ref UserDto? user)
    {
        Console.Clear();

        GetAuthData(out var login, out var password);
        user = UserService.Register(login, password);
    }
    
    public static void Login(ref UserDto? user)
    {
        Console.Clear();

        GetAuthData(out var login, out var password);
        user = UserService.Login(login, password);
    }

    public static void Logout(ref UserDto? user)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Вы уверены, что хотите выйти [Y/n]");
            var option = Console.ReadKey().KeyChar;
            switch (option)
            {
                case 'y':
                    user = UserService.Logout();
                    return;
                case 'n':
                    return;
            }
        }
    }
}
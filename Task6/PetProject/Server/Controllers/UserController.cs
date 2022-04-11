using Server.Dtos;
using Server.Services;

namespace Server.Controllers;

public class UserController
{
    public static void ShowUsers(ref UserDto? user)
    {
        Console.Clear();
        
        var users = UserService.GetAllUsers().ToList();
        users.ForEach(userDto => Console.WriteLine($"{userDto?.Login} - {userDto?.Role}"));
        
        Console.WriteLine("Для продолжения нажмите любую кнопку...");
        Console.ReadKey();
    }

    public static void ShowUserByLogin(ref UserDto? user)
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Введите логин для поиска: ");
            var login = Console.ReadLine()!;
            var foundUser = UserService.GetUserByLogin(login);

            Console.WriteLine(foundUser == null
                ? "Такого пользователя не существует"
                : $"{foundUser.Login} - {foundUser.Role}");

            Console.WriteLine("r - поиск по другому логину");
            var option = Console.ReadKey().KeyChar;
            
            if (option != 'r') return;
        }
    }
    
    public static void DeleteUserByLogin(ref UserDto? user)
    {
        Console.Clear();

        Console.Write("Введите логин для удаления: ");
        var login = Console.ReadLine()!;

        while (true)
        {
            Console.WriteLine($"Вы уверены, что хотите удалить {login} [Y/n]");
            var confirm = Console.ReadKey().KeyChar;
            if (confirm == 'n') return;
            if (confirm == 'y') break;
        }

        var success = UserService.DeleteUser(login);

        Console.WriteLine(success
            ? "Такого пользователя не существует"
            : $"Пользователь {login} удален");

        Console.WriteLine("Для продолжения нажмите любую кнопку...");
    }
    
    public static void ChangeUserRoleByLogin(ref UserDto? user)
    {
        Console.Clear();

        Console.Write("Введите логин для выдачи админки: ");
        var login = Console.ReadLine()!;

        var success = UserService.ChangeUserRole(login);

        Console.WriteLine(success
            ? "Такого пользователя не существует"
            : $"Пользователь {login} стал администратором");

        Console.WriteLine("Для продолжения нажмите любую кнопку...");
    }
}
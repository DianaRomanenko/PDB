using Client.Routes;
using Server.Dtos;

namespace Client.Views;

public static class UserView
{
    private static UserDto? _user;

    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            
            var currentRoutes = UserRoutes.GetActualRoutes(_user);
            var index = 1;
            
            if (_user != null) Console.WriteLine($"{_user.Login} - {_user.Role}");
            
            currentRoutes.ForEach(route => Console.WriteLine($"{index++} - {route.Path}"));
            Console.WriteLine("q - Выход из программы");
            
            var option = Console.ReadKey().KeyChar;
            if (option == 'q') return;

            var actionIndex = option - '1';
            if (actionIndex >= currentRoutes.Count || actionIndex < 0) continue;
            
            var action = currentRoutes[actionIndex].Action;
            action(ref _user);
        }
    }
}
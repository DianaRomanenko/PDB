using System.Security.Cryptography;
using System.Text;
using Server.Contexts;
using Server.Dtos;
using Server.Models;

namespace Server.Services;

public static class UserService
{
    private static readonly int _saltBytes = 16;
    private static readonly int _hashBytes = 32;
    private static readonly UserContext _context = new ();
    
    private static string GetHash(string password)
    {
        using var sha256 = SHA256.Create();
        
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hash = BitConverter.ToString(hashedBytes).Replace("-", "");
        
        return hash;
    }

    public static UserDto Register(string login, string password, string role = "REGULAR")
    {
        var candidate = _context.Users.Find(login);
        if (candidate != null) throw new Exception("Такой пользователь уже существует");
        
        var hashedPassword = GetHash(password);
        var user = new UserModel(login, hashedPassword, role);
        _context.Users.Add(user);
        _context.SaveChanges();

        return new UserDto(user);
    }

    public static UserDto Login(string login, string password)
    {
        var candidate = _context.Users.Find(login);
        if (candidate == null) throw new Exception("Такого пользователя не существует");

        var hashedPassword = GetHash(password);
        if (candidate.HashedPassword != hashedPassword) throw new Exception("Неверный логин или пароль");

        return new UserDto(candidate);
    }

    public static UserDto? Logout()
    {
        return null;
    }

    public static IEnumerable<UserDto?> GetAllUsers()
    {
        var users = _context.Users;
        var usersDto = users.Select(user => new UserDto(user));
        return usersDto;
    }

    public static UserDto? GetUserByLogin(string login)
    {
        try
        {
            var user = _context.Users.First(user => user.Login == login);

            var userDto = new UserDto(user);
            return userDto;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static bool ChangeUserRole(string login)
    {
        try
        {
            var candidate = _context.Users.First(user => user.Login == login);
            candidate.Role = "ADMIN";
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public static bool DeleteUser(string login)
    {
        try
        {
            var candidate = _context.Users.First(user => user.Login == login);
            _context.Users.Remove(candidate);
            _context.SaveChanges();
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
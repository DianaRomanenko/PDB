using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Contexts;

public class UserContext : DbContext
{
    private const string DB_NAME = "MySuperDuperSQLiteBD";
    private readonly string _path;
    public DbSet<UserModel> Users { get; set; }

    public UserContext()
    {
        try
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.Parent!.FullName;
            _path = Path.Join(projectDirectory, DB_NAME);
        }
        catch (Exception e)
        {
            Console.WriteLine("What's gone wrong!");
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data Source={_path}");
}
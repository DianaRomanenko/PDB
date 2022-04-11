namespace Broker.Subscriber;

public class Student : ISubscriber
{
    
    private readonly string _login;
    public string Login => $"Student {_login}";

    public Student(string login)
    {
        _login = login;
    }

    public override string ToString()
    {
        return Login;
    }

    public void Update(string message)
    {
        Console.WriteLine(Login + $" received message \"{message}\"");
    }
}
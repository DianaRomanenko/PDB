namespace Broker.Subscriber;

public class Professor : ISubscriber
{
    private readonly string _login;
    public string Login => $"Professor {_login}";

    public Professor(string login)
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
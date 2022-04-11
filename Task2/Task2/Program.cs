// See https://aka.ms/new-console-template for more information

using Broker.Publisher;
using Broker.Subscriber;

namespace Solution;

public class Program
{
    public static void Main(string[] args)
    {
        List<ISubscriber> currSubscribers = new List<ISubscriber>();
        IPublisher countdown = new CountDown();
        string output = "Application Menu: \n" +
                        "1 - Add subscriber \"Student\" \n" +
                        "2 - Add subscriber \"Professor\" \n" +
                        "3 - Delete subscriber \n" +
                        "4 - Notify subscribers \n" +
                        "0 - Exit programm";
        char input;
        string login, subsList, message;
        ISubscriber currSub;
        double timeout;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(output);
            input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Enter Student login: ");
                    login = Console.ReadLine()!;
                    currSub = new Student(login);
                    countdown.AddSubscriber(currSub);
                    currSubscribers.Add(currSub);
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Enter Professor login: ");
                    login = Console.ReadLine()!;
                    currSub = new Professor(login);
                    countdown.AddSubscriber(currSub);
                    currSubscribers.Add(currSub);
                    break;
                case '3':
                    Console.Clear();
                    if (currSubscribers.Count == 0)
                    {
                        break;
                    }
                    subsList = string.Join("\n", currSubscribers.Select((sub, index) => $"{index + 1} - {sub}"));
                    Console.WriteLine("Choose the number:");
                    Console.WriteLine(subsList);
                    input = Console.ReadKey().KeyChar;
                    currSub = currSubscribers[input - '1'];
                    countdown.DeleteSubscriber(currSub);
                    currSubscribers.Remove(currSub);
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Enter the message to send");
                    message = Console.ReadLine()!;
                    Console.WriteLine("Enter the timeout (in seconds)");
                    while (!double.TryParse(Console.ReadLine()!.Replace('.', ','), out timeout)) { }
                    countdown.NotifySubscribers(message, timeout);
                    Console.WriteLine("To continue press something...");
                    Console.ReadKey();
                    break;
                case '0':
                    return;
            }
        }
    }
}
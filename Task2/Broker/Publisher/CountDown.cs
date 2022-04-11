using System.Linq; 
using Broker.Subscriber;

namespace Broker.Publisher;

public class CountDown : IPublisher
{
    //лист подписчиков
    private List<ISubscriber> _subscribers;
    public List<ISubscriber> Subscribers => _subscribers;
    
    //конструкторы
    public CountDown()
    {
        _subscribers = new ();
    }
    public CountDown(List<ISubscriber> subscribers)
    {
        _subscribers = new (subscribers);
    }
    //реализация добавления
    public void AddSubscriber(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
    
    //реализация удаления
    public void DeleteSubscriber(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    //реализация оповещения ВСЕХ текущих подписчиков (установить начальное значение задержки 0)
    public void NotifySubscribers(string message, double timeout = 0)
    {
        Thread.Sleep((int)(timeout * 1000));
        _subscribers.ForEach(subscriber => subscriber.Update(message));
    }
}
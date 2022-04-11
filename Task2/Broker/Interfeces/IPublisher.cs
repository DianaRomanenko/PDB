using Broker.Subscriber;

namespace Broker.Publisher;

public interface IPublisher
{
    void AddSubscriber(ISubscriber subscriber);
    void DeleteSubscriber(ISubscriber subscriber);
    void NotifySubscribers(string message, double timeout);
}
namespace Broker.Subscriber;

public interface ISubscriber
{
    string ToString();
    void Update(string state); 
}
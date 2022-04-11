using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using Broker.Publisher;
using Broker.Subscriber;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Test.Utils;

namespace UnitTest;

public class Test
{
    private ConsoleReader _consolereader;
    private List<ISubscriber> _subs;
    
    [SetUp]
    public void Setup()
    {
        _consolereader = new ConsoleReader();
        _subs = new List<ISubscriber>
        {
            new Student("Bob"), 
            new Student("Tom"), 
            new Professor("Prof")
        };
    }

    [Test]
    public void PublisherConstructor()
    {
        var publisher = new CountDown(_subs);
        Assert.AreEqual(_subs.Count, publisher.Subscribers.Count);
    }
    
    [Test]
    public void TestAddSubscriber()
    {
        var publisher = new CountDown();
        for (int i = 0; i < _subs.Count; i++)
        {
            publisher.AddSubscriber(_subs[i]);
            Assert.AreEqual(i+1, publisher.Subscribers.Count);
        }
    }
    
    [Test]
    public void TestRemoveSubscriber()
    {
        var publisher = new CountDown(_subs);
        
        for (int i = _subs.Count - 1; i >= 0; i--)
        {
            publisher.DeleteSubscriber(_subs[i]);
            Assert.AreEqual(i, publisher.Subscribers.Count);
        }
    }

    [Test]
    public void TestNotifySubscribers()
    {
        var publisher = new CountDown(_subs);
        string message = new string("Hi!");
        string expectedOutput = string.Join("\r\n", _subs.Select(sub => $"{sub} received message \"{message}\""));
        expectedOutput += "\r\n";
        publisher.NotifySubscribers(message);
        string output = _consolereader.GetOutput();
        Assert.AreEqual(expectedOutput, output);
    }
    
}
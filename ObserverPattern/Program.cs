using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("Lowder With Crowder");
            var sub1 = new Subscriber("Jordan Peterson");
            var sub2 = new Subscriber("Sam Harris");

            sub1.Subscribe(channel);
            sub2.Subscribe(channel);

            channel.Upload("God Is Dead!");

            sub2.UnSubscribe();

            channel.Upload("The God Delusion");
        }
    }

    public class Channel
    {
        private List<Subscriber> Subscribers { get; set; }
        public string channelName { get; private set; }
        
        public Channel(string channelName)
        {
            this.channelName = channelName;
            Subscribers = new List<Subscriber>();
        }

        private void NotifySubscribers(string videoName)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Update(videoName);
            }
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            
            Subscribers.Add(subscriber);
            Console.WriteLine($"[NOTIFICATION IN CHANNEL CLASS] => {subscriber.Name} has subscribed to {channelName}");
        }

        public void RemoveSubscriber(Subscriber subscriber)
        {
            Subscribers.Remove(subscriber);
            Console.WriteLine($"[NOTIFICATION IN CHANNEL CLASS] => {subscriber.Name} has unsubscribed from {channelName}");

        }

        public void Upload(string videoName)
        {
            NotifySubscribers(videoName);
        }
    }

    public class Subscriber
    {
        public string Name { get; private set; }
        public Channel Channel { get; set; }

        public Subscriber(string Name)
        {
            this.Name = Name;
        }
        public void Subscribe(Channel channel)
        {
            Channel = channel;
            Channel.AddSubscriber(this);

        }

        public void UnSubscribe()
        {
            Channel.RemoveSubscriber(this);
            Channel = null;
        }

        public void Update(string videoName)
        {
            Console.WriteLine($"[NOTIFICATION IN SUBSCRIBER CLASS] => Hey {Name} :: New Video Upload [{videoName}] from {Channel.channelName}");
        }
    }
}

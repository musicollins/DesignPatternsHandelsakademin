using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel1 = new Channel("Lowder With Crowder");
            Channel channel2 = new Channel("Kalle Med Jointen");
            Channel channel3 = new Channel("How Its Made");
            Subscriber sub1 = new Subscriber("Jordan Peterson");
            Subscriber sub2 = new Subscriber("Sam Harris");
            Subscriber sub3 = new Subscriber("Raffe");

            sub3.Subscribe(channel1);
            sub3.Subscribe(channel2);
            sub3.Subscribe(channel3);

            sub1.Subscribe(channel1);
            sub1.Subscribe(channel2);

            sub2.Subscribe(channel1);
            sub2.Subscribe(channel2);


            channel1.Upload("God Is Dead!");
            channel2.Upload("Making roaches from keef only");

            sub2.UnSubscribe(channel1);
            sub2.UnSubscribe(channel2);
            channel1.Upload("The God Delusion");
            channel2.Upload("Cross joint engineering");

            sub1.GetSubscriptions();
            sub2.GetSubscriptions();
            sub3.GetSubscriptions();
            sub3.UnSubscribe(channel1);
            sub3.UnSubscribe(channel2);
            channel3.Upload("Hot Dogs");
            channel3.Upload("Babies");
            channel3.Upload("Water");
            sub3.GetSubscriptions();
        }
    }

    public class Channel
    {
        private List<Subscriber> Subscribers { get; set; }
        private List<Video> Videos { get; set; }
        public string channelName { get; set; }

        public Channel(string channelName)
        {
            this.channelName = channelName;
            Subscribers = new List<Subscriber>();
            Videos = new List<Video>();
        }

        private void NotifySubscribers(string videoName, string url)
        {
            foreach (Subscriber subscriber in Subscribers)
            {
                subscriber.Update(videoName, channelName, url);
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
            Video video = new Video(this, videoName);
            Videos.Add(video);
            NotifySubscribers(videoName, video.Url);
        }
        public int VideosCount()
        {
            return Videos.Count;
        }
    }

    public class Video
    {
        private Channel Channel;
        public string Url;
        private string VideoName;

        public Video(Channel channel, string videoName)
        {
            Channel = channel;
            Url = SetUrl(videoName);
            VideoName = videoName;

        }
        private string SetUrl(string videoName)
        {
            return $"https://video.com/{Channel.channelName.Replace(" ", "")}/{Channel.VideosCount()}/";
        }
    }

    public class Subscriber
    {
        public string Name { get; private set; }

        private List<Channel> Subscriptions { get; set; }

        public Subscriber(string Name)
        {
            this.Name = Name;
            Subscriptions = new List<Channel>();
        }
        public void GetSubscriptions()
        {
            if (Subscriptions.Count>0)
            {
                string str = $"{Name} is subscribed to channels:\n";
                for (int i = 0; i < Subscriptions.Count; i++)
                {
                    str += $"{Subscriptions[i].channelName}\n";
                }
                Console.WriteLine(str);
            }
            
        }



        public void Subscribe(Channel channel)
        {
            channel.AddSubscriber(this);
            Subscriptions.Add(channel);

        }
        public void UnSubscribe(Channel channel)
        {
            channel.RemoveSubscriber(this);
            Subscriptions.Remove(channel);
        }

        public void Update(string videoName, string channelName, string url)
        {
            Console.WriteLine($"[NOTIFICATION IN SUBSCRIBER CLASS] => Hey {Name} :: New Video Upload [{videoName}] from {channelName} on {url}");
        }
    }
}

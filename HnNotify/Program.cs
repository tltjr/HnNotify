using System;
using System.Configuration;
using BusinessLogic;
using Notifications;

namespace HnNotify
{
    class Program
    {
        const int Interval = 5;
        private static INotificationReceiver _notificationReceiver;
        private static IStoryProvider _storyProvider;

        // potentially use autofac to configure the correct notify/story providers
        static void Main()
        {
            _notificationReceiver = new GrowlNotification();

            // extract configuration logic and validate
            var diffbottoken = ConfigurationManager.AppSettings["diffbottoken"];

            //var proxy = ConfigurationManager.AppSettings["proxy"];
            //var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            //_storyProvider = new DiffbotStoryProvider(proxy, port, diffbottoken) { NumberOfStories = 10 };
            _storyProvider = new DiffbotStoryProvider(diffbottoken) { NumberOfStories = 10 };
            CheckStories();
            var updateTime = DateTime.Now.AddMinutes(Interval);
            while(true)
            {
                if (DateTime.Now <= updateTime) continue;
                CheckStories();
                updateTime = DateTime.Now.AddMinutes(Interval);
            }
        }

        static void CheckStories()
        {
            var newStories = _storyProvider.GetNewStories();
            foreach (var story in newStories)
            {
                _notificationReceiver.Notify(story);
            }
        }
    }
}
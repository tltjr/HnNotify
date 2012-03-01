using System;
using System.Configuration;
using System.Linq;
using System.Net;
using DiffbotApi;
using Growl.Connector;

namespace HnNotify
{
    class Program
    {
        const string ApplicationName = "HnNotify";
        const string NotificationTypeName = "NewStory";
        static GrowlConnector _growl;
        static Diffbot _diffbot;
        static TopStories _currentStories;
        const int Interval = 5;
        const int NumberOfStories = 10;

        static void Main()
        {
            _growl = new GrowlConnector();
            var application = new Application(ApplicationName) {Icon = @"T:\ycombinator-logo.gif"};
            var newStory = new NotificationType(NotificationTypeName, "New Story");
            _growl.Register(application, new[] {newStory});
            var proxy = new WebProxy(ConfigurationManager.AppSettings["proxy"], int.Parse(ConfigurationManager.AppSettings["port"]));
            _diffbot = new Diffbot(ConfigurationManager.AppSettings["diffbottoken"], proxy);
            //make initial check
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
            var frontpage = _diffbot.Frontpage(@"http://news.ycombinator.com/");
            var topFive = new TopStories(frontpage, NumberOfStories);
            if (topFive.Equals(_currentStories)) return;
            var newest = topFive.Difference(_currentStories).ToList();
            _currentStories = new TopStories(frontpage, NumberOfStories);
            foreach (var story in newest)
            {
                var notification = new Notification(ApplicationName, NotificationTypeName, "ID", story.Title, story.Link);
                var callback = new CallbackContext(story.Link);
                _growl.Notify(notification, callback);
            }
        }
    }
}
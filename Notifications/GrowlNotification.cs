using System.IO;
using BusinessLogic;
using Growl.Connector;

namespace Notifications
{
    public class GrowlNotification : INotificationReceiver
    {
        private const string ApplicationName = "HnNotify";
        private const string NotificationTypeName = "NewStory";
        private readonly GrowlConnector _growl;

        public GrowlNotification()
        {
            var icon = Path.Combine(Directory.GetCurrentDirectory(), @"img\ycombinator-logo.gif");
            var application = new Application(ApplicationName) {Icon = icon};
            var newStory = new NotificationType(NotificationTypeName, "New Story");
            _growl = new GrowlConnector();
            _growl.Register(application, new[] {newStory});
            
        }

        public void Notify(Story story)
        {
            var frontpageItem = story.Item;
            var notification = new Notification(ApplicationName, NotificationTypeName, "ID", frontpageItem.Title, frontpageItem.Link);
            var callback = new CallbackContext(frontpageItem.Link);
            _growl.Notify(notification, callback);
        }
    }

    public interface INotificationReceiver
    {
        void Notify(Story story);
    }
}

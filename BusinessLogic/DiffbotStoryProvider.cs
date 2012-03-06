using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DiffbotApi;
using Wintellect.PowerCollections;

namespace BusinessLogic
{
    public class DiffbotStoryProvider : IStoryProvider
    {
        private readonly Diffbot _diffbot;
        private readonly List<Story> _viewedStories = new List<Story>();

        public DiffbotStoryProvider(string proxy, int port, string diffbottoken)
        {
            var webproxy = new WebProxy(proxy, port);
            _diffbot = new Diffbot(diffbottoken, webproxy);
        }

        public DiffbotStoryProvider(string diffbottoken)
        {
            _diffbot = new Diffbot(diffbottoken);
        }

        public IEnumerable<Story> GetNewStories()
        {
            Frontpage frontpage;
            try
            {
                frontpage = _diffbot.Frontpage(@"http://news.ycombinator.com/");
            }
            catch(WebException)
            {
                return Enumerable.Empty<Story>();
            }
            var frontpageItems = frontpage.Items.Take(NumberOfStories);
            var stories = frontpageItems.Select(o => new Story(o)).ToList();
            var newStories = stories.Difference(_viewedStories).ToList();
            foreach(var story in newStories)
            {
                _viewedStories.Insert(0, story);
            }
            _viewedStories.AddRange(newStories);
            _viewedStories.Trim(100);
            return newStories;
        }

        private int? _numberOfStories;
        public int NumberOfStories
        {
            get { return _numberOfStories ?? 10; }
            set { _numberOfStories = value; }
        }
    }
}

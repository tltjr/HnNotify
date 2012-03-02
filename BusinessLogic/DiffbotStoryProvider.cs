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
        private readonly Set<Story> _viewedStories = new Set<Story>();

        public DiffbotStoryProvider(string proxy, int port, string diffbottoken)
        {
            var webproxy = new WebProxy(proxy, port);
            _diffbot = new Diffbot(diffbottoken, webproxy);
            //_diffbot = new Diffbot(diffbottoken);
        }

        public IEnumerable<Story> GetNewStories()
        {
            var frontpage = _diffbot.Frontpage(@"http://news.ycombinator.com/");
            var frontpageItems = frontpage.Items.Take(NumberOfStories);
            var topFive = new Set<Story>(frontpageItems.Select(o => new Story(o)));
            if (topFive.IsSubsetOf(_viewedStories)) return Enumerable.Empty<Story>();
            var newStories = topFive.Difference(_viewedStories).ToList();
            _viewedStories.AddMany(newStories);
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

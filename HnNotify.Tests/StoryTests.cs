using BusinessLogic;
using DiffbotApi;
using NUnit.Framework;
using Wintellect.PowerCollections;

namespace HnNotify.Tests
{
    [TestFixture]
    public class StoryTests
    {
        [Test]
        public void ContainsStory()
        {
            var set = new Set<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah" });
            set.Add(story);
            Assert.True(set.Contains(story));
        }

        [Test]
        public void ContainsStoryTwoAddsHaveDifferentTimes()
        {
            var set = new Set<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" });
            var story2 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" });
            set.Add(story);
            set.Add(story2);
            Assert.True(set.Contains(story));
            Assert.True(set.Contains(story2));
        }

        [Test]
        public void OrderedSetTest()
        {
            var set = new OrderedSet<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" });
            var story2 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" });
            set.Add(story);
            set.Add(story2);
            set.RemoveLast();
            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(story2, set[0]);
        }

        [Test]
        public void OrderedSetOrder()
        {
            var set = new OrderedSet<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" });
            var story2 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" });
            // reverse order
            set.Add(story2);
            set.Add(story);
            set.RemoveLast();
            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(story2, set[0]);
        }
    }
}

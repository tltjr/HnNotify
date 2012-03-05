using System.Collections.Generic;
using BusinessLogic;
using DiffbotApi;
using NUnit.Framework;

namespace HnNotify.Tests
{
    [TestFixture]
    public class ListStoryExtensionsTest
    {
        [Test]
        public void Trim()
        {
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" });
            var story2 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" });
            var story3 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" });
            var list = new List<Story> { story, story2, story3 };
            list.Trim(2);
            Assert.AreEqual(2, list.Count);
            Assert.Contains(story, list);
            Assert.Contains(story2, list);
        }
    }
}

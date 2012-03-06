using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic;
using DiffbotApi;
using NUnit.Framework;
using Wintellect.PowerCollections;

namespace HnNotify.Tests
{
    [TestFixture]
    public class OrderedSetExtensionsTests
    {
        [Test]
        public void Trim()
        {
            var set = new OrderedSet<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" }) { DisplayTime = DateTime.Now};
            var story2 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            set.Add(story);
            set.Add(story2);
            set.Trim(1);
            Assert.AreEqual(1, set.Count);
            Assert.AreEqual(story2, set[0]);
        }

        [Test]
        public void TrimTwo()
        {
            var set = new OrderedSet<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah" }) { DisplayTime = DateTime.Now};
            var story2 = new Story(new FrontpageItem { Title = "title2", Link = "blah" }) {DisplayTime = DateTime.MinValue};
            set.Add(story);
            set.Add(story2);
            set.Trim(2);
            Assert.AreEqual(2, set.Count);
        }

        [Test]
        public void TrimLarger()
        {
            var set = new OrderedSet<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" }) { DisplayTime = DateTime.Now};
            var story2 = new Story(new FrontpageItem { Title = "title2", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            var story3 = new Story(new FrontpageItem { Title = "title3", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            var story4 = new Story(new FrontpageItem { Title = "title4", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            var story5 = new Story(new FrontpageItem { Title = "title5", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            var story6 = new Story(new FrontpageItem { Title = "title6", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            var story7 = new Story(new FrontpageItem { Title = "title7", Link = "blah", Description = "diff but irrelevant" }) {DisplayTime = DateTime.MinValue};
            set.Add(story);
            set.Add(story2);
            set.Add(story3);
            set.Add(story4);
            set.Add(story5);
            set.Add(story6);
            set.Add(story7);
            set.Trim(3);
            Assert.AreEqual(3, set.Count);
        }
    }
}
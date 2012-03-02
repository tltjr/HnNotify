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
    }
}

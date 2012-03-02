﻿using BusinessLogic;
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
        public void ContainsStoryIrrelevantFieldsChanged()
        {
            var set = new Set<Story>();
            var story = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "shouldnt matter" });
            var story2 = new Story(new FrontpageItem { Title = "title", Link = "blah", Description = "diff but irrelevant" });
            set.Add(story);
            Assert.True(set.Contains(story2));
        }
    }
}
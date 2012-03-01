using System;
using System.Collections.Generic;
using System.Linq;
using DiffbotApi;

namespace HnNotify
{
    public class TopStories : IEquatable<TopStories>
    {
        private readonly IEnumerable<FrontpageItem> _stories;

        public TopStories(Frontpage frontpage, int num)
        {
            _stories = frontpage.Items.Take(num);
        }

        public IEnumerable<FrontpageItem> Difference(TopStories other)
        {
            return null == other ? _stories : _stories.Where(o => !other.Contains(o));
        }

        public bool Equals(TopStories other)
        {
            return null != other && _stories.All(other.Contains);
        }

        public bool Contains(FrontpageItem item)
        {
            return _stories.Contains(item);
        }
    }
}

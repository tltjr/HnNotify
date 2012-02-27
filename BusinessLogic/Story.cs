using System;
using DiffbotApi;

namespace BusinessLogic
{
    public class Story : IComparable<Story>
    {
        public FrontpageItem Item { get; set; }
        public DateTime DisplayTime { get; set; }

        public Story(FrontpageItem item)
        {
            Item = item;
        }

        public int CompareTo(Story other)
        {
            var fpi = other.Item;
            if (Item.Title.Equals(fpi.Title) 
                && Item.Link.Equals(fpi.Link)) return 0;
            return DisplayTime > other.DisplayTime ? 1 : -1;
        }

        public override bool Equals(object obj)
        {
            var story = (Story)obj;
            var fpi = story.Item;
            return Item.Title.Equals(fpi.Title) || Item.Link.Equals(fpi.Link);
        }

        public override int GetHashCode()
        {
            return Item.Title.GetHashCode() + Item.Link.GetHashCode();
        }
    }
}
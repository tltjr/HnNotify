using DiffbotApi;

namespace BusinessLogic
{
    public class Story
    {
        public FrontpageItem Item { get; set; }

        public Story(FrontpageItem item)
        {
            Item = item;
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
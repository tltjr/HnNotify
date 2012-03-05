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
            var story = obj as Story;
            if (story == null) return false;
            return Item.Title.Equals(story.Item.Title) || Item.Link.Equals(story.Item.Link);
        }
    }
}
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IStoryProvider
    {
        IEnumerable<Story> GetNewStories();
        int NumberOfStories { set; }
    }
}

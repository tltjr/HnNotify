using Wintellect.PowerCollections;

namespace BusinessLogic
{
    public static class OrderedSetExtensions
    {
        public static void Trim(this OrderedSet<Story> src, int count)
        {
            for(int i = count; i < src.Count; i++)
            {
                var item = src[i];
                src.Remove(item);
            }
        }
    }
}

using Wintellect.PowerCollections;

namespace BusinessLogic
{
    public static class OrderedSetExtensions
    {
        public static void Trim(this OrderedSet<Story> src, int count)
        {
            if(src.Count > 0) 
            {
                var numToDrop = src.Count - count;
                for (int i = 0; i < numToDrop; i++)
                {
                    src.RemoveLast();
                }
            }
        }
    }
}

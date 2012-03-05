using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public static class ListStoryExtensions
    {
        public static IEnumerable<Story> Difference(this List<Story> src, List<Story> other)
        {
            return src.Where(o => !other.Contains(o));
        }

        public static void Trim(this List<Story> src, int count)
        {
            var remove = src.Select((x, i) => new {Value = x, Index = i}).Where(it => it.Index >= count).Select(it => it.Value).ToList();
            src.RemoveAll(remove.Contains);
        }
    }
}
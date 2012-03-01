using System.Collections.Generic;
using System.Linq;
using DiffbotApi;

namespace HnNotify
{
    public static class EnumerableFrontpageExtensions
    {
        public static bool Contains(this IEnumerable<FrontpageItem> src, FrontpageItem item)
        {
            return src.Any(o => o.Title.Equals(item.Title) || o.Link.Equals(item.Link));
        }
    }
}
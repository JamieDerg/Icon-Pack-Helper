using System;
using System.Collections.Generic;
using System.Linq;

namespace Icon_Pack_Helper.CLasses.Drawable
{
    public class DrawableItem
    {
        public string drawable;

        public string tag;
        public string GroupTag;
        private static Random random = new Random();
        public static List<string> usedTags = new List<string>();
        public DrawableItem(string drawable, string groupTag)
        {
            this.drawable = drawable;

            GroupTag = groupTag;
            tag = generateTag(4);
            while (usedTags.Find(x => x == tag) != null)
            {
                tag = generateTag(4);
            }
            usedTags.Add(tag);

        }
        private string generateTag(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
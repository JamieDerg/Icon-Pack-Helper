using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Icon_Pack_Helper.CLasses.Drawable
{

    public class DrawableCategory
    {
        public string tag;
        public string name;
        private static Random random = new Random();
        public static List<string> usedTags = new List<string>();
        public List<DrawableItem> DrawableItems = new List<DrawableItem>();
        public DrawableCategory(string name)
        {
            this.name = name;
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
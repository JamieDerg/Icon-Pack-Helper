using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon_Pack_Helper.CLasses.Files.AppFilter
{
    public class AppFilterItem
    {
        public string name;
        public string packetName;
        public string acitivity;
        //public string componentAtt;
        public string drawable;
        public string tag;
        private static Random random = new Random();
        public static List<string> usedTags = new List<string>();
        public static int test = 0;

        public AppFilterItem(string name, string packetName, string acitivity, string drawable)
        {
            this.name = name;
            this.packetName = packetName;
            this.acitivity = acitivity;
            /* this.componentAtt = componentAtt;*/
            this.drawable = drawable;

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

        public string ComponentInfo()
        {
            return $"ComponentInfo{{{packetName}/{acitivity}}}";
        }

    }
}

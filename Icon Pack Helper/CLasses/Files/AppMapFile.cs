using Icon_Pack_Helper.CLasses.Files.AppFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Icon_Pack_Helper.CLasses.Files
{
    public class AppMapFile
    {
        public XmlDocument doc;
        private string path;
        public AppMapFile(string path)
        {
            this.path = path;
        }

        public void save(List<AppFilterItem> AppFilterItems)
        {
            doc = new XmlDocument();
            XmlNode xmlDecleration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement appmapNode = doc.CreateElement("appmap");
            XmlElement resourceNode = doc.CreateElement("resource");
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDecleration, root);
            doc.AppendChild(appmapNode);
            appmapNode.AppendChild(resourceNode);
            foreach (AppFilterItem item in AppFilterItems)
            {
                XmlComment name = doc.CreateComment(item.name);
                XmlElement itemNode = doc.CreateElement("item");

                itemNode.SetAttribute("class", item.acitivity);
                itemNode.SetAttribute("name", item.drawable);

                resourceNode.AppendChild(name);
                resourceNode.AppendChild(itemNode);
            }
            doc.Save(path);

        }
    }
}

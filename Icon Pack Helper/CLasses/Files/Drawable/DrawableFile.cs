using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Icon_Pack_Helper.CLasses.Drawable
{
    public class DrawableFile
    {
        private int version;
        private string[] path;
        private string ImagesPath;

        public ImageList images = new ImageList();
        public List<DrawableCategory> categories = new List<DrawableCategory>();
        public XmlDocument doc = new XmlDocument();
        public bool wasEdited = false;

        public DrawableFile(string[] path, string ImagesPath, int version = 1)
        {
            this.path = path;
            this.version = version;
            this.ImagesPath = ImagesPath;
        }

        public void save()
        {
            doc = new XmlDocument();
            XmlElement root = doc.DocumentElement;
            XmlNode xmlDecleration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement ResourceNode = doc.CreateElement("resources");
            XmlElement version = doc.CreateElement("version");

            version.InnerText = "1";

            
                
            doc.InsertBefore(xmlDecleration, root);
            doc.AppendChild(ResourceNode);
            ResourceNode.AppendChild(version);
            foreach(DrawableCategory  category in categories)
            {
                XmlElement categoryNode = doc.CreateElement("category");
                categoryNode.SetAttribute("title", category.name);
                ResourceNode.AppendChild(categoryNode);
                foreach(DrawableItem item in category.DrawableItems)
                {
                    XmlElement itemNode = doc.CreateElement("item");
                    itemNode.SetAttribute("drawable", item.drawable);
                    ResourceNode.AppendChild(itemNode);
                }
            }

            doc.Save(path[0]);
            doc.Save(path[1]);

        }

        public void load()
        {
            string[] files = Directory.GetFiles(ImagesPath, "*.png");
            images.ColorDepth = ColorDepth.Depth32Bit;
            images.ImageSize = new Size(64, 64);
            foreach (string file in files)
            {
                var image = Image.FromFile(file);
                images.Images.Add(Path.GetFileName(file).Replace(".png", ""), image);
            }
            XmlNodeList ResourceChildNodes;
            doc.Load(path[0]);
            try
            {
                ResourceChildNodes = doc.DocumentElement.SelectSingleNode("//resources").ChildNodes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                DialogResult res = MessageBox.Show(@"a Fatal Error has occured: " + e, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            for (int i = 0; i < ResourceChildNodes.Count; i++)
            {
                var currentNode = ResourceChildNodes[i];
                if (currentNode.Name == "category")
                {
                    DrawableCategory category = new DrawableCategory(currentNode.Attributes[0].Value);

                    while (i < ResourceChildNodes.Count - 1 && ResourceChildNodes[i + 1].Name != "category")
                    {
                        i++;
                        var currentItemNode = ResourceChildNodes[i];
                        category.DrawableItems.Add(new DrawableItem(currentItemNode.Attributes[0].Value, category.tag));

                    }

                    categories.Add(category);
                }
            }



        }
    }
}

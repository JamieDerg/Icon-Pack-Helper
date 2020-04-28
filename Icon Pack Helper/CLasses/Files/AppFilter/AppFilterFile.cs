using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Icon_Pack_Helper.CLasses.Files.AppFilter
{
    public class AppFilterFile
    {
        private int Version;
        private string[] path;
        public List<AppFilterItem> AppFilterItems = new List<AppFilterItem>();
        public XmlDocument doc = new XmlDocument();
        public bool wasEdited = false;
        public AppFilterFile(string[] path, int Version = 1)
        {
            this.path = path;
            this.Version = Version;
        }

        public void save()
        {
            doc = new XmlDocument();
            XmlNode xmlDecleration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement resourceNode = doc.CreateElement("resources");

            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDecleration, root);
            doc.AppendChild(resourceNode);
            foreach (AppFilterItem item in AppFilterItems)
            {
                var name = doc.CreateComment(item.name);
                var itemNode = doc.CreateElement("item");

                itemNode.SetAttribute("component", item.ComponentInfo());
                itemNode.SetAttribute("drawable", item.drawable);

                resourceNode.AppendChild(name);
                resourceNode.AppendChild(itemNode);
            }
            doc.Save(path[0]);
            doc.Save(path[1]);
        }

        public void addItemFromComponentInfo(string name, string ComponentInfo, string drawable)
        {

            string packetName = ComponentInfo.Split('/')[0];
            string activity = ComponentInfo.Split('/')[1];
            AppFilterItem item = new AppFilterItem(name, packetName, activity, drawable);
            AppFilterItems.Add(item);
        }

        public void Load()
        {
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
                if (ResourceChildNodes[i].Name == "#comment")
                {
                    string name = ResourceChildNodes[i].Value.Trim();
                    string packetName = null;
                    string activity = null;
                    string componentAtt = ResourceChildNodes[i + 1].Attributes[0].Value.Trim();
                    string drawable = ResourceChildNodes[i + 1].Attributes[1].Value.Trim();
                    string zwischen1 = componentAtt.Split('{')[1].Trim();
                    try
                    {
                        packetName = zwischen1.Split('/')[0].Trim();
                        activity = zwischen1.Split('/')[1].Trim();
                    }
                    catch
                    {
                        if (packetName == null)
                        {
                            packetName = "";
                        }

                        if (activity == null)
                        {
                            activity = "";
                        }
                    }
                    activity = activity.Replace('}', ' ').Trim();
                    AppFilterItems.Add(new AppFilterItem(name, packetName, activity, drawable));
                }
            }
            
            sortAppFilterList();
        }
        public void sortAppFilterList() { AppFilterItems = AppFilterItems.OrderBy(x => x.name).ToList(); }
    }
}

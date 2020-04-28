using Icon_Pack_Helper.CLasses.Files.AppFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Icon_Pack_Helper.CLasses.Files
{
    public class theme_resourceFile
    {
        public XmlDocument doc;
        private string path;
        string version = "1";
        string Label = "Childish Icon Pack";
        string Wallpaper = "wallpaper_01";
        string LockScreenWallpaper = "wallpaper_02";
        string ThemePreview = "drawer";
        string ThemePreviewWork = "preview1";
        string ThemePreviewMenu = "preview1";
        string DockMenuAppIcon = "drawer";

        public theme_resourceFile(string path)
        {
            this.path = path;
            doc = new XmlDocument();
            try
            {
                doc.Load(path);
                version = doc.SelectNodes("/Theme")[0].Attributes[0].Value;
                Label = doc.SelectNodes("/Theme/Label")[0].Attributes[0].Value;
                Wallpaper = doc.SelectNodes("/Theme/Wallpaper")[0].Attributes[0].Value;
                LockScreenWallpaper = doc.SelectNodes("/Theme/LockScreenWallpaper")[0].Attributes[0].Value;
                ThemePreview = doc.SelectNodes("/Theme/ThemePreview")[0].Attributes[0].Value;
                ThemePreviewWork = doc.SelectNodes("/Theme/ThemePreviewWork")[0].Attributes[0].Value;
                ThemePreviewMenu = doc.SelectNodes("/Theme/ThemePreviewMenu")[0].Attributes[0].Value;
                DockMenuAppIcon = doc.SelectNodes("/Theme/DockMenuAppIcon")[0].Attributes[0].Value;

            }
            catch (Exception)
            {

            }
        }

        public void save(List<AppFilterItem> AppFilterItems)
        {
            doc = new XmlDocument();
            XmlNode xmlDecleration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            XmlElement themeNode = doc.CreateElement("Theme");
            XmlElement LabelNode = doc.CreateElement("Label");
            XmlElement WallpaperNode = doc.CreateElement("Wallpaper");
            XmlElement LockScreenWallpaperNode = doc.CreateElement("LockScreenWallpaper");
            XmlElement ThemePreviewNode = doc.CreateElement("ThemePreview");
            XmlElement ThemePreviewWorkNode = doc.CreateElement("ThemePreviewWork");
            XmlElement ThemePreviewMenuNode = doc.CreateElement("ThemePreviewMenu");
            XmlElement DockMenuAppIconNode = doc.CreateElement("DockMenuAppIcon");

            themeNode.SetAttribute("version", version);
            LabelNode.SetAttribute("value", Label);
            WallpaperNode.SetAttribute("image", Wallpaper);
            LockScreenWallpaperNode.SetAttribute("image", LockScreenWallpaper);
            ThemePreviewNode.SetAttribute("image",ThemePreview);
            ThemePreviewWorkNode.SetAttribute("image", ThemePreviewWork);
            ThemePreviewMenuNode.SetAttribute("image", ThemePreviewMenu);
            DockMenuAppIconNode.SetAttribute("selector", DockMenuAppIcon);

            doc.InsertBefore(xmlDecleration, root);

            doc.AppendChild(themeNode);
            themeNode.AppendChild(LabelNode);
            themeNode.AppendChild(WallpaperNode);
            themeNode.AppendChild(LockScreenWallpaperNode);
            themeNode.AppendChild(ThemePreviewNode);
            themeNode.AppendChild(ThemePreviewWorkNode);
            themeNode.AppendChild(ThemePreviewMenuNode);
            themeNode.AppendChild(DockMenuAppIconNode);
         
            foreach (AppFilterItem item in AppFilterItems)
            {
                var name = doc.CreateComment(item.name);
                var AppIconNode = doc.CreateElement("AppIcon");

                AppIconNode.SetAttribute("name", item.acitivity);
                AppIconNode.SetAttribute("image", item.drawable);

                themeNode.AppendChild(name);
                themeNode.AppendChild(AppIconNode);
            }
            doc.Save(path);

        }
    }
}

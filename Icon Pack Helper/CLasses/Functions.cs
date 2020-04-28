using Icon_Pack_Helper.CLasses.Drawable;
using Icon_Pack_Helper.GUI.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Icon_Pack_Helper.CLasses.ProgrammSettings;

namespace Icon_Pack_Helper.CLasses
{
    static class Functions
    {
        
        
        
        public static void AddPictures()
        {
            OpenFileDialog AddPictureDialog = new OpenFileDialog();
            AddPictureDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            AddPictureDialog.Title = "Select Pictures";
            AddPictureDialog.Multiselect = true;
            bool overwriteAll = false;
            DialogResult result = AddPictureDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string FileName in AddPictureDialog.FileNames)
                {                                
                    if (File.Exists(images + @"/" +Path.GetFileName(FileName)) && overwriteAll == false)
                    {
                        DialogResult res = Overwrite.ShowOverwriteDialog(out overwriteAll, Path.GetFileName(FileName));
                        if (res != DialogResult.Yes) continue;

                    }
                    try
                    {
                        File.Copy(FileName, images + @"/" + Path.GetFileName(FileName),true);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("There was an error while copying the file\n"+e.StackTrace, "error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static void PopulateCategoryView(ListView categoryView, DrawableFile drawableFile)
        {

            categoryView.Items.Clear();
            foreach (var item in drawableFile.categories)
            {

                categoryView.Items.Add(item.name);

            }

        }
    }
}

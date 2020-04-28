using Icon_Pack_Helper.CLasses.Drawable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Icon_Pack_Helper.CLasses.Functions;

namespace Icon_Pack_Helper.GUI.Forms
{
    public partial class EditCategory : Form
    {
        DrawableFile drawableFile;
        public EditCategory(DrawableFile drawableFile)
        {
            InitializeComponent();
            this.drawableFile = drawableFile;
            
        }

        private void EditCategory_Load(object sender, EventArgs e)
        {
            PopulateCategoryView(listView1,drawableFile);
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var index = listView1.SelectedItems[0].Index;
            if (index == 0) return;
           
            var item = drawableFile.categories[index];
            drawableFile.categories.RemoveAt(index);
            drawableFile.categories.Insert(--index, item);
            PopulateCategoryView(listView1, drawableFile);
            drawableFile.wasEdited = true;

        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var index = listView1.SelectedItems[0].Index;
            if (index == listView1.Items.Count - 1) return;
          
            var item = drawableFile.categories[index];
            drawableFile.categories.RemoveAt(index);
            drawableFile.categories.Insert(++index, item);
            PopulateCategoryView(listView1, drawableFile);
            drawableFile.wasEdited = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (nameText.TextLength == 0) return;
            if(drawableFile.categories.Find(x => x.name == nameText.Text) != null)
            {
                MessageBox.Show("Diese Category Existiert bereits!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DrawableCategory category = new DrawableCategory(nameText.Text);
            drawableFile.categories.Add(category);
            PopulateCategoryView(listView1, drawableFile);
            drawableFile.wasEdited = true;
        }
    }
}

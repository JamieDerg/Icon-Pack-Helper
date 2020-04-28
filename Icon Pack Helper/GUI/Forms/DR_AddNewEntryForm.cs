using Icon_Pack_Helper.CLasses.Drawable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Icon_Pack_Helper.CLasses.Functions;
using static Icon_Pack_Helper.CLasses.ProgrammSettings;

namespace Icon_Pack_Helper.GUI.Forms
{
    public partial class DR_AddNewEntryForm : Form
    {
        MainForm main;
        AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
        public DR_AddNewEntryForm(MainForm main )
        {
            InitializeComponent();

            GenerateAutoComplete();
            this.main = main;
        }

        private void GenerateAutoComplete()
        {
            List<string> Drawables = new List<string>();
            foreach (string file in Directory.EnumerateFiles(images))
            {
                Drawables.Add(Path.GetFileNameWithoutExtension(file));
            }
            autoCompleteStringCollection.AddRange(Drawables.ToArray());
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void AddPicturesButton_Click(object sender, EventArgs e)
        {
            AddPictures();
            GenerateAutoComplete();
        }

        private void DR_AddNewEntryForm_Load(object sender, EventArgs e)
        {
            PopulateCategoryView(listView1, MainForm.DrawableXML);
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            var selectedGroups = listView1.SelectedItems;
            if(textBox1.Text == "")
            {
                MessageBox.Show("Du hast eventuell etwas vergessen", "Fehler", MessageBoxButtons
                    .OK, MessageBoxIcon.Error);
                return;
            }
            if(selectedGroups.Count == 0)
            {
                MessageBox.Show("Du musst mindestens eine Category auswählen", "Fehler", MessageBoxButtons
                    .OK, MessageBoxIcon.Error);
                    return;
            }

            foreach(ListViewItem item in selectedGroups)
            {
                var group = MainForm.DrawableXML.categories.Find(x => x.name == item.Text);
                group.DrawableItems.Add(new DrawableItem(textBox1.Text, group.tag));


            }
             

            this.DialogResult = DialogResult.OK;
            

        }
    }
}

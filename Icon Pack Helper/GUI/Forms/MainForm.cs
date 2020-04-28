using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Icon_Pack_Helper.CLasses;
using Icon_Pack_Helper.CLasses.Drawable;
using Icon_Pack_Helper.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using static Icon_Pack_Helper.CLasses.ProgrammSettings;
using static Icon_Pack_Helper.CLasses.Functions;
using Icon_Pack_Helper.CLasses.Files.AppFilter;
using Icon_Pack_Helper.CLasses.Files;

namespace Icon_Pack_Helper.GUI.Forms
{


    public partial class MainForm : Form
    {
        public bool save = false;
   
        //private XmlDocument drawableDoc = new XmlDocument();
        //private XmlDocument appMapDoc = new XmlDocument();

       /* public static List<AppFilterItem> appFilterItems = new List<AppFilterItem>(); 4815*/
        public static AppFilterFile AppFilterXML;
        public static DrawableFile DrawableXML;
        public AppMapFile AppMapXML;
        public theme_resourceFile theme_resourceXML;
        private AppFilterItem AppfilterSelectedItem;
        bool edit = false;
       
        //private bool isSaved = true;
        //private bool FilesLoaded = false;
        private bool Drag = false;
        ListViewItem heldDownItem;
       private DrawableItem DrawbleSelectedItem;


        public MainForm() //test
        {
            
            InitializeComponent();
            
            AppFilterList.DoubleBuffering(true);
            DrawableListView.DoubleBuffering(true);
           

        }
        #region INITSTUFF
        private void Form1_Load(object sender, EventArgs e)
        {
            init();
            Console.Write("");
            Debug.Write(this.Bounds.X + "," + this.Bounds.Y);
         
          
        }

        private void init()
        {
            if (LoadSettings() != false)
            {
                AppFilterXML = new AppFilterFile(appfilterPath);
                DrawableXML = new DrawableFile(drawablePath, images);
                AppMapXML = new AppMapFile(appmapPath);
                theme_resourceXML = new theme_resourceFile(theme_resourcePath);
                AppFilterXML.Load();
                DrawableXML.load();
                PopulateAppFilterListView();
                PopulateDrawableListView();
            }
        }
        private bool LoadSettings()
        {
            if (Settings.Default.Path == "NULL")
            {
                tabControl1.Enabled = false;

                return false;
            }
            path = Settings.Default.Path;
            appmapPath = path + @"\app\src\main\res\xml\appmap.xml";
            theme_resourcePath = path + @"\app\src\main\res\xml\theme_resources.xml";
            appfilterPath[0] = path + @"\app\src\main\res\xml\appfilter.xml";
            appfilterPath[1] = path + @"\app\src\main\assets\appfilter.xml";
            drawablePath[0] = path + @"\app\src\main\res\xml\drawable.xml";
            drawablePath[1] = path + @"\app\src\main\assets\drawable.xml";
            images = path + "\\app\\src\\main\\res\\drawable-nodpi";
            if (!File.Exists(appfilterPath[0]) || !File.Exists(drawablePath[0]))
            {
                if (!File.Exists(appfilterPath[0])) MessageBox.Show("Die Datei: " + appfilterPath[0] + "konnte nicht gefunden werden", "YOU FUCKED UP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Die Datei: " + drawablePath[0] + "konnte nicht gefunden werden", "YOU FUCKED UP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
                
            OrdnerLabel.Text = @"Geladener Ordner: " + path;
            OrdnerLabel.ForeColor = Color.DarkGreen;
            tabControl1.Enabled = true;

            return true;
        }
        #endregion

        #region LISTVIEWS
        #region APPFILTER
        private void PopulateAppFilterListView()
        {
            AppFilterList.Items.Clear();
            var items = new List<ListViewItem>();
            foreach (AppFilterItem item in AppFilterXML.AppFilterItems)
            {
                string[] row = {item.name, item.packetName, item.acitivity, item.drawable,item.tag};
                items.Add(new ListViewItem(row));

            }
            
            AppFilterList.BeginUpdate();
            AppFilterList.Items.AddRange(items.ToArray());
            AppFilterList.EndUpdate();
        }
        #endregion
        #region DRAWABLE
        public void PopulateDrawableListView()
        {
            
            foreach (ListViewItem item in DrawableListView.Items)
            {
                DrawableListView.Items.Remove(item);
            }
            comboBox1.Items.Clear();
            DrawableListView.LargeImageList = DrawableXML.images;
            var items = new List<ListViewItem>();
            foreach(DrawableCategory category in DrawableXML.categories)
            {
                ListViewGroup group = new ListViewGroup(category.name);
                DrawableListView.Groups.Add(group);
                comboBox1.Items.Add(new ComboItem { ID = category.tag, Text = category.name });
                foreach (DrawableItem item in category.DrawableItems)
                {
                    string[] row = {item.drawable, item.GroupTag, item.tag};
                    ListViewItem listItem = new ListViewItem(row);
                    listItem.Group = group;
                    listItem.ImageKey = item.drawable;
                   
                    
                    items.Add(listItem);
                }
            }

            DrawableListView.BeginUpdate();
            DrawableListView.Items.AddRange(items.ToArray());
            DrawableListView.EndUpdate();

            DrawableListView.Refresh();
        }

        private void DrawableListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.MouseButtons == MouseButtons.Left)
            {
                heldDownItem = DrawableListView.GetItemAt(e.X, e.Y);
                Drag = true;
            }
            
            


        }

        private void DrawableListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (heldDownItem != null)
            {
                Cursor.Current = Cursors.Hand;

                ListViewItem HoverItem;
                if ((HoverItem = DrawableListView.GetItemAt(e.X, e.Y)) != null)
                {
                    try
                    {
                        DrawableListView.SelectedItems.Clear();
                        DrawableListView.Items[heldDownItem.Index].Selected = true;
                        DrawableListView.Items[HoverItem.Index].Selected = true;
                    }
                    catch( Exception ex)
                    {

                    }
                }



            }


        }

        private void DrawableListView_MouseUp(object sender, MouseEventArgs e)
        {

            var newItem = DrawableListView.GetItemAt(e.X, e.Y);
            if(newItem != null && newItem.Group != heldDownItem.Group && Drag)
            {
                
                var oldGroup = DrawableXML.categories.Find(x => x.tag == heldDownItem.SubItems[1].Text);
                var newGroup = DrawableXML.categories.Find(x => x.tag == newItem.SubItems[1].Text);
                var oldItem = oldGroup.DrawableItems.Find(x => x.tag == heldDownItem.SubItems[2].Text);


                oldGroup.DrawableItems.Remove(oldItem);
                newGroup.DrawableItems.Add(oldItem);

                

                //MessageBox.Show(heldDownItem.Text);
              
                Drag = false;
                heldDownItem = null;
                DrawableXML.wasEdited = true;
                SortDrawble();
                PopulateDrawableListView();
             

                

            }


            /*ListViewItem NewItem;
            if ((NewItem = DrawableListView.GetItemAt(e.X, e.Y)) != null && NewItem != heldDownItem && Drag)
            {
                ListViewGroup group = NewItem.Group;
                /*var Newgroup = DrawableXML.categories.Find(x => x.tag == NewItem.SubItems[1].Text);
                var Drawableitem = Newgroup.DrawableItems.Find(x => x.tag == NewItem.SubItems[2].Text);
                var itemIndex = Newgroup.DrawableItems.IndexOf(Drawableitem);

                var oldIGroup = DrawableXML.categories.Find(x => x.tag == heldDownItem.SubItems[1].Text);
                var oldDrawableItem = oldIGroup.DrawableItems.Find(x => x.tag == heldDownItem.SubItems[2].Text);


                var oldItemIndex = oldIGroup.DrawableItems.IndexOf(oldDrawableItem);



                oldIGroup.DrawableItems.RemoveAt(oldItemIndex);
                Newgroup.DrawableItems.Insert(itemIndex, oldDrawableItem);

                /*var groupIndex = heldDownItem.Group;
                var index = groupIndex.Items.IndexOf(NewItem);
                groupIndex.Items.Remove(heldDownItem);
                groupIndex.Items.Insert(index, heldDownItem);*/

            // DrawableListView.Refresh();

            // Drag = false;
            // PopulateDrawableListView();


            // heldDownItem = null;
            //}


        }
        #endregion
        #endregion

        #region BUTTONS

        #region NORMAL
        private void AppMapAddButton_Click(object sender, EventArgs e)
        {
            Form addNewEntryForm = new AddNewEntryForm();
            DialogResult result = addNewEntryForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                AppFilterXML.wasEdited = true;
                PopulateAppFilterListView();
            }

        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            edit = false;
            AppfilterNameText.Text = "";
            AppfilterActivityText.Text = "";
            AppfilterPacketNameText.Text = "";
            AppfilterDrawableText.Text = "";
            AppfilterDoneButton.Enabled = false;
            AppfilterCancelButton.Enabled = false;
            AppfilterAddButton.Enabled = true;
        }
        
        private void DoneButton_Click(object sender, EventArgs e)
        {
            AppfilterSelectedItem.name = AppfilterNameText.Text;
            AppfilterSelectedItem.acitivity = AppfilterActivityText.Text;
            AppfilterSelectedItem.packetName = AppfilterPacketNameText.Text;
            AppfilterSelectedItem.drawable = AppfilterDrawableText.Text;
            AppfilterNameText.Text = "";
            AppfilterActivityText.Text = "";
            AppfilterPacketNameText.Text = "";
            AppfilterDrawableText.Text = "";
            AppfilterDoneButton.Enabled = false;
            AppfilterCancelButton.Enabled = false;
            AppfilterAddButton.Enabled = true;
            AppFilterXML.sortAppFilterList();
            AppFilterXML.wasEdited = true;
            PopulateAppFilterListView();
        }

        private void DrawableDoneButton_Click(object sender, EventArgs e)
        {
            ComboItem item = (ComboItem)comboBox1.SelectedItem;
            if (item.ID != DrawbleSelectedItem.GroupTag)
            {
                var oldGroup = DrawableXML.categories.Find(x => x.tag == DrawbleSelectedItem.tag);
                var Newgroup = DrawableXML.categories.Find(x => x.tag == item.ID);

                MessageBox.Show($"oldGroup: {oldGroup.name} New Group: {Newgroup.name}");

                DrawbleSelectedItem.GroupTag = item.ID;
                oldGroup.DrawableItems.Remove(DrawbleSelectedItem);              
                Newgroup.DrawableItems.Insert(0,DrawbleSelectedItem);

                DrawableXML.wasEdited = true;
                PopulateDrawableListView();
                
            };
        }

        private void DrawableAddButton_Click(object sender, EventArgs e)
        {
            DR_AddNewEntryForm addNewForm = new DR_AddNewEntryForm(this);
            var result = addNewForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                DrawableXML.wasEdited = true;
                SortDrawble();
                PopulateDrawableListView();
            }
        }
        #endregion

        #region TOOLSTRIP
        private void LoadFilesToolStripButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "%userprofile%";
            dialog.IsFolderPicker = true;
            dialog.Title = "bitte suche einen ordner aus °^°";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (!File.Exists(dialog.FileName + @"\app\src\main\res\xml\appfilter.xml"))
                {
                    MessageBox.Show(
                        "Die Datei: " + dialog.FileName + @"\app\src\main\res\xml\Appfilter.xml " +
                        "konnte nicht gefunden werden", "YOU FUCKED UP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Settings.Default.Path = dialog.FileName;
                Settings.Default.Save();
                init();
            }
        }
        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFiles();
        }

        private void SaveFiles()
        {
            AppFilterXML.save();
            AppMapXML.save(AppFilterXML.AppFilterItems);
            theme_resourceXML.save(AppFilterXML.AppFilterItems);
            DrawableXML.save();
        }

        private void sortGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortDrawble();
        }

        public void SortDrawble()
        {
            foreach (var category in DrawableXML.categories)
            {
                category.DrawableItems.Sort((a, b) => (a.drawable.CompareTo(b.drawable)));
            }
            PopulateDrawableListView();
            DrawableXML.wasEdited = true;
        }

        private void addPicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPictures();

        }

        private void editCategToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCategory editCategory = new EditCategory(DrawableXML);
            editCategory.ShowDialog();
            PopulateDrawableListView();
        }

        #endregion

        #region CONTEXTMENUS
        #region APPFILTER
        private void EditContextMenuButton_Click(object sender, EventArgs e)
        {
            edit = true;
            string selectedItemTag = AppFilterList.SelectedItems[0].SubItems[4].Text;
            AppfilterSelectedItem = AppFilterXML.AppFilterItems.Find(x => x.tag == selectedItemTag);
            AppfilterNameText.Text = AppfilterSelectedItem.name;
            AppfilterActivityText.Text = AppfilterSelectedItem.acitivity;
            AppfilterPacketNameText.Text = AppfilterSelectedItem.packetName;
            AppfilterDrawableText.Text = AppfilterSelectedItem.drawable;
            AppfilterDoneButton.Enabled = true;
            AppfilterCancelButton.Enabled = true;
            AppfilterAddButton.Enabled = false;
            
        }

        private void DeleteContextMenuButton_Click(object sender, EventArgs e)
        {
           
            string selectedItemTag = AppFilterList.SelectedItems[0].SubItems[4].Text;
            AppfilterSelectedItem = AppFilterXML.AppFilterItems.Find(x => x.tag == selectedItemTag);
            AppFilterXML.AppFilterItems.Remove(AppfilterSelectedItem);
            AppFilterXML.sortAppFilterList();
            PopulateAppFilterListView();
            AppFilterXML.wasEdited = true;
        }
        #endregion
        #region DRAWABLE
        private void DrawableDeleteToolStripItem_Click(object sender, EventArgs e)
        {
            var selectedItem = DrawableListView.SelectedItems[0];
            var group = DrawableXML.categories.Find(x => x.tag == selectedItem.SubItems[1].Text);
            var item = group.DrawableItems.Find(x => x.tag == selectedItem.SubItems[2].Text);
            group.DrawableItems.Remove(item);
            DrawableXML.wasEdited = true;
            PopulateDrawableListView();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = DrawableListView.SelectedItems[0];
            var group = DrawableXML.categories.Find(x => x.tag == selectedItem.SubItems[1].Text);
            var item = group.DrawableItems.Find(x => x.tag == selectedItem.SubItems[2].Text);
            
            

            DR_DrawbleText.Text = item.drawable;
            comboBox1.SelectedIndex = comboBox1.FindStringExact(group.name);
            DrawbleSelectedItem = item;
            DrawableDoneButton.Enabled = true;
            DrawableCancelButton.Enabled = true;
        }
        #endregion
        #endregion




        #endregion

        #region MISC
        private void OrdnerLabel_MouseMove(object sender, MouseEventArgs e)
        {
           
                if (OrdnerLabel.ForeColor != Color.DarkGreen) return;
                Cursor.Current = Cursors.Hand;
            
        }
        private void OrdnerLabel_Click(object sender, EventArgs e)
        {
            
            if (OrdnerLabel.ForeColor != Color.DarkGreen) return;
            Process.Start(path);
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DrawableXML != null && DrawableXML != null  && (DrawableXML.wasEdited || AppFilterXML.wasEdited))
            {
                var result = MessageBox.Show("Du hast ungespeicherte änderungen, #nderungen Speichern?", "nani?!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    SaveFiles();
                }
                else if(result == DialogResult.Cancel)
                {
                    e.Cancel = false;
                }
            }
        }










        #endregion



        //private void INDEXToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    var selectedItem = DrawableListView.SelectedItems[0];
        //    MessageBox.Show(selectedItem.Index.ToString());
        //}

        //private void categoryText_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}



        class ComboItem
        {
            public string ID { get; set; }
            public string Text { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

      
    }


}


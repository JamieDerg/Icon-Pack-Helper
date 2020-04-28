using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icon_Pack_Helper.GUI.Forms
{
    public partial class AddNewEntryForm : Form
    {
        public AddNewEntryForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            string name = NameText.Text;
            string componentInfo = ComponentInfoText.Text;
            string drawable = DrawableText.Text;

            if (componentInfo.Split('/').Length != 2)
            {
                MessageBox.Show(
                    "Die COmponentInfo hat ein Falsches format! beispiel:\n" +
                    "com.google.android.apps.messaging/com.google.android.apps.messaging.ui.ConversationListActivity","Falsches FOrmat",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            MainForm.AppFilterXML.addItemFromComponentInfo(name, componentInfo, drawable);
            MainForm.AppFilterXML.sortAppFilterList();
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddNewEntryForm_Load(object sender, EventArgs e)
        {

        }
    }
}

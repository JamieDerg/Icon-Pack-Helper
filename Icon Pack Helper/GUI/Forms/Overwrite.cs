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
    public partial class Overwrite : Form
    {

        bool reference;
        public Overwrite(string fileName)
        {
            
            InitializeComponent();
            label1.Text = string.Format(label1.Text, fileName);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        
        public static DialogResult ShowOverwriteDialog(out bool overwriteAll,string fileName)
        {
            var f = new Overwrite(fileName);
            DialogResult result = f.ShowDialog();

            overwriteAll = f.checkBox1.Checked;        
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            reference = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            reference = checkBox1.Checked;
        }
    }
}

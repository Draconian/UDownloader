using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDL.View
{
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBoxSavePath.Text = folderBrowserDialogSave.SelectedPath;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.textBoxSavePath.Text))
            {
                MessageBox.Show("Save Folder \"" + this.textBoxSavePath.Text + "\" doesnt exist");
                return;
            }


            UDL.Properties.Settings.Default.OutputPath = this.textBoxSavePath.Text;


            UDL.Properties.Settings.Default.Save();

            this.Close();
        }

        private void SettingsView_Load(object sender, EventArgs e)
        {
            this.textBoxSavePath.Text = UDL.Properties.Settings.Default.OutputPath;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

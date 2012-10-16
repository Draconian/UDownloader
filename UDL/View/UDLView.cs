using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDL.Model;

namespace UDL.View
{
    public partial class UDLView : Form
    {
        public UDLView()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Video video = new Video();
            video.GetURLs(textBoxVideoURL.Text.Trim());

            comboBoxVideoURL.Items.Clear();

            comboBoxVideoURL.Items.AddRange(video.VideoURLs);

            if (comboBoxVideoURL.Items.Count > 0)
            {
                comboBoxVideoURL.SelectedIndex = 0;
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            VideoURL vU = (VideoURL)comboBoxVideoURL.SelectedItem;
            vU.Download("C:\\");
        }
    }
}

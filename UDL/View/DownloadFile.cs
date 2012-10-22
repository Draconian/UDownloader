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
    public partial class DownloadFile : Form
    {
        private VideoURL _videoURL = null;
        private String _ouputPath = null;

        public DownloadFile(VideoURL aVideoURL, String aOutputPath)
        {
            this._videoURL = aVideoURL;
            this._ouputPath = aOutputPath;
            InitializeComponent();
        }

        private void backgroundWorkerDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            this._videoURL.Download(this._ouputPath, this.backgroundWorkerDownload);
        }

        private void DownloadFile_Load(object sender, EventArgs e)
        {
            this.backgroundWorkerDownload.RunWorkerAsync();
        }

        private void backgroundWorkerDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProg.Text = String.Format("Progress: {0}", e.UserState.ToString());
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.backgroundWorkerDownload.CancelAsync();
            this.Close();
        }


    }
}

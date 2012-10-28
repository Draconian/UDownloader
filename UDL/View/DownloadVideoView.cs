using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDL.Model;
using UDL.Model.Observer;

namespace UDL.View
{
    public partial class DownloadVideoView : Form, IObserver
    {
        private DownloadVideo _videoDownload = null;

        public DownloadVideoView(DownloadVideo aVideoDownload)
        {
            this._videoDownload = aVideoDownload;
            InitializeComponent();
        }

        private void backgroundWorkerDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            this._videoDownload.Download();
        }

        private void DownloadFile_Load(object sender, EventArgs e)
        {
            this.backgroundWorkerDownload.RunWorkerAsync();
        }

        private void backgroundWorkerDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarVideoDownload.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarVideoDownload.Value = 100;
            labelProg.Text = "Progress: Completed";
            buttonCancel.Text = "Close";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.backgroundWorkerDownload.CancelAsync();
            this.Close();
        }

        public void NotifyObserver(Subject aSubject)
        {
            this.Invoke((MethodInvoker)delegate
            {
                float pourcentage = (float)this._videoDownload.DownloadedLenght * 100 / (float)this._videoDownload.Lenght;
                this.progressBarVideoDownload.Value = (int)pourcentage;

                this.textBoxLocalPath.Text = this._videoDownload.LocalPath;
                this.labelProg.Text = String.Format("Progress: {0} / {1} | {2:0.00}/sec", DownloadVideo.ConvertByteString(this._videoDownload.DownloadedLenght),DownloadVideo.ConvertByteString(this._videoDownload.Lenght), DownloadVideo.ConvertByteString(this._videoDownload.AverageDownloadSpeed()));
                
               
                Debug.WriteLine(DownloadVideo.ConvertByteString(this._videoDownload.AverageDownloadSpeed()));
            });
        }

        private void DownloadVideoView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._videoDownload.IsDownloading
                && MessageBox.Show("Closing the window will cancel the download, are you sure you want to continue ?","Confirmation cancel",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.backgroundWorkerDownload.CancelAsync();
            }

        }
    }
}

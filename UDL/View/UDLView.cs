using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDL.Controller;
using UDL.Model;
using UDL.Model.Observer;

namespace UDL.View
{
    public partial class UDLView : Form, IObserver
    {
        private UDLController _udlController = null;
        private String _currentVideoID = string.Empty;

        public UDLView(UDLController aUdlController)
        {
            this._udlController = aUdlController;
            InitializeComponent();

            this.buttonLoad.Click += this._udlController.Load_Click;
            this.buttonDownload.Click += this._udlController.Download_Click;
        }

        private void UDLView_Load(object sender, EventArgs e)
        {

        }

        #region Notifications
        public void NotifyObserver(Subject aSubject)
        {
            if (aSubject.GetType() == typeof(Video))
            {
                this.NotifyObserver((Video)aSubject);
            }
            else
            {
                throw new Exception("NotifyObserver | Unknown subject");
            }
        }

        public void NotifyObserver(Video aVideo)
        {


            if (!this._currentVideoID.Equals(aVideo.VideoID))
            {
                //Selected video ID changed, modify video information.
                this.labelTitle.Text = String.Format("Title: {0}",aVideo.Title);
                this.labelAuthor.Text = String.Format("Author: {0}", aVideo.Author);
                this.labelLenght.Text = String.Format("Length: {0} seconds", aVideo.Length);

                this.comboBoxVideoURL.Items.Clear();

                if (aVideo.VideoURLs.Length > 0)
                {
                    this.comboBoxVideoURL.Items.AddRange(aVideo.VideoURLs);
                    this.groupBoxVidList.Enabled = true;
                    this.comboBoxVideoURL.SelectedIndex = 0;
                }
                else
                {
                    this.groupBoxVidList.Enabled = false;
                }

                this._currentVideoID = aVideo.VideoID;
            }          

        }
        #endregion

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsView sv = new SettingsView();
            sv.ShowDialog();
        }

        private void textBoxVideoURL_DoubleClick(object sender, EventArgs e)
        {
            this.textBoxVideoURL.SelectAll();
        }

       
    }
}

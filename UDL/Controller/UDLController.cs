﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDL.Model;
using UDL.View;

namespace UDL.Controller
{
    public class UDLController
    {
        private UDLView _udlView = null;

        public UDLController()
        {
            this._udlView = new UDLView(this);
            Application.Run(this._udlView);
        }

        public void Load_Click(object sender, EventArgs e)
        {
            Video video = new Video();
            video.Attach(this._udlView);
            video.GetURLs(this._udlView.textBoxVideoURL.Text.Trim());

        }

        public void Download_Click(object sender, EventArgs e)
        {

        }

    }
}

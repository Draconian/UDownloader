namespace UDL.View
{
    partial class UDLView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoad = new System.Windows.Forms.Button();
            this.comboBoxVideoURL = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxVidList = new System.Windows.Forms.GroupBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxVideoURL = new System.Windows.Forms.TextBox();
            this.groupBoxURL = new System.Windows.Forms.GroupBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.labelLenght = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.groupBoxVidList.SuspendLayout();
            this.groupBoxURL.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(657, 23);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // comboBoxVideoURL
            // 
            this.comboBoxVideoURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoURL.FormattingEnabled = true;
            this.comboBoxVideoURL.Location = new System.Drawing.Point(56, 22);
            this.comboBoxVideoURL.Name = "comboBoxVideoURL";
            this.comboBoxVideoURL.Size = new System.Drawing.Size(184, 21);
            this.comboBoxVideoURL.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Video:";
            // 
            // groupBoxVidList
            // 
            this.groupBoxVidList.Controls.Add(this.buttonDownload);
            this.groupBoxVidList.Controls.Add(this.comboBoxVideoURL);
            this.groupBoxVidList.Controls.Add(this.label1);
            this.groupBoxVidList.Enabled = false;
            this.groupBoxVidList.Location = new System.Drawing.Point(407, 78);
            this.groupBoxVidList.Name = "groupBoxVidList";
            this.groupBoxVidList.Size = new System.Drawing.Size(343, 65);
            this.groupBoxVidList.TabIndex = 3;
            this.groupBoxVidList.TabStop = false;
            this.groupBoxVidList.Text = "Video List";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(255, 22);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 6;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "URL:";
            // 
            // textBoxVideoURL
            // 
            this.textBoxVideoURL.Location = new System.Drawing.Point(44, 25);
            this.textBoxVideoURL.Name = "textBoxVideoURL";
            this.textBoxVideoURL.Size = new System.Drawing.Size(596, 20);
            this.textBoxVideoURL.TabIndex = 5;
            this.textBoxVideoURL.DoubleClick += new System.EventHandler(this.textBoxVideoURL_DoubleClick);
            // 
            // groupBoxURL
            // 
            this.groupBoxURL.Controls.Add(this.label2);
            this.groupBoxURL.Controls.Add(this.textBoxVideoURL);
            this.groupBoxURL.Controls.Add(this.buttonLoad);
            this.groupBoxURL.Location = new System.Drawing.Point(12, 12);
            this.groupBoxURL.Name = "groupBoxURL";
            this.groupBoxURL.Size = new System.Drawing.Size(738, 60);
            this.groupBoxURL.TabIndex = 4;
            this.groupBoxURL.TabStop = false;
            this.groupBoxURL.Text = "URL";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelLenght);
            this.groupBoxInfo.Controls.Add(this.labelAuthor);
            this.groupBoxInfo.Controls.Add(this.labelTitle);
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 78);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(389, 104);
            this.groupBoxInfo.TabIndex = 5;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Video Informations";
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.labelLenght.Location = new System.Drawing.Point(11, 70);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(43, 13);
            this.labelLenght.TabIndex = 3;
            this.labelLenght.Text = "Lenght:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(11, 47);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(41, 13);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Author:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(11, 24);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title:";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(662, 159);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSettings.TabIndex = 7;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // UDLView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 194);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxURL);
            this.Controls.Add(this.groupBoxVidList);
            this.Name = "UDLView";
            this.Text = "UDownloader";
            this.Load += new System.EventHandler(this.UDLView_Load);
            this.groupBoxVidList.ResumeLayout(false);
            this.groupBoxVidList.PerformLayout();
            this.groupBoxURL.ResumeLayout(false);
            this.groupBoxURL.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        internal System.Windows.Forms.ComboBox comboBoxVideoURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxVidList;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxURL;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelLenght;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTitle;
        internal System.Windows.Forms.TextBox textBoxVideoURL;
        private System.Windows.Forms.Button buttonSettings;
    }
}
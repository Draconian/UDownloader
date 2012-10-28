namespace UDL.View
{
    partial class DownloadVideoView
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
            this.backgroundWorkerDownload = new System.ComponentModel.BackgroundWorker();
            this.progressBarVideoDownload = new System.Windows.Forms.ProgressBar();
            this.labelProg = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLocalFile = new System.Windows.Forms.Label();
            this.textBoxLocalPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // backgroundWorkerDownload
            // 
            this.backgroundWorkerDownload.WorkerReportsProgress = true;
            this.backgroundWorkerDownload.WorkerSupportsCancellation = true;
            this.backgroundWorkerDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownload_DoWork);
            this.backgroundWorkerDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDownload_ProgressChanged);
            this.backgroundWorkerDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownload_RunWorkerCompleted);
            // 
            // progressBarVideoDownload
            // 
            this.progressBarVideoDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarVideoDownload.Location = new System.Drawing.Point(9, 36);
            this.progressBarVideoDownload.Name = "progressBarVideoDownload";
            this.progressBarVideoDownload.Size = new System.Drawing.Size(670, 23);
            this.progressBarVideoDownload.TabIndex = 0;
            // 
            // labelProg
            // 
            this.labelProg.AutoSize = true;
            this.labelProg.Location = new System.Drawing.Point(6, 14);
            this.labelProg.Name = "labelProg";
            this.labelProg.Size = new System.Drawing.Size(51, 13);
            this.labelProg.TabIndex = 2;
            this.labelProg.Text = "Progress:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(604, 78);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelLocalFile
            // 
            this.labelLocalFile.AutoSize = true;
            this.labelLocalFile.Location = new System.Drawing.Point(6, 83);
            this.labelLocalFile.Name = "labelLocalFile";
            this.labelLocalFile.Size = new System.Drawing.Size(61, 13);
            this.labelLocalFile.TabIndex = 4;
            this.labelLocalFile.Text = "Local Path:";
            // 
            // textBoxLocalPath
            // 
            this.textBoxLocalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocalPath.Location = new System.Drawing.Point(69, 79);
            this.textBoxLocalPath.Name = "textBoxLocalPath";
            this.textBoxLocalPath.ReadOnly = true;
            this.textBoxLocalPath.Size = new System.Drawing.Size(529, 20);
            this.textBoxLocalPath.TabIndex = 5;
            // 
            // DownloadVideoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 111);
            this.Controls.Add(this.textBoxLocalPath);
            this.Controls.Add(this.labelLocalFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelProg);
            this.Controls.Add(this.progressBarVideoDownload);
            this.MaximumSize = new System.Drawing.Size(99999, 150);
            this.Name = "DownloadVideoView";
            this.Text = "DownloadFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadVideoView_FormClosing);
            this.Load += new System.EventHandler(this.DownloadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerDownload;
        private System.Windows.Forms.ProgressBar progressBarVideoDownload;
        private System.Windows.Forms.Label labelProg;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelLocalFile;
        private System.Windows.Forms.TextBox textBoxLocalPath;
    }
}
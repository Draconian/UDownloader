namespace UDL.View
{
    partial class DownloadFile
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelProg = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(60, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(476, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Progress:";
            // 
            // labelProg
            // 
            this.labelProg.AutoSize = true;
            this.labelProg.Location = new System.Drawing.Point(3, 9);
            this.labelProg.Name = "labelProg";
            this.labelProg.Size = new System.Drawing.Size(51, 13);
            this.labelProg.TabIndex = 2;
            this.labelProg.Text = "Progress:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(461, 65);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // DownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 111);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelProg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "DownloadFile";
            this.Text = "DownloadFile";
            this.Load += new System.EventHandler(this.DownloadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProg;
        private System.Windows.Forms.Button buttonCancel;
    }
}
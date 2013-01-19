using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using UDL.Model.Observer;

namespace UDL.Model
{
    public class DownloadVideo : Subject
    {
        private static readonly int HISTORIC_DOWNLOAD_MAX = 5;
        private static readonly int TIMER_DOWNLOAD_INTERVAL = 1000;

        private ulong downloadedSize = 0;
        private ulong previousDownloadSize = 0;

        private List<int> historicDownloadSpeedPerSecond = new List<int>();
        private VideoURL videoURLDownload = null;
        private String outputFolder = null;
        private Timer timerDownload = null;
        
        private bool isDownloading = false;
        private bool isDownloadFinish = false;

        public DownloadVideo(VideoURL aVideoURL, String aOutputFolder)
        {
            this.videoURLDownload = aVideoURL;
            this.outputFolder = aOutputFolder;

            this.timerDownload = new Timer();

            this.timerDownload.Elapsed += new ElapsedEventHandler(timerSecond_Tick);
            this.timerDownload.Interval = TIMER_DOWNLOAD_INTERVAL;
        }


        #region Properties
        public string LocalPath
        {
            get
            {
                return Path.Combine(this.outputFolder, String.Format("{0}_{1}.{2}", this.videoURLDownload.Video.Author, 
                    this.videoURLDownload.Video.Title, 
                    this.videoURLDownload.FileExtension));
            }
        }

        public float Length
        {
            get { return (float)this.videoURLDownload.Size; }
        }

        public float DownloadedLength
        {
            get { return (float)this.downloadedSize; }
        }

        public bool IsDownloading
        {
            get { return this.isDownloading && !this.isDownloadFinish; }
        }
        #endregion

        public void Download()
        {
            if (this.isDownloading)
            {
                throw new Exception("Video already downloading");
            }
            this.timerDownload.Start();

            byte[] buffer = new byte[10000];

            Debug.WriteLine("Download started");

            HttpWebRequest webRequest = WebRequest.Create(this.videoURLDownload.DownloadURL) as HttpWebRequest;
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;

            BinaryWriter binWriter = new BinaryWriter(File.Open(this.LocalPath, FileMode.Create));
            BinaryReader binReader = new BinaryReader(webResponse.GetResponseStream());

            while (true)
            {
                int nbByteReads = binReader.Read(buffer, 0, buffer.Length);
                if (nbByteReads == 0) break;

                this.downloadedSize += (ulong)nbByteReads;
                binWriter.Write(buffer, 0, nbByteReads);

            }

            binWriter.Close();
            binReader.Close();


            Debug.WriteLine("Download done");

            this.isDownloadFinish = true;
            this.timerDownload.Stop();
        }

        private void timerSecond_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(String.Format("{0} | {1} \\/ {2}",this.downloadedSize,this.previousDownloadSize,(int)(this.downloadedSize - this.previousDownloadSize)));
            this.historicDownloadSpeedPerSecond.Add((int)(this.downloadedSize - this.previousDownloadSize));
            this.previousDownloadSize = this.downloadedSize;

            this.NotifyObservers();
        }

        public float AverageDownloadSpeed()
        {
            int speedTotal = 0;
            float averageDownloadSpeed = 0.0f;

            
            this.historicDownloadSpeedPerSecond.Select(speed => { speedTotal += speed; return speed; }).ToList();

            if (historicDownloadSpeedPerSecond.Count > 0)
            {
                averageDownloadSpeed = (float)speedTotal / (float)this.historicDownloadSpeedPerSecond.Count;
            }
                
            return averageDownloadSpeed;
        }

        ~DownloadVideo()
        {
            Debug.WriteLine("Download Destructor");
        }
      

        #region Static
        public static string FormatFileName(String outputFile)
        {

            String[] illegalChars = { "/", "?", "<", ">", "\\", ":", "*", "|", "\"", "|" };
            foreach (String c in illegalChars)
            {
                outputFile = outputFile.Replace(c, "");
            }

            return outputFile;
        }

        private static float AverageBytePerSecond(int[] aHistoricBytePerSecond)
        {
            float bytePerSecondTotal = 0.0f;

            foreach (int bps in aHistoricBytePerSecond)
            {
                bytePerSecondTotal += bps;
            }

            return bytePerSecondTotal / aHistoricBytePerSecond.Length;
        }

        public static string ConvertByteString(float aSize)
        {
            string[] sizeType = { "B", "KB", "MB", "GB", "TB" };
            int indexSizeType = 0;

            do
            {
                aSize = aSize / 1024;
                indexSizeType++;

                if (indexSizeType >= 5 || aSize < 1024)
                {
                    break;
                }
            } while (true);

            return string.Format("{0:0.00} {1}", aSize, sizeType[indexSizeType]);
        }

        #endregion
    }
}

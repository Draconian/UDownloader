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

        private ulong _downloadedSize = 0;
        private ulong _previousDownloadSize = 0;

        private List<int> _historicDownloadSpeedPerSecond = new List<int>();
        private VideoURL _videoURLDownload = null;
        private String _outputFolder = null;
        private Timer _timerDownload = null;
        
        private bool _isDownloading = false;
        private bool _isDownloadFinish = false;

        public DownloadVideo(VideoURL aVideoURL, String aOutputFolder)
        {
            this._videoURLDownload = aVideoURL;
            this._outputFolder = aOutputFolder;

            this._timerDownload = new Timer();

            this._timerDownload.Elapsed += new ElapsedEventHandler(timerSecond_Tick);
            this._timerDownload.Interval = TIMER_DOWNLOAD_INTERVAL;
        }


        #region Properties
        public string LocalPath
        {
            get
            {
                return Path.Combine(this._outputFolder, String.Format("{0}_{1}.{2}", this._videoURLDownload.Video.Author, 
                    this._videoURLDownload.Video.Title, 
                    this._videoURLDownload.FileExtension));
            }
        }

        public float Lenght
        {
            get { return (float)this._videoURLDownload.Size; }
        }

        public float DownloadedLenght
        {
            get { return (float)this._downloadedSize; }
        }

        public bool IsDownloading
        {
            get { return this._isDownloading && !this._isDownloadFinish; }
        }
        #endregion

        public void Download()
        {
            if (this._isDownloading)
            {
                throw new Exception("Video already downloading");
            }
            this._timerDownload.Start();

            byte[] buffer = new byte[10000];

            Debug.WriteLine("Download started");

            HttpWebRequest webRequest = WebRequest.Create(this._videoURLDownload.DownloadURL) as HttpWebRequest;
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;

            BinaryWriter binWriter = new BinaryWriter(File.Open(this.LocalPath, FileMode.Create));
            BinaryReader binReader = new BinaryReader(webResponse.GetResponseStream());

            while (true)
            {
                int nbByteReads = binReader.Read(buffer, 0, buffer.Length);
                if (nbByteReads == 0) break;

                this._downloadedSize += (ulong)nbByteReads;
                binWriter.Write(buffer, 0, nbByteReads);

            }

            binWriter.Close();
            binReader.Close();


            Debug.WriteLine("Download done");

            this._isDownloadFinish = true;
            this._timerDownload.Stop();
        }

        private void timerSecond_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(String.Format("{0} | {1} \\/ {2}",this._downloadedSize,this._previousDownloadSize,(int)(this._downloadedSize - this._previousDownloadSize)));
            this._historicDownloadSpeedPerSecond.Add((int)(this._downloadedSize - this._previousDownloadSize));
            this._previousDownloadSize = this._downloadedSize;

            this.NotifyObservers();
        }
        /*
        private void DownloadProgress()
        {
             

            float percentage = 0;
            ulong previousSize = 0;
            int historicIndex = 0;
            
            while (true)
            {
                Thread.Sleep(1000);
                int bytePerSecond = (int)(this._downloadedSize - previousSize);

                historicBytePerSecond[historicIndex] = bytePerSecond;

                String update = String.Format("{0}/sec | {1} on {2} downloaded. {3:0.00}%", ConvertByteString(AverageBytePerSecond(historicBytePerSecond)), ConvertByteString(this._downloadedSize), ConvertByteString(this._totalSize), percentage);

                if (this._totalSize > 0)
                {
                    percentage = (float)((this._downloadedSize * 100.0) / this._totalSize);
                }

                base.NotifyObservers();

                //this._backGroundWorker.ReportProgress((int)percentage, update);

                Debug.WriteLine(update);
                historicIndex++;

                previousSize = this._downloadedSize;

                if (historicIndex >= HISTORIC_DOWNLOAD_MAX)
                {
                    historicIndex = 0;
                }
            }*/

        public float AverageDownloadSpeed()
        {
            int speedTotal = 0;
            float averageDownloadSpeed = 0.0f;

            
            this._historicDownloadSpeedPerSecond.Select(speed => { speedTotal += speed; return speed; }).ToList();

            if (_historicDownloadSpeedPerSecond.Count > 0)
            {
                averageDownloadSpeed = (float)speedTotal / (float)this._historicDownloadSpeedPerSecond.Count;
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

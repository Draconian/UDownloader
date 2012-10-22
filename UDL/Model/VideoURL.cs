using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDL.Model.Observer;

namespace UDL.Model
{
    public class VideoURL : Subject
    {
        private static readonly int HISTORIC_DL_MAX = 5;

        //public int iTag { get; set; }
        public String Quality { get; set; }
        public String SIG { get; set; }
        public String Type { get; set; }

        private Video _video = null;
        private ulong _totalSize = 0;
        private ulong _downloadedSize = 0;
        private bool _isDownloading = false;
        private BackgroundWorker _backGroundWorker = null;
        private string _videoURL = null;

        public VideoURL(Video aRelatedVideo)
        {
            this._video = aRelatedVideo;
            
        }

        #region Properties
        public ulong Size
        {
            get { return this._totalSize; }
        }

        public String BaseURL
        {
            get
            {
                return this._videoURL;
            }
            set
            {
                this._videoURL = value;
                this.GetSize();
            }
        }

        public String DownloadURL
        {
            //String downloadURL = this.URL + "&signature=" + this.SIG;
            get { return String.Format("{0}&signature={1}", this.BaseURL, this.SIG); }
        }
        #endregion

        private void GetSize()
        {
            HttpWebResponse webResponse = null;
            HttpWebRequest webRequest = null;

            try
            {
                webRequest = WebRequest.Create(this.DownloadURL) as HttpWebRequest;
                webResponse = webRequest.GetResponse() as HttpWebResponse;

                //Get size
                NameValueCollection headers = webResponse.Headers;
                this._totalSize = Convert.ToUInt64(headers["Content-Length"]);
            }
            catch (Exception e)
            {
                throw new UdlVUrlException(this, e.Message, e);
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }
        }

        public void Download(String aOutputFolder, BackgroundWorker aBackGroundWorker)
        {
            if (_isDownloading)
            {
                throw new Exception("Video already downloading");
            }

            Thread t = new Thread(new ThreadStart(DownloadProgress));
            t.Start();

            this._backGroundWorker = aBackGroundWorker;
            String[] illegalChars = { "/", "?", "<", ">", "\\", ":", "*", "|", "\"" };
            Debug.WriteLine("Download started");
            byte[] buffer = new byte[10000];
            String extension = this.GetExtension();
            String outputFile = String.Format("{0}_{1}.{2}", this._video.Author, this._video.Title, extension);

            foreach (String c in illegalChars)
            {
                outputFile = outputFile.Replace(c, "");
            }

            outputFile = Path.Combine(aOutputFolder, outputFile);

            HttpWebRequest webRequest = WebRequest.Create(this.DownloadURL) as HttpWebRequest;
            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;

            BinaryWriter binWriter = new BinaryWriter(File.Open(outputFile, FileMode.Create));
            BinaryReader binReader = new BinaryReader(webResponse.GetResponseStream());

            //Get size
            NameValueCollection headers = webResponse.Headers;
            this._totalSize = Convert.ToUInt64(headers["Content-Length"]);

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

            t.Abort();
            this._isDownloading = false;
        }

        private void DownloadProgress()
        {
            int percentage = 0;
            ulong previousSize = 0;
            int[] historicBytePerSecond = new int[HISTORIC_DL_MAX];
            int historicIndex = 0;

            while (true)
            {
                Thread.Sleep(1000);
                int bytePerSecond = (int)(this._downloadedSize - previousSize);

                historicBytePerSecond[historicIndex] = bytePerSecond;

                String update = ConvertByteString(AverageBytePerSecond(historicBytePerSecond)) + " " + ConvertByteString(this._downloadedSize) + " / " + ConvertByteString(this._totalSize);

                if (this._totalSize > 0)
                {
                    percentage = (int)((this._downloadedSize * 100) / this._totalSize);
                }

                this._backGroundWorker.ReportProgress(percentage, update);

                Debug.WriteLine(update);
                historicIndex++;

                previousSize = this._downloadedSize;

                if (historicIndex >= HISTORIC_DL_MAX)
                {
                    historicIndex = 0;
                }
            }
        }

        private float AverageBytePerSecond(int[] aHistoricBytePerSecond)
        {
            float bytePerSecondTotal = 0.0f;

            foreach (int bps in aHistoricBytePerSecond)
            {
                bytePerSecondTotal += bps;
            }

            return bytePerSecondTotal / aHistoricBytePerSecond.Length;
        }

        private string GetExtension()
        {
            if (this.Type.Equals("video/webm"))
            {
                return "webm";
            }
            else if (this.Type.Equals("video/mp4"))
            {
                return "mp4";
            }
            else if (this.Type.Equals("video/x-flv"))
            {
                return "flv";
            }
            else if (this.Type.Equals("video/3gpp"))
            {
                return "3gpp";
            }
            else
            {
                throw new Exception("Unkown extension: " + this.Type);
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} | {2}", this.Type, this.Quality, ConvertByteString(this._totalSize));
        }

        public string ConvertByteString(float aSize)
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

    }
}

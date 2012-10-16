using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDL.Model
{
    public class VideoURL
    {
         
        //public int iTag { get; set; }
        public String Quality { get; set; }
        public String URL { get; set; }
        public String SIG { get; set; }
        public String Type { get; set; }

        private Video _video = null;
        private ulong _totalSize = 0;
        private ulong _downloadedSize = 0;


        public VideoURL(Video aRelatedVideo)
        {
            this._video = aRelatedVideo;
        }

        public void Download(String aOutputFolder)
        {
            Thread t = new Thread(new ThreadStart(DownloadProgress));
            t.Start();

            String[] illegalChars = { "/", "?", "<", ">", "\\", ":", "*", "|", "\"" };
            Debug.WriteLine("Download started");
            byte[] buffer = new byte[2048];
            String extension = this.GetExtension();
            String outputFile = String.Format("{0}_{1}.{2}", this._video.Author, this._video.Title, extension);

            foreach (String c in illegalChars)
            {
                outputFile = outputFile.Replace(c, "");
            }

            outputFile = Path.Combine(aOutputFolder, outputFile);

           

            String downloadURL = this.URL + "&signature=" + this.SIG;


            HttpWebRequest webRequest = WebRequest.Create(downloadURL) as HttpWebRequest;
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
        }

        private void DownloadProgress()
        {
            ulong previousSize = 0;
            int[] historicBytePerSecond = new int[3];
            int historicIndex = 0;

            while (true)
            {
                Thread.Sleep(1000);
                int bytePerSecond = (int)(this._downloadedSize - previousSize);

                historicBytePerSecond[historicIndex] = bytePerSecond;

                Debug.WriteLine(ConvertByteString(AverageBytePerSecond(historicBytePerSecond)) + " " + ConvertByteString(this._downloadedSize) + " / " + ConvertByteString(this._totalSize));
                historicIndex++;

                previousSize = this._downloadedSize;

                if (historicIndex >= 3)
                {
                    historicIndex = 0;
                }
            }
        }

        private float AverageBytePerSecond(int[] aHistoricBytePerSecond)
        {

            float bytePerSecondTotal = aHistoricBytePerSecond[0] + aHistoricBytePerSecond[1] + aHistoricBytePerSecond[2];

            return bytePerSecondTotal / 3;
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
                throw new Exception("Unkown extension:" + this.Type);
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.Type, this.Quality);
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

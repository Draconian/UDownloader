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
    public class VideoURL
    {
        //public int iTag { get; set; }
        public String Quality { get; set; }
        public String SIG { get; set; }
        public String Type { get; set; }

        private Video _video = null;
        private string _videoURL = null;
        private ulong _totalSize;

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

        public string FileExtension
        {
            get
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
        }

        public Video Video
        {
            get { return this._video; }
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



        public override string ToString()
        {
            return String.Format("{0} {1} | {2}", this.Type, this.Quality, DownloadVideo.ConvertByteString(this._totalSize));
        }

        

    }
}

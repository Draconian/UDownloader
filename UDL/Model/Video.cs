using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using UDL.Model.Observer;
using UDL.Model.UrlParser;

[assembly: InternalsVisibleTo("UDL Test")]
namespace UDL.Model
{
    public class Video : Subject
    {
        internal static readonly String VIDEO_INFO_URL = "http://www.youtube.com/get_video_info?video_id={0}";

        internal String title = string.Empty;
        internal String author = String.Empty;
        internal String mainURL = string.Empty;
        internal String videoInfoURL = String.Empty;
        internal String videoID = string.Empty;
        internal int length = 0;
        internal List<VideoURL> videoUrls;

        public Video()
        {
            
        }

        #region Properties
        public VideoURL[] VideoURLs
        {
            get { return this.videoUrls.ToArray(); }
        }

        public String Title
        {
            get { return DownloadVideo.FormatFileName(this.title); }
        }

        public String Author
        {
            get { return this.author; }
        }

        public String VideoID
        {
            get { return this.videoID; }
        }

        public int Length
        {
            get { return this.length; }
        }

        #endregion

        public void GetURLs(String aURL)
        {
            this.videoUrls = new List<VideoURL>();
            this.mainURL = aURL;
            this.videoID = this.GetVideoID();
            this.videoInfoURL = this.GetVideoInfoUrl(this.videoID);
            this.AnalyseVideoInfoURL(this.videoInfoURL);

            this.NotifyObservers();
        }

        private String GetVideoID()
        {
            int indexInterogationPoint = this.mainURL.IndexOf('?');

            String v = this.mainURL.Substring(indexInterogationPoint);
            NameValueCollection mainURLParams = HttpUtility.ParseQueryString(v);

            String id = mainURLParams["v"];

            return id;
        }

        private String GetVideoInfoUrl(String aViD)
        {
            Char[] buffer = new Char[2048];
            StreamReader streamReaderWeb = null;
            HttpWebRequest webRequest = null;
            HttpWebResponse webResponse = null;
            StringBuilder webResponseStringBuilder = new StringBuilder();
            int nbCharReads = 0;

            String url = String.Format(VIDEO_INFO_URL, aViD);

            try
            {
                webRequest = WebRequest.Create(url) as HttpWebRequest;
                webResponse = webRequest.GetResponse() as HttpWebResponse;

                streamReaderWeb = new StreamReader(webResponse.GetResponseStream(), UTF8Encoding.UTF8);

                while (true)
                {
                    nbCharReads = streamReaderWeb.Read(buffer, 0, buffer.Length);
                    if (nbCharReads == 0) break;

                    webResponseStringBuilder.Append(new String(buffer, 0, nbCharReads));
                }
            }
            catch (HttpException httpEx)
            {
                throw httpEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }

            return webResponseStringBuilder.ToString();
        }

        private void AnalyseVideoInfoURL(String aURLInfo)
        {
            IUrlParser urlParser = new YT2013Parser(aURLInfo);

            String status = urlParser.extractStatus();

            if (status.Equals("ok"))
            {

                this.title = urlParser.extractTitle();
                this.author = urlParser.extractAuthor();
                this.length = urlParser.extractLengthSeconds();
                this.AnalyseVideoStreamMap(urlParser.extractStreamMap());
            }
            else if(status.Equals("fail"))
            {
                String errno = urlParser.extractErrNo();
                String reason = urlParser.extractReason();

                MessageBox.Show("Error number" + errno + " Reason: " + reason, "Cannot load Youtube Video File"); 

            }

            
        }

        private void AnalyseVideoStreamMap(String aMap)
        {
            IVideoInfoUrlParser[] vidInfoParsers = YT2013VideoInfoParser.Split(aMap);


            foreach(IVideoInfoUrlParser vidInfoParser in vidInfoParsers)
            {
                VideoURL videoURL = new VideoURL(this);
                videoURL.Quality = vidInfoParser.extractQuality();
                videoURL.Type = vidInfoParser.extractType();
                videoURL.SIG = vidInfoParser.extractSig();
                videoURL.BaseURL = vidInfoParser.extractURL();
                this.videoUrls.Add(videoURL);
            }
        }

    }
}

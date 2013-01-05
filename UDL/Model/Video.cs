using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using UDL.Model.Observer;
using UDL.Model.UrlParser;
/*
account_playback_token
ptk
url_encoded_fmt_stream_map
allow_embed
vq
fexp
allow_ratings
keywords
track_embed
view_count
video_verticals
fmt_list
author
muted
length_seconds
pltype
iurlmaxres
has_cc
tmi
ftoken
iurlsd
status
watermark
timestamp
storyboard_spec
plid
endscreen_module
hl
no_get_video_log
avg_rating
title
sendtmp
token
thumbnail_url
video_id
*/
namespace UDL.Model
{
    public class Video : Subject
    {
        private static readonly String VIDEO_INFO_URL = "http://www.youtube.com/get_video_info?video_id={0}";
        private static readonly String URL_VIDEOS = "url_encoded_fmt_stream_map";

        private String _title = string.Empty;
        private String _author = String.Empty;
        private String _mainURL = string.Empty;
        private String _videoInfoURL = String.Empty;
        private String _videoID = string.Empty;
        private List<VideoURL> _videoUrls;

        public Video()
        {
            
        }

        #region Properties
        public VideoURL[] VideoURLs
        {
            get { return this._videoUrls.ToArray(); }
        }

        public String Title
        {
            get { return DownloadVideo.FormatFileName(this._title); }
        }

        public String Author
        {
            get { return this._author; }
        }

        public String VideoID
        {
            get { return this._videoID; }
        }

        #endregion

        public void GetURLs(String aURL)
        {
            this._videoUrls = new List<VideoURL>();
            this._mainURL = aURL;
            this._videoID = this.GetVideoID();
            this._videoInfoURL = this.GetVideoInfoUrl(this._videoID);
            this.AnalyseVideoInfoURL(this._videoInfoURL);

            this.NotifyObservers();
        }

        private String GetVideoID()
        {
            int indexInterogationPoint = this._mainURL.IndexOf('?');

            String v = this._mainURL.Substring(indexInterogationPoint);
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

                this._title = urlParser.extractTitle();
                this._author = urlParser.extractAuthor();

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
                this._videoUrls.Add(videoURL);
            }
        }

    }
}

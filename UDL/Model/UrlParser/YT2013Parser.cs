using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace UDL.Model.UrlParser
{
    public class YT2013Parser : IUrlParser
    {
        protected String videoURL = String.Empty;
        private string authorRegex = "author=(.*?)&";
        private string lengthRegex = "length_seconds=(.*?)&";
        private string titleRegex = "title=(.*?)&";
        private string statusRegex = "status=(.*?)&";
        private string thumbnailUrlRegex = "thumbnail_url=(.*?)&";
        private string streamMapRegex = "url_encoded_fmt_stream_map=(.*?)&";
        private string errnoRegex = "errorcode=(.*?)&";
        private string reasonRegex = "reason=(.*?)&";

        public YT2013Parser(String videoURL)
        {
            this.videoURL = videoURL + "&";
        }

        public String extractAuthor()
        {
            Regex regex = new Regex(this.authorRegex);
            Match match = regex.Match(this.videoURL);

            String author = match.Groups[1].Value;

            author = HttpUtility.UrlDecode(author);

            return author;
        }

        public int extractLengthSeconds()
        {
            Regex regex = new Regex(this.lengthRegex);
            Match match = regex.Match(this.videoURL);

            String length = match.Groups[1].Value;

            return Int32.Parse(length);
        }

        public String extractTitle()
        {
            Regex regex = new Regex(this.titleRegex);
            Match match = regex.Match(this.videoURL);

            String title = match.Groups[1].Value;

            title = HttpUtility.UrlDecode(title);

            return title;
        }

        public String extractStatus()
        {
            Regex regex = new Regex(this.statusRegex);
            Match match = regex.Match(this.videoURL);

            String status = match.Groups[1].Value;

            return status;
        }

        public String extractThumbnailUrl()
        {
            Regex regex = new Regex(this.thumbnailUrlRegex);
            Match match = regex.Match(this.videoURL);

            String thumbUrl = match.Groups[1].Value;

            thumbUrl = HttpUtility.UrlDecode(thumbUrl);

            return thumbUrl;
        }

        public string extractStreamMap()
        {
            Regex regex = new Regex(this.streamMapRegex);
            Match match = regex.Match(this.videoURL);

            String streamMap = match.Groups[1].Value;

            streamMap = HttpUtility.UrlDecode(streamMap);

            return streamMap;
        }

        public string extractErrNo()
        {
            Regex regex = new Regex(this.errnoRegex);
            Match match = regex.Match(this.videoURL);

            String errNo = match.Groups[1].Value;

            return errNo;
        }

        public string extractReason()
        {
            Regex regex = new Regex(this.reasonRegex);
            Match match = regex.Match(this.videoURL);

            String reason = match.Groups[1].Value;

            reason = HttpUtility.UrlDecode(reason);

            return reason;
        }
    }
}

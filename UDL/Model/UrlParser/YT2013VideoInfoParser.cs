using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace UDL.Model.UrlParser
{
    public class YT2013VideoInfoParser : IVideoInfoUrlParser
    {
        private static Char[] videoInfoSplitter = { ',' };

        protected String videoInfoUrl = string.Empty;
        private string typeRegex = "type=(.*?)&";
        private string urlRegex = "url=(.*?)&";
        private string qualityRegex = "quality=(.*?)&";
        private string sigRegex = "sig=(.*?)&";

        public YT2013VideoInfoParser(String videoInfoUrl)
        {
            this.videoInfoUrl = videoInfoUrl + "&";
        }



        public String extractType()
        {
            Regex regex = new Regex(this.typeRegex);
            Match match = regex.Match(this.videoInfoUrl);

            String type = match.Groups[1].Value;

            type = HttpUtility.UrlDecode(type);

            if (type.Contains(";"))
            {
                type = type.Substring(0, type.IndexOf(";")).Trim();
            }

            return type;
        }

        public string extractURL()
        {
            Regex regex = new Regex(this.urlRegex);
            Match match = regex.Match(this.videoInfoUrl);

            String url = match.Groups[1].Value;

            url = HttpUtility.UrlDecode(url);

            return url;
        }

        public string extractQuality()
        {
            Regex regex = new Regex(this.qualityRegex);
            Match match = regex.Match(this.videoInfoUrl);

            String quality = match.Groups[1].Value;

            return quality;
        }

        public string extractSig()
        {
            Regex regex = new Regex(this.sigRegex);
            Match match = regex.Match(this.videoInfoUrl);

            String sig = match.Groups[1].Value;

            return sig;
        }

        public static YT2013VideoInfoParser[] Split(String videoInfo)
        {
            String[] videoInfoParserURL = videoInfo.Split(videoInfoSplitter);

            YT2013VideoInfoParser[] videoInfoParsers = videoInfoParserURL.Select(vInfo => { return new YT2013VideoInfoParser(vInfo); }).ToArray();
            return videoInfoParsers;
        }

    }
}

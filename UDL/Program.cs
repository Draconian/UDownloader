using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using UDL.View;

namespace UDL
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new UDLView());

            /*
            //http://www.youtube.com/v/ZoEOPEkuQ8I?version=3&amp;autohide=1
            //http://www.youtube.com/get_video_info?video_id=PFlKxzKM9Vs
            //http://www.youtube.com/watch?v=sxwAuZn8bes&NR=1&feature=endscreen
            char[] buffer = new char[2048];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.youtube.com/get_video_info?video_id=sxwAuZn8bes");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream webStream = response.GetResponseStream();
            StringBuilder stringBuilder = new StringBuilder();
            
            StreamReader streamReader = new StreamReader(webStream, UTF8Encoding.UTF8);

            while (true)
            {
                int byteReads = streamReader.Read(buffer, 0, buffer.Length);
                if (byteReads == 0) break;



                stringBuilder.Append(new String(buffer,0,byteReads));


            }

            response.Close();
            String url1 = stringBuilder.ToString();



            NameValueCollection queryCollection = HttpUtility.ParseQueryString(url1);


            //String url2 = HttpUtility.UrlDecode(url1);
            //String url3 = HttpUtility.UrlDecode(url2);
            //Debug.WriteLine(url);

/*account_playback_token
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


            foreach (String s in queryCollection.AllKeys)
            {
                String output = String.Format("{0} : {1}", s, queryCollection[s]);
                Debug.WriteLine(output);
            }

            queryCollection = HttpUtility.ParseQueryString(queryCollection["url_encoded_fmt_stream_map"]);

            Debug.WriteLine("*********************");

           foreach (String s in queryCollection.AllKeys)
            {
                String output = String.Format("{0} : {1}", s, queryCollection[s]);
                Debug.WriteLine(output);
            }
           Char[] splitters = { ',' };

           String[] urls = queryCollection["url"].Split(splitters);

           foreach (String s in urls)
           {
               String output = String.Format("{0}",s);
               Debug.WriteLine(output);
           }

            request = (HttpWebRequest)WebRequest.Create("http://r1---cbf01t07.c.youtube.com/videoplayback?upn=_alTtk5MUdU&sparams=cp%2Cid%2Cip%2Cipbits%2Citag%2Cratebypass%2Csource%2Cupn%2Cexpire&fexp=927104%2C922401%2C920704%2C912806%2C927201%2C913546%2C913556%2C925109%2C919003%2C912706%2C900816%2C911112&key=yt1&expire=1350269632&itag=45&ipbits=8&sver=3&ratebypass=yes&mt=1350245462&ip=24.37.196.113&mv=m&source=youtube&ms=tsu&cp=U0hURVJRV19ITENONF9KS0FHOjU5TlhIOHlLT2E0&id=66810e3c492e43c2&signature=341149727562318C751302AA3DCB54D1757C3ABF.9E2430DAE1244C6C48D9B7628F6D848B50227B87&cms_redirect=yes&redirect_counter=2&ir=1");
            response = (HttpWebResponse)request.GetResponse();

            Stream s2 = response.GetResponseStream();

            response.Close();

        */}
    }
}

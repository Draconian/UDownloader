using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UDL.Model;

namespace UDL_Test
{
    [TestClass]
    public class VideoTest
    {
        [TestMethod]
        public void GetVideoIDTest()
        {
            Video v = new Video();
            v.GetURLs("http://www.youtube.com/watch?v=sxwAuZn8bes&NR=1&feature=endscreen");

            PrivateObject accessor = new PrivateObject(v);

            String id = (String)accessor.Invoke("GetVideoID", null);

            //String id = v.GetVideoID();

            Assert.AreEqual("sxwAuZn8bes", id);


        }

        [TestMethod]
        public void GetVideoInfoUrlTest()
        {

        }

        [TestMethod]
        public void TypeParserTest()
        {

            String[] types = TypeParser.Parse(@"video/webm; codecs=""vp8.0, vorbis"",video/mp4; codecs=""avc1.64001F, mp4a.40.2"",video/webm; codecs=""vp8.0, vorbis"",video/x-flv,video/webm; codecs=""vp8.0, vorbis"",video/x-flv,video/mp4; codecs=""avc1.42001E, mp4a.40.2"",video/x-flv,video/3gpp; codecs=""mp4v.20.3, mp4a.40.2"",video/3gpp; codecs=""mp4v.20.3, mp4a.40.2""");


        }

        [TestMethod]
        public void QualityParserTest()
        {

            String[] qualities = QualityParser.Parse(@"hd720,itag=22,hd720,itag=44,large,itag=35,large,itag=43,medium,itag=34,medium,itag=18,medium,itag=5,small,itag=36,small,itag=17,small");


        }
    }
}

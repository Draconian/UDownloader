using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDL.Model;

namespace UDL_Test
{
    [TestClass]
    public class DownloadVideoTest
    {

        [TestMethod]
        public void testCreateLocalPath()
        {
            Video video = new Video();
            video.author = "Test Author";
            video.title = "Test Title";

            VideoURL videoURL = new VideoURL(video);
            videoURL.Type = "video/x-flv";

            DownloadVideo downloadVideo = new DownloadVideo(videoURL, @"C:\VIDEO");
            String localPath = downloadVideo.CreateLocalPath();
            String expected = @"C:\VIDEO\Test Author_Test Title.flv";

            Assert.AreEqual(expected, localPath);
        }
    }
}

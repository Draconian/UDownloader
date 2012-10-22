using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDL.Model
{
    public class UdlVideoException : Exception
    {
        private Video _exVideo = null;

        public UdlVideoException(Video aExVideo, String aMessage)
            : base(aMessage) 
        {
            this._exVideo = aExVideo;
        }

        public UdlVideoException(Video aExVideo, String aMessage, Exception aInnerException)
            : base(aMessage, aInnerException) 
        {
            this._exVideo = aExVideo;
        }

    }

    public class UdlVUrlException : Exception
    {
        private VideoURL _videoURL = null;

        public UdlVUrlException(VideoURL aVideoURL, String aMessage)
            : base(aMessage)
        {
            this._videoURL = aVideoURL;
        }

        public UdlVUrlException(VideoURL aVideoURL, String aMessage, Exception aInnerException)
            : base(aMessage, aInnerException)
        {
            this._videoURL = aVideoURL;
        }

    }



}

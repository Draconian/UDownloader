using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDL.Model.UrlParser;

namespace UDL_Test
{
    [TestClass]
    public class YT2013VideoInfoParserTest
    {
        private String videoInfoURLTest = "type=video%2Fwebm%3B+codecs%3D%22vp8.0%2C+vorbis%22&fallback_host=tc.v17.cache1.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dcp%252Cid%252Cip%252Cipbits%252Citag%252Cratebypass%252Csource%252Cupn%252Cexpire%26key%3Dyt1%26itag%3D45%26expire%3D1357374870%26ratebypass%3Dyes%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26source%3Dyoutube%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26mv%3Dm&sig=B2E24513AAF9EF951F4011F05DB7E26AA764D5D3.9E946F0870DFBD35654A046B0938CED9EF17A192&quality=hd720&itag=45";

        [TestMethod]
        public void TestExtractType()
        {
            YT2013VideoInfoParser videoInfoParser = new YT2013VideoInfoParser(this.videoInfoURLTest);
            String type = videoInfoParser.extractType();

            Assert.AreEqual("video/webm; codecs=\"vp8.0, vorbis\"", type);
        }

        [TestMethod]
        public void TestExtractURL()
        {
            YT2013VideoInfoParser videoInfoParser = new YT2013VideoInfoParser(this.videoInfoURLTest);
            String url = videoInfoParser.extractURL();

            Assert.AreEqual("http://r2---sn-8qu-t0al.c.youtube.com/videoplayback?id=b31c00b999fc6deb&sparams=cp%2Cid%2Cip%2Cipbits%2Citag%2Cratebypass%2Csource%2Cupn%2Cexpire&key=yt1&itag=45&expire=1357374870&ratebypass=yes&newshard=yes&sver=3&ipbits=8&source=youtube&upn=bhi7IfOu-Qc&ip=24.201.54.186&cp=U0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5&ms=au&fexp=920704%2C912806%2C928001%2C922403%2C922405%2C929901%2C913605%2C929104%2C929110%2C913546%2C913556%2C908493%2C908496%2C920201%2C913302%2C919009%2C911116%2C926403%2C901451%2C902556&mt=1357352051&mv=m", url);
        }

        [TestMethod]
        public void TestExtractQuality()
        {
            YT2013VideoInfoParser videoInfoParser = new YT2013VideoInfoParser(this.videoInfoURLTest);
            String quality = videoInfoParser.extractQuality();

            Assert.AreEqual("hd720", quality);
        }

        [TestMethod]
        public void TestExtractSig()
        {
            YT2013VideoInfoParser videoInfoParser = new YT2013VideoInfoParser(this.videoInfoURLTest);
            String sig = videoInfoParser.extractSig();

            Assert.AreEqual("B2E24513AAF9EF951F4011F05DB7E26AA764D5D3.9E946F0870DFBD35654A046B0938CED9EF17A192", sig); 
        }

        [TestMethod]
        public void TestSplit()
        {
            String videoURLMap = "type=video%2Fwebm%3B+codecs%3D%22vp8.0%2C+vorbis%22&fallback_host=tc.v17.cache1.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dcp%252Cid%252Cip%252Cipbits%252Citag%252Cratebypass%252Csource%252Cupn%252Cexpire%26key%3Dyt1%26itag%3D45%26expire%3D1357374870%26ratebypass%3Dyes%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26source%3Dyoutube%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26mv%3Dm&sig=B2E24513AAF9EF951F4011F05DB7E26AA764D5D3.9E946F0870DFBD35654A046B0938CED9EF17A192&quality=hd720&itag=45,type=video%2Fmp4%3B+codecs%3D%22avc1.64001F%2C+mp4a.40.2%22&fallback_host=tc.v6.cache3.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dcp%252Cid%252Cip%252Cipbits%252Citag%252Cratebypass%252Csource%252Cupn%252Cexpire%26key%3Dyt1%26itag%3D22%26expire%3D1357374870%26ratebypass%3Dyes%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26source%3Dyoutube%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26mv%3Dm&sig=10D2BE7B2E1E4C20C58F347F9753C7DE0918F431.A67CC5523B144AA66759EFD0E5562F221F47EED8&quality=hd720&itag=22,type=video%2Fwebm%3B+codecs%3D%22vp8.0%2C+vorbis%22&fallback_host=tc.v8.cache1.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dcp%252Cid%252Cip%252Cipbits%252Citag%252Cratebypass%252Csource%252Cupn%252Cexpire%26key%3Dyt1%26itag%3D44%26expire%3D1357374870%26ratebypass%3Dyes%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26source%3Dyoutube%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26mv%3Dm&sig=98C2A7E18BF110913A61DEFE81EE85E7D1B28848.1C91850F2BEA8E4657527D71E0401446D77AFFE7&quality=large&itag=44,type=video%2Fx-flv&fallback_host=tc.v6.cache1.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dalgorithm%252Cburst%252Ccp%252Cfactor%252Cid%252Cip%252Cipbits%252Citag%252Csource%252Cupn%252Cexpire%26burst%3D40%26itag%3D35%26key%3Dyt1%26factor%3D1.25%26algorithm%3Dthrottle-factor%26expire%3D1357374870%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26mv%3Dm%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26source%3Dyoutube&sig=1ECDCFFF92BAD96016829E8270727C34D94D0AAE.993EEA019AE2EDCA93C5EB91CA552431FFAF3CA7&quality=large&itag=35,type=video%2Fwebm%3B+codecs%3D%22vp8.0%2C+vorbis%22&fallback_host=tc.v13.cache2.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dcp%252Cid%252Cip%252Cipbits%252Citag%252Cratebypass%252Csource%252Cupn%252Cexpire%26key%3Dyt1%26itag%3D43%26expire%3D1357374870%26ratebypass%3Dyes%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26source%3Dyoutube%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26mv%3Dm&sig=697BCFF7732ECA1630570B75787762FCE857E07A.1D8B97630E551DBD146911DE172D18C8823CE6A7&quality=medium&itag=43,type=video%2Fx-flv&fallback_host=tc.v10.cache8.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dalgorithm%252Cburst%252Ccp%252Cfactor%252Cid%252Cip%252Cipbits%252Citag%252Csource%252Cupn%252Cexpire%26burst%3D40%26itag%3D34%26key%3Dyt1%26factor%3D1.25%26algorithm%3Dthrottle-factor%26expire%3D1357374870%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26mv%3Dm%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26source%3Dyoutube&sig=36214072A2FDA9D7FF828279AC2FCBC7E93BC90C.8384D6724A15ACD48481522B25D0257C0890803C&quality=medium&itag=34,type=video%2Fmp4%3B+codecs%3D%22avc1.42001E%2C+mp4a.40.2%22&fallback_host=tc.v7.cache3.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dcp%252Cid%252Cip%252Cipbits%252Citag%252Cratebypass%252Csource%252Cupn%252Cexpire%26key%3Dyt1%26itag%3D18%26expire%3D1357374870%26ratebypass%3Dyes%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26source%3Dyoutube%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26mv%3Dm&sig=CA126BA05A0C48176A3BCC8F689504F1614A8C23.61EE06F15E590CE74D7B20A4F4166935C2DCBEAE&quality=medium&itag=18,type=video%2Fx-flv&fallback_host=tc.v20.cache4.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dalgorithm%252Cburst%252Ccp%252Cfactor%252Cid%252Cip%252Cipbits%252Citag%252Csource%252Cupn%252Cexpire%26burst%3D40%26itag%3D5%26key%3Dyt1%26factor%3D1.25%26algorithm%3Dthrottle-factor%26expire%3D1357374870%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26mv%3Dm%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26source%3Dyoutube&sig=63BC1A780B272B4AD5508DD6E2A67B7C19738F7D.6DF7E5F2FF7351DF7219CCD2CD4A83BC8EFC7F2A&quality=small&itag=5,type=video%2F3gpp%3B+codecs%3D%22mp4v.20.3%2C+mp4a.40.2%22&fallback_host=tc.v17.cache2.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dalgorithm%252Cburst%252Ccp%252Cfactor%252Cid%252Cip%252Cipbits%252Citag%252Csource%252Cupn%252Cexpire%26burst%3D40%26itag%3D36%26key%3Dyt1%26factor%3D1.25%26algorithm%3Dthrottle-factor%26expire%3D1357374870%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26mv%3Dm%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26source%3Dyoutube&sig=03D500DC1FA1BEA9D6DBF73CA93F9A98B005C046.09C979AEFE2F3A9E6013F0021D1340DA3B3160F9&quality=small&itag=36,type=video%2F3gpp%3B+codecs%3D%22mp4v.20.3%2C+mp4a.40.2%22&fallback_host=tc.v17.cache1.c.youtube.com&url=http%3A%2F%2Fr2---sn-8qu-t0al.c.youtube.com%2Fvideoplayback%3Fid%3Db31c00b999fc6deb%26sparams%3Dalgorithm%252Cburst%252Ccp%252Cfactor%252Cid%252Cip%252Cipbits%252Citag%252Csource%252Cupn%252Cexpire%26burst%3D40%26itag%3D17%26key%3Dyt1%26factor%3D1.25%26algorithm%3Dthrottle-factor%26expire%3D1357374870%26newshard%3Dyes%26sver%3D3%26ipbits%3D8%26mv%3Dm%26upn%3Dbhi7IfOu-Qc%26ip%3D24.201.54.186%26cp%3DU0hUTFNSUl9MSkNONF9LTFZJOmxvTXU5ZlpHeGV5%26ms%3Dau%26fexp%3D920704%252C912806%252C928001%252C922403%252C922405%252C929901%252C913605%252C929104%252C929110%252C913546%252C913556%252C908493%252C908496%252C920201%252C913302%252C919009%252C911116%252C926403%252C901451%252C902556%26mt%3D1357352051%26source%3Dyoutube&sig=0838C1C3EBA65320E9696D608D0A599CACF13A60.9804F41DCBD29CDE3A74652827135CD59C77F8BA&quality=small&itag=17";

            Object[] maps = YT2013VideoInfoParser.Split(videoURLMap);

            Assert.AreEqual(10, maps.Length);
        }
        
    }
}

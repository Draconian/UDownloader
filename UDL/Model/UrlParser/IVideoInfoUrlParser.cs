using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDL.Model.UrlParser
{
    interface IVideoInfoUrlParser
    {
        string extractType();
        string extractURL();
        string extractQuality();
        string extractSig();
    }
}

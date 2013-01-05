using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDL.Model.UrlParser
{
    interface IUrlParser
    {
        string extractAuthor();
        int extractLengthSeconds();
        string extractTitle();
        string extractStatus();
        string extractThumbnailUrl();
        string extractStreamMap();
        string extractErrNo();
        string extractReason();
    }
}

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
using UDL.Controller;
using UDL.View;

namespace UDL
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new UDLController();
        }
    }
}

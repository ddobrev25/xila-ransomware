using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace xila_2._0
{
    internal class InfoGatherer
    {
        public string GetPublicIPv4Address()
        {
            WebClient wc = new WebClient();
            string webData = wc.DownloadString("https://www.myip.com/");
            int startPos = webData.LastIndexOf("<span id=\"ip\">") + "<span id=\"ip\">".Length;
            int length = webData.IndexOf("</span>") - startPos;
            return webData.Substring(startPos, length);
        }
    }
}

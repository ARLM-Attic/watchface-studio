using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WatchfaceStudio
{
    public static class UpdateChecker
    {
        public static string CodePlexUrl = "https://watchfacestudio.codeplex.com/releases/";
        public static Regex VersionGetter = new Regex(@" v([\d]+\.[\d]+)");
        public static Regex TagRemover = new Regex(@"\<[\/\s\w=""']+\>");
        
        public static void CheckForUpdates(out string version, out string releaseNotes)
        {
            using (var wc = new WebClient())
            {
                var str = wc.DownloadString(CodePlexUrl);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(str);
                version = VersionGetter.Match(doc.GetElementbyId("ReleaseLinkStable0").InnerText).Groups[1].Value;
                releaseNotes = WebUtility.HtmlDecode(TagRemover.Replace(doc.GetElementbyId("ReleaseNotes").InnerHtml.Replace("<li>", "* "), string.Empty).TrimStart());
                
            }
        }
    }
}

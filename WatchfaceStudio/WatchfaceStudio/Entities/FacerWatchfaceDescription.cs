using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public class FacerWatchfaceDescription
    {
        public static string AppBuild = "0.90.1";

        private string _id;
        private string _title;
        private string _build = AppBuild;
        private int _build_int = 50;

        public string id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public string build { get { return _build; } set { _build = value; } }
        public int build_int { get { return _build_int; } set { _build_int = value; } }
    }
}

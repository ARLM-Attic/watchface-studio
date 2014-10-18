using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public class FacerCustomFont
    {
        private PrivateFontCollection _pfc;
        public FontFamily FontFamily {get; set;}
        public byte[] FileBytes;

        public FacerCustomFont(string path)
        {
            _pfc = new PrivateFontCollection();
            _pfc.AddFontFile(path);
            FontFamily = _pfc.Families.Last();
            FileBytes = File.ReadAllBytes(path);
        }
    }
}

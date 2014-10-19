using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace WatchfaceStudio.Entities
{
    public class FacerCustomFont
    {
        private PrivateFontCollection _pfc;
        public FontFamily FontFamily {get; set; }
        private FontStyle _fontStyle;
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
        }

        public byte[] FileBytes;

        public FacerCustomFont(string path)
        {
            _pfc = new PrivateFontCollection();
            _pfc.AddFontFile(path);
            FontFamily = _pfc.Families.Last();
            _fontStyle = default(FontStyle);
            while (!FontFamily.IsStyleAvailable(_fontStyle))
                _fontStyle++;
            FileBytes = File.ReadAllBytes(path);
        }
    }
}

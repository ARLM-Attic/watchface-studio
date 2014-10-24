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
        private FontStyle _regularFontStyle;
        public FontStyle RegularFontStyle
        {
            get { return _regularFontStyle; }
        }

        public byte[] FileBytes;

        public FacerCustomFont(string path)
        {
            _pfc = new PrivateFontCollection();
            _pfc.AddFontFile(path);
            FontFamily = _pfc.Families.Last();
            _regularFontStyle = default(FontStyle);
            while (!FontFamily.IsStyleAvailable(_regularFontStyle))
                _regularFontStyle++;
            FileBytes = File.ReadAllBytes(path);
        }

        public FontStyle GetAvailableFontStyle(FontStyle wantedFontStyle)
        {
            var suggestedFontStyle = _regularFontStyle | wantedFontStyle;
            if (!FontFamily.IsStyleAvailable(suggestedFontStyle))
                return _regularFontStyle;
            return suggestedFontStyle;
        }
    }
}

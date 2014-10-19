using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Imaging
{
    public static class DrawingCalculations
    {
        public static Size GetContainedSize(Size obj, Size container)
        {
            //if it fits do nothing
            if (obj.Width * obj.Height <= container.Width * container.Height)
                return obj;

            return GetZoomSize(obj, container);
        }

        public static Size GetZoomSize(Size obj, Size container)
        {
            //if it fits then zoom
            var zoomSize = new Size();

            if (obj.Width > obj.Height) //wide
            {
                zoomSize.Width = container.Width;
                zoomSize.Height = (int)((float)obj.Height / obj.Width * container.Width);
            }
            else
            {
                zoomSize.Width = (int)((float)obj.Width / obj.Height * container.Height);
                zoomSize.Height = container.Height;
            }

            return zoomSize;
        }

        public static float DrawStringOnBaseline(this Graphics g, string s, Font f, Brush b, int x, int y, StringFormat format)
        {
            float baselineOffset = f.SizeInPoints / f.FontFamily.GetEmHeight(f.Style) * f.FontFamily.GetCellAscent(f.Style);
            float baselineOffsetPixels = g.DpiY / 72f * baselineOffset;

            //g.DrawString(s, f, b, new Point(x, y + (int)(baselineOffsetPixels + 0.5f)), format);
            g.DrawString(s, f, b, x, y + (int)(baselineOffsetPixels - 0.5f), format);//StringFormat.GenericTypographic); // ;//format);

            return (int)(baselineOffsetPixels - 0.5f);
        }
    }
}

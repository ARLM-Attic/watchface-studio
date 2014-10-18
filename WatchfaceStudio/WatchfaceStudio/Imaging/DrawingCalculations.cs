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
    }
}

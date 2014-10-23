using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public enum EWatchType
    {
        Moto_360 = 0,
        LG_G_Watch = 1,
        LG_G_Watch_R = 2,
        Samsung_Gear_Live = 3
    }

    public static class WatchType
    {
        public static Dictionary<EWatchType, Bitmap> Masks;
        public static Dictionary<EWatchType, Size> Dimensions;

        static WatchType()
        {
            Masks = new Dictionary<EWatchType, Bitmap>();
            Dimensions = new Dictionary<EWatchType, Size>();

            //Moto 360
            var moto360face = new Bitmap(320, 290);
            var mask = new Bitmap(320, 320);
            using (var gm = Graphics.FromImage(moto360face))
            using (var g = Graphics.FromImage(mask))
            {
                gm.Clear(Color.Transparent);
                gm.FillEllipse(Brushes.Black, 0, 0, mask.Width, mask.Height);
                g.Clear(Color.Transparent);
                g.DrawImage(moto360face, 0, 0);
            }
            Masks.Add(EWatchType.Moto_360, mask);
            Dimensions.Add(EWatchType.Moto_360, new Size(320,320));

            // Samsung Gear Live
            Dimensions.Add(EWatchType.Samsung_Gear_Live, new Size(320, 320));

            // LG G-Watch R
            mask = new Bitmap(320, 320);
            using (var g = Graphics.FromImage(mask))
            {
                g.Clear(Color.Transparent);
                g.FillEllipse(Brushes.Black, 0, 0, mask.Width, mask.Height);
            }
            Masks.Add(EWatchType.LG_G_Watch_R, mask);
            Dimensions.Add(EWatchType.LG_G_Watch_R, new Size(320, 320));

            // LG G-Watch
            Dimensions.Add(EWatchType.LG_G_Watch, new Size(280, 280));
        }
    }
}

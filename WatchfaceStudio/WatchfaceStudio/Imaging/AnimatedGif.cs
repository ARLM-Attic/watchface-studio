using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;

namespace WatchfaceStudio.Imaging
{
    public class AnimatedGif
    {
        private const int PropertyTagFrameDelay = 0x5100;
        private const int PropertyTagLoopCount = 0x5101;

        public readonly List<AnimatedGifFrame> Frames;
        public readonly int LoopCount; //0 means infinte

        public bool IsGif(string path)
        {
            var fs = File.OpenRead(path);
            var magicBytes = new byte[3];
            fs.Read(magicBytes, 0, magicBytes.Length);
            fs.Close();
            return magicBytes[0] == 'G' && magicBytes[1] == 'I' && magicBytes[2] == 'F';
        }

        public AnimatedGif(string path)
        {
            if (!IsGif(path))
                throw new ArgumentException("The specified file is not a GIF.", "path");
            using (var image = Image.FromFile(path))
            {
                Frames = new List<AnimatedGifFrame>();
                var frameCount = image.GetFrameCount(FrameDimension.Time);
                LoopCount = BitConverter.ToInt32(image.GetPropertyItem(PropertyTagLoopCount).Value, 0);
                var durations = image.GetPropertyItem(PropertyTagFrameDelay).Value; //actually an int32 array
                for (var frame = 0; frame < frameCount; frame++)
                {
                    if (frame > 0)
                        image.SelectActiveFrame(FrameDimension.Time, frame);
                    var duration = BitConverter.ToInt32(durations, 4 * frame);
                    Frames.Add(new AnimatedGifFrame(new Bitmap(image), duration));
                }
            }
        }
    }

    public class AnimatedGifFrame
    {
        public readonly Image Frame;
        public readonly int Duration;

        internal AnimatedGifFrame(Image image, int duration)
        {
            Frame = image; 
            Duration = duration;
        }
    }
}

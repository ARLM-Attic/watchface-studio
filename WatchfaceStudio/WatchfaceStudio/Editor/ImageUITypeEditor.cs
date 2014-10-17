using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WatchfaceStudio.Editor
{
    public class ImageUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.None;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            var g = e.Graphics;
            Image img;

            if (e.Value == null || !EditorContext.SelectedWatchface.Images.TryGetValue(e.Value.ToString(), out img))
            {
                //Draw X
                g.DrawLine(Pens.Black, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left + e.Bounds.Width - 1, e.Bounds.Top + e.Bounds.Height - 1);
                g.DrawLine(Pens.Black, e.Bounds.Width - 1, e.Bounds.Top, e.Bounds.Left, e.Bounds.Top + e.Bounds.Height - 1);
            }
            else
            {
                if (img.Width > img.Height) //[_____] / [_]
                {
                    var newHeight = (int)(img.Height / img.Width * e.Bounds.Width);
                    g.DrawImage(img, new Rectangle(e.Bounds.Left, e.Bounds.Height / 2 - newHeight / 2 + 1, e.Bounds.Width, newHeight));
                }
                else if (img.Height >= img.Width) //[]
                {
                    var newWidth = (int)(img.Width / img.Height * e.Bounds.Height);
                    g.DrawImage(img, new Rectangle(e.Bounds.Width / 2 - newWidth / 2 + 1, e.Bounds.Top, newWidth, e.Bounds.Height));
                }
                else
                {
                    g.DrawImage(img, e.Bounds);
                }
                
            }
        }
    }
}

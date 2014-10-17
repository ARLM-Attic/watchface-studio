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
    public class ColorUITypeEditor : UITypeEditor
    {
        private static Image Checkers = CreateCheckers();

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (svc != null)
            {
                Color color = Color.FromArgb(int.Parse((value ?? 0).ToString()));
                
                using (var form = new ColorDialogForm(color))
                {
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        var returnedColor = form.Color;
                        var colorInt = returnedColor.ToArgb();
                        return context.PropertyDescriptor.PropertyType == typeof(int?) ? colorInt : (object)colorInt.ToString();
                    }
                }
            }

            return value;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public static Image CreateCheckers()
        {
            var bmp = new Bitmap(16, 16);

            using (var g = Graphics.FromImage(bmp))
            using (var brush1 = new SolidBrush(Color.LightGray))
            using (var brush2 = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush1, 0, 0, 8, 8);
                g.FillRectangle(brush1, 8, 8, 8, 8);
                g.FillRectangle(brush2, 8, 0, 8, 8);
                g.FillRectangle(brush2, 0, 8, 8, 8);
            }

            return bmp;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            var g = e.Graphics;

            if (e.Value == null)
            {
                //Draw X
                g.DrawLine(Pens.Black, e.Bounds.Left, e.Bounds.Top, e.Bounds.Width - 1, e.Bounds.Height - 1);
                g.DrawLine(Pens.Black, e.Bounds.Width - 1, e.Bounds.Top, e.Bounds.Left, e.Bounds.Height - 1);
            }
            else
            {
                var strValue = e.Value.ToString();

                if (strValue.Contains("#"))
                {
                    g.DrawString("Σ", SystemFonts.DefaultFont, Brushes.Black, e.Bounds.Location);
                }
                else
                {
                    var color = Color.FromArgb(int.Parse(strValue));

                    if (color.A < 255)
                    {
                        g.DrawImage(Checkers, e.Bounds);
                    }

                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                }
            }
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds);
        }
    }
}

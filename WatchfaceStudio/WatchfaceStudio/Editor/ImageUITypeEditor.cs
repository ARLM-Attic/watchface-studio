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
            return UITypeEditorEditStyle.None; //TODO: convert to dropdown
        }

        /*public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
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
        }*/

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
                g.DrawLine(Pens.Black, e.Bounds.Left, e.Bounds.Top, e.Bounds.Width - 1, e.Bounds.Height - 1);
                g.DrawLine(Pens.Black, e.Bounds.Width - 1, e.Bounds.Top, e.Bounds.Left, e.Bounds.Height - 1);
            }
            else
            {
                g.DrawImage(img, e.Bounds);
            }
        }
    }
}

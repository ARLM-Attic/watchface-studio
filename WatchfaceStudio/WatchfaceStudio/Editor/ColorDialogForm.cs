using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchfaceStudio.Editor
{
    public partial class ColorDialogForm : Form
    {
        public Color Color;

        public ColorDialogForm(Color color)
        {
            Color = color;

            InitializeComponent();
        }

        private void ColorDialogForm_Load(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog {Color = Color})
            {
                DialogResult = dlg.ShowDialog();
                Color = dlg.Color;
                Close();
            }
        }
    }
}

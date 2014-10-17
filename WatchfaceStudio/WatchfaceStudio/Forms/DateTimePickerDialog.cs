using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchfaceStudio.Forms
{
    public partial class DateTimePickerDialog : Form
    {
        public DateTime DateTime = DateTime.Now;

        public DateTimePickerDialog()
        {
            InitializeComponent();

            dateTimePicker.Value = DateTime;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DateTime = dateTimePicker.Value;
        }

        public static DialogResult ShowDialog(ref DateTime dateTime)
        {
            var form = new DateTimePickerDialog
            {
                DateTime = dateTime
            };
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
                dateTime = form.DateTime;
            return result;
        }
    }
}

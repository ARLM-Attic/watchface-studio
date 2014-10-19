using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WatchfaceStudio.Editor
{
    public class DateTimeIntTypeEditor : DateTimeEditor
    {
        private IWindowsFormsEditorService _svc;
        private MonthCalendar _calendar = new MonthCalendar { MaxSelectionCount = 1 };

        public DateTimeIntTypeEditor()
        {
            _calendar.DateChanged += _calendar_DateChanged;
        }

        void _calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            _svc.CloseDropDown();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var _svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (_svc != null)
            {
                var inDate = DateTime.FromBinary((long)((int)value));
                _calendar.SetDate(inDate);

                _svc.DropDownControl(_calendar);
                var outDate = _calendar.SelectionStart;
                value = (int)outDate.ToBinary();
            }
            return value;
        }
    }
}

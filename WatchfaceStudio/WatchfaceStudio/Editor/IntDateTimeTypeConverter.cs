using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Editor
{
    public class IntDateTimeTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);// false;
        }
        
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is int)
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMinutes((int)value).ToString("MM/dd/yyy HH:mm"); // DateTime.FromBinary((int)value).ToString("MM/dd/yyy HH:mm");

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

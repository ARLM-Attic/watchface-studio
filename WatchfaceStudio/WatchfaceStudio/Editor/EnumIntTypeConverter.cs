using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Editor
{
    public class EnumTypeConverter<TSource, TEnum> : TypeConverter where TEnum : struct, IConvertible
    {
        public Dictionary<TSource, string> EnumDictionary;
        public Type EnumType;

        public EnumTypeConverter() 
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }
            EnumType = typeof(TEnum);
            EnumDictionary = new Dictionary<TSource,string>();
            foreach (var val in Enum.GetValues(EnumType))
                EnumDictionary.Add((TSource)GetKey(val), Enum.Parse(EnumType, val.ToString()).ToString());
        }

        private static object GetKey(object value)
        {
            if (Equals(typeof(TSource),typeof(string)))
            {
                return ((int)value).ToString();
            }
            return value;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(EnumDictionary.Values);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                return (TSource)GetKey((int)Enum.Parse(EnumType, value.ToString()));
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return EnumDictionary[(TSource)GetKey((int)Enum.Parse(EnumType, value.ToString()))];

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

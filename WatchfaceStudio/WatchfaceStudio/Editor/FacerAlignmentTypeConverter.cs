using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchfaceStudio.Entities;

namespace WatchfaceStudio.Editor
{
    public class FacerAlignmentTypeConverter : TypeConverter
    {
        private static Dictionary<Type, Dictionary<int, string>> Alignments;

            static FacerAlignmentTypeConverter()
            {
                Alignments = new Dictionary<Type, Dictionary<int, string>>();
                
                var imgDic = new Dictionary<int, string>();
                foreach (int val in Enum.GetValues(typeof(FacerImageAlignment)))
                    imgDic.Add(val, Enum.Parse(typeof(FacerImageAlignment), val.ToString()).ToString());
                Alignments.Add(typeof(FacerImageAlignment), imgDic);

                var txtDic = new Dictionary<int, string>();
                foreach (int val in Enum.GetValues(typeof(FacerTextAlignment)))
                    txtDic.Add(val, Enum.Parse(typeof(FacerTextAlignment), val.ToString()).ToString());
                Alignments.Add(typeof(FacerTextAlignment), txtDic);
                
            }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var layerType = ((FacerLayer)(context.Instance)).type;
            var aType = layerType == "text" ? typeof(FacerTextAlignment) : typeof(FacerImageAlignment);

            return new StandardValuesCollection(Alignments[aType].Values);
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
            var layerType = ((FacerLayer)(context.Instance)).type;
            var aType = layerType == "text" ? typeof(FacerTextAlignment) : typeof(FacerImageAlignment);

            if (value is string)
            {
                return (int)Enum.Parse(aType, value.ToString());
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (context != null)
            {
                var layerType = ((FacerLayer)(context.Instance)).type;
                var aType = layerType == "text" ? typeof(FacerTextAlignment) : typeof(FacerImageAlignment);

                if (destinationType == typeof(string))
                    return Alignments[aType][(int)Enum.Parse(aType, value.ToString())];
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

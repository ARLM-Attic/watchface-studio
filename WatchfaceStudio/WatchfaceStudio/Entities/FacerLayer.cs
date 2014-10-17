using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using WatchfaceStudio.Editor;

namespace WatchfaceStudio.Entities
{
    public class FacerLayer
    {
        private DynamicCustomTypeDescriptor _dctd = null;
        
        private string _type;
        private int _id;

        private string _hash;
        private bool? _is_tinted;
        private int? _tint_color;

        private string _x;
        private string _y;
        private string _r;
        private string _opacity;
        private bool _low_power;

       
        public FacerLayer()
        {
            _dctd = ProviderInstaller.Install(this);
            _dctd.PropertySortOrder = CustomSortOrder.DescendingById;
            _dctd.CategorySortOrder = CustomSortOrder.DescendingById;
        }


        [Category("Facer"), DisplayName("Layer Type"), ReadOnly(true), Id(0, 99)]
        public string type { 
            get { return _type; }
            set { 
                _type = value;
                if (_type != "image")
                {
                    _dctd.RemoveProperty("hash");
                    _dctd.RemoveProperty("is_tinted");
                    _dctd.RemoveProperty("tint_color");
                }
                else
                {
                    _dctd.RemoveProperty("color");
                }

                if (_type != "text")
                {
                    _dctd.RemoveProperty("text");
                    _dctd.RemoveProperty("size");
                    _dctd.RemoveProperty("font_family");
                    _dctd.RemoveProperty("font_hash");
                    _dctd.RemoveProperty("bold");
                    _dctd.RemoveProperty("italic");
                    _dctd.RemoveProperty("transform");
                    _dctd.RemoveProperty("bgcolor");
                    _dctd.RemoveProperty("low_power_color");
                }
                else
                {
                    _dctd.RemoveProperty("width");
                    _dctd.RemoveProperty("height");
                }

                if (_type != "shape")
                {
                    _dctd.RemoveProperty("shape_type");
                    _dctd.RemoveProperty("radius");
                    _dctd.RemoveProperty("sides");
                    _dctd.RemoveProperty("shape_opt");
                    _dctd.RemoveProperty("stroke_size");
                }
                else
                {
                    _dctd.RemoveProperty("alignment");

                    var shapeProp = _dctd.GetProperty("shape_type");
                    foreach (int enumValue in Enum.GetValues(typeof(FacerShapeType)))
                    {
                        shapeProp.StatandardValues.Add(new StandardValueAttribute(new Nullable<int>(enumValue), ((FacerShapeType)enumValue).ToString()));
                    }
                }
            } 
        }
        [Category("Facer"), DisplayName("Id"), ReadOnly(true), Id(0, 99)]
        public int id { get { return _id; } set { _id = value; } }

        [Category("Image"), DisplayName("Image"), 
        TypeConverter(typeof(WatchfaceImageTypeConverter)),
        Editor(typeof(ImageUITypeEditor), typeof(UITypeEditor)), Id(0, 90)]
        public string hash { get { return _hash; } set { _hash = value; } }

        [Category("Image"), DisplayName("Is Tinted"), Id(0, 90)]
        public bool? is_tinted { get { return _is_tinted; } set { _is_tinted = value; } }
        [Category("Image"), DisplayName("Tint Color"), Editor(typeof(ColorUITypeEditor),typeof(UITypeEditor)), Id(0, 90)]
        public int? tint_color { get { return _tint_color; } set { _tint_color = value; } }

        // IMAGE & SHAPE
        [Category("Size"), DisplayName("Width"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor)), Id(0, 80)]
        public string width { get; set; } //on shape (square & line)
        [Category("Size"), DisplayName("Height"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor)), Id(0, 80)]
        public string height { get; set; } //on shape (square & line)

        [Category("Placement"), DisplayName("X Offset"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor)), Id(0, 2)]
        public string x { get { return _x; } set { _x = value; } }
        [Category("Placement"), DisplayName("Y Offset"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor)), Id(0, 2)]
        public string y { get { return _y; } set { _y = value; } }
        [Category("Placement"), DisplayName("Rotation"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor)), Id(0, 2)]
        public string r { get { return _r; } set { _r = value; } }
        [Category("Placement"), DisplayName("Opacity"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor)), Id(0, 2)]
        public string opacity { get { return _opacity; } set { _opacity = value; } }
        [Category("Placement"), DisplayName("Display when Dimmed"), Id(0, 2)]
        public bool low_power { get { return _low_power; } set { _low_power = value; } }
       
        // IMAGE & TEXT
        [Category("Placement"), DisplayName("Alignment"), TypeConverter(typeof(FacerAlignmentTypeConverter)), Id(0, 2)]
        public int? alignment { get; set; }

        // SHAPE
        [Category("Shape"), DisplayName("Shape Type"), TypeConverter(typeof(EnumTypeConverter<int, FacerShapeType>))]
        public int? shape_type { get; set; } //circle, square, polygon, line, triangle
        //TODO: add showing/hiding fields based on shape type
        [Category("Shape"), DisplayName("Radius"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor))]
        public string radius { get; set; } //circle, polygon & triangle
        [Category("Shape"), DisplayName("Sides"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor))]
        public string sides { get; set; } //polygon
        [Category("Shape"), DisplayName("Shape Options"), TypeConverter(typeof(EnumTypeConverter<string, FacerShapeOptions>))]
        public string shape_opt { get; set; } //0-fill, 1-stroke
        [Category("Shape"), DisplayName("Stroke Size")]
        public string stroke_size { get; set; }
        
        // SHAPE & TEXT
        [Category("Color"), DisplayName("Color"), Editor(typeof(ColorUITypeEditor), typeof(UITypeEditor))]
        public string color { get; set; }
        

        // TEXT
        [Category("Text Related"), DisplayName("Text"), Editor(typeof(ExpressionTypeEditor), typeof(UITypeEditor))]
        public string text { get; set; }
        [Category("Text Related"), DisplayName("Font Size")]
        public string size { get; set; }
        [Category("Text Related"), DisplayName("Font Family"), TypeConverter(typeof(EnumTypeConverter<int, FacerFont>))]
        public int? font_family { get; set; }
        [Category("Text Related"), DisplayName("Custom Font"), TypeConverter(typeof(WatchfaceFontTypeConverter))]
        public string font_hash { get; set; } //font-family=9
        [Category("Text Related"), DisplayName("Is Bold")]
        public bool? bold { get; set; }
        [Category("Text Related"), DisplayName("Is Italic")]
        public bool? italic { get; set; }
        [Category("Text Related"), DisplayName("Transform")]
        public int? transform { get; set; } //0-none, 1-uppercase, 2-lowercase
        [Category("Text Related"), DisplayName("Background Color"), Editor(typeof(ColorUITypeEditor), typeof(UITypeEditor))]
        public string bgcolor { get; set; }
        [Category("Text Related"), DisplayName("Dimmed Color"), Editor(typeof(ColorUITypeEditor), typeof(UITypeEditor))]
        public string low_power_color { get; set; }    
    }
}

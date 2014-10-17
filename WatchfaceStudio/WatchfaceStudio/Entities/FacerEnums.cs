using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public enum FacerImageAlignment
    {
        TopLeft = 0,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public enum FacerTextAlignment
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    public enum FacerTextTransform
    {
        None = 0,
        AllUppercase = 1,
        AllLowercase = 2
    }

    public enum FacerFont
    {
        RobotoThin = 0,
        RobotoLight = 1,
        RobotoLightCondensed = 2,
        Roboto = 3,
        RobotoBlack = 4,
        RobotoCondensed = 5,
        RobotoSlabThin = 6,
        RobotoSlabLight = 7,
        RobotoSlab = 8,

        Custom = 9,

        [Browsable(false)]
        RobotoThin_Bold = 100,
        [Browsable(false)]
        RobotoLight_Bold = 101,
        [Browsable(false)]
        RobotoLightCondensed_Bold = 102,
        [Browsable(false)]
        Roboto_Bold = 103,
        [Browsable(false)]
        RobotoBlack_Bold = 104,
        [Browsable(false)]
        RobotoCondensed_Bold = 105,
        [Browsable(false)]
        RobotoSlabThin_Bold = 106,
        [Browsable(false)]
        RobotoSlabLight_Bold = 107,
        [Browsable(false)]
        RobotoSlab_Bold = 108,

        [Browsable(false)]
        RobotoThin_Italic = 200,
        [Browsable(false)]
        RobotoLight_Italic = 201,
        [Browsable(false)]
        RobotoLightCondensed_Italic = 202,
        [Browsable(false)]
        Roboto_Italic = 203,
        [Browsable(false)]
        RobotoBlack_Italic = 204,
        [Browsable(false)]
        RobotoCondensed_Italic = 205,
        [Browsable(false)]
        RobotoSlabThin_Italic = 206,
        [Browsable(false)]
        RobotoSlabLight_Italic = 207,
        [Browsable(false)]
        RobotoSlab_Italic = 208,

        [Browsable(false)]
        RobotoThin_BoldItalic = 300,
        [Browsable(false)]
        RobotoLight_BoldItalic = 301,
        [Browsable(false)]
        RobotoLightCondensed_BoldItalic = 302,
        [Browsable(false)]
        Roboto_BoldItalic = 303,
        [Browsable(false)]
        RobotoBlack_BoldItalic = 304,
        [Browsable(false)]
        RobotoCondensed_BoldItalic = 305,
        [Browsable(false)]
        RobotoSlabThin_BoldItalic = 306,
        [Browsable(false)]
        RobotoSlabLight_BoldItalic = 307,
        [Browsable(false)]
        RobotoSlab_BoldItalic = 308
    }

    public enum FacerShapeType
    {
        Circle = 0,
        Square = 1,
        Polygon = 2,
        Line = 3,
        Triangle = 4
    }

    public enum FacerShapeOptions
    {
        Fill = 0,
        Stroke = 1
    }
}

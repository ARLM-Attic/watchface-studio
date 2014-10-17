using System;
using System.Collections.Generic;
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

        RobotoThin_Bold = 100,
        RobotoLight_Bold = 101,
        RobotoLightCondensed_Bold = 102,
        Roboto_Bold = 103,
        RobotoBlack_Bold = 104,
        RobotoCondensed_Bold = 105,
        RobotoSlabThin_Bold = 106,
        RobotoSlabLight_Bold = 107,
        RobotoSlab_Bold = 108,

        RobotoThin_Italic = 200,
        RobotoLight_Italic = 201,
        RobotoLightCondensed_Italic = 202,
        Roboto_Italic = 203,
        RobotoBlack_Italic = 204,
        RobotoCondensed_Italic = 205,
        RobotoSlabThin_Italic = 206,
        RobotoSlabLight_Italic = 207,
        RobotoSlab_Italic = 208,

        RobotoThin_BoldItalic = 300,
        RobotoLight_BoldItalic = 301,
        RobotoLightCondensed_BoldItalic = 302,
        Roboto_BoldItalic = 303,
        RobotoBlack_BoldItalic = 304,
        RobotoCondensed_BoldItalic = 305,
        RobotoSlabThin_BoldItalic = 306,
        RobotoSlabLight_BoldItalic = 307,
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

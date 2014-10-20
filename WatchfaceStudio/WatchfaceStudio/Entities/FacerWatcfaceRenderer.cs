using System.Globalization;
using System.Windows.Forms;
using ExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WatchfaceStudio.Imaging;

namespace WatchfaceStudio.Entities
{
    public static class FacerWatcfaceRenderer
    {
        private static System.Data.DataTable _computer = new System.Data.DataTable();
        public static Dictionary<FacerFont, Tuple<PrivateFontCollection, FontStyle>> FacerFontConfig;

        public const float ScreenDPI = 120f;
        public const float DefaultScreenDPI = 160f;
        private static float DpToPx(float dp)
        {
            return dp * ScreenDPI / DefaultScreenDPI;
        }

        static FacerWatcfaceRenderer()
        {
            FacerFontConfig = new Dictionary<FacerFont, Tuple<PrivateFontCollection, FontStyle>>();

            FacerFontConfig.Add(FacerFont.RobotoThin, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(19), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLight, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(10), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(6), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.Roboto, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(14), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(0), FontStyle.Bold));
            FacerFontConfig.Add(FacerFont.RobotoCondensed, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(8), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(18), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabLight, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(16), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlab, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(17), FontStyle.Regular));

            FacerFontConfig.Add(FacerFont.RobotoThin_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(19), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoLight_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(10), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(6), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.Roboto_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(1), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(0), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoCondensed_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(3), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(18), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoSlabLight_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(16), FontStyle.Bold)); //needs bold
            FacerFontConfig.Add(FacerFont.RobotoSlab_Bold, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(15), FontStyle.Regular));

            FacerFontConfig.Add(FacerFont.RobotoThin_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(20), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLight_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(11), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(7), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.Roboto_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(9), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(0), FontStyle.Italic));//needs italic
            FacerFontConfig.Add(FacerFont.RobotoCondensed_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(5), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(18), FontStyle.Italic));//needs italic
            FacerFontConfig.Add(FacerFont.RobotoSlabLight_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(16), FontStyle.Italic));//needs italic
            FacerFontConfig.Add(FacerFont.RobotoSlab_Italic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(17), FontStyle.Italic));//needs italic

            FacerFontConfig.Add(FacerFont.RobotoThin_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(20), FontStyle.Bold));//needs bold
            FacerFontConfig.Add(FacerFont.RobotoLight_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(11), FontStyle.Bold));//needs bold
            FacerFontConfig.Add(FacerFont.RobotoLightCondensed_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(7), FontStyle.Bold));//needs bold
            FacerFontConfig.Add(FacerFont.Roboto_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(2), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoBlack_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(0), FontStyle.Bold | FontStyle.Italic));//needs bold & italic
            FacerFontConfig.Add(FacerFont.RobotoCondensed_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(4), FontStyle.Regular));
            FacerFontConfig.Add(FacerFont.RobotoSlabThin_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(18), FontStyle.Bold | FontStyle.Italic));//needs bold & italic
            FacerFontConfig.Add(FacerFont.RobotoSlabLight_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(16), FontStyle.Bold | FontStyle.Italic));//needs bold & italic
            FacerFontConfig.Add(FacerFont.RobotoSlab_BoldItalic, new Tuple<PrivateFontCollection, FontStyle>(PFCWithFont(15), FontStyle.Bold | FontStyle.Italic));//needs italic
 
        }

        private static PrivateFontCollection PFCWithFont(int index)
        {
            var col = new PrivateFontCollection();
            switch (index)
            {
                case 0: col.AddFontFile("Fonts/Roboto-Black.ttf"); break;
                case 1: col.AddFontFile("Fonts/Roboto-Bold.ttf"); break;
                case 2: col.AddFontFile("Fonts/Roboto-BoldItalic.ttf"); break;
                case 3: col.AddFontFile("Fonts/RobotoCondensed-Bold.ttf"); break;
                case 4: col.AddFontFile("Fonts/RobotoCondensed-BoldItalic.ttf"); break;
                case 5: col.AddFontFile("Fonts/RobotoCondensed-Italic.ttf"); break;
                case 6: col.AddFontFile("Fonts/RobotoCondensed-Light.ttf"); break;
                case 7: col.AddFontFile("Fonts/RobotoCondensed-LightItalic.ttf"); break;
                case 8: col.AddFontFile("Fonts/RobotoCondensed-Regular.ttf"); break;
                case 9: col.AddFontFile("Fonts/Roboto-Italic.ttf"); break;
                case 10: col.AddFontFile("Fonts/Roboto-Light.ttf"); break;
                case 11: col.AddFontFile("Fonts/Roboto-LightItalic.ttf"); break;
                case 12: col.AddFontFile("Fonts/Roboto-Medium.ttf"); break;
                case 13: col.AddFontFile("Fonts/Roboto-MediumItalic.ttf"); break;
                case 14: col.AddFontFile("Fonts/Roboto-Regular.ttf"); break;
                case 15: col.AddFontFile("Fonts/RobotoSlab-Bold.ttf"); break;
                case 16: col.AddFontFile("Fonts/RobotoSlab-Light.ttf"); break;
                case 17: col.AddFontFile("Fonts/RobotoSlab-Regular.ttf"); break;
                case 18: col.AddFontFile("Fonts/RobotoSlab-Thin.ttf"); break;
                case 19: col.AddFontFile("Fonts/Roboto-Thin.ttf"); break;
                case 20: col.AddFontFile("Fonts/Roboto-ThinItalic.ttf"); break;
            }
            return col;
        }

        private static PointF AlignedPoint(int width, int height, int alignment)
        {
            switch ((FacerImageAlignment)alignment)
            {
                case FacerImageAlignment.TopCenter:
                    return new PointF(-(width / 2), 0);
                case FacerImageAlignment.TopRight:
                    return new PointF(-width, 0);
                case FacerImageAlignment.CenterLeft:
                    return new PointF(0,-(height / 2));
                case FacerImageAlignment.Center:
                    return new PointF(-(width / 2),-(height / 2));
                case FacerImageAlignment.CenterRight:
                    return new PointF(-width,-(height / 2));
                case FacerImageAlignment.BottomLeft:
                    return new PointF(0,-height);
                case FacerImageAlignment.BottomCenter:
                    return new PointF(-(width / 2),-height);
                case FacerImageAlignment.BottomRight:
                    return new PointF(-width,-height);
                default: //& FacerImageAlignment.TopLeft
                    return new PointF(0, 0);
            }
        }

        private enum ChannelARGB
        {
            Blue = 0,
            Green = 1,
            Red = 2,
            Alpha = 3
        }

        private static void CopyChannel(Bitmap source, Bitmap dest, ChannelARGB sourceChannel, ChannelARGB destChannel)
        {
            if (source.Size != dest.Size)
                throw new ArgumentException();
            Rectangle r = new Rectangle(Point.Empty, source.Size);
            var bdSrc = source.LockBits(r, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bdDst = dest.LockBits(r, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* bpSrc = (byte*)bdSrc.Scan0.ToPointer();
                byte* bpDst = (byte*)bdDst.Scan0.ToPointer();
                bpSrc += (int)sourceChannel;
                bpDst += (int)destChannel;
                for (int i = r.Height * r.Width; i > 0; i--)
                {
                    *bpDst = *bpSrc;
                    bpSrc += 4;
                    bpDst += 4;
                }
            }
            source.UnlockBits(bdSrc);
            dest.UnlockBits(bdDst);
        }

        public static Bitmap Render(FacerWatchface watchface, EWatchType watchtype, bool checkForErrors, List<WatchfaceRendererError> errors)
        {
            var bmp = new Bitmap(320, 320);
            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextContrast = 1;
                g.PixelOffsetMode = PixelOffsetMode.None;
                g.PageUnit = GraphicsUnit.Pixel;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.Clear(Color.Black);

                var outRect = Rectangle.Empty;
                var selectedRectangle = Rectangle.Empty;
                Matrix selectedTransform = null;

                foreach (var layer in watchface.Layers)
                {
                    try 
                    {
                        if (Properties.Settings.Default.LowPowerMode && !layer.low_power) continue; //don't show on dimmed

                        var opacity = (float)(ExpressionCalculator.Calc(layer.opacity) / 100);
                        if (opacity == 0) continue;

                        var x = (float)ExpressionCalculator.Calc(layer.x);
                        var y = (float)ExpressionCalculator.Calc(layer.y);
                    
                        var rotation = layer.r != "0" ? (float)ExpressionCalculator.Calc(layer.r) : 0.0F;

                        g.TranslateTransform(x, y);
                        g.RotateTransform(rotation);

                        var alp = new PointF(0, 0); ;
                        int width, height;

                        if (layer.type == "image")
                        {
                            var imageAtt = new ImageAttributes();

                            if (opacity > 0.999 || (layer.is_tinted ?? false))
                            {
                                var tint_color = (layer.is_tinted ?? false) && layer.tint_color != null ? Color.FromArgb(layer.tint_color.Value) : Color.Empty;
                                const float intensity = 0.3f;

                                var colorMatrix = new ColorMatrix();
                                if (opacity > 0.999)
                                    colorMatrix.Matrix33 = opacity;
                                if (tint_color != Color.Empty)
                                {
                                    colorMatrix.Matrix40 = tint_color.R / 255 * intensity;
                                    colorMatrix.Matrix41 = tint_color.G / 255 * intensity;
                                    colorMatrix.Matrix42 = tint_color.B / 255 * intensity;
                                }
                                imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                            }

                            width = (int)ExpressionCalculator.Calc(layer.width);
                            height = (int)ExpressionCalculator.Calc(layer.height);
                            alp = AlignedPoint(width, height, layer.alignment.Value);

                            if (!watchface.Images.ContainsKey(layer.hash))
                            {
                                throw new Exception("The image \"" + layer.hash + "\" was not found in the images folder.");
                            }
                            var img = watchface.Images[layer.hash];
                            outRect = new Rectangle((int)alp.X, (int)alp.Y, width, height);
                            g.DrawImage(img, outRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtt);
                        }
                        else if (layer.type == "text")
                        {
                            var colorToUse = Properties.Settings.Default.LowPowerMode ? layer.low_power_color : layer.color;
                            var foreColor = Color.FromArgb(((int)ExpressionCalculator.Calc(colorToUse) & 0xFFFFFF) + ((int)(opacity * 255) << 24));
                            var fontSize = DpToPx((float)ExpressionCalculator.Calc(layer.size));
                            var fontStyle = (layer.bold ?? false) && (layer.italic ?? false) ? FontStyle.Bold | FontStyle.Italic :
                                ((layer.bold ?? false) && !(layer.italic ?? false) ? FontStyle.Bold :
                                (!(layer.bold ?? false) && (layer.italic ?? false) ? FontStyle.Italic : FontStyle.Regular));
                            Font layerFont;
                            if (layer.font_family == (int)FacerFont.Custom)
                            {
                                if (!watchface.CustomFonts.ContainsKey(layer.font_hash))
                                {
                                    throw new Exception("The font \"" + layer.hash + "\" was not found in the fonts folder.");
                                }
                                var customFont = watchface.CustomFonts[layer.font_hash];
                                layerFont = new Font(customFont.FontFamily, fontSize, customFont.FontStyle); //TODO: use the right font style
                            }
                            else
                            {
                                var facerFontKey = layer.font_family + 100 * (layer.bold ?? false ? 1 : 0) + 200 * (layer.italic ?? false ? 1 : 0);
                                var fontPair = FacerFontConfig[(FacerFont)facerFontKey];
                                layerFont = new Font(fontPair.Item1.Families[0], fontSize, fontPair.Item2, GraphicsUnit.Point);
                            }

                            var resolvedText = FacerTags.ResolveTags(layer.text)
                                .Replace("\n", string.Empty)
                                .Replace("\x10",string.Empty).Replace("\x13",string.Empty); //remove new lines

                            if (layer.transform == (int)FacerTextTransform.AllUppercase)
                                resolvedText = resolvedText.ToUpper();
                            else if (layer.transform == (int)FacerTextTransform.AllLowercase)
                                resolvedText = resolvedText.ToLower();

                            var textBrush = new SolidBrush(foreColor);
                            var textAlign = (FacerTextAlignment)layer.alignment.Value;
                            var textFormat = StringFormat.GenericTypographic; //ToStringFormat(textAlign);
                            textFormat.LineAlignment = StringAlignment.Far;
                            textFormat.Trimming = StringTrimming.None;
                            textFormat.FormatFlags = StringFormatFlags.NoWrap;
                            
                            var measurements = TextRenderer.MeasureText(g, resolvedText, layerFont, bmp.Size, TextFormatFlags.Top | TextFormatFlags.NoClipping | TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
                            var drawMeasurements = g.MeasureString(resolvedText, layerFont, bmp.Width, textFormat);
                            width = measurements.Width;
                            height = measurements.Height;

                            var xOffset = textAlign == FacerTextAlignment.Left ? 0 :
                                textAlign == FacerTextAlignment.Center ? width / 2 : 
                                width;

                            var baselineOffset = layerFont.SizeInPoints / layerFont.FontFamily.GetEmHeight(layerFont.Style) * layerFont.FontFamily.GetCellAscent(layerFont.Style);
                            var yOffset = (int) (g.DpiY / 72f * baselineOffset);

                            var textPoint = new PointF(-(int)(drawMeasurements.Width - measurements.Width) - xOffset, height - yOffset);
                            g.DrawString(resolvedText, layerFont, textBrush, textPoint, textFormat);

                            outRect = new Rectangle((int)textPoint.X, (int)textPoint.Y - height, width, height);
                        }
                        else if (layer.type == "shape")
                        {
                            var foreColor = Color.FromArgb(((int)ExpressionCalculator.Calc(layer.color) & 0xFFFFFF) + ((int)(opacity * 255) << 24));
                            var radius = string.IsNullOrEmpty(layer.radius) ? 0 : (float)ExpressionCalculator.Calc(layer.radius);
                            var shapeOptions = layer.shape_opt == ((int)FacerShapeOptions.Stroke).ToString(CultureInfo.InvariantCulture) ? FacerShapeOptions.Stroke : FacerShapeOptions.Fill;
                            var strokeSize = (float)ExpressionCalculator.Calc(layer.stroke_size) / 2;
                            Pen penToUse = shapeOptions == FacerShapeOptions.Stroke ? new Pen(foreColor, strokeSize) : null;
                            Brush brushToUse = shapeOptions == FacerShapeOptions.Fill ? new SolidBrush(foreColor) : null;

                            switch (layer.shape_type)
                            {
                                case (int)FacerShapeType.Circle:
                                    outRect = new Rectangle((int)(-radius), (int)(-radius), (int)(2 * radius), (int)(2 * radius));
                                    if (shapeOptions == FacerShapeOptions.Stroke)
                                    {
                                        g.DrawEllipse(penToUse, outRect);
                                        outRect.Inflate((int)strokeSize, (int)strokeSize);
                                        outRect.Offset((int)(-strokeSize/2f + 0.5f), (int)(-strokeSize/2f + 0.5f));
                                    }
                                    else
                                    {
                                        g.FillEllipse(brushToUse, outRect);
                                    }
                                    break;
                                case (int)FacerShapeType.Line:
                                case (int)FacerShapeType.Square:
                                    width = (int)ExpressionCalculator.Calc(layer.width);
                                    height = (int)ExpressionCalculator.Calc(layer.height);

                                    outRect = new Rectangle(0, 0, width, height);
                                    if (shapeOptions == FacerShapeOptions.Stroke)
                                    {
                                        g.DrawRectangle(penToUse, outRect);
                                    }
                                    else
                                    {
                                        g.FillRectangle(brushToUse, outRect);
                                    }
                                    break;
                                case (int)FacerShapeType.Triangle:
                                case (int)FacerShapeType.Polygon:
                                    outRect = new Rectangle((int)(-radius), (int)(-radius), (int)(2 * radius), (int)(2 * radius));
                                    var polyN = layer.shape_type == (int)FacerShapeType.Triangle ? 3 : (int)ExpressionCalculator.Calc(layer.sides);
                                    var polyPoints = new Point[polyN];
                                    for (var i = 0; i < polyN; i++)
                                    {
                                        polyPoints[i] = new Point(
                                            (int)(radius * Math.Cos(2 * Math.PI * i / polyN)),
                                            (int)(radius * Math.Sin(2 * Math.PI * i / polyN)));
                                    }
                                    if (shapeOptions == FacerShapeOptions.Stroke)
                                    {
                                        g.DrawPolygon(penToUse, polyPoints);
                                        outRect.Inflate((int)strokeSize, (int)strokeSize);
                                        outRect.Offset((int)(-strokeSize / 2f + 0.5f), (int)(-strokeSize / 2f + 0.5f));
                                    }
                                    else
                                    {
                                        g.FillPolygon(brushToUse, polyPoints);
                                    }
                                    break;
                            }

                        }

                        if (layer == watchface.SelectedLayer)
                        {
                            selectedRectangle = outRect;
                            selectedTransform = g.Transform;
                        }

                        g.ResetTransform();
                    }
                    catch (NullReferenceException)
                    {
                        if (checkForErrors)
                            errors.Add(new WatchfaceRendererError
                            {
                                Severity = WatchfaceRendererErrorSeverity.Error,
                                Object = layer.GetIdentifier(),
                                Message = "General Error"
                            });
                    }
                    catch (Exception ex)
                    {
                        if (checkForErrors)
                            errors.Add(new WatchfaceRendererError
                            {   
                                Severity = WatchfaceRendererErrorSeverity.Error,
                                Object = layer.GetIdentifier(),
                                Message = ex.Message
                            });
                    }
                }

                if (selectedRectangle != Rectangle.Empty)
                {
                    g.ResetTransform();
                    g.Transform = selectedTransform;
                    g.DrawXorRectangle(bmp, selectedRectangle);
                }

                Bitmap mask;
                if (WatchType.Masks.TryGetValue(watchtype, out mask))
                    CopyChannel(mask, bmp, ChannelARGB.Alpha, ChannelARGB.Alpha);
            }

            
            
            return bmp;
        }
    }
}

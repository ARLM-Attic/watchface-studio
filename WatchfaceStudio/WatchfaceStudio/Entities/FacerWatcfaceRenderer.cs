﻿using ExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public static class FacerWatcfaceRenderer
    {
        private static System.Data.DataTable _computer = new System.Data.DataTable();
        private static Regex ConditionalRegex = new Regex(@"\$([^\$]+)\$");

        private static double Calc(string formula)
        {
            if (string.IsNullOrEmpty(formula)) return 0;
            var resolvedFormula = FacerTags.ResolveTags(formula).Replace(" ", string.Empty);
            double dblVal;
            if (double.TryParse(resolvedFormula, out dblVal))
                return dblVal;

            //convert formula to c#
            resolvedFormula = ConditionalRegex.Replace(resolvedFormula, "($1)");
            resolvedFormula = resolvedFormula.Replace("=", "==").Replace('[', '(').Replace(']', ')');
            var expression = new CompiledExpression(resolvedFormula);
            var result = expression.Eval();
            return Convert.ToDouble(result);
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

        private static float DpToPx(float dp)
        {
            return (120 / (float)160) * dp;
        }

        private static StringFormat ToStringFormat(FacerTextAlignment alignment)
        {
            return new StringFormat
            {
                LineAlignment = StringAlignment.Far,
                Alignment = (alignment == FacerTextAlignment.Center ? StringAlignment.Center :
                            (alignment == FacerTextAlignment.Left ? StringAlignment.Near :
                            StringAlignment.Far))
            };
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

        private static Bitmap TintBitmap(Bitmap b, Color color, float intensity)
        {
            var b2 = new Bitmap(b.Width, b.Height);
            var ia = new ImageAttributes();

            var m = new ColorMatrix(new float[][] {
		        new float[] {1,0,0,0,0},
		        new float[] {0,1,0,0,0},
		        new float[] {0,0,1,0,0},
		        new float[] {0,0,0,1,0},
		        new float[] {
                    color.R / 255 * intensity,
			        color.G / 255 * intensity,
			        color.B / 255 * intensity,
			        0,
			        1
		        }
	        });

            ia.SetColorMatrix(m);
            Graphics g = Graphics.FromImage(b2);
            g.DrawImage(b, new Rectangle(0, 0, b.Width, b.Height), 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, ia);
            return b2;

        }

        public static Bitmap Render(FacerWatchface watchface, EWatchType watchtype)
        {
            var bmp = new Bitmap(320, 320);
            using (var g = Graphics.FromImage(bmp))
            {
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.Clear(Color.Black);

                var outRect = Rectangle.Empty;
                var selectedRectangle = Rectangle.Empty;
                System.Drawing.Drawing2D.Matrix selectedTransform = null;

                foreach (var layer in watchface.Layers)
                {
                    try 
                    {
                        if (FacerMockData.LowPowerMode && !layer.low_power) continue; //don't show on dimmed

                        var opacity = (float)Calc(layer.opacity) / 100;
                        if (opacity == 0) continue;

                        var x = (float)Calc(layer.x);
                        var y = (float)Calc(layer.y);
                    
                        var rotation = layer.r != "0" ? (float)Calc(layer.r) : 0.0F;

                        var alp = new PointF(0, 0); ;
                        int width = 0, height = 0;

                        if (layer.type == "image")
                        {
                            var imageAtt = new ImageAttributes();

                            if (opacity != 1 || (layer.is_tinted ?? false))
                            {
                                var tint_color = (layer.is_tinted ?? false) && layer.tint_color != null ? Color.FromArgb(layer.tint_color.Value) : Color.Empty;
                                const float intensity = 0.3f;

                                var colorMatrix = new ColorMatrix();
                                if (opacity != 1)
                                    colorMatrix.Matrix33 = opacity;
                                if (tint_color != Color.Empty)
                                {
                                    colorMatrix.Matrix40 = tint_color.R / 255 * intensity;
                                    colorMatrix.Matrix41 = tint_color.G / 255 * intensity;
                                    colorMatrix.Matrix42 = tint_color.B / 255 * intensity;
                                }
                                imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                            }

                            width = (int)Calc(layer.width);
                            height = (int)Calc(layer.height);
                            alp = AlignedPoint(width, height, layer.alignment.Value);

                            g.TranslateTransform(x, y);
                            g.RotateTransform(rotation);

                            var img = watchface.Images[layer.hash];
                            outRect = new Rectangle((int)alp.X, (int)alp.Y, width, height);
                            g.DrawImage(img, outRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAtt);
                        }
                        else if (layer.type == "text")
                        {
                            var foreColor = Color.FromArgb(((int)Calc(layer.color) & 0xFFFFFF) + ((int)(opacity * 255) << 24));
                            var fontSize = DpToPx((float)Calc(layer.size));
                            var fontStyle = (layer.bold ?? false) && (layer.italic ?? false) ? FontStyle.Bold | FontStyle.Italic :
                                ((layer.bold ?? false) && !(layer.italic ?? false) ? FontStyle.Bold :
                                (!(layer.bold ?? false) && (layer.italic ?? false) ? FontStyle.Italic : FontStyle.Regular));
                            Font layerFont;
                            if (layer.font_family == (int)FacerFont.Custom)
                            {
                                layerFont = new Font(watchface.CustomFonts[layer.font_hash], fontSize, fontStyle);
                            }
                            else
                            {
                                var facerFontKey = layer.font_family + 100 * (layer.bold ?? false ? 1 : 0) + 200 * (layer.italic ?? false ? 1 : 0);
                                var fontPair = FacerWatchface.FacerFontConfig[(FacerFont)facerFontKey];
                                layerFont = new Font(fontPair.Item1.Families[0], fontSize,fontPair.Item2);
                            }

                            var resolvedText = FacerTags.ResolveTags(layer.text);

                            if (layer.transform == (int)FacerTextTransform.AllUppercase)
                                resolvedText = resolvedText.ToUpper();
                            else if (layer.transform == (int)FacerTextTransform.AllLowercase)
                                resolvedText = resolvedText.ToLower();

                            var textBrush = new SolidBrush(foreColor);
                            var textAlign = (FacerTextAlignment)layer.alignment.Value;
                            var textFormat = ToStringFormat(textAlign);

                            var measurements = g.MeasureString(resolvedText, layerFont, bmp.Width, textFormat);
                            width = (int)measurements.Width;
                            height = (int)measurements.Height;
                            alp = AlignedPoint(width, height, (int)FacerImageAlignment.TopLeft);
                            var textPoint = new PointF(alp.X, alp.Y);

                            g.TranslateTransform(x, y);
                            g.RotateTransform(rotation);

                            g.DrawString(resolvedText, layerFont, textBrush, textPoint, textFormat);

                            var xOffset = textAlign == FacerTextAlignment.Left ? 0 :
                                textAlign == FacerTextAlignment.Center ? width / 2 : width;
                            outRect = new Rectangle((int)alp.X - xOffset, (int)alp.Y - height, width, height);
                        }
                        else if (layer.type == "shape")
                        {
                            var foreColor = Color.FromArgb(((int)Calc(layer.color) & 0xFFFFFF) + ((int)(opacity * 255) << 24));
                            var radius = string.IsNullOrEmpty(layer.radius) ? 0 : (float)Calc(layer.radius);
                            var shapeOptions = layer.shape_opt == ((int)FacerShapeOptions.Stroke).ToString() ? FacerShapeOptions.Stroke : FacerShapeOptions.Fill;
                            Pen penToUse = shapeOptions == FacerShapeOptions.Stroke ? new Pen(foreColor, (float)Calc(layer.stroke_size) / 3) : null;
                            Brush brushToUse = shapeOptions == FacerShapeOptions.Fill ? new SolidBrush(foreColor) : null;

                            switch (layer.shape_type)
                            {
                                case (int)FacerShapeType.Circle:
                                    outRect = new Rectangle((int)(x - radius), (int)(y - radius), (int)(2 * radius), (int)(2 * radius));
                                    if (shapeOptions == FacerShapeOptions.Stroke)
                                    {
                                        g.DrawEllipse(penToUse, outRect);
                                    }
                                    else
                                    {
                                        g.FillEllipse(brushToUse, outRect);
                                    }
                                    break;
                                case (int)FacerShapeType.Line:
                                case (int)FacerShapeType.Square:
                                    width = (int)Calc(layer.width);
                                    height = (int)Calc(layer.height);
                                    alp = AlignedPoint(width, height, layer.alignment.Value);

                                    g.TranslateTransform(x, y);
                                    g.RotateTransform(rotation);

                                    outRect = new Rectangle((int)alp.X, (int)alp.Y, width, height);
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
                                    outRect = new Rectangle((int)(alp.X - radius), (int)(alp.X - radius), (int)(2 * radius), (int)(2 * radius));
                                    var polyN = layer.shape_type == (int)FacerShapeType.Triangle ? 3 : (int)Calc(layer.sides);
                                    var polyPoints = new Point[polyN];
                                    for (var i = 0; i < polyN; i++)
                                    {
                                        polyPoints[i] = new Point(
                                            (int)(x + radius * Math.Cos(2 * Math.PI * i / polyN)),
                                            (int)(y + radius * Math.Sin(2 * Math.PI * i / polyN)));
                                    }
                                    if (shapeOptions == FacerShapeOptions.Stroke)
                                    {
                                        g.DrawPolygon(penToUse, polyPoints);
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
                    catch {}
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
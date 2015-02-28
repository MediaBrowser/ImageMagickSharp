using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp.Extensions
{
	/// <summary> A media browser wand extension. </summary>
	public static class MediaBrowserWandExtension
	{
		/// <summary> A MagickWand extension method that draw text. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="text"> The text. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="fontName"> Name of the font. </param>
		/// <param name="fontSize"> Size of the font. </param>
		/// <param name="fontColor"> The font color. </param>
		/// <param name="fontWeight"> The font weight. </param>
		public static void DrawText(this ImageWand wand, string text, double x, double y, string fontName, double fontSize, PixelWand fontColor, FontWeightType fontWeight)
		{
			using (var draw = new DrawingWand())
			{
				using (fontColor)
				{
					draw.FillColor = fontColor;
					draw.Font = fontName;
					draw.FontSize = fontSize;
					draw.FontWeight = fontWeight;
					draw.TextAntialias = true;
					draw.DrawAnnotation(x, y, text);
					wand.DrawImage(draw);
				}
			}
		}

		/// <summary> A MagickWand extension method that draw rectangle. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="x1"> The first x value. </param>
		/// <param name="y1"> The first y value. </param>
		/// <param name="x2"> The second x value. </param>
		/// <param name="y2"> The second y value. </param>
		/// <param name="strokeColor"> The stroke color. </param>
		/// <param name="fillcolor"> The fillcolor. </param>
		public static void DrawRectangle(this ImageWand wand, double x1, double y1, double x2, double y2, PixelWand strokeColor, PixelWand fillcolor)
		{
			using (var draw = new DrawingWand())
			{
				draw.StrokeColor = strokeColor;
				draw.FillColor = fillcolor;
				draw.DrawRectangle(x1, y1, x2, y2);
				wand.DrawImage(draw);
			}
		}

		/// <summary> A MagickWand extension method that draw round rectangle. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="x1"> The first x value. </param>
		/// <param name="y1"> The first y value. </param>
		/// <param name="x2"> The second x value. </param>
		/// <param name="y2"> The second y value. </param>
		/// <param name="rx"> The receive. </param>
		/// <param name="ry"> The ry. </param>
		/// <param name="strokeColor"> The stroke color. </param>
		/// <param name="fillcolor"> The fillcolor. </param>
		public static void DrawRoundRectangle(this ImageWand wand, double x1, double y1, double x2, double y2, double rx, double ry, PixelWand strokeColor, PixelWand fillcolor)
		{
			using (var draw = new DrawingWand())
			{
				draw.StrokeColor = strokeColor;
				draw.FillColor = fillcolor;
				draw.DrawRoundRectangle(x1, y1, x2, y2, rx, ry);
				wand.DrawImage(draw);
			}
		}

		/// <summary> A MagickWand extension method that draw circle. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="ox"> The ox. </param>
		/// <param name="oy"> The oy. </param>
		/// <param name="px"> The px. </param>
		/// <param name="py"> The py. </param>
		/// <param name="strokeColor"> The stroke color. </param>
		/// <param name="fillcolor"> The fillcolor. </param>
		public static void DrawCircle(this ImageWand wand, double ox, double oy, double px, double py, PixelWand strokeColor, PixelWand fillcolor)
		{
			using (var draw = new DrawingWand())
			{
				draw.StrokeColor = strokeColor;
				draw.FillColor = fillcolor;
				draw.DrawCircle(ox, oy, px, py);
				wand.DrawImage(draw);
			}
		}

		/// <summary> A MagickWand extension method that draw circle. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="p"> The double to process. </param>
		/// <param name="strokeColor"> The stroke color. </param>
		/// <param name="fillcolor"> The fillcolor. </param>
		public static void DrawCircle(this ImageWand wand, double x, double y, double p, PixelWand strokeColor, PixelWand fillcolor)
		{
			using (var draw = new DrawingWand())
			{
				draw.StrokeColor = strokeColor;
				draw.FillColor = fillcolor;
				draw.DrawCircle(x + p, y + p, x + p, y + p * 2);
				wand.DrawImage(draw);
			}
		}

		/// <summary> A MagickWand extension method that overlay image. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="compose"> The compose. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="magickwand"> The magickwand. </param>
		public static void OverlayImage(this ImageWand wand, CompositeOperator compose, double x, double y, double width, double height, MagickWand magickwand)
		{
			using (var draw = new DrawingWand())
			{
				draw.DrawComposite(compose, x, y, width, height, magickwand.CurrentImage);
				wand.DrawImage(draw);
			}
		}

		/// <summary> Round corners. </summary>
		/// <param name="wand"> The wand to act on. </param>
		/// <param name="cofactor"> The cofactor. </param>
		/// <returns> A MagickWand. </returns>
		public static MagickWand RoundCorners(this MagickWand wand, Double cofactor)
		{
			var newWand = new MagickWand(wand.CurrentImage.Width, wand.CurrentImage.Height, new PixelWand(ColorName.None, 1));
			using (var draw = new DrawingWand(ColorName.White))
			{
				draw.DrawRoundRectangle(cofactor, cofactor, wand.CurrentImage.Width - cofactor, wand.CurrentImage.Height - cofactor, cofactor, cofactor);
				newWand.CurrentImage.DrawImage(draw);
				newWand.CurrentImage.CompositeImage(wand, CompositeOperator.SrcInCompositeOp, 0, 0);
				return newWand;
			}
		}

	}

}

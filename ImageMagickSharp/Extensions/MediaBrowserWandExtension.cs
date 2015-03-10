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
			var currentWidth = wand.CurrentImage.Width;
			var currentHeight = wand.CurrentImage.Height;

			var newWand = new MagickWand(currentWidth, currentHeight, new PixelWand(ColorName.None, 1));
			using (var draw = new DrawingWand(ColorName.White))
			{
				draw.DrawRoundRectangle(0, 0, currentWidth, currentHeight, cofactor, cofactor);
				newWand.CurrentImage.DrawImage(draw);
				newWand.CurrentImage.CompositeImage(wand, CompositeOperator.SrcInCompositeOp, 0, 0);
				return newWand;
			}
		}

		/// <summary> Media browser collection image. </summary>
		/// <param name="wandImages"> The wand images. </param>
		/// <param name="label"> The label. </param>
		/// <returns> A MagickWand. </returns>
		public static MagickWand MediaBrowserCollectionImage(MagickWand wandImages, string label)
		{
			int width = 960;
			int height = 540;

			var wand = new MagickWand(width, height);
			wand.OpenImage("gradient:black-grey10");
			using (var draw = new DrawingWand())
			{
				using (var fcolor = new PixelWand(ColorName.White))
				{
					draw.FillColor = fcolor;
					draw.Font = "Arial";
					draw.FontSize = 52;
					draw.FontWeight = FontWeightType.BoldStyle;
					draw.TextAntialias = true;
				}

				var fontMetrics = wand.QueryFontMetrics(draw, label);
				wand.CurrentImage.AnnotateImage(draw, (width - fontMetrics.TextWidth) / 2, fontMetrics.BoundingBoxY1 + fontMetrics.TextHeight, 0.0, label);

				int iSlice = 118;
				int iMarge = 80;
				int iTrans = 120;
				int iHeight = (int)Math.Abs((height - (fontMetrics.TextHeight + iMarge))) - iTrans;

				foreach (var element in wandImages.ImageList)
				{
					int iWidth = (int)Math.Abs(iHeight * element.Width / element.Height);
					element.Gravity = GravityType.CenterGravity;
					element.BackgroundColor = ColorName.Black;
					element.ResizeImage(iWidth, iHeight, FilterTypes.LanczosFilter);
					int ix = (int)Math.Abs((iWidth - iSlice) / 2);
					element.CropImage(iSlice, iHeight, ix, 0);
					element.ExtentImage(iSlice, iHeight, -10, 0);
				}

				wandImages.SetFirstIterator();
				using (var wandList = wandImages.AppendImages())
				{
					wandList.CurrentImage.TrimImage(1);
					using (var mwr = wandList.CloneMagickWand())
					{
						mwr.CurrentImage.ResizeImage(wandList.CurrentImage.Width, (wandList.CurrentImage.Height / 2), FilterTypes.LanczosFilter, 1);
						mwr.CurrentImage.FlipImage();

						mwr.CurrentImage.AlphaChannel = AlphaChannelType.DeactivateAlphaChannel;
						mwr.CurrentImage.ColorizeImage(ColorName.Black, ColorName.Grey80);

						using (var mwg = new MagickWand(wandList.CurrentImage.Width, iTrans))
						{
							mwg.OpenImage("gradient:black-none");
							mwr.CurrentImage.CompositeImage(mwg, CompositeOperator.CopyOpacityCompositeOp, 0, 0);

							wandList.AddImage(mwr);
							int ex = (int)(wand.CurrentImage.Width - mwg.CurrentImage.Width) / 2;
							wand.CurrentImage.CompositeImage(wandList.AppendImages(true), CompositeOperator.AtopCompositeOp, ex, (int)fontMetrics.TextHeight + iMarge / 2);
						}
					}
				}
			}

			return wand;

		}

	}

}

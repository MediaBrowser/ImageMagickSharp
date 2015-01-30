using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ImageMagickSharp.Modules.MediaBrowser;
using System.Diagnostics;
namespace ImageMagickSharp.Tests
{
	[TestClass()]
	public class MediaBrowserWandTests : BaseTest
	{
		[TestMethod()]
		public void MediaBrowserWandTextTests()
		{
			using (var wand = new MagickWand(TestImageBackdrop))
			{

				wand.DrawRoundRectangle(10, 10, wand.Image.Width - 10, 70, 5, 5, "yellow", new PixelWand("black", 0.5));

				wand.DrawCircle(400, 300, 500, 400, "yellow", new PixelWand("black", 0.5));
				wand.DrawCircle(400, 400, 60, "yellow", new PixelWand("black", 0.5));

				wand.DrawRectangle(0, wand.Image.Height - 70, wand.Image.Width - 1, wand.Image.Height, "yellow", new PixelWand("black", 0.5));
				wand.DrawText("Media Browser", 10, wand.Image.Height - 10, "Arial", 60, "white", FontWeightType.BoldStyle);
				
				wand.SaveImage(Path.Combine(SaveDirectory, "TestImageBackdrop.jpg"));
			}
		}

		[TestMethod()]
		public void MediaBrowserWandOverlayTests()
		{
			using (var wand = new MagickWand(TestImageBackdrop))
			{
				using (MagickWand wandComposit = new MagickWand(TestImageLogo))
				{
					//draw.FillOpacity = 0.5;
					wand.OverlayImage(CompositeOperator.AtopCompositeOp, 560, 660, wandComposit.Image.Width, wandComposit.Image.Height, wandComposit);
				}

				wand.SaveImage(Path.Combine(SaveDirectory, "TestImageBackdrop.jpg"));
			}
		}

		[TestMethod()]
		public void MediaBrowserWandCropWhitespaceTests()
		{
			using (var wand = new MagickWand(TestImageLogo))
			{
				wand.Image.TrimImage(10);
				wand.SaveImage(Path.Combine(SaveDirectory, "TestImageBackdrop.png"));
			}
		}
	}
}

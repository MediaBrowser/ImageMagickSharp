using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ImageMagickSharp.Extensions;
using System.Diagnostics;

namespace ImageMagickSharp.Tests
{
	[TestClass()]
	public class ImageWandTests : BaseTest
	{

		[TestMethod()]
		public void ResizeImageTest()
		{
			var path = TestImageLogo;

			Assert.IsTrue(File.Exists(path));

			using (var wand = new MagickWand(path))
			{
				wand.CurrentImage.ResizeImage(400, 150);

				wand.SaveImage(Path.Combine(SaveDirectory, "TestResize.jpg"));
				wand.SaveImage(Path.Combine(SaveDirectory, "TestResize.png"));
				wand.SaveImage(Path.Combine(SaveDirectory, "TestResize.webp"));
			}
		}

		[TestMethod()]
		public void ExtendcanvasaroundimageTest()
		{

			var path = TestImageThumb;

			Assert.IsTrue(File.Exists(path));

			using (var wand = new MagickWand(path))
			{
				wand.OpenImage(path);
				var w = wand.CurrentImage.Width;
				var h = wand.CurrentImage.Height;

				using (PixelWand newPixelWand = new PixelWand("blue"))
				{
					wand.CurrentImage.BackgroundColor = newPixelWand;
				}
				wand.CurrentImage.ExtentImage(1024, 768, -(1024 - w) / 2, -(768 - h) / 2);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.jpg"));

			}
		}

		[TestMethod()]
		public void ImageWandCreateManyTest()
		{

			using (var wand = new MagickWand())
			{
				wand.NewImage(200, 200, "Blue");
				wand.CurrentImage.DrawRoundRectangle(10, 10, wand.CurrentImage.Width - 10, 70, 5, 5, "yellow", new PixelWand("black", 0.5));
				wand.NewImage(200, 200, "red");
				wand.CurrentImage.DrawRoundRectangle(10, 10, wand.CurrentImage.Width - 10, 70, 5, 5, "yellow", new PixelWand("black", 0.5));
				wand.NewImage(200, 200, "green");
				wand.CurrentImage.DrawRoundRectangle(10, 10, wand.CurrentImage.Width - 10, 70, 5, 5, "yellow", new PixelWand("black", 0.5));
				wand.SaveImages(Path.Combine(SaveDirectory, "logo_extent.jpg"));

			}
		}

		[TestMethod()]
		public void ImageWandImageClassTest()
		{

			using (var wand = new MagickWand())
			{
				wand.NewImage(200, 200, "Blue");
				wand.CurrentImage.DrawRoundRectangle(10, 10, wand.CurrentImage.Width - 10, 70, 5, 5, "yellow", new PixelWand("black", 0.5));
				var t = wand.GetImage();
				//wand.Image.RotateImage("red", 45);
				//t.RotateImage("red", 45);
				t.SaveImages(Path.Combine(SaveDirectory, "logo_extent.jpg"));
				wand.SaveImages(Path.Combine(SaveDirectory, "logo_extent.jpg"));

			}
		}

		//Todo
		[TestMethod()]
		public void ImageWandLabelImageTests()
		{
			using (var wand = new MagickWand(200, 200, "lightblue"))
			{
				wand.BackgroundColor = ColorName.Maroon;
				
				wand.Font = "Arial";
				Debug.Print(wand.Font);
				wand.Pointsize = 72;
				wand.CurrentImage.LabelImage("Media Browser");
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}

	}
}

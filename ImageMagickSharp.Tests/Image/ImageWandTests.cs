using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
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
				wand.Image.ResizeImage(400, 150);

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
				var w = wand.Image.Width;
				var h = wand.Image.Height;

				using (PixelWand newPixelWand = new PixelWand("blue"))
				{
					wand.Image.BackgroundColor = newPixelWand;
				}
				wand.Image.ExtentImage(1024, 768, -(1024 - w) / 2, -(768 - h) / 2);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.jpg"));

			}
		}
	}
}

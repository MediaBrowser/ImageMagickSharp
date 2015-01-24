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
	public class DrawingWandTests : BaseTest
	{
		[TestMethod()]
		public void ExtendcanvasaroundimageTest()
		{

			var path = TestImagePath2;

			Assert.IsTrue(File.Exists(path));

			using (var wand = new MagickWand(path))
			{
				wand.OpenImage(path);
				var w = wand.Image.Width;
				var h = wand.Image.Height;

				using (PixelWand newPixelWand = new PixelWand("blue"))
				{
					wand.Image.ImageBackgroundColor = newPixelWand;
				}
				wand.Image.ExtentImage(1024, 768, -(1024 - w) / 2, -(768 - h) / 2);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.jpg"));

			}
		}
	}
}

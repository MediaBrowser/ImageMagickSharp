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
	public class CoverArtWandTests : BaseTest
	{

		[TestMethod()]
		public void CoverArtWandRotateTests()
		{
			using (var wand = new MagickWand(TestImageLogo))
			{
				wand.Image.RotateImage(new PixelWand("transparent", 1), 30);
				wand.Image.TrimImage(10);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}

		[TestMethod()]
		public void CoverArtWand3DTests()
		{
			using (var wand = new MagickWand(TestImageBackdrop))
			{
				wand.Image.BackgroundColor = "black";
				//wand.Image.RaiseImage(10, 10, 5,10, true);
				//wand.Image.ShadeImage(false, 1, 10);
				//wand.Image.ShearImage("blue", -2,2);
				wand.Image.ShadowImage(80,10, 5, 5);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}

		[TestMethod()]
		public void CoverArtWandLabelImageTests()
		{
			using (var wand = new MagickWand(TestImageBackdrop))
			{
				wand.Image.BackgroundColor = "Orange";
				wand.Image.LabelImage("Media Browser");
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}
	}
}

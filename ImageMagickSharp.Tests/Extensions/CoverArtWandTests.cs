using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
using ImageMagickSharp.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;
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
				wand.CurrentImage.RotateImage(new PixelWand("transparent", 1), 30);
				wand.CurrentImage.TrimImage(10);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}

		[TestMethod()]
		public void CoverArtWand3DTests()
		{
			using (var wand = new MagickWand(TestImageBackdrop))
			{
				wand.CurrentImage.BackgroundColor = "black";
				//wand.Image.RaiseImage(10, 10, 5,10, true);
				//wand.Image.ShadeImage(false, 1, 10);
				//wand.Image.ShearImage("blue", -2,2);
				wand.CurrentImage.ShadowImage(80, 10, 5, 5);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}

		[TestMethod()]
		public void CoverArtWandStackTests()
		{
			using (var wand = new MagickWand(1000, 1500, "White"))
			{
				wand.CoverArtStack(60, 60, 0, 0, this.TestImageFolder1, this.TestImageFolder2, this.TestImageFolder3);			
				wand.SaveImage(Path.Combine(SaveDirectory, "StackOutput.png"));
			}
		}
	}
}

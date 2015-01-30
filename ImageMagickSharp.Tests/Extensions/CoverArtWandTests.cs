using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
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
		public void CoverArtWandLabelImageTests()
		{
			using (var wand = new MagickWand(TestImageBackdrop))
			{
				wand.CurrentImage.BackgroundColor = "Orange";
				wand.CurrentImage.LabelImage("Media Browser");
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));

			}
		}

		[TestMethod()]
		public void CoverArtWandStackTests()
		{
			using (var wandOutput = new MagickWand(1000, 1500, "White"))
			{
				using (var draw = new DrawingWand())
				{
					double x = 0;
					double y = 0;
					using (var wand = new MagickWand(this.TestImageFolder1, this.TestImageFolder2, this.TestImageFolder3))
					{
						foreach (ImageWand imageWand in wand.ImageList)
						{
							imageWand.BorderImage("black", 2, 2);
							draw.DrawComposite(CompositeOperator.AtopCompositeOp, x, y, 900, 1400, imageWand);
							x += 40;
							y +=40;
							Debug.WriteLine(imageWand.Filename);
						}
					}
					wandOutput.CurrentImage.DrawImage(draw);
				}
				wandOutput.SaveImage(Path.Combine(SaveDirectory, "StackOutput.png"));
			}
		}
	}
}

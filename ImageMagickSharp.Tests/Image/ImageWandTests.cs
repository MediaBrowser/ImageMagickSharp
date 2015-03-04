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
		public void ResizeImageTestDir()
		{
			var path = @"D:\Video\TV\Carnivàle\Season 2\Carnivàle - 2x09 - Lincoln Highway DVD.jpg";

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

		[TestMethod()]
		public void GetImagePixelColorTest()
		{
			var path = TestImageFolder1;

			Assert.IsTrue(File.Exists(path));

			using (var wand = new MagickWand(path))
			{
				var pi = wand.CurrentImage.GetImagePixelColor(1, 1);
				Debug.Print(pi.Color);
			}
		}

		//Todo
		[TestMethod()]
		public void ColorMatrixTests()
		{
			using (var wand = new MagickWand(TestImageFolder1))
			{
				double[,] m = 
				{
				 {0.5, 0.5, 0.5, 0, 0} ,
				  {0.5, 1, 0.5, 0, 0 },
				 { 0.5, 0.5,1, 0, 0 },
				 { 0.5, 0.5, 0.5, 1, 1 } ,
				 { 0.5, 0.5, 0.5, 1, 0 }
				};
				//wand.CurrentImage.ImageVirtualPixel = VirtualPixelType.Black;
				bool t = wand.CurrentImage.ColorMatrixImage(m);
				wand.SaveImage(Path.Combine(SaveDirectory, "ColorMatrix_Out.png"));
			}
		}

		[TestMethod()]
		public void DistortImageTest()
		{
			var path = TestImageFolder1;

			Assert.IsTrue(File.Exists(path));

			using (var wand = new MagickWand(path))
			{
				ImageMatrix matrix = new ImageMatrix();

				wand.CurrentImage.ImageVirtualPixel = VirtualPixelType.White;
				matrix.RotateX(10).Scale(0.5, 0.5);
				var pi = wand.CurrentImage.DistortImage( DistortImageMethodType.AffineDistortion, matrix, true);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));
			}
		}

		[TestMethod()]
		public void DistortImagePerspectiveTest()
		{
			var path = TestImageFolder1;

			Assert.IsTrue(File.Exists(path));

			using (var wand = new MagickWand(path))
			{
				double[] matrix = new double[] { 7.40, 4.30, 4.124, 4.123, 85.122, 100.123, 85.2, 100.30 };

				wand.CurrentImage.ImageVirtualPixel = VirtualPixelType.White;

				var pi = wand.CurrentImage.DistortImage(DistortImageMethodType.PerspectiveDistortion,matrix, true);
				wand.SaveImage(Path.Combine(SaveDirectory, "logo_extent.png"));
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ImageMagickSharp.Tests
{
	[TestClass()]
	public class ImageWandTests : BaseTest
	{
		[TestMethod()]
		public void ImageWandTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ResizeImageTest()
		{
			var path = TestImagePath;

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
		public void CropImageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void RotateImageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void FlipImageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void TransparentTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ResizeImageTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void SetQualityTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void FillTest()
		{
			Assert.Fail();
		}
	}
}

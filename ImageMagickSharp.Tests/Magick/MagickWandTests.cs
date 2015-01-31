using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagickSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace ImageMagickSharp.Tests
{
    [TestClass()]
    public class MagickWandTests : BaseTest
    {

        [TestMethod()]
        public void GetFontTest()
        {
            using (var wand = new MagickWand())
            {
				//wand.SetFont("Arial");
				//Debug.WriteLine(wand.GetFont());
            }
        }

        [TestMethod()]
        public void SetFontTest()
        {
            using (var wand = new MagickWand())
            {
				//wand.SetFont("Arial");
				//Debug.WriteLine(wand.GetFont());
            }
        }

        [TestMethod()]
        public void NewImageTest()
        {
            using (var wand = new MagickWand(100, 100, "#ffffff"))
            {
                wand.NewImage(100, 100, "#ffffff");
                wand.SaveImage(Path.Combine(SaveDirectory, "TestSetBackgroundColor.png"));
            }
        }

        [TestMethod()]
        public void NewImageTest2()
        {
            using (var wand = new MagickWand(100, 100, "#ffffff"))
            {
                //wand.NewImage(100, 100, "#ffffff");

                wand.SaveImage(Path.Combine(SaveDirectory, "TestSetBackgroundColor.png"));
            }
        }

        [TestMethod()]
        public void OpenImageTest()
        {
            var path = TestImageLogo;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand(path))
            {
            }

            using (var wand2 = new MagickWand())
            {
                Assert.IsTrue(wand2.OpenImage(path));
            }
        }

        [TestMethod()]
        public void SaveImageTest()
        {
            var path = TestImageLogo;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand(path))
            {

                wand.SaveImage(Path.Combine(SaveDirectory, "test.jpg"));
                wand.SaveImage(Path.Combine(SaveDirectory, "test.png"));
                wand.SaveImage(Path.Combine(SaveDirectory, "test.webp"));
            }
        }

        public void SaveImageWithQualityTest()
        {

            var path = TestImageLogo;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand(path))
            {
                wand.CurrentImage.CompressionQuality = 90;
                wand.SaveImage(Path.Combine(SaveDirectory, "test.jpg"));

                wand.CurrentImage.CompressionQuality = 90;
                wand.SaveImage(Path.Combine(SaveDirectory, "test.png"));

                wand.CurrentImage.CompressionQuality = 90;
                wand.SaveImage(Path.Combine(SaveDirectory, "test.webp"));
            }
        }

        [TestMethod()]
        public void SaveImagesTest()
        {

            var path = TestImageLogo;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand(path))
            {
                wand.SaveImages(Path.Combine(SaveDirectory, "logo.png"), true);
            }
        }

        [TestMethod()]
        public void PageSizeTest()
        {
            using (var wand = new MagickWand(100, 100, "#ffffff"))
            {
                wand.PageSize = new WandRectangle(100, 100, 0, 0);
                Console.WriteLine(wand.PageSize);
            }
        }

        [TestMethod()]
        public void IteratorSetImageTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void ImageSizeTest()
        {
            var path = TestImageLogo;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand(path))
            {
                Debug.WriteLine(wand.CurrentImage.Height);
            }

            using (var wand2 = new MagickWand())
            {
                Assert.IsTrue(wand2.OpenImage(path));
            }
        }

        [TestMethod()]
        public void ImageOverlayTest()
        {
            var path = TestImageLogo;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand(path))
            {
                //wand.NewImage(100, 100, "#ffffff");
                wand.OpenImage(TestImageThumb);
                Debug.WriteLine(wand.GetNumberImages());
                //wand.IteratorIndex = 0;
                wand.ResetIterator();
                using (var w = wand.AppendImages())
                {
                    //w.SaveImage(Path.Combine(SaveDirectory, "test.png"));
                }


                wand.SaveImage(path);
            }
        }

		[TestMethod()]
		public void ImageWandImageListTest()
		{

			using (var wand = new MagickWand(this.TestImageLogo, this.TestImageThumb, this.TestImageBackdrop, this.TestImageFolder1, this.TestImageFolder2, this.TestImageFolder3, this.TestImageFolder4))
			{
				foreach (ImageWand imageWand in wand.ImageList)
				{
					imageWand.RotateImage(new PixelWand("", 1), 45);
					imageWand.TrimImage(100);
					Debug.WriteLine(imageWand.Filename);
				}
				wand.SaveImages(Path.Combine(SaveDirectory, "ListOutput.png"));
			}
		}
    }
}

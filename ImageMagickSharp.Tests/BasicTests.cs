using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageMagickSharp.Tests
{
    [TestClass]
    public class BasicTests
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        private string SaveDirectory
        {
            get
            {
                var path = Path.Combine(TestContext.TestDir, TestContext.TestName);
                Directory.CreateDirectory(path);
                return path;
            }
        }

        private string TestImagePath
        {
            get
            {
                var path = Path.Combine(SaveDirectory, "logo.png");

                if (!File.Exists(path))
                {
                    using (var stream = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".logo.png"))
                    {
                        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            stream.CopyTo(fs);
                        }
                    }
                }
                return path;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            MagickWand.StartEnvironment();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            MagickWand.DisposeEnvironment();
        }

        [TestMethod]
        public void TestReadFile()
        {
            var path = TestImagePath;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand())
            {
                wand.OpenImage(path);
            }
        }

        [TestMethod]
        public void TestSaveFile()
        {
            var path = TestImagePath;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand())
            {
                wand.OpenImage(path);

                wand.SaveImage(Path.Combine(SaveDirectory, "test.jpg"));
                wand.SaveImage(Path.Combine(SaveDirectory, "test.png"));
                wand.SaveImage(Path.Combine(SaveDirectory, "test.webp"));
            }
        }

        [TestMethod]
        public void TestSaveFileWithQuality()
        {
            var path = TestImagePath;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand())
            {
                wand.OpenImage(path);

                wand.SetQuality(90);
                wand.SaveImage(Path.Combine(SaveDirectory, "test.jpg"));

                wand.SetQuality(90);
                wand.SaveImage(Path.Combine(SaveDirectory, "test.png"));

                wand.SetQuality(90);
                wand.SaveImage(Path.Combine(SaveDirectory, "test.webp"));
            }
        }

        [TestMethod]
        public void TestResize()
        {
            var path = TestImagePath;

            Assert.IsTrue(File.Exists(path));

            using (var wand = new MagickWand())
            {
                wand.OpenImage(path);

                wand.ResizeImage(400, 150);

                wand.SaveImage(Path.Combine(SaveDirectory, "TestResize.jpg"));
                wand.SaveImage(Path.Combine(SaveDirectory, "TestResize.png"));
                wand.SaveImage(Path.Combine(SaveDirectory, "TestResize.webp"));
            }
        }

        [TestMethod]
        public void TestNewImage()
        {
            // Need to be able to create a new image, give it a background color, then overlay an image on top of it (potentially with transparency)

            using (var wand = new MagickWand())
            {
                wand.NewImage(100, 100, "#ffffff");

                //wand.SaveImage(Path.Combine(SaveDirectory, "TestSetBackgroundColor.jpg"));
                //wand.SaveImage(Path.Combine(SaveDirectory, "TestSetBackgroundColor.png"));
                //wand.SaveImage(Path.Combine(SaveDirectory, "TestSetBackgroundColor.webp"));
            }
        }
    }
}

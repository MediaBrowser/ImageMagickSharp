using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ImageMagickSharp.Tests
{
    public abstract class BaseTest
    {
        #region [Public Properties]

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region [Protected Properties]

        //[AssemblyInitialize]
        //public static void AssemblyInit(TestContext testContext)
        //{
        //	DirectoryInfo dir = new DirectoryInfo(testContext.DeploymentDirectory);
        //	testContext.Properties["DeploymentDirectory"] = dir.Parent.Parent.FullName;
        //}

        protected string UnitTestPath { get { return this.GetType().Name; } }

        protected string SaveDirectory
        {
            get
            {
                //var path = Path.Combine(TestContext.TestDir, TestContext.TestName);
                //var path = Path.Combine("..\\..\\..\\TestResults\\Deploy " + DateTime.Now.ToString("yyyy-MM-dd hh_mm"), this.UnitTestPath, TestContext.TestName);
                var path = Path.Combine("..\\..\\..\\TestResults\\Deploy", this.UnitTestPath, TestContext.TestName);
                Directory.CreateDirectory(path);
                return path;
            }
        }

        protected string TestImageLogo
        {
            get { return CreateImageResource("logo.png"); }
        }

        protected string TestImageThumb
        {
            get { return CreateImageResource("thumb.jpg"); }
        }

        protected string TestImageBackdrop
        {
            get { return CreateImageResource("backdrop.jpg"); }
        }

        protected string TestImageFolder
        {
            get { return CreateImageResource("folder.jpg"); }
        }

        private string CreateImageResource(string fileName)
        {
            var path = Path.Combine(SaveDirectory, fileName);

            if (!File.Exists(path))
            {
                using (var stream = GetType().Assembly.GetManifestResourceStream(string.Format("{0}.ResourceImages.{1}", GetType().Namespace, fileName)))
                {
                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        stream.CopyTo(fs);
                    }
                }
            }
            return path;
        }

        #endregion

        #region [Public Methods]

        [TestCleanup]
        public void TestCleanup()
        {
            //WandInitializer.DisposeEnvironment();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //WandInitializer.StartEnvironment();
        }

        #endregion

    }
}

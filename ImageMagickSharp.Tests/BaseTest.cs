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

		protected string UnitTestPath { get {return this.GetType().Name;}}

		protected string SaveDirectory
		{
			get
			{
				//var path = Path.Combine(TestContext.TestDir, TestContext.TestName);
				var path = Path.Combine("..\\..\\..\\TestResults\\Deploy " + DateTime.Now.ToString("yyyy-MM-dd hh_mm"), this.UnitTestPath, TestContext.TestName);
				Directory.CreateDirectory(path);
				return path;
			}
		}

		protected string TestImagePath
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

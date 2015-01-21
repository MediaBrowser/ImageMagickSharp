using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A wand initializer. </summary>
	public class WandInitializer
	{
		#region [Public Methods]

		/// <summary> Starts an environment. </summary>
		public static void StartEnvironment()
		{
			Environment.SetEnvironmentVariable("MAGICK_CODER_MODULE_PATH", "Libraries\\x86\\Coders");
			MagickWandInterop.MagickWandGenesis();
		}

		/// <summary> Dispose environment. </summary>
		public static void DisposeEnvironment()
		{
			MagickWandInterop.MagickWandTerminus();
		}

		#endregion
	}
}

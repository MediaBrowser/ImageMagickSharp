using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A wand interop. </summary>
	internal class WandInterop
	{

		#region [Wand Properties]
		/// <summary> Magick get version. </summary>
		/// <param name="version"> The version. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetVersion(out int version);

		/// <summary> Query if this object is magick wand instantiated. </summary>
		/// <returns> true if magick wand instantiated, false if not. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool IsMagickWandInstantiated();

		/// <summary> Query if 'wand' is magick wand. </summary>
		/// <param name="wand"> The wand. </param>
		/// <returns> true if magick wand, false if not. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool IsMagickWand(IntPtr wand);

		#endregion

		#region [Wand Methods]

		/// <summary> Magick wand genesis. </summary>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void MagickWandGenesis();

		/// <summary> Magick wand terminus. </summary>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void MagickWandTerminus();

		/// <summary> Magick command genesis. </summary>
		/// <param name="image_info"> Information describing the image. </param>
		/// <param name="command"> The command. </param>
		/// <param name="argc"> The argc. </param>
		/// <param name="argv"> The argv. </param>
		/// <param name="metadata"> The metadata. </param>
		/// <param name="exception"> The exception. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool MagickCommandGenesis(IntPtr image_info, MagickCommandType command, int argc, string[] argv, byte[] metadata, ref IntPtr exception);

		/// <summary> Magick command genesis. </summary>
		/// <param name="image_info"> Information describing the image. </param>
		/// <param name="command"> The command. </param>
		/// <param name="argc"> The argc. </param>
		/// <param name="argv"> The argv. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool MagickCommandGenesis(IntPtr image_info, MagickCommandType command, int argc, string[] argv);

		/// <summary> Magick query formats. </summary>
		/// <param name="pattern"> Specifies the pattern. </param>
		/// <param name="number_formats"> Number of formats. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickQueryFormats(IntPtr pattern, ref int number_formats);

		/// <summary> Magick query fonts. </summary>
		/// <param name="pattern"> Specifies the pattern. </param>
		/// <param name="number_formats"> Number of formats. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickQueryFonts(IntPtr pattern, ref int number_formats);
		#endregion

	}
}

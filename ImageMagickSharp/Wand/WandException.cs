using System;
using System.Linq;

namespace ImageMagickSharp
{
	/// <summary> Exception for signalling wand errors. </summary>
	/// <seealso cref="T:System.Exception"/>
	public class WandException : Exception
	{
		#region [Constructors]

		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.WandException class. </summary>
		/// <param name="wand"> Handle of the wand. </param>
		public WandException(IntPtr wand)
			: base(DecodeException(wand))
		{
		}

		#endregion

		#region [Private Methods]

		/// <summary> Decode exception. </summary>
		/// <param name="wand"> Handle of the wand. </param>
		/// <returns> A string. </returns>
		private static string DecodeException(IntPtr wand)
		{
			int exceptionSeverity;
			IntPtr exceptionPtr = MagickWandInterop.MagickGetException(wand, out exceptionSeverity);
			MagickWandInterop.MagickClearException(wand);
			return WandNativeString.Load(exceptionPtr);
		}

		#endregion

	}
}

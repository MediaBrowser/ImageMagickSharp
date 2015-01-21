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
		/// <param name="wandHandle"> Handle of the wand. </param>
		public WandException(IntPtr wandHandle)
			: base(DecodeException(wandHandle))
		{
		}

		#endregion

		#region [Private Methods]

		/// <summary> Decode exception. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> A string. </returns>
		private static string DecodeException(IntPtr wandHandle)
		{
			int exceptionSeverity;
			IntPtr exceptionPtr = MagickWandInterop.MagickGetException(wandHandle, out exceptionSeverity);
			MagickWandInterop.MagickClearException(wandHandle);
			return WandNativeString.Load(exceptionPtr);
		}

		#endregion

	}
}

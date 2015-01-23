using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMagickSharp
{
	/// <summary> A wand native string. </summary>
	/// <seealso cref="T:System.IDisposable"/>
	public class WandNativeString : IDisposable
	{
		#region [Constructors]

		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.WandNativeString class. </summary>
		/// <param name="value"> The value. </param>
		public WandNativeString(string value)
		{
			byte[] utf8 = Encoding.UTF8.GetBytes(value);
			this.Pointer = Marshal.AllocHGlobal(utf8.Length + 1);
			Marshal.Copy(utf8, 0, this.Pointer, utf8.Length);
			Marshal.Copy(Single0ByteArray, 0, this.Pointer + utf8.Length, 1);
		}

		#endregion

		#region [Private Fields]

		/// <summary> Array of single 0 bytes. </summary>
		private static byte[] Single0ByteArray = new byte[] { 0 };

		#endregion

		#region [Public Properties]

		/// <summary> Gets the pointer. </summary>
		/// <value> The pointer. </value>
		public IntPtr Pointer { get; private set; }

		#endregion

		#region [Public Methods]

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
		/// resources. </summary>
		/// <seealso cref="M:System.IDisposable.Dispose()"/>
		public void Dispose()
		{
			Marshal.FreeHGlobal(this.Pointer);
		}

		/// <summary> Loads. </summary>
		/// <param name="pointer"> The pointer. </param>
		/// <param name="relinquish"> true to relinquish. </param>
		/// <returns> A string. </returns>
		public static string Load(IntPtr pointer, bool relinquish = true)
		{
			List<byte> bytes = new List<byte>();
			byte[] buf = new byte[1];
			int index = 0;
			while (true)
			{
				Marshal.Copy(pointer + index, buf, 0, 1);
				if (buf[0] == 0)
				{
					break;
				}
				bytes.Add(buf[0]);
				++index;
			}
			if (relinquish)
			{
				MagickWandInterop.MagickRelinquishMemory(pointer);
			}
			return Encoding.UTF8.GetString(bytes.ToArray());
		}

		#endregion

	}
}

using System;
using System.Runtime.InteropServices;

namespace ImageMagickSharp
{
	/// <summary> A magick wand. </summary>
	/// <seealso cref="T:ImageMagickSharp.WandBase"/>
	/// <seealso cref="T:System.IDisposable"/>
	public class MagickWand : WandBase, IDisposable
	{
		#region [Constructors]
		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		public MagickWand()
		{
			this.WandHandle = MagickWandInterop.NewMagickWand();
		}

		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="color"> The color. </param>
		public MagickWand(int width, int height, string color)
			: this(width, height, new PixelWand(color))
		{

		}

		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		/// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="pixelWand"> The pixel wand. </param>
		public MagickWand(int width, int height, PixelWand pixelWand)
		{
			this.WandHandle = MagickWandInterop.NewMagickWand();
			if (this.WandHandle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring wand.");
			}

			this.CheckError(MagickWandInterop.MagickNewImage(this.WandHandle, width, height, pixelWand.WandHandle));
		}

		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		/// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
		/// <param name="path"> Full pathname of the file. </param>
		public MagickWand(string path)
		{
			this.WandHandle = MagickWandInterop.NewMagickWand();
			if (this.WandHandle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring wand.");
			}

			using (WandNativeString pathString = new WandNativeString(path))
			{
				this.CheckError(MagickWandInterop.MagickReadImage(this.WandHandle, pathString.Pointer));
			}
		}

		#endregion

		#region [Magick Wand Properties]
		/// <summary> Gets or sets the image compression quality. </summary>
		/// <value> The image compression quality. </value>
		public int ImageCompressionQuality
		{
			get { return MagickWandInterop.MagickGetImageCompressionQuality(this.WandHandle); }
			set { this.CheckError(MagickWandInterop.MagickSetImageCompressionQuality(this.WandHandle, value)); }
		}

		/// <summary> Gets the width. </summary>
		/// <value> The width. </value>
		public int Width
		{
			get { return MagickWandInterop.MagickGetImageWidth(this.WandHandle); }
		}

		/// <summary> Gets the height. </summary>
		/// <value> The height. </value>
		public int Height
		{
			get { return MagickWandInterop.MagickGetImageHeight(this.WandHandle); }
		}

		/// <summary> Gets the filename of the file. </summary>
		/// <value> The filename. </value>
		public string Filename
		{
			get { return WandNativeString.Load(MagickWandInterop.MagickGetImageFilename(this.WandHandle)); }
		}

		/// <summary> Gets or sets the format to use. </summary>
		/// <value> The format. </value>
		public string Format
		{
			get { return WandNativeString.Load(MagickWandInterop.MagickGetImageFormat(this.WandHandle)); }
			set
			{
				using (var formatString = new WandNativeString(value))
				{
					this.CheckError(MagickWandInterop.MagickSetImageFormat(this.WandHandle, formatString.Pointer));
				}
			}
		}

		/// <summary> Sets a value indicating whether the matte. </summary>
		/// <value> true if matte, false if not. </value>
		public bool Matte
		{
			set { this.CheckError(MagickWandInterop.MagickSetImageMatte(this.WandHandle, value ? 1 : 0)); }
		}

		#endregion


		#region [Magick Wand Image Methods]

		//public void OpenImage(string path)
		//{
		//	this.CheckError(MagickWandInterop.MagickReadImage(this.WandHandle, path));
		//}


		//public void NewImage(int width, int height, string backgroundColor)
		//{
		//	using (var pixelWand = new PixelWand(backgroundColor))
		//	{
		//		MagickWandInterop.PixelSetColor(pixelWand.WandHandle, backgroundColor);
		//		MagickWandInterop.MagickNewImage(this.WandHandle, width, height, pixelWand.WandHandle);
		//		//MagickWandInterop.PixelSetMagickColor(pixelWand.IntPtr, backgroundColor);
		//		//MagickWandInterop.MagickNewImage(this.WandHandle, width, height, pixelWand.IntPtr);
		//	}
		//}

		/// <summary> Saves an image. </summary>
		/// <param name="path"> Full pathname of the file. </param>
		public void SaveImage(string path)
		{
			this.CheckError(MagickWandInterop.MagickWriteImage(this.WandHandle, path));
		}

		/// <summary> Resize image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		public void ResizeImage(int width, int height)
		{
			ResizeImage(width, height, FilterTypes.LanczosFilter);
		}

		/// <summary> Resize image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="filter"> Specifies the filter. </param>
		public void ResizeImage(int width, int height, FilterTypes filter)
		{
			this.CheckError((MagickWandInterop.MagickResizeImage(this.WandHandle, width, height, (int)filter, 1.0)));
		}

		/// <summary> Crop image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public void CropImage(int width, int height, int x, int y)
		{
			this.CheckError(MagickWandInterop.MagickCropImage(this.WandHandle, width, height, x, y));
		}

		/// <summary> Rotates. </summary>
		/// <param name="pixelWand"> The pixel wand. </param>
		/// <param name="degrees"> The degrees. </param>
		public void Rotate(PixelWand pixelWand, double degrees)
		{
			this.CheckError(MagickWandInterop.MagickRotateImage(this.WandHandle, pixelWand.WandHandle, degrees));
		}

		/// <summary> Transparents. </summary>
		/// <param name="target"> Target for the. </param>
		/// <param name="alpha"> The alpha. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> true to invert. </param>
		public void Transparent(PixelWand target, double alpha, double fuzz, bool invert)
		{
			this.CheckError(MagickWandInterop.MagickTransparentPaintImage(this.WandHandle, target.WandHandle, alpha, fuzz, invert ? 1 : 0));
		}

		/// <summary> Sets a quality. </summary>
		/// <param name="value"> The value. </param>
		public void SetQuality(int value)
		{
			this.CheckError((MagickWandInterop.MagickSetImageCompressionQuality(this.WandHandle, value)));
		}

		/// <summary> Fills. </summary>
		/// <param name="target"> Target for the. </param>
		/// <param name="fill"> The fill. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> true to invert. </param>
		public void Fill(PixelWand target, PixelWand fill, double fuzz, bool invert)
		{
			this.CheckError(MagickWandInterop.MagickOpaquePaintImage(this.WandHandle, target.WandHandle, fill.WandHandle, fuzz, invert ? 1 : 0));
		}

		#endregion

		#region [Private Methods]

		/// <summary> Finalizes an instance of the ImageMagickSharp.MagickWand class. </summary>
		~MagickWand()
		{
			this.Dispose();
		}

		#endregion

		#region [IDisposable]
		
		/// <summary> true if disposed. </summary>
		private bool disposed = false;

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
		/// resources. </summary>
		/// <seealso cref="M:System.IDisposable.Dispose()"/>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases the unmanaged resources used by the ImageMagickSharp.MagickWand and optionally
		/// releases the managed resources. </summary>
		/// <param name="disposing"> true to release both managed and unmanaged resources; false to
		/// release only unmanaged resources. </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				this.WandHandle = MagickWandInterop.DestroyMagickWand(this.WandHandle);
				this.WandHandle = IntPtr.Zero;
				disposed = true;

			}
		}

		#endregion

	}
}

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageMagickSharp
{
	/// <summary> A magick wand. </summary>
	/// <seealso cref="T:ImageMagickSharp.WandBase"/>
	/// <seealso cref="T:System.IDisposable"/>
	public class MagickWand : WandCore, IDisposable
	{
		#region [Constructors]
		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		public MagickWand()
		{
			Wand.EnsureInitialized();
			this.Handle = MagickWandInterop.NewMagickWand();
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
			Wand.EnsureInitialized();
			this.Handle = MagickWandInterop.NewMagickWand();
			if (this.Handle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring wand.");
			}

			this.NewImage(width, height, pixelWand);
		}

		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		/// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
		/// <param name="path"> Full pathname of the file. </param>
		public MagickWand(string path)
		{
			Wand.EnsureInitialized();
			this.Handle = MagickWandInterop.NewMagickWand();
			if (this.Handle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring wand.");
			}

			this.OpenImage(path);
		}

		#endregion

		#region [Magick Wand Properties]
		/// <summary> Gets the image. </summary>
		/// <value> The image. </value>
		public ImageWand Image
		{
			get
			{
				if (this._Image == null)
					this._Image = new ImageWand(this);
				return _Image;
			}
		}

		/// <summary> Gets the drawing. </summary>
		/// <value> The drawing. </value>
		public DrawingWand Drawing
		{
			get
			{
				if (this._Drawing == null)
					this._Drawing = new DrawingWand();
				return _Drawing;
			}
		}

		/// <summary> Gets the filename of the file. </summary>
		/// <value> The filename. </value>
		public string Filename
		{
			get { return WandNativeString.Load(ImageWandInterop.MagickGetImageFilename(this.Handle)); }
		}

		#endregion

		#region [Magick Wand Properties - Fonts]

		/// <summary> Gets the font. </summary>
		/// <returns> The font. </returns>
		public string GetFont()
		{
			return WandNativeString.Load(MagickWandInterop.MagickGetFont(this.Handle)); ;
		}

		/// <summary> Sets a font. </summary>
		/// <param name="font"> The font. </param>
		/// <returns> A string. </returns>
		public void SetFont(string font)
		{
			MagickWandInterop.MagickSetFont(this.Handle, font);
		}
		#endregion

		#region [Magick Wand Methods - Image]

		/// <summary> Creates a new image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="pixelWand"> The pixel wand. </param>
		public void NewImage(int width, int height, PixelWand pixelWand)
		{
			this.CheckError(MagickWandInterop.MagickNewImage(this.Handle, width, height, pixelWand.Handle));
		}

		/// <summary> Creates a new image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="backgroundColor"> The background color. </param>
		public void NewImage(int width, int height, string backgroundColor)
		{
			using (var pixelWand = new PixelWand(backgroundColor))
			{
				this.NewImage(width, height, pixelWand);
			}
		}

		public bool OpenImage(string path)
		{
			using (WandNativeString pathString = new WandNativeString(path))
			{
				return this.CheckErrorBool(MagickWandInterop.MagickReadImage(this.Handle, pathString.Pointer));
			}
		}
		/// <summary> Saves an image. </summary>
		/// <param name="path"> Full pathname of the file. </param>
		public void SaveImage(string path)
		{
			this.CheckError(MagickWandInterop.MagickWriteImage(this.Handle, path));
		}

		/// <summary> Saves the images. </summary>
		/// <param name="path"> Full pathname of the file. </param>
		/// <param name="adjoin"> true to adjoin. </param>
		public void SaveImages(string path, bool adjoin = false)
		{
			this.CheckError(MagickWandInterop.MagickWriteImages(this.Handle, path, adjoin));
		}

		/// <summary>
		/// ClearMagickWand() clears resources associated with the wand, leaving the wand blank, and
		/// ready to be used for a new set of images. </summary>
		public void ClearMagickWand()
		{
			MagickWandInterop.ClearMagickWand(this.Handle);
		}


		private Rectangle _PageSize;

		public Rectangle GetPageSize()
		{
			int width;
			int height;
			int x;
			int y;
			MagickWandInterop.MagickGetPage(this.Handle, out width, out height, out x, out y);
			this._PageSize = new Rectangle(x, y, width, height);
			return _PageSize;
		}

		public void SetPageSize(int width, int height, int x, int y)
		{
			MagickWandInterop.MagickSetPage(this.Handle, width, height, x, y);
		}
		#endregion

		#region [Magick Wand Methods - Iterator]

		/// <summary> Iterator set image. </summary>
		/// <param name="source"> Source for the. </param>
		/// <param name="target"> Target for the. </param>
		public void IteratorSetImage(MagickWand target)
		{
			this.CheckError(MagickWandInterop.MagickSetImage(this.Handle, target.Handle));
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

		private DrawingWand _Drawing;
		private ImageWand _Image;
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
				this.Handle = MagickWandInterop.DestroyMagickWand(this.Handle);
				this.Handle = IntPtr.Zero;
				disposed = true;

			}
		}

		#endregion

	}
}

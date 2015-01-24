using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageMagickSharp
{
	/// <summary> A magick wand. </summary>
	/// <seealso cref="T:ImageMagickSharp.WandBase"/>
	/// <seealso cref="T:System.IDisposable"/>
	public class MagickWand : WandCore<MagickWand>, IDisposable
	{
		#region [Constructors]

		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		public MagickWand()
		{
			Wand.EnsureInitialized();
			this.Handle = MagickWandInterop.NewMagickWand();
		}

		/// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
		/// <param name="wand"> The wand. </param>
		public MagickWand(IntPtr wand)
		{
			Wand.EnsureInitialized();
			this.Handle = wand;
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

		/// <summary> Gets the filename of the file. </summary>
		/// <value> The filename. </value>
		public string Filename
		{
			get { return WandNativeString.Load(ImageWandInterop.MagickGetImageFilename(this)); }
		}

		/// <summary> Gets or sets the zero-based index of the iterator. </summary>
		/// <value> The iterator index. </value>
		public int IteratorIndex
		{
			get { return MagickWandInterop.MagickGetIteratorIndex(this); }
			set { MagickWandInterop.MagickSetIteratorIndex(this, value); }
		}

		#endregion

		#region [Magick Wand Properties - Fonts]

		/// <summary> Gets the font. </summary>
		/// <returns> The font. </returns>
		public string GetFont()
		{
			return WandNativeString.Load(MagickWandInterop.MagickGetFont(this)); ;
		}

		/// <summary> Sets a font. </summary>
		/// <param name="font"> The font. </param>
		/// <returns> A string. </returns>
		public void SetFont(string font)
		{
			MagickWandInterop.MagickSetFont(this, font);
		}
		#endregion

		#region [Magick Wand Methods]
		
		/// <summary> Clone magick wand. </summary>
		/// <returns> A MagickWand. </returns>
		public MagickWand CloneMagickWand()
		{
			return new MagickWand(MagickWandInterop.CloneMagickWand(this));
		}

		#endregion

		#region [Magick Wand Methods - Image]

		/// <summary> Creates a new image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="pixelWand"> The pixel wand. </param>
		public void NewImage(int width, int height, PixelWand pixelWand)
		{
			this.CheckError(MagickWandInterop.MagickNewImage(this, width, height, pixelWand));
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
			return this.CheckErrorBool(MagickWandInterop.MagickReadImage(this, path));
		}

		/// <summary> Removes the image. </summary>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool RemoveImage()
		{
			return MagickWandInterop.MagickRemoveImage(this);
			
		}

		/// <summary> Saves an image. </summary>
		/// <param name="path"> Full pathname of the file. </param>
		public void SaveImage(string path)
		{
			this.CheckError(MagickWandInterop.MagickWriteImage(this, path));
		}

		/// <summary> Saves the images. </summary>
		/// <param name="path"> Full pathname of the file. </param>
		/// <param name="adjoin"> true to adjoin. </param>
		public void SaveImages(string path, bool adjoin = false)
		{
			this.CheckError(MagickWandInterop.MagickWriteImages(this, path, adjoin));
		}

		/// <summary>
		/// ClearMagickWand() clears resources associated with the wand, leaving the wand blank, and
		/// ready to be used for a new set of images. </summary>
		public void ClearMagickWand()
		{
			MagickWandInterop.ClearMagickWand(this);
		}


		private Rectangle _PageSize;

		public Rectangle GetPageSize()
		{
			int width;
			int height;
			int x;
			int y;
			MagickWandInterop.MagickGetPage(this, out width, out height, out x, out y);
			this._PageSize = new Rectangle(x, y, width, height);
			return _PageSize;
		}

		/// <summary> Sets page size. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public void SetPageSize(int width, int height, int x, int y)
		{
			MagickWandInterop.MagickSetPage(this, width, height, x, y);
		}

		/// <summary> Combine images. </summary>
		/// <param name="channel"> The channel. </param>
		/// <returns> A MagickWand. </returns>
		public MagickWand CombineImages(int channel)
		{
			return new MagickWand(MagickWandInterop.MagickCombineImages(this, channel));
		}

		/// <summary> Combine images. </summary>
		/// <param name="stack"> true to stack. </param>
		/// <returns> A MagickWand. </returns>
		public MagickWand AppendImages(bool stack = false)
		{
			return new MagickWand(MagickWandInterop.MagickAppendImages(this, stack));
		}


		#endregion

		#region [Magick Wand Methods - Iterator]
	
		/// <summary> Iterator set image. </summary>
		/// <param name="source"> Source for the. </param>
		/// <param name="target"> Target for the. </param>
		public void IteratorSetImage(MagickWand target)
		{
			this.CheckError(MagickWandInterop.MagickSetImage(this, target.Handle));
		}

		/// <summary> Resets the iterator. </summary>
		public void ResetIterator()
		{
			MagickWandInterop.MagickResetIterator(this);
		}
		/// <summary> Sets first iterator. </summary>
		public void SetFirstIterator()
		{
			MagickWandInterop.MagickSetFirstIterator(this);
		}

		/// <summary> Sets last iterator. </summary>
		public void SetLastIterator()
		{
			MagickWandInterop.MagickSetLastIterator(this);
		}

		/// <summary> Gets number images. </summary>
		/// <returns> The number images. </returns>
		public int GetNumberImages()
		{
			return MagickWandInterop.MagickGetNumberImages(this);
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
				this.Handle = MagickWandInterop.DestroyMagickWand(this);
				this.Handle = IntPtr.Zero;
				disposed = true;

			}
		}

		#endregion

	}
}

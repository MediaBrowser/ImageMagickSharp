using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	public class ImageWand : WandBase
	{

		#region [Constructors]

		/// <summary> Initializes a new instance of the MagickBase class. </summary>
		/// <param name="magickWand"> . </param>
		public ImageWand(MagickWand magickWand)
			: base(magickWand)
		{

		}

		#endregion


		#region [Image Wand Properties]

		/// <summary> Gets the width. </summary>
		/// <value> The width. </value>
		public int Width
		{
			get { return ImageWandInterop.MagickGetImageWidth(this.MagickWand.Handle); }
		}

		/// <summary> Gets the height. </summary>
		/// <value> The height. </value>
		public int Height
		{
			get { return ImageWandInterop.MagickGetImageHeight(this.MagickWand.Handle); }
		}

		/// <summary> Gets or sets the image compression quality. </summary>
		/// <value> The image compression quality. </value>
		public int ImageCompressionQuality
		{
			get { return ImageWandInterop.MagickGetImageCompressionQuality(this.MagickWand.Handle); }
			set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageCompressionQuality(this.MagickWand.Handle, value)); }
		}

		/// <summary> Sets a value indicating whether the matte. </summary>
		/// <value> true if matte, false if not. </value>
		public bool Matte
		{
			set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageMatte(this.MagickWand.Handle, value ? 1 : 0)); }
		}

		/// <summary> Gets or sets the format to use. </summary>
		/// <value> The format. </value>
		public string Format
		{
			get { return WandNativeString.Load(ImageWandInterop.MagickGetImageFormat(this.MagickWand.Handle)); }
			set
			{
				using (var formatString = new WandNativeString(value))
				{
					this.MagickWand.CheckError(ImageWandInterop.MagickSetImageFormat(this.MagickWand.Handle, formatString.Pointer));
				}
			}
		}
		#endregion


		#region [Image Wand Methods]

		/// <summary> Resize image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="filter"> Specifies the filter. </param>
		public void ResizeImage(int width, int height, FilterTypes filter)
		{
			this.MagickWand.CheckError((ImageWandInterop.MagickResizeImage(this.MagickWand.Handle, width, height, (int)filter, 1.0)));
		}

		/// <summary> Crop image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public void CropImage(int width, int height, int x, int y)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickCropImage(this.MagickWand.Handle, width, height, x, y));
		}

		/// <summary> Rotate image. </summary>
		/// <param name="pixelWand"> The pixel wand. </param>
		/// <param name="degrees"> The degrees. </param>
		public void RotateImage(PixelWand pixelWand, double degrees)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickRotateImage(this.MagickWand.Handle, pixelWand.Handle, degrees));
		}

		/// <summary> Flip image. </summary>
		public void FlipImage()
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickFlipImage(this.MagickWand.Handle)); ;
		}

		/// <summary> Transparents. </summary>
		/// <param name="target"> Target for the. </param>
		/// <param name="alpha"> The alpha. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> true to invert. </param>
		public void Transparent(PixelWand target, double alpha, double fuzz, bool invert)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickTransparentPaintImage(this.MagickWand.Handle, target.Handle, alpha, fuzz, invert ? 1 : 0));
		}


		/// <summary> Resize image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		public void ResizeImage(int width, int height)
		{
			ResizeImage(width, height, FilterTypes.LanczosFilter);
		}

		/// <summary> Sets a quality. </summary>
		/// <param name="value"> The value. </param>
		public void SetQuality(int value)
		{
			this.MagickWand.CheckError((ImageWandInterop.MagickSetImageCompressionQuality(this.MagickWand.Handle, value)));
		}

		/// <summary> Fills. </summary>
		/// <param name="target"> Target for the. </param>
		/// <param name="fill"> The fill. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> true to invert. </param>
		public void Fill(PixelWand target, PixelWand fill, double fuzz, bool invert)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickOpaquePaintImage(this.MagickWand.Handle, target.Handle, fill.Handle, fuzz, invert ? 1 : 0));
		}

		#endregion
	}
}

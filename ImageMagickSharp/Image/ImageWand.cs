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
			get { return ImageWandInterop.MagickGetImageWidth(this.MagickWand); }
		}

		/// <summary> Gets the height. </summary>
		/// <value> The height. </value>
		public int Height
		{
			get { return ImageWandInterop.MagickGetImageHeight(this.MagickWand); }
		}

		/// <summary> Gets or sets the image compression quality. </summary>
		/// <value> The image compression quality. </value>
		public int ImageCompressionQuality
		{
			get { return ImageWandInterop.MagickGetImageCompressionQuality(this.MagickWand); }
			set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageCompressionQuality(this.MagickWand, value)); }
		}

		public PixelWand ImageBackgroundColor
		{
			get
			{
				IntPtr background;
				ImageWandInterop.MagickGetImageBackgroundColor(this.MagickWand, out background);
				return new PixelWand(background);
			}
			set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageBackgroundColor(this.MagickWand, value)); }
		}

		/// <summary> Sets a value indicating whether the matte. </summary>
		/// <value> true if matte, false if not. </value>
		public bool Matte
		{
			set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageMatte(this.MagickWand, value ? 1 : 0)); }
		}

		/// <summary> Gets or sets the format to use. </summary>
		/// <value> The format. </value>
		public string Format
		{
			get { return WandNativeString.Load(ImageWandInterop.MagickGetImageFormat(this.MagickWand)); }
			set
			{
				using (var formatString = new WandNativeString(value))
				{
					this.MagickWand.CheckError(ImageWandInterop.MagickSetImageFormat(this.MagickWand, formatString.Pointer));
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
			this.MagickWand.CheckError((ImageWandInterop.MagickResizeImage(this.MagickWand, width, height, (int)filter, 1.0)));
		}

		/// <summary> Crop image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public void CropImage(int width, int height, int x, int y)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickCropImage(this.MagickWand, width, height, x, y));
		}

		/// <summary> Rotate image. </summary>
		/// <param name="pixelWand"> The pixel wand. </param>
		/// <param name="degrees"> The degrees. </param>
		public void RotateImage(PixelWand pixelWand, double degrees)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickRotateImage(this.MagickWand, pixelWand, degrees));
		}

		/// <summary> Flip image. </summary>
		public void FlipImage()
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickFlipImage(this.MagickWand)); ;
		}

		/// <summary> Transparents. </summary>
		/// <param name="target"> Target for the. </param>
		/// <param name="alpha"> The alpha. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> true to invert. </param>
		public void Transparent(PixelWand target, double alpha, double fuzz, bool invert)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickTransparentPaintImage(this.MagickWand, target, alpha, fuzz, invert ? 1 : 0));
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
			this.MagickWand.CheckError((ImageWandInterop.MagickSetImageCompressionQuality(this.MagickWand, value)));
		}

		/// <summary> Fills. </summary>
		/// <param name="target"> Target for the. </param>
		/// <param name="fill"> The fill. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> true to invert. </param>
		public void Fill(PixelWand target, PixelWand fill, double fuzz, bool invert)
		{
			this.MagickWand.CheckError(ImageWandInterop.MagickOpaquePaintImage(this.MagickWand, target, fill, fuzz, invert ? 1 : 0));
		}

		/// <summary> Sets image extent. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool SetImageExtent(int width, int height, int x, int y)
		{
			return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickSetImageExtent(this.MagickWand, width, height));
		}

		/// <summary> Extent image. </summary>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool ExtentImage(int width, int height, int x, int y)
		{
			return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickExtentImage(this.MagickWand, width, height, x, y));
		}

		#endregion

		#region [Image Wand Methods - Drawing]

		public bool DrawImage(PixelWand target, DrawingWand drawing_wand)
		{
			return this.MagickWand.CheckError(ImageWandInterop.MagickDrawImage(this.MagickWand, drawing_wand));
		}

		#endregion
	}
}

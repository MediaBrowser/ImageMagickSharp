using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A magick wand interop. </summary>
	internal static class MagickWandInterop
	{
		#region [Magick Wand]

		/// <summary> Magick wand genesis. </summary>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void MagickWandGenesis();


		/// <summary> Magick wand terminus. </summary>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void MagickWandTerminus();

		/// <summary> Creates a new magick wand. </summary>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr NewMagickWand();

		/// <summary> Destroys the magick wand described by wandHandle. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr DestroyMagickWand(IntPtr wandHandle);

		/// <summary> Clone magick wand. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr CloneMagickWand(IntPtr wandHandle);

		#endregion

		#region [Magick Wand Exception]
		/// <summary> Magick get exception. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="exceptionType"> Type of the exception. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetException(IntPtr wandHandle, out int exceptionType);

		/// <summary> Magick clear exception. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickClearException(IntPtr wandHandle);

		#endregion

		#region [Magick Wand Image]
		/// <summary> Magick new image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="columns"> The columns. </param>
		/// <param name="rows"> The rows. </param>
		/// <param name="background"> The background. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickNewImage(IntPtr wandHandle, int columns, int rows, IntPtr background);

		/// <summary> Magick new image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="columns"> The columns. </param>
		/// <param name="rows"> The rows. </param>
		/// <param name="pixelWand"> The pixel wand. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		public static extern int MagickNewImage(IntPtr wandHandle, ulong columns, ulong rows, IntPtr pixelWand);

		/// <summary> Magick read image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="path"> Full pathname of the file. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickReadImage(IntPtr wandHandle, IntPtr path);

		/// <summary> Magick read image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="file_name"> Filename of the file. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickReadImage(IntPtr wandHandle, string file_name);

		/// <summary> Magick write image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="path"> Full pathname of the file. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickWriteImage(IntPtr wandHandle, IntPtr path);

		/// <summary> Magick write image. </summary>
		/// <param name="magick_wand"> The magick wand. </param>
		/// <param name="file_name"> Filename of the file. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool MagickWriteImage(IntPtr magick_wand, string file_name);

		/// <summary> Magick resize image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="columns"> The columns. </param>
		/// <param name="rows"> The rows. </param>
		/// <param name="filterType"> Type of the filter. </param>
		/// <param name="blur"> The blur. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickResizeImage(IntPtr wandHandle, int columns, int rows, int filterType, double blur);

		/// <summary> Magick crop image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickCropImage(IntPtr wandHandle, int width, int height, int x, int y);

		/// <summary> Magick get image compression quality. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickGetImageCompressionQuality(IntPtr wandHandle);

		/// <summary> Magick set image compression quality. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="quality"> The quality. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickSetImageCompressionQuality(IntPtr wandHandle, int quality);

		/// <summary> Magick set image compression quality. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="quality"> The quality. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickSetImageCompressionQuality(IntPtr wandHandle, uint quality);

		/// <summary> Magick gaussian blur image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="radius"> The radius. </param>
		/// <param name="sigma"> The sigma. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickGaussianBlurImage(IntPtr wandHandle, double radius, double sigma);

		/// <summary> Magick unsharp mask image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="radius"> The radius. </param>
		/// <param name="sigma"> The sigma. </param>
		/// <param name="amount"> The amount. </param>
		/// <param name="threshold"> The threshold. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickUnsharpMaskImage(IntPtr wandHandle, double radius, double sigma, double amount, double threshold);

		/// <summary> Magick get image filename. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetImageFilename(IntPtr wandHandle);

		/// <summary> Magick get image format. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetImageFormat(IntPtr wandHandle);

		/// <summary> Magick set image format. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="format"> Describes the format to use. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickSetImageFormat(IntPtr wandHandle, IntPtr format);

		/// <summary> Magick get image BLOB. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="length"> The length. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetImageBlob(IntPtr wandHandle, out int length);

		/// <summary> Magick read image BLOB. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="blob"> The BLOB. </param>
		/// <param name="length"> The length. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickReadImageBlob(IntPtr wandHandle, IntPtr blob, int length);

		/// <summary> Magick relinquish memory. </summary>
		/// <param name="resource"> The resource. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickRelinquishMemory(IntPtr resource);

		/// <summary> Magick get quantum depth. </summary>
		/// <param name="depth"> The depth. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetQuantumDepth(out int depth);

		/// <summary> Magick get version. </summary>
		/// <param name="version"> The version. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetVersion(out int version);

		/// <summary> Magick reset image page. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="page"> The page. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickResetImagePage(IntPtr wandHandle, IntPtr page);

		/// <summary> Magick composite image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="sourcePtr"> Source pointer. </param>
		/// <param name="compositeOperator"> The composite operator. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickCompositeImage(IntPtr wandHandle, IntPtr sourcePtr, int compositeOperator, int x, int y);

		/// <summary> Magick rotate image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="background"> The background. </param>
		/// <param name="degrees"> The degrees. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickRotateImage(IntPtr wandHandle, IntPtr background, double degrees);

		/// <summary> Magick transparent paint image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="target"> Target for the. </param>
		/// <param name="alpha"> The alpha. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> The invert. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickTransparentPaintImage(IntPtr wandHandle, IntPtr target, double alpha, double fuzz, int invert);

		/// <summary> Magick opaque paint image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="target"> Target for the. </param>
		/// <param name="fill"> The fill. </param>
		/// <param name="fuzz"> The fuzz. </param>
		/// <param name="invert"> The invert. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickOpaquePaintImage(IntPtr wandHandle, IntPtr target, IntPtr fill, double fuzz, int invert);

		/// <summary> Magick threshold image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="threshold"> The threshold. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickThresholdImage(IntPtr wandHandle, double threshold);

		/// <summary> Magick adaptive threshold image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="bias"> The bias. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickAdaptiveThresholdImage(IntPtr wandHandle, int width, int height, double bias);

		/// <summary> Magick transform image colorspace. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="colorspaceType"> Type of the colorspace. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickTransformImageColorspace(IntPtr wandHandle, int colorspaceType);

		/// <summary> Magick quantize image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="number_colors"> Number of colors. </param>
		/// <param name="colorsapceType"> Type of the colorsapce. </param>
		/// <param name="treedepth"> The treedepth. </param>
		/// <param name="dither_method"> The dither method. </param>
		/// <param name="measure_error"> The measure error. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickQuantizeImage(IntPtr wandHandle, int number_colors, int colorsapceType, int treedepth, int dither_method, int measure_error);

		/// <summary> Magick normalize image. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickNormalizeImage(IntPtr wandHandle);

		/// <summary> Magick get image width. </summary>
		/// <param name="ptr"> The pointer. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickGetImageWidth(IntPtr ptr);

		/// <summary> Magick get image height. </summary>
		/// <param name="ptr"> The pointer. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickGetImageHeight(IntPtr ptr);

		/// <summary> Magick set image matte. </summary>
		/// <param name="ptr"> The pointer. </param>
		/// <param name="matte"> The matte. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickSetImageMatte(IntPtr ptr, int matte);

		#endregion

		#region [Pixel Wand]
		/// <summary> Creates a new pixel wand. </summary>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr NewPixelWand();

		/// <summary> Destroys the pixel wand described by wandHandle. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void ClearPixelWand(IntPtr wandHandle);


		#endregion

		#region [Pixel Wand Color]
		/// <summary> Pixel set color. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="color"> The color. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int PixelSetColor(IntPtr wandHandle, IntPtr color);

		/// <summary> Pixel set color. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="color"> The color. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int PixelSetColor(IntPtr wandHandle, string color);

		/// <summary> Pixel get color as string. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr PixelGetColorAsString(IntPtr wandHandle);

		/// <summary> Pixel get color as normalized string. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr PixelGetColorAsNormalizedString(IntPtr wandHandle);

		/// <summary> Pixel get alpha. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> A double. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern double PixelGetAlpha(IntPtr wandHandle);

		/// <summary> Pixel set alpha. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="value"> The value. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void PixelSetAlpha(IntPtr wandHandle, double value);

		/// <summary> Pixel get opacity. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> A double. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern double PixelGetOpacity(IntPtr wandHandle);

		/// <summary> Pixel set opacity. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="value"> The value. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void PixelSetOpacity(IntPtr wandHandle, double value);

		/// <summary> Pixel get red. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> A double. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern double PixelGetRed(IntPtr wandHandle);

		/// <summary> Pixel set red. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="value"> The value. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void PixelSetRed(IntPtr wandHandle, double value);

		/// <summary> Pixel get green. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> A double. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern double PixelGetGreen(IntPtr wandHandle);

		/// <summary> Pixel set green. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="value"> The value. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void PixelSetGreen(IntPtr wandHandle, double value);

		/// <summary> Pixel get blue. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <returns> A double. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern double PixelGetBlue(IntPtr wandHandle);

		/// <summary> Pixel set blue. </summary>
		/// <param name="wandHandle"> Handle of the wand. </param>
		/// <param name="value"> The value. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void PixelSetBlue(IntPtr wandHandle, double value);

		#endregion

		/// <summary> The magick false. </summary>
		public static readonly int MagickFalse = 0;
	}
}

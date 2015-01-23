using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    internal static class ImageWandInterop
    {
        #region [Image Wand]

        /// <summary> Magick resize image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="rows"> The rows. </param>
        /// <param name="filterType"> Type of the filter. </param>
        /// <param name="blur"> The blur. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickResizeImage(IntPtr wand, int columns, int rows, int filterType, double blur);

        /// <summary> Magick crop image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickCropImage(IntPtr wand, int width, int height, int x, int y);

        /// <summary> Magick get image compression quality. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickGetImageCompressionQuality(IntPtr wand);

        /// <summary> Magick set image compression quality. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="quality"> The quality. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickSetImageCompressionQuality(IntPtr wand, int quality);

        /// <summary> Magick set image compression quality. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="quality"> The quality. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickSetImageCompressionQuality(IntPtr wand, uint quality);
        /// <summary> Magick gaussian blur image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="radius"> The radius. </param>
        /// <param name="sigma"> The sigma. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickGaussianBlurImage(IntPtr wand, double radius, double sigma);

        /// <summary> Magick unsharp mask image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="radius"> The radius. </param>
        /// <param name="sigma"> The sigma. </param>
        /// <param name="amount"> The amount. </param>
        /// <param name="threshold"> The threshold. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickUnsharpMaskImage(IntPtr wand, double radius, double sigma, double amount, double threshold);

		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool MagickSetImageFilename(IntPtr wand, string filename);

		/// <summary> Magick get image filename. </summary>
		/// <param name="wand"> Handle of the wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr MagickGetImageFilename(IntPtr wand);

        /// <summary> Magick get image format. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> An IntPtr. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr MagickGetImageFormat(IntPtr wand);

        /// <summary> Magick set image format. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="format"> Describes the format to use. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickSetImageFormat(IntPtr wand, IntPtr format);

        /// <summary> Magick get image BLOB. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="length"> The length. </param>
        /// <returns> An IntPtr. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr MagickGetImageBlob(IntPtr wand, out int length);

        /// <summary> Magick read image BLOB. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="blob"> The BLOB. </param>
        /// <param name="length"> The length. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickReadImageBlob(IntPtr wand, IntPtr blob, int length);

        /// <summary> Magick reset image page. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="page"> The page. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickResetImagePage(IntPtr wand, IntPtr page);

        /// <summary> Magick composite image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="sourcePtr"> Source pointer. </param>
        /// <param name="compositeOperator"> The composite operator. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickCompositeImage(IntPtr wand, IntPtr sourcePtr, int compositeOperator, int x, int y);

        /// <summary> Magick rotate image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="background"> The background. </param>
        /// <param name="degrees"> The degrees. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickRotateImage(IntPtr wand, IntPtr background, double degrees);

        /// <summary> Magick transparent paint image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="target"> Target for the. </param>
        /// <param name="alpha"> The alpha. </param>
        /// <param name="fuzz"> The fuzz. </param>
        /// <param name="invert"> The invert. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickTransparentPaintImage(IntPtr wand, IntPtr target, double alpha, double fuzz, int invert);

        /// <summary> Magick opaque paint image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="target"> Target for the. </param>
        /// <param name="fill"> The fill. </param>
        /// <param name="fuzz"> The fuzz. </param>
        /// <param name="invert"> The invert. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickOpaquePaintImage(IntPtr wand, IntPtr target, IntPtr fill, double fuzz, int invert);

        /// <summary> Magick threshold image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="threshold"> The threshold. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickThresholdImage(IntPtr wand, double threshold);

        /// <summary> Magick adaptive threshold image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="bias"> The bias. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickAdaptiveThresholdImage(IntPtr wand, int width, int height, double bias);

        /// <summary> Magick transform image colorspace. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="colorspaceType"> Type of the colorspace. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickTransformImageColorspace(IntPtr wand, int colorspaceType);

        /// <summary> Magick quantize image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="number_colors"> Number of colors. </param>
        /// <param name="colorsapceType"> Type of the colorsapce. </param>
        /// <param name="treedepth"> The treedepth. </param>
        /// <param name="dither_method"> The dither method. </param>
        /// <param name="measure_error"> The measure error. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickQuantizeImage(IntPtr wand, int number_colors, int colorsapceType, int treedepth, int dither_method, int measure_error);

        /// <summary> Magick normalize image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickNormalizeImage(IntPtr wand);

        /// <summary> Magick get image width. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickGetImageWidth(IntPtr wand);

        /// <summary> Magick get image height. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickGetImageHeight(IntPtr wand);

        /// <summary> Magick set image matte. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="matte"> The matte. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int MagickSetImageMatte(IntPtr wand, int matte);


        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int MagickGetImageBackgroundColor(IntPtr wand, IntPtr backgroundcolor);

        /// <summary> Magick flip image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickFlipImage(IntPtr wand);

		/// <summary> Magick border image. </summary>
		/// <param name="wand"> Handle of the wand. </param>
		/// <param name="bordercolor"> The bordercolor. </param>
		/// <param name="widith"> The widith. </param>
		/// <param name="height"> The height. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool MagickBorderImage(IntPtr wand, IntPtr bordercolor, int widith, int height);

		/// <summary> Magick thumbnail image. </summary>
		/// <param name="wand"> Handle of the wand. </param>
		/// <param name="columns"> The columns. </param>
		/// <param name="rows"> The rows. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern bool MagickThumbnailImage(IntPtr wand, int columns, int rows);


        #endregion

    }
}

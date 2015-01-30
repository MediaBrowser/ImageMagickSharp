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
        internal static extern bool MagickCompositeImage(IntPtr wand, IntPtr sourcePtr, CompositeOperator compositeOperator, int x, int y);

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

        /// <summary> Magick transform image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="crop"> A crop geometry string. This geometry defines a subregion of the image to crop. </param>
        /// <param name="geomety"> An image geometry string. This geometry defines the final size of the image. </param>
        /// <returns> An int. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr MagickTransformImage(IntPtr wand, string crop, string geomety);

        /// <summary> Magick transform image colorspace. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="colorspace"> The colorspace. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickTransformImageColorspace(IntPtr wand, ImageColorspaceType colorspace);

        /// <summary> Magick transpose image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickTransposeImage(IntPtr wand);

        /// <summary> Magick transverse image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickTransverseImage(IntPtr wand);

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
        /// <param name="matte"> true to matte. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickSetImageMatte(IntPtr wand, bool matte);

        /// <summary> Magick set image matte color. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="matteColor"> The matte color. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickSetImageMatteColor(IntPtr wand, IntPtr matteColor);

        /// <summary> Magick get image matte color. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="matteColor"> The matte color. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickGetImageMatteColor(IntPtr wand, out IntPtr matteColor);

        /// <summary> Magick get image background color. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="backgroundcolor"> The backgroundcolor. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickGetImageBackgroundColor(IntPtr wand, out IntPtr backgroundcolor);

        /// <summary> Magick set image background color. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="backgroundcolor"> The backgroundcolor. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickSetImageBackgroundColor(IntPtr wand, IntPtr backgroundcolor);

        /// <summary> Magick flip image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickFlipImage(IntPtr wand);

        /// <summary> Magick flop image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickFlopImage(IntPtr wand);

        /// <summary> Magick border image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="bordercolor"> The bordercolor. </param>
        /// <param name="widith"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickBorderImage(IntPtr wand, IntPtr bordercolor, int width, int height);

        /// <summary> Magick thumbnail image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="rows"> The rows. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickThumbnailImage(IntPtr wand, int columns, int rows);

        /// <summary> Magick extent image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickExtentImage(IntPtr wand, int width, int height, int x, int y);

        /// <summary> Magick get image region. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> An IntPtr. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr MagickGetImageRegion(IntPtr wand, int width, int height, int x, int y);

        /// <summary> Magick set image extent. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="rows"> The rows. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickSetImageExtent(IntPtr wand, int columns, int rows);

        /// <summary> Magick trim image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="fuzz"> The fuzz. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickTrimImage(IntPtr wand, double fuzz);

        /// <summary> Magick label image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="label"> The label. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickLabelImage(IntPtr wand, string label);

        /// <summary> Magick get image border color. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="border_color"> The border color. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickGetImageBorderColor(IntPtr wand, out IntPtr border_color);

        /// <summary> Magick set image border color. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="border_color"> The border color. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickSetImageBorderColor(IntPtr wand, IntPtr border_color);

        /// <summary> Magick raise image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <param name="raise"> true to raise. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickRaiseImage(IntPtr wand, int width, int height, int x, int y, bool raise);

        /// <summary> Magick shadow image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="opacity"> The opacity. </param>
        /// <param name="sigma"> The sigma. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickShadowImage(IntPtr wand, double opacity, double sigma, int x, int y);

        /// <summary> Magick shade image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="gray"> true to gray. </param>
        /// <param name="azimuth"> The azimuth. </param>
        /// <param name="elevation"> The elevation. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickShadeImage(IntPtr wand, bool gray, double azimuth, double elevation);

        /// <summary> Magick shear image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="background"> The background. </param>
        /// <param name="x_shear"> The shear. </param>
        /// <param name="y_shear"> The shear. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickShearImage(IntPtr wand, IntPtr background, double x_shear, double y_shear);

        /// <summary> Magick distort image. </summary>
        /// <param name="wand"> Handle of the wand. </param>
        /// <param name="method"> The method. </param>
        /// <param name="number_arguments"> Number of arguments. </param>
        /// <param name="arguments"> The arguments. </param>
        /// <param name="bestfit"> true to bestfit. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool MagickDistortImage(IntPtr wand, DistortImageMethodType method, int number_arguments, double arguments, bool bestfit);


        #endregion
    }
}

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

        /// <summary> Gets the filename of the file. </summary>
        /// <value> The filename. </value>
        public string Filename
        {
            get { return WandNativeString.Load(ImageWandInterop.MagickGetImageFilename(this.MagickWand)); }
            set { ImageWandInterop.MagickSetImageFilename(this.MagickWand, value); }
        }

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
        public int CompressionQuality
        {
            get { return ImageWandInterop.MagickGetImageCompressionQuality(this.MagickWand); }
            set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageCompressionQuality(this.MagickWand, value)); }
        }

        public PixelWand BackgroundColor
        {
            get
            {
                IntPtr background;
                ImageWandInterop.MagickGetImageBackgroundColor(this.MagickWand, out background);
                return new PixelWand(background);
            }
            set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageBackgroundColor(this.MagickWand, value)); }
        }

        /// <summary> Gets or sets the color of the image border. </summary>
        /// <value> The color of the image border. </value>
        public PixelWand ImageBorderColor
        {
            get
            {
                IntPtr background;
                ImageWandInterop.MagickGetImageBorderColor(this.MagickWand, out background);
                return new PixelWand(background);
            }
            set { ImageWandInterop.MagickSetImageBorderColor(this.MagickWand, value); }
        }

        /// <summary> Gets or sets the color of the image matte. </summary>
        /// <value> The color of the image matte. </value>
        public PixelWand MatteColor
        {
            get
            {
                IntPtr color;
                ImageWandInterop.MagickGetImageMatteColor(this.MagickWand, out color);
                return new PixelWand(color);
            }
            set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageMatteColor(this.MagickWand, value)); }
        }

        /// <summary> Sets a value indicating whether the matte. </summary>
        /// <value> true if matte, false if not. </value>
        public bool Matte
        {
            set { this.MagickWand.CheckError(ImageWandInterop.MagickSetImageMatte(this.MagickWand, value)); }
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

        /// <summary> Resize image. </summary>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        public void ResizeImage(int width, int height)
        {
            ResizeImage(width, height, FilterTypes.LanczosFilter);
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
        /// <param name="background"> The background. </param>
        /// <param name="degrees"> The degrees. </param>
        public void RotateImage(PixelWand background, double degrees)
        {
            this.MagickWand.CheckError(ImageWandInterop.MagickRotateImage(this.MagickWand, background, degrees));
        }

        /// <summary> Transform image. </summary>
        /// <param name="crop"> The crop. </param>
        /// <param name="geomety"> The geomety. </param>
        /// <returns> A MagickWand. </returns>
        public MagickWand TransformImage(string crop, string geomety)
        {
            return new MagickWand(ImageWandInterop.MagickTransformImage(this.MagickWand, crop, geomety));
        }

        /// <summary> Transform image colorspace. </summary>
        /// <param name="colorspace"> The colorspace. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool TransformImageColorspace(ImageColorspaceType colorspace)
        {
            return this.MagickWand.CheckError(ImageWandInterop.MagickTransformImageColorspace(this.MagickWand, colorspace));
        }

        /// <summary> Determines if we can transpose image. </summary>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool TransposeImage()
        {
            return this.MagickWand.CheckError(ImageWandInterop.MagickTransposeImage(this.MagickWand));
        }

        /// <summary> Determines if we can transverse image. </summary>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool TransverseImage()
        {
            return this.MagickWand.CheckError(ImageWandInterop.MagickTransverseImage(this.MagickWand));
        }

        /// <summary> Thumbnail image. </summary>
        /// <param name="columns"> The columns. </param>
        /// <param name="rows"> The rows. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool ThumbnailImage(int columns, int rows)
        {
            return this.MagickWand.CheckError(ImageWandInterop.MagickThumbnailImage(this.MagickWand, columns, rows));
        }

        /// <summary> Gets image region. </summary>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> The image region. </returns>
        public MagickWand GetImageRegion(int width, int height, int x, int y)
        {
            return new MagickWand(ImageWandInterop.MagickGetImageRegion(this.MagickWand, width, height, x, y));
        }
        /// <summary> Flip image. </summary>
        public void FlipImage()
        {
            this.MagickWand.CheckError(ImageWandInterop.MagickFlipImage(this.MagickWand)); ;
        }

        /// <summary> Flop image. </summary>
        public void FlopImage()
        {
            this.MagickWand.CheckError(ImageWandInterop.MagickFlopImage(this.MagickWand)); ;
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

        /// <summary> Trim image. </summary>
        /// <param name="fuzz"> The fuzz. By default target must match a particular pixel color exactly.
        /// However, in many cases two colors may differ by a small amount. The fuzz member of image
        /// defines how much tolerance is acceptable to consider two colors as the same. For example, set
        /// fuzz to 10 and the color red at intensities of 100 and 102 respectively are now interpreted
        /// as the same color for the purposes of the floodfill. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool TrimImage(double fuzz)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickTrimImage(this.MagickWand, fuzz));
        }

        /// <summary> Composite image. </summary>
        /// <param name="sourcePtr"> Source pointer. </param>
        /// <param name="compositeOperator"> The composite operator. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool CompositeImage(MagickWand sourcePtr, CompositeOperator compositeOperator, int x, int y)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickCompositeImage(this.MagickWand, sourcePtr, compositeOperator, x, y));
        }

        /// <summary> Label image. </summary>
        /// <param name="label"> The label. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool LabelImage(string label)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickLabelImage(this.MagickWand, label));
        }

        /// <summary> Raises the image event. </summary>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <param name="raise"> true to raise. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool RaiseImage(int width, int height, int x, int y, bool raise)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickRaiseImage(this.MagickWand, width, height, x, y, raise));
        }

        /// <summary> Border image. </summary>
        /// <param name="bordercolor"> The bordercolor. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool BorderImage(PixelWand bordercolor, int width, int height)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickBorderImage(this.MagickWand, bordercolor, width, height));
        }

        /// <summary> Shadow image. </summary>
        /// <param name="opacity"> The opacity. </param>
        /// <param name="sigma"> The sigma. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool ShadowImage(double opacity, double sigma, int x, int y)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickShadowImage(this.MagickWand, opacity, sigma, x, y));

        }

        /// <summary>
        /// Shade image. shines a distant light on an image to create a three-dimensional effect. You
        /// control the positioning of the light with azimuth and elevation; azimuth is measured in
        /// degrees off the x axis and elevation is measured in pixels above the Z axis. </summary>
        /// <param name="gray"> true to gray. </param>
        /// <param name="azimuth"> The azimuth. </param>
        /// <param name="elevation"> The elevation. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool ShadeImage(bool gray, double azimuth, double elevation)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickShadeImage(this.MagickWand, gray, azimuth, elevation));

        }

        /// <summary> Shear image. </summary>
        /// <param name="background"> The background. </param>
        /// <param name="x_shear"> The shear. </param>
        /// <param name="y_shear"> The shear. </param>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool ShearImage(PixelWand background, double x_shear, double y_shear)
        {
            return this.MagickWand.CheckErrorBool(ImageWandInterop.MagickShearImage(this.MagickWand, background, x_shear, y_shear));
        }


        #endregion
    }
}

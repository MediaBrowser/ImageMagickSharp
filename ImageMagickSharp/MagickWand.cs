using System;
using System.Runtime.InteropServices;

namespace ImageMagickSharp
{
    public class MagickWand : IDisposable
    {
        IntPtr magick_wand;

        public MagickWand()
        {
            magick_wand = MagickWandInterop.NewMagickWand();
        }

        public void OpenImage(string path)
        {
            var status = MagickWandInterop.MagickReadImage(magick_wand, path);
            CheckError(status);
        }

        public void ResizeImage(uint width, uint height)
        {
            ResizeImage(width, height, FilterTypes.LanczosFilter);
        }

        public void ResizeImage(uint width, uint height, FilterTypes filter)
        {
            var status = MagickWandInterop.MagickResizeImage(magick_wand, width, height, filter, 1.0);
            CheckError(status);
        }

        public void SetQuality(uint value)
        {
            var status = MagickWandInterop.MagickSetImageCompressionQuality(magick_wand, value);
            CheckError(status);
        }

        public void NewImage(uint width, uint height, string backgroundColor)
        {
            using (var pixelWand = new PixelWand())
            {
                MagickWandInterop.PixelSetMagickColor(pixelWand.IntPtr, backgroundColor);
                MagickWandInterop.MagickNewImage(magick_wand, width, height, pixelWand.IntPtr);
            }
        }

        public void SaveImage(string path)
        {
            MagickWandInterop.MagickWriteImage(magick_wand, path);
        }

        private void CheckError(int status)
        {
            if (status == MagickWandInterop.MagickFalse)
            {
                //int type = 0;

                //var msg = MagickWandInterop.MagickGetException(magick_wand, ref type);
                throw new Exception("ImageMagick method failed: ");
            }
        }

        public void Dispose()
        {
            magick_wand = MagickWandInterop.DestroyMagickWand(magick_wand);
        }

        public static void StartEnvironment()
        {
            MagickWandInterop.MagickWandGenesis();
        }

        public static void DisposeEnvironment()
        {
            MagickWandInterop.MagickWandTerminus();
        }
    }
}

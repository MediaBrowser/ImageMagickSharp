using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    internal static class MagickWandInterop
    {
        [DllImport("CORE_RL_wand_")]
        public static extern void MagickWandGenesis();

        [DllImport("CORE_RL_wand_")]
        public static extern void MagickWandTerminus();

        [DllImport("CORE_RL_wand_")]
        public static extern IntPtr NewMagickWand();

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MagickReadImage(IntPtr magick_wand, string file_name);

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MagickResizeImage(IntPtr magick_wand, ulong columns, ulong rows, FilterTypes filter, double blur);

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MagickScaleImage(IntPtr magick_wand, ulong columns, ulong rows);

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MagickAdaptiveResizeImage(IntPtr magick_wand, ulong columns, ulong rows);
        
        [DllImport("CORE_RL_wand_")]
        public static extern bool MagickWriteImage(IntPtr magick_wand, string file_name);

        [DllImport("CORE_RL_wand_")]
        public static extern int MagickSetImageBackgroundColor(IntPtr magick_wand, string file_name);
        
        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DestroyMagickWand(IntPtr magick_wand);

        [DllImport("CORE_RL_wand_")]
        public static extern int MagickSetImageCompressionQuality(IntPtr magick_wand, uint quality);

        [DllImport("CORE_RL_wand_")]
        public static extern int MagickNewImage(IntPtr magick_wand, ulong columns, ulong rows, IntPtr pixelWand);

        [DllImport("CORE_RL_wand_")]
        public static extern IntPtr NewPixelWand();

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DestroyPixelWand(IntPtr magick_wand);

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern int PixelSetMagickColor(IntPtr pixelWand, string color);

        [DllImport("CORE_RL_wand_", CallingConvention = CallingConvention.Cdecl)]
        public static extern string MagickGetException(IntPtr magick_wand, ref int type);
        
        public static readonly int MagickFalse = 0;

    }
}

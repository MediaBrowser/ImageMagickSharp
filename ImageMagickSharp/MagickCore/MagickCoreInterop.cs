using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    internal class MagickCoreInterop
    {
        [DllImport("CORE_RL_magick_.dll", CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr AcquireImageInfo();

        [DllImport("CORE_RL_magick_.dll", CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr AcquireExceptionInfo();

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool ConvertImageCommand(IntPtr image_info, int argc, string[] argv, string[] metadata, IntPtr exception);
    }
}

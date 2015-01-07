using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    public class PixelWand : IDisposable
    {
        public IntPtr IntPtr { get; private set; }

        public PixelWand()
        {
            IntPtr = MagickWandInterop.NewPixelWand();
        }
        
        public void Dispose()
        {
            IntPtr = MagickWandInterop.DestroyPixelWand(IntPtr);
        }
    }
}

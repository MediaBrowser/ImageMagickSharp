using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    public class MagickCore : WandCore<MagickCore>, IDisposable
    {
        /// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
        public MagickCore()
        {
            Wand.EnsureInitialized();
        }

        /// <summary> Initializes a new instance of the ImageMagickSharp.MagickWand class. </summary>
        /// <param name="wand"> The wand. </param>
        public MagickCore(IntPtr wand)
        {
            Wand.EnsureInitialized();
            this.Handle = wand;
        }

        public IntPtr AcquireImageInfo()
        {
            return MagickCoreInterop.AcquireImageInfo();
        }

        public IntPtr AcquireExceptionInfo()
        {
            return MagickCoreInterop.AcquireExceptionInfo();
        }

        public bool ConvertImageCommand(IntPtr image_info, int argc, string[] argv, string[] metadata, IntPtr exception)
        {
            return this.CheckError(MagickCoreInterop.ConvertImageCommand(image_info, argc, argv, metadata, exception));
        }


        #region [Wand Methods - Exception]

        /// <summary> Gets the exception. </summary>
        /// <returns> The exception. </returns>
        public override IntPtr GetException(out int exceptionSeverity)
        {
            IntPtr exceptionPtr = MagickWandInterop.MagickGetException(this, out exceptionSeverity);
            return exceptionPtr;
        }

        /// <summary> Clears the exception. </summary>
        /// <returns> An IntPtr. </returns>
        public override void ClearException()
        {
            MagickWandInterop.MagickClearException(this);
        }

        #endregion

        #region [IDisposable]

        private List<ImageWand> _ImageList = new List<ImageWand>();

        /// <summary> Finalizes an instance of the ImageMagickSharp.MagickWand class. </summary>
        ~MagickCore()
        {
            this.Dispose();
        }

        /// <summary> true if disposed. </summary>
        private bool disposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources. </summary>
        /// <seealso cref="M:System.IDisposable.Dispose()"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the ImageMagickSharp.MagickWand and optionally
        /// releases the managed resources. </summary>
        /// <param name="disposing"> true to release both managed and unmanaged resources; false to
        /// release only unmanaged resources. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                //this.Handle = MagickWandInterop.DestroyMagickWand(this);
                this.Handle = IntPtr.Zero;
                disposed = true;

            }
        }

        #endregion

    }
}

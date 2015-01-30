using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    internal class PixelIteratorInterop
    {
        #region [PixelIterator Wand]

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr NewPixelIterator();

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern void ClearPixelIterator(IntPtr wand);


        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr ClonePixelIterator(IntPtr wand);


        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern void DestroyPixelIterator(IntPtr wand);

        #endregion

        #region [PixelIterator Wand - Properties]

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int PixelGetIteratorRow(IntPtr wand);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool PixelSetIteratorRow(IntPtr wand, int row);

        #endregion

        #region [PixelIterator Wand - Methods]

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool IsPixelIterator(IntPtr wand);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr NewPixelRegionIterator(IntPtr wand, int x, int y, int width, int height);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr PixelGetCurrentIteratorRow(IntPtr wand, int number_wands);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr PixelGetNextIteratorRow(IntPtr wand, int number_wands);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr PixelGetPreviousIteratorRow(IntPtr wand, int number_wands);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern void PixelResetIterator(IntPtr wand);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern void PixelSetFirstIteratorRow(IntPtr wand);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern void PixelSetLastIteratorRow(IntPtr wand);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern bool PixelSyncIterator(IntPtr wand);

        #endregion

        #region [Wand Methods - Exception]

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int PixelClearIteratorException(IntPtr wand);


        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern IntPtr PixelGetIteratorException(IntPtr wand, out int exceptionType);

        [DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
        internal static extern int PixelGetIteratorExceptionType(IntPtr wand);

        #endregion

    }
}

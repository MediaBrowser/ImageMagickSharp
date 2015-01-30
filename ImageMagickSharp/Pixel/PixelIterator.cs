using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    /// <summary> A pixel iterator. </summary>
    /// <seealso cref="T:ImageMagickSharp.WandCore{ImageMagickSharp.PixelIterator}"/>
    /// <seealso cref="T:System.IDisposable"/>
    public class PixelIterator : WandCore<PixelIterator>, IDisposable
    {
        #region [Constructors]
        /// <summary>
        /// Initializes a new instance of the ImageMagickSharp.PixelIterator class. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        public PixelIterator()
        {
            this.Handle = PixelIteratorInterop.NewPixelIterator();
            if (this.Handle == IntPtr.Zero)
            {
                throw new Exception("Error acquiring pixel wand.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the ImageMagickSharp.PixelIterator class. </summary>
        /// <param name="handle"> The handle. </param>
        public PixelIterator(IntPtr handle)
            : base(handle)
        {

        }

        /// <summary>
        /// Initializes a new instance of the ImageMagickSharp.PixelIterator class. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <param name="wand"> The wand. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
        public PixelIterator(IntPtr wand, int x, int y, int width, int height)
        {
            this.Handle = PixelIteratorInterop.NewPixelRegionIterator(wand, x, y, width, height);
            if (this.Handle == IntPtr.Zero)
            {
                throw new Exception("Error acquiring pixel wand.");
            }
        }

        #endregion

        #region [PixelIterator Wand]


        /// <summary> Clears the pixel iterator. </summary>
        public void ClearPixelIterator()
        {
            PixelIteratorInterop.ClearPixelIterator(this);
        }

        /// <summary> Clone pixel iterator. </summary>
        /// <returns> A PixelIterator. </returns>
        public PixelIterator ClonePixelIterator()
        {
            return new PixelIterator(PixelIteratorInterop.ClonePixelIterator(this));
        }

        /// <summary> Destroys the pixel iterator. </summary>
        public void DestroyPixelIterator()
        {
            PixelIteratorInterop.DestroyPixelIterator(this);
        }

        #endregion

        #region [PixelIterator Wand - Properties]
        /// <summary> Gets or sets the iterator row. </summary>
        /// <value> The iterator row. </value>
        public int IteratorRow
        {
            get { return PixelIteratorInterop.PixelGetIteratorRow(this); }
            set { this.CheckError(PixelIteratorInterop.PixelSetIteratorRow(this, value)); }
        }

        #endregion


        #region [PixelIterator Wand - Methods]
        /// <summary> Query if this object is pixel iterator. </summary>
        /// <returns> true if pixel iterator, false if not. </returns>
        public bool IsPixelIterator()
        {
            return this.CheckError(PixelIteratorInterop.IsPixelIterator(this));
        }

        /// <summary> Current iterator row. </summary>
        /// <param name="number_wands"> Number of wands. </param>
        /// <returns> A PixelWand. </returns>
        public PixelWand CurrentIteratorRow(int number_wands)
        {
            return new PixelWand(PixelIteratorInterop.PixelGetCurrentIteratorRow(this, number_wands));
        }

        /// <summary> Next iterator row. </summary>
        /// <param name="number_wands"> Number of wands. </param>
        /// <returns> A PixelWand. </returns>
        public PixelWand NextIteratorRow(int number_wands)
        {
            return new PixelWand(PixelIteratorInterop.PixelGetNextIteratorRow(this, number_wands));
        }

        /// <summary> Previous iterator row. </summary>
        /// <param name="number_wands"> Number of wands. </param>
        /// <returns> A PixelWand. </returns>
        public PixelWand PreviousIteratorRow(int number_wands)
        {
            return new PixelWand(PixelIteratorInterop.PixelGetPreviousIteratorRow(this, number_wands));
        }

        /// <summary> Resets the iterator. </summary>
        public void ResetIterator()
        {
            PixelIteratorInterop.PixelResetIterator(this);
        }


        /// <summary> Pixel set first iterator row. </summary>
        public void PixelSetFirstIteratorRow()
        {
            PixelIteratorInterop.PixelSetFirstIteratorRow(this);
        }

        /// <summary> Pixel set last iterator row. </summary>
        public void PixelSetLastIteratorRow()
        {
            PixelIteratorInterop.PixelSetLastIteratorRow(this);
        }

        /// <summary> Determines if we can pixel synchronise iterator. </summary>
        /// <returns> true if it succeeds, false if it fails. </returns>
        public bool PixelSyncIterator()
        {
            return this.CheckError(PixelIteratorInterop.PixelSyncIterator(this));
        }

        #endregion

        #region [Wand Methods - Exception]
        /// <summary> Gets the exception. </summary>
        /// <param name="exceptionSeverity"> The exception severity. </param>
        /// <returns> The exception. </returns>
        public override IntPtr GetException(out int exceptionSeverity)
        {
            IntPtr exceptionPtr = PixelWandInterop.PixelGetException(this, out exceptionSeverity);
            return exceptionPtr;
        }

        /// <summary> Clears the exception. </summary>
        public override void ClearException()
        {
            PixelWandInterop.PixelClearException(this);
        }

        #endregion

        #region [IDisposable]


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
        /// Releases the unmanaged resources used by the ImageMagickSharp.PixelWand and optionally
        /// releases the managed resources. </summary>
        /// <param name="disposing"> true to release both managed and unmanaged resources; false to
        /// release only unmanaged resources. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                PixelWandInterop.ClearPixelWand(this);
                this.Handle = IntPtr.Zero;
                disposed = true;

            }
        }
        #endregion

    }
}

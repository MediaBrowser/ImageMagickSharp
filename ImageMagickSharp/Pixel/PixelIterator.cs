using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
				throw new Exception("Error acquiring pixel iterator wand.");
			}
		}

		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.PixelIterator class. </summary>
		/// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
		/// <param name="magickWand"> The magick wand. </param>
		public PixelIterator(MagickWand magickWand)
		{
			this.Handle = PixelIteratorInterop.NewPixelIterator(magickWand);
			if (this.Handle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring pixel iterator wand.");
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
		/// <param name="wand"> The magickWand. </param>
        /// <param name="x"> The x coordinate. </param>
        /// <param name="y"> The y coordinate. </param>
        /// <param name="width"> The width. </param>
        /// <param name="height"> The height. </param>
		public PixelIterator(IntPtr magickWand, int x, int y, int width, int height)
        {
			this.Handle = PixelIteratorInterop.NewPixelRegionIterator(magickWand, x, y, width, height);
            if (this.Handle == IntPtr.Zero)
            {
                throw new Exception("Error acquiring pixel iterator wand.");
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
		/// <returns> A PixelWand. </returns>
		public IntPtr[] GetCurrentIteratorRow()
		{
			int number_wands;
			IntPtr iteratorRow = PixelIteratorInterop.PixelGetCurrentIteratorRow(this, out number_wands);
			IntPtr[] rowArray = new IntPtr[number_wands];
			Marshal.Copy(iteratorRow, rowArray, 0, number_wands);
			return rowArray;
        }

		/// <summary> Gets current pixel iterator row. </summary>
		/// <returns> An array of pixel wand. </returns>
		public PixelWand[] GetCurrentPixelIteratorRow()
		{
			IntPtr[] rowArray = this.GetCurrentIteratorRow();
			PixelWand[] pixelArray = rowArray.Select(n => new PixelWand(n)).ToArray();
			return pixelArray;
		}

		/// <summary> Gets the next iterator row. </summary>
		/// <returns> An array of int pointer. </returns>
		public IntPtr[] GetNextIteratorRow()
		{
			int number_wands;
			IntPtr iteratorRow = PixelIteratorInterop.PixelGetNextIteratorRow(this, out number_wands);
			IntPtr[] rowArray = new IntPtr[number_wands];
			Marshal.Copy(iteratorRow, rowArray, 0, number_wands);
			return rowArray;
		}

		/// <summary> Gets the next pixel iterator row. </summary>
		/// <returns> An array of pixel wand. </returns>
		public PixelWand[] GetNextPixelIteratorRow()
		{
			IntPtr[] rowArray = this.GetNextIteratorRow();
			PixelWand[] pixelArray = rowArray.Select(n=> new PixelWand(n)).ToArray();
			return pixelArray;
		}

		/// <summary> Previous iterator row. </summary>
		/// <returns> A PixelWand. </returns>
		public IntPtr[] GetPreviousIteratorRow()
		{
			int number_wands;
			IntPtr iteratorRow = PixelIteratorInterop.PixelGetPreviousIteratorRow(this, out number_wands);
			IntPtr[] rowArray = new IntPtr[number_wands];
			Marshal.Copy(iteratorRow, rowArray, 0, number_wands);
			return rowArray;
        }

		/// <summary> Gets the previous pixel iterator row. </summary>
		/// <returns> An array of pixel wand. </returns>
		public PixelWand[] GetPreviousPixelIteratorRow()
		{
			IntPtr[] rowArray = this.GetPreviousIteratorRow();
			PixelWand[] pixelArray = rowArray.Select(n => new PixelWand(n)).ToArray();
			return pixelArray;
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
            IntPtr exceptionPtr = PixelIteratorInterop.PixelGetIteratorException(this, out exceptionSeverity);
            return exceptionPtr;
        }

        /// <summary> Clears the exception. </summary>
        public override void ClearException()
        {
            PixelIteratorInterop.PixelClearIteratorException(this);
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
                PixelIteratorInterop.DestroyPixelIterator(this);
                this.Handle = IntPtr.Zero;
                disposed = true;
            }
        }
        #endregion

    }
}

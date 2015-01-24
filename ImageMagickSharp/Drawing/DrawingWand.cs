using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	public class DrawingWand : WandCore<DrawingWand>, IDisposable
	{

		#region [Constructors]

		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.DrawingWand&lt;T&gt; class. </summary>
		public DrawingWand()
		{

		}

		/// <summary>
		/// Initializes a new instance of the DrawingWand class.
		/// </summary>
		/// <param name="handle"></param>
		public DrawingWand(IntPtr handle)
			: base(handle)
		{

		}

		#endregion

		#region [Private Fields]

		/// <summary> true if disposed. </summary>
		private bool disposed = false;

		#endregion

		#region [Public Methods]

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
		/// resources. </summary>
		/// <seealso cref="M:System.IDisposable.Dispose()"/>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		#region [Protected Methods]

		/// <summary>
		/// Releases the unmanaged resources used by the ImageMagickSharp.PixelWand and optionally
		/// releases the managed resources. </summary>
		/// <param name="disposing"> true to release both managed and unmanaged resources; false to
		/// release only unmanaged resources. </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				DrawingWandInterop.DestroyDrawingWand(this);
				this.Handle = IntPtr.Zero;
				disposed = true;

			}
		}

		#endregion

	}
}

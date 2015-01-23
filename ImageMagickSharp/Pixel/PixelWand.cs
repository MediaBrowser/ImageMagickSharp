using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A pixel wand. </summary>
	/// <seealso cref="T:ImageMagickSharp.WandBase"/>
	/// <seealso cref="T:System.IDisposable"/>
	public class PixelWand : WandCore, IDisposable
	{
		#region [Constructors]
		/// <summary> Initializes a new instance of the ImageMagickSharp.PixelWand class. </summary>
		/// <param name="color"> The color. </param>
		public PixelWand(string color)
			: this()
		{
			this.Color = color;
		}

		/// <summary> Initializes a new instance of the ImageMagickSharp.PixelWand class. </summary>
		/// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
		public PixelWand()
		{
			this.Handle = PixelWandInterop.NewPixelWand();
			if (this.Handle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring pixel wand.");
			}
		}

		#endregion

		#region [Public Properties]
		/// <summary> Gets or sets the color. </summary>
		/// <value> The color. </value>
		public string Color
		{
			get { return WandNativeString.Load(PixelWandInterop.PixelGetColorAsString(this.Handle)); }
			set
			{
				using (var colorString = new WandNativeString(value))
				{
					this.CheckError(PixelWandInterop.PixelSetColor(this.Handle, colorString.Pointer));
				}
			}
		}

		/// <summary> Gets the color of the normalized. </summary>
		/// <value> The color of the normalized. </value>
		public string NormalizedColor
		{
			get
			{
				return WandNativeString.Load(PixelWandInterop.PixelGetColorAsNormalizedString(this.Handle));
			}
		}

		#endregion

		#region [Public Methods]
		/// <summary> From a RGB. </summary>
		/// <param name="alpha"> The alpha. </param>
		/// <param name="red"> The red. </param>
		/// <param name="green"> The green. </param>
		/// <param name="blue"> The blue. </param>
		/// <returns> A PixelWand. </returns>
		public static PixelWand FromARGB(double alpha, double red, double green, double blue)
		{
			return new PixelWand()
			{
				Alpha = alpha,
				Red = red,
				Green = green,
				Blue = blue,
			};
		}

		/// <summary> From RGB. </summary>
		/// <param name="red"> The red. </param>
		/// <param name="green"> The green. </param>
		/// <param name="blue"> The blue. </param>
		/// <returns> A PixelWand. </returns>
		public static PixelWand FromRGB(double red, double green, double blue)
		{
			return new PixelWand()
			{
				Red = red,
				Green = green,
				Blue = blue,
			};
		}

		#endregion

		#region [Private Methods]

		/// <summary> Finalizes an instance of the ImageMagickSharp.PixelWand class. </summary>
		~PixelWand()
		{
			this.Dispose();
		}

		#endregion

		#region [PixelWand RGB]
		/// <summary> Gets or sets the alpha. </summary>
		/// <value> The alpha. </value>
		public double Alpha
		{
			get { return PixelWandInterop.PixelGetAlpha(this.Handle); }
			set { PixelWandInterop.PixelSetAlpha(this.Handle, value); }
		}

		/// <summary> Gets or sets the opacity. </summary>
		/// <value> The opacity. </value>
		public double Opacity
		{
			get { return PixelWandInterop.PixelGetOpacity(this.Handle); }
			set { PixelWandInterop.PixelSetOpacity(this.Handle, value); }
		}

		/// <summary> Gets or sets the red. </summary>
		/// <value> The red. </value>
		public double Red
		{
			get { return PixelWandInterop.PixelGetRed(this.Handle); }
			set { PixelWandInterop.PixelSetRed(this.Handle, value); }
		}

		/// <summary> Gets or sets the green. </summary>
		/// <value> The green. </value>
		public double Green
		{
			get { return PixelWandInterop.PixelGetGreen(this.Handle); }
			set { PixelWandInterop.PixelSetGreen(this.Handle, value); }
		}

		/// <summary> Gets or sets the blue. </summary>
		/// <value> The blue. </value>
		public double Blue
		{
			get { return PixelWandInterop.PixelGetBlue(this.Handle); }
			set { PixelWandInterop.PixelSetBlue(this.Handle, value); }
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
				PixelWandInterop.ClearPixelWand(this.Handle);
				this.Handle = IntPtr.Zero;
				disposed = true;

			}
		}
		#endregion

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A wand base. </summary>
	public class WandBase
	{
		#region [Public Properties]
		/// <summary> Gets the handle of the wand. </summary>
		/// <value> The wand handle. </value>
		public IntPtr WandHandle { get; protected set; }

		#endregion

		#region [Public Methods]
		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public int CheckError(int status)
		{
			if (status == MagickWandInterop.MagickFalse)
			{
				throw new WandException(this.WandHandle);
			}

			return status;
		}

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool CheckError(bool status)
		{
			if (status == false)
			{
				throw new WandException(this.WandHandle);
			}

			return status;
		}

		#endregion

	}
}

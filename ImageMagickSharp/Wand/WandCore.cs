using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{

	public abstract class WandCore
	{
		#region [Wand Handle]
		/// <summary> Gets the handle of the wand. </summary>
		/// <value> The wand handle. </value>
		public IntPtr Handle { get; protected set; }

		#endregion

		#region [Wand Check Error]

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public int CheckError(int status)
		{
			if (status == Constants.MagickFalse)
			{
				throw new WandException(this.Handle);
			}

			return status;
		}

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool CheckErrorBool(int status)
		{
			if (status == Constants.MagickFalse)
			{
				throw new WandException(this.Handle);
			}

			return true;
		}

		/// <summary> Check error. </summary>
		/// <exception cref="WandException"> Thrown when a Wand error condition occurs. </exception>
		/// <param name="status"> true to status. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool CheckError(bool status)
		{
			if (status == false)
			{
				throw new WandException(this.Handle);
			}

			return status;
		}

		#endregion

	}
}

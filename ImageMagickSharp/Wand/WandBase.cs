using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    /// <summary> A wand base. </summary>
    public abstract class WandBase
    {

		#region [Constructors]

		/// <summary> Initializes a new instance of the MagickBase class. </summary>
		/// <param name="magickWand"> . </param>
		public WandBase(MagickWand magickWand)
		{
			_MagickWand = magickWand;
		}

		#endregion

		#region [Private Fields]

		/// <summary> The magick wand. </summary>
		private MagickWand _MagickWand;

		#endregion

		#region [Public Properties]

		/// <summary> Gets the magick wand. </summary>
		/// <value> The magick wand. </value>
		public MagickWand MagickWand
		{
			get { return _MagickWand; }
		}

		#endregion
     
    }
}

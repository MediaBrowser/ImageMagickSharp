using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A wand size. </summary>
	public struct WandSize
	{
		#region [Constructors]
	
		/// <summary>
		/// Initializes a new instance of the WandSize structure.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public WandSize(int width, int height)
			: this()
		{
			Width = width;
			Height = height;
		}

		#endregion

		#region [Public Properties]
		/// <summary> Gets or sets the width. </summary>
		/// <value> The width. </value>
		public int Width { get; set; }

		/// <summary> Gets or sets the height. </summary>
		/// <value> The height. </value>
		public int Height { get; set; }

		#endregion

	}

	/// <summary> A wand size double. </summary>
	public struct WandSizeD
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the WandSizeD structure.
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public WandSizeD(double width, double height)
			: this()
		{
			Width = width;
			Height = height;
		}

		#endregion

		#region [Public Properties]
		/// <summary> Gets or sets the width. </summary>
		/// <value> The width. </value>
		public double Width { get; set; }

		/// <summary> Gets or sets the height. </summary>
		/// <value> The height. </value>
		public double Height { get; set; }

		#endregion

	}

	/// <summary> A wand point. </summary>
	public struct WandPoint
	{
		#region [Constructors]
		
		/// <summary> Initializes a new instance of the WandPoint structure. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public WandPoint(int x, int y)
			: this()
		{
			X = x;
			Y = y;
		}

		#endregion

		#region [Public Properties]
		/// <summary> Gets or sets the x coordinate. </summary>
		/// <value> The x coordinate. </value>
		public int X { get; set; }

		/// <summary> Gets or sets the y coordinate. </summary>
		/// <value> The y coordinate. </value>
		public int Y { get; set; }

		#endregion

	}

	/// <summary> A wand point double. </summary>
	public struct WandPointD
	{
		#region [Constructors]
		
		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.Global.WandPointD struct. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public WandPointD(double x, double y)
			: this()
		{
			X = x;
			Y = y;
		}

		#endregion

		#region [Public Properties]
		/// <summary> Gets or sets the x coordinate. </summary>
		/// <value> The x coordinate. </value>
		public double X { get; set; }

		/// <summary> Gets or sets the y coordinate. </summary>
		/// <value> The y coordinate. </value>
		public double Y { get; set; }

		#endregion

	}

	public struct WandRectangle
	{
		#region [Constructors]
		
		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.Global.WandRectangle struct. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		public WandRectangle(int x, int y, int width, int height)
			: this()
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
		#endregion

		#region [Public Properties]

		/// <summary> Gets or sets the x coordinate. </summary>
		/// <value> The x coordinate. </value>
		public int X { get; set; }

		/// <summary> Gets or sets the y coordinate. </summary>
		/// <value> The y coordinate. </value>
		public int Y { get; set; }

		/// <summary> Gets or sets the width. </summary>
		/// <value> The width. </value>
		public int Width { get; set; }

		/// <summary> Gets or sets the height. </summary>
		/// <value> The height. </value>
		public int Height { get; set; }
		#endregion
	}

	public struct WandRectangleD
	{
		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.Global.WandRectangleD struct. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		public WandRectangleD(double x, double y, double width, double height)
			: this()
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		#endregion

		#region [Public Properties]

		/// <summary> Gets or sets the x coordinate. </summary>
		/// <value> The x coordinate. </value>
		public double X { get; set; }

		/// <summary> Gets or sets the y coordinate. </summary>
		/// <value> The y coordinate. </value>
		public double Y { get; set; }

		/// <summary> Gets or sets the width. </summary>
		/// <value> The width. </value>
		public double Width { get; set; }

		/// <summary> Gets or sets the height. </summary>
		/// <value> The height. </value>
		public double Height { get; set; }

		#endregion
	}
}

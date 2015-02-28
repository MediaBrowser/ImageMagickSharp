using System;
using System.Collections.Generic;
using System.Drawing;
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
			this.Handle = DrawingWandInterop.NewDrawingWand();
			if (this.Handle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring wand.");
			}
		}
		public DrawingWand(PixelWand fillColor)
		{
			this.Handle = DrawingWandInterop.NewDrawingWand();
			if (this.Handle == IntPtr.Zero)
			{
				throw new Exception("Error acquiring wand.");
			}
			this.FillColor = fillColor;
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

		#region [Drawing Wand]

		/// <summary> Clears the pixel wand. </summary>
		public void ClearPixelWand()
		{
			DrawingWandInterop.ClearDrawingWand(this);
		}

		/// <summary> Clone drawing wand. </summary>
		/// <returns> A DrawingWand. </returns>
		public DrawingWand CloneDrawingWand()
		{
			return new DrawingWand(DrawingWandInterop.CloneDrawingWand(this));
		}

		/// <summary> Destroys the drawing wand. </summary>
		public void DestroyDrawingWand()
		{
			DrawingWandInterop.DestroyDrawingWand(this);
		}

		/// <summary> Resets the vector graphics. </summary>
		public void ResetVectorGraphics()
		{
			DrawingWandInterop.DrawResetVectorGraphics(this);
		}

		#endregion

		#region [Drawing Wand Methods]

		/// <summary> Gets or sets the gravity. </summary>
		/// <value> The gravity. </value>
		public GravityType Gravity
		{
			get { return DrawingWandInterop.DrawGetGravity(this); }
			set { DrawingWandInterop.DrawSetGravity(this, value); }
		}

		/// <summary> Gets or sets a value indicating whether the stroke antialias. </summary>
		/// <value> true if stroke antialias, false if not. </value>
		public bool StrokeAntialias
		{
			get { return DrawingWandInterop.DrawGetStrokeAntialias(this); }
			set { DrawingWandInterop.DrawSetStrokeAntialias(this, value); }
		}


		/// <summary> Gets or sets the fill opacity. </summary>
		/// <value> The fill opacity. </value>
		public double FillOpacity
		{
			get { return DrawingWandInterop.DrawGetFillOpacity(this); }
			set { DrawingWandInterop.DrawSetFillOpacity(this, value); }
		}

		/// <summary> Gets or sets the opacity. </summary>
		/// <value> The opacity. </value>
		public double Opacity
		{
			get { return DrawingWandInterop.DrawGetOpacity(this); }
			set { DrawingWandInterop.DrawSetOpacity(this, value); }
		}

		/// <summary> Gets or sets the vector graphics. </summary>
		/// <value> The vector graphics. </value>
		public string VectorGraphics
		{
			get { return DrawingWandInterop.DrawGetVectorGraphics(this); }
			set { DrawingWandInterop.DrawSetVectorGraphics(this, value); }
		}

		/// <summary> Draw composite. </summary>
		/// <param name="compose"> The compose. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="width"> The width. </param>
		/// <param name="height"> The height. </param>
		/// <param name="magickwand"> The magickwand. </param>
		/// <returns> true if it succeeds, false if it fails. </returns>
		public bool DrawComposite(CompositeOperator compose, double x, double y, double width, double height, ImageWand imageWand)
		{
			return this.CheckErrorBool(DrawingWandInterop.DrawComposite(this, (int)compose, x, y, width, height, imageWand.MagickWand.Handle));
		}

		/// <summary> Draw matte. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="paint_method"> The paint method. </param>
		public void DrawMatte( double x, double y, PaintMethodType paint_method)
		{
			DrawingWandInterop.DrawMatte(this, x, y, paint_method);
		}

		/// <summary> Skew x coordinate. </summary>
		/// <param name="degrees"> The degrees. </param>
		public void SkewX(double degrees)
		{
			DrawingWandInterop.DrawSkewX(this, degrees);
		}

		/// <summary> Skew y coordinate. </summary>
		/// <param name="degrees"> The degrees. </param>
		public void SkewY(double degrees)
		{
			DrawingWandInterop.DrawSkewY(this, degrees);
		}

		/// <summary> Translates. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		public void Translate(double x, double y)
		{
			DrawingWandInterop.DrawTranslate(this, x, y);
		}
		public void Scale(double x, double y)
		{
			DrawingWandInterop.DrawScale(this, x, y);
		}

		/// <summary> Rotates. </summary>
		/// <param name="degrees"> The degrees. </param>
		public void Rotate(double degrees)
		{
			DrawingWandInterop.DrawRotate(this, degrees);
		}

		#endregion

		#region [Drawing Wand Methods - Text]
		/// <summary> Gets or sets the font. </summary>
		/// <value> The font. </value>
		public string Font
		{
			get { return DrawingWandInterop.DrawGetFont(this); }
			set { DrawingWandInterop.DrawSetFont(this, value); }
		}

		/// <summary> Gets or sets the font family. </summary>
		/// <value> The font family. </value>
		public string FontFamily
		{
			get { return DrawingWandInterop.DrawGetFontFamily(this); }
			set { DrawingWandInterop.DrawSetFontFamily(this, value); }
		}

		/// <summary> Gets or sets the size of the font. </summary>
		/// <value> The size of the font. </value>
		public double FontSize
		{
			get { return DrawingWandInterop.DrawGetFontSize(this); }
			set { DrawingWandInterop.DrawSetFontSize(this, value); }
		}

		/// <summary> Gets or sets the font stretch. </summary>
		/// <value> The font stretch. </value>
		public FontStretchType FontStretch
		{
			get { return (FontStretchType)DrawingWandInterop.DrawGetFontStretch(this); }
			set { DrawingWandInterop.DrawSetFontStretch(this, (int)value); }
		}

		/// <summary> Gets or sets the font style. </summary>
		/// <value> The font style. </value>
		public FontStyleType FontStyle
		{
			get { return DrawingWandInterop.DrawGetFontStyle(this); }
			set { DrawingWandInterop.DrawSetFontStyle(this, value); }
		}

		/// <summary> Gets or sets the font weight. </summary>
		/// <value> The font weight. </value>
		public FontWeightType FontWeight
		{
			get { return DrawingWandInterop.DrawGetFontWeight(this); }
			set { DrawingWandInterop.DrawSetFontWeight(this, value); }
		}

		/// <summary> Gets or sets a value indicating whether the text antialias. </summary>
		/// <value> true if text antialias, false if not. </value>
		public bool TextAntialias
		{
			get { return DrawingWandInterop.DrawGetTextAntialias(this); }
			set { DrawingWandInterop.DrawSetTextAntialias(this, value); }
		}

		/// <summary> Gets or sets the text alignment. </summary>
		/// <value> The text alignment. </value>
		public TextAlignType TextAlignment
		{
			get { return DrawingWandInterop.DrawGetTextAlignment(this); }
			set { DrawingWandInterop.DrawSetTextAlignment(this, value); }
		}

		/// <summary> Gets or sets the font resolution. </summary>
		/// <value> The font resolution. </value>
		public WandPointD FontResolution
		{
			get
			{
				double x;
				double y;
				DrawingWandInterop.DrawGetFontResolution(this, out x, out y);
				return new WandPointD(x, y);
			}
			set
			{
				DrawingWandInterop.DrawSetFontResolution(this, value.X, value.Y);
			}
		}

		/// <summary> Draw annotation. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="text"> The text. </param>
		public void DrawAnnotation(double x, double y, string text)
		{
			DrawingWandInterop.DrawAnnotation(this, x, y, text);
		}

		#endregion

		#region [Drawing Wand Methods - Colors]
		public PixelWand FillColor
		{
			get
			{
				IntPtr color;
				DrawingWandInterop.DrawGetFillColor(this, out color);
				return new PixelWand(color);
			}
			set { DrawingWandInterop.DrawSetFillColor(this, value); }
		}

		/// <summary> Gets or sets the color of the border. </summary>
		/// <value> The color of the border. </value>
		public PixelWand BorderColor
		{
			get
			{
				IntPtr background;
				DrawingWandInterop.DrawGetBorderColor(this, out background);
				return new PixelWand(background);
			}
			set { DrawingWandInterop.DrawSetBorderColor(this, value); }
		}

		/// <summary> Gets or sets the color of the stroke. </summary>
		/// <value> The color of the stroke. </value>
		public PixelWand StrokeColor
		{
			get
			{
				IntPtr background;
				DrawingWandInterop.DrawGetStrokeColor(this, out background);
				return new PixelWand(background);
			}
			set { DrawingWandInterop.DrawSetStrokeColor(this, value); }
		}

		/// <summary> Gets or sets the stroke opacity. </summary>
		/// <value> The stroke opacity. </value>
		public double StrokeOpacity
		{
			get { return DrawingWandInterop.DrawGetStrokeOpacity(this); }
			set { DrawingWandInterop.DrawSetStrokeOpacity(this, value); }
		}

		/// <summary> Gets or sets the width of the stroke. </summary>
		/// <value> The width of the stroke. </value>
		public double StrokeWidth
		{
			get { return DrawingWandInterop.DrawGetStrokeWidth(this); }
			set { DrawingWandInterop.DrawSetStrokeWidth(this, value); }
		}

		/// <summary> Gets or sets the color of the text under. </summary>
		/// <value> The color of the text under. </value>
		public PixelWand TextUnderColor
		{
			get
			{
				IntPtr background;
				DrawingWandInterop.DrawGetTextUnderColor(this, out background);
				return new PixelWand(background);
			}
			set { DrawingWandInterop.DrawSetTextUnderColor(this, value); }
		}

		/// <summary> Draw color. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="paintmethod"> The paintmethod. </param>
		public void DrawColor(double x, double y, PaintMethodType paintmethod)
		{
			DrawingWandInterop.DrawColor(this, x, y, paintmethod);
		}

		#endregion

		#region [Drawing Wand Methods - Geometry]

		/// <summary> Draw rectangle. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="x1"> The first x value. </param>
		/// <param name="y1"> The first y value. </param>
		/// <param name="x2"> The second x value. </param>
		/// <param name="y2"> The second y value. </param>
		public void DrawRectangle(double x1, double y1, double x2, double y2)
		{
			DrawingWandInterop.DrawRectangle(this, x1, y1, x2, y2);
		}

		/// <summary> Draw round rectangle. </summary>
		/// <param name="x1"> The first x value. </param>
		/// <param name="y1"> The first y value. </param>
		/// <param name="x2"> The second x value. </param>
		/// <param name="y2"> The second y value. </param>
		/// <param name="rx"> The radius of corner in horizontal direction. </param>
		/// <param name="ry"> The radius of corner in vertical direction. </param>
		public void DrawRoundRectangle(double x1, double y1, double x2, double y2, double rx, double ry)
		{
			DrawingWandInterop.DrawRoundRectangle(this, x1, y1, x2, y2, rx, ry);
		}

		/// <summary> Draw circle. </summary>
		/// <param name="ox"> The origin x ordinate. </param>
		/// <param name="oy"> The origin y ordinate. </param>
		/// <param name="px"> The perimeter x ordinate. </param>
		/// <param name="py"> The perimeter y ordinate. </param>
		public void DrawCircle(double ox, double oy, double px, double py)
		{
			DrawingWandInterop.DrawCircle(this, ox, oy, px, py);
		}

		/// <summary> Draw ellipse. </summary>
		/// <param name="ox"> The origin x ordinate. </param>
		/// <param name="oy"> The origin y ordinate. </param>
		/// <param name="rx"> The radius of corner in horizontal direction. </param>
		/// <param name="ry"> The radius of corner in vertical direction. </param>
		/// <param name="start"> starting rotation in degrees. </param>
		/// <param name="end"> ending rotation in degrees. </param>
		public void DrawEllipse(double ox, double oy, double rx, double ry, double start, double end)
		{
			DrawingWandInterop.DrawEllipse(this, ox, oy, rx, ry, start, end);
		}

		/// <summary> Draw arc. </summary>
		/// <param name="sx"> The starting x ordinate of bounding rectangle. </param>
		/// <param name="sy"> The starting y ordinate of bounding rectangle. </param>
		/// <param name="ex"> The ending x ordinate of bounding rectangle. </param>
		/// <param name="ey"> The ending y ordinate of bounding rectangle. </param>
		/// <param name="sd"> The starting degrees of rotation. </param>
		/// <param name="ed"> The ending degrees of rotation. </param>
		public void DrawArc(double sx, double sy, double ex, double ey, double sd, double ed)
		{
			DrawingWandInterop.DrawArc(this, sx, sy, ex, ey, sd, ed);
		}

		/// <summary> Draw line. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="sx"> The starting x ordinate of bounding rectangle. </param>
		/// <param name="sy"> The starting y ordinate of bounding rectangle. </param>
		/// <param name="ex"> The ending x ordinate of bounding rectangle. </param>
		/// <param name="ey"> The ending y ordinate of bounding rectangle. </param>
		void DrawLine(IntPtr wand, double sx, double sy, double ex, double ey)
		{
			DrawingWandInterop.DrawLine(this, sx, sy, ex, ey);
		}
		#endregion

		#region [Wand Methods - Exception]

		/// <summary> Gets the exception. </summary>
		/// <returns> The exception. </returns>
		public override IntPtr GetException(out int exceptionSeverity)
		{
			IntPtr exceptionPtr = DrawingWandInterop.DrawGetException(this, out exceptionSeverity);
			return exceptionPtr;
		}

		/// <summary> Clears the exception. </summary>
		/// <returns> An IntPtr. </returns>
		public override void ClearException()
		{
			DrawingWandInterop.DrawClearException(this);
		}

		#endregion

		#region [IDisposable]
		/// <summary> true if disposed. </summary>
		private bool disposed = false;

		~DrawingWand()
		{
			this.Dispose();
		}


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
				DrawingWandInterop.DestroyDrawingWand(this);
				this.Handle = IntPtr.Zero;
				disposed = true;

			}
		}

		#endregion
	}
}

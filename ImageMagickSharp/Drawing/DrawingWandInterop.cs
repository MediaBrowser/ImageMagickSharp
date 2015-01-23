using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
    /// <summary> A drawing wand interop. </summary>
    internal static class DrawingWandInterop
    {
        #region [Drawing Wand]
		
		/// <summary> Creates a new drawing wand. </summary>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr NewDrawingWand();

		/// <summary> Clears the drawing wand described by wand. </summary>
		/// <param name="wand"> The wand. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void ClearDrawingWand(IntPtr wand);

		/// <summary> Destroys the drawing wand described by wand. </summary>
		/// <param name="wand"> The wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr DestroyDrawingWand(IntPtr wand);

        #endregion

		#region [Drawing Wand Methods]

		#endregion

		#region [Drawing Wand Methods Geometry]

		/// <summary> Draw arc. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="sx"> The starting x ordinate of bounding rectangle. </param>
		/// <param name="sy"> The starting y ordinate of bounding rectangle. </param>
		/// <param name="ex"> The ending x ordinate of bounding rectangle. </param>
		/// <param name="ey"> The ending y ordinate of bounding rectangle. </param>
		/// <param name="sd"> The starting degrees of rotation. </param>
		/// <param name="ed"> The ending degrees of rotation. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void DrawArc(IntPtr wand, double sx, double sy, double ex, double ey, double sd, double ed);

		/// <summary> Draw circle. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="ox"> The origin x ordinate. </param>
		/// <param name="oy"> The origin y ordinate. </param>
		/// <param name="px"> The perimeter x ordinate. </param>
		/// <param name="py"> The perimeter y ordinate. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void DrawCircle(IntPtr wand, double ox, double oy, double px, double py);

		/// <summary> Draw rectangle. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="x1"> The first x value. </param>
		/// <param name="y1"> The first y value. </param>
		/// <param name="x2"> The second x value. </param>
		/// <param name="y2"> The second y value. </param>
		///
		/// ### <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void DrawRectangle(IntPtr wand, double x1, double y1, double x2, double y2);

		/// <summary> Draw round rectangle. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="x1"> The first x value. </param>
		/// <param name="y1"> The first y value. </param>
		/// <param name="x2"> The second x value. </param>
		/// <param name="y2"> The second y value. </param>
		/// <param name="rx"> The radius of corner in horizontal direction. </param>
		/// <param name="ry"> The radius of corner in vertical direction. </param>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void DrawRoundRectangle(IntPtr wand, double x1, double y1, double x2, double y2, double rx, double ry);

		#endregion

		#region [Drawing Wand Methods - Text]
		/// <summary> Draw annotation. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <param name="text"> The text. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern void DrawAnnotation(IntPtr wand, double x, double y, string text);
		#endregion


		#region [Drawing Wand Methods - Colors]

		#endregion

		#region [Drawing Wand Methods - Exceptions]
		/// <summary> Clear any exceptions associated with the wand.. </summary>
		/// <param name="wand"> The wand. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr DrawClearException(IntPtr wand);

		/// <summary> Draw get exception. </summary>
		/// <param name="wand"> The wand. </param>
		/// <param name="exceptionType"> Type of the exception. </param>
		/// <returns> An IntPtr. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern IntPtr DrawGetException(IntPtr wand, out int exceptionType);

		/// <summary> Draw get exception type. </summary>
		/// <param name="wand"> The wand. </param>
		/// <returns> An int. </returns>
		[DllImport(Constants.WandLibrary, CallingConvention = Constants.WandCallingConvention)]
		internal static extern int DrawGetExceptionType(IntPtr wand);

		#endregion
	}
}

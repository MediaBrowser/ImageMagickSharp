using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> An image matrix. </summary>
	public class ImageMatrix
	{

		#region [Constructors]

		/// <summary> Initializes a new instance of the ImageMatrix class. </summary>
		/// <param name="matrix"> . </param>
		public ImageMatrix(double[,] matrix)
		{
			_Matrix = matrix;
		}

		/// <summary>
		/// Initializes a new instance of the ImageMagickSharp.Image.ImageMatrix class. </summary>
		/// <param name="matrix"> . </param>
		public ImageMatrix(double[] matrix)
		{
			_Matrix = ConvertMatrix(matrix);
		}

		/// <summary> Initializes a new instance of the ImageMatrix class. </summary>
		public ImageMatrix()
		{
			this.Initialize();
		}

		#endregion

		#region [Private Fields]

		/// <summary> The matrix. </summary>
		private double[,] _Matrix = new double[3, 2];

		/// <summary> The degrees in radians. </summary>
		private Func<double, double> DegreesToRadians = (a) => (a * Math.PI / 180);

		/// <summary> The modifier. </summary>
		private Func<double, double, double> FMod = (a, s) => a % s;

		/// <summary> The radians in degrees. </summary>
		private Func<double, double> RadiansToDegrees = (a) => (a * 180 / Math.PI);

		#endregion

		#region [Public Properties]

		/// <summary> Gets the lenght. </summary>
		/// <value> The lenght. </value>
		public int Length
		{
			get
			{
				return _Matrix.Length;
			}
		}

		/// <summary> Gets the matrix. </summary>
		/// <value> The matrix. </value>
		public double[,] Matrix
		{
			get
			{
				return _Matrix;
			}
		}

		#endregion

		#region Operators

		/// <summary> Implicit cast that converts the given ImageMatrix to a double[]. </summary>
		/// <param name="matrix"> . </param>
		/// <returns> The result of the operation. </returns>
		public static implicit operator double[](ImageMatrix matrix)
		{
			return ConvertMatrix(matrix.Matrix);
		}

		/// <summary> Implicit cast that converts the given double[,] to an ImageMatrix. </summary>
		/// <param name="matrix"> . </param>
		/// <returns> The result of the operation. </returns>
		public static implicit operator ImageMatrix(double[,] matrix)
		{
			return new ImageMatrix(matrix);
		}

		/// <summary> Implicit cast that converts the given ImageMatrix to a double[,]. </summary>
		/// <param name="matrix"> . </param>
		/// <returns> The result of the operation. </returns>
		public static implicit operator double[,](ImageMatrix matrix)
		{
			return matrix.Matrix;
		}

		/// <summary> Implicit cast that converts the given double[] to an ImageMatrix. </summary>
		/// <param name="matrix"> . </param>
		/// <returns> The result of the operation. </returns>
		public static implicit operator ImageMatrix(double[] matrix)
		{
			return new ImageMatrix(matrix);
		}

		#endregion

		#region [Public Methods]

		/// <summary> Initializes this object. </summary>
		public void Initialize()
		{
			Matrix[0, 0] = 1;
			Matrix[1, 0] = 0;
			Matrix[2, 0] = 0;
			Matrix[0, 1] = 0;
			Matrix[1, 1] = 1;
			Matrix[2, 1] = 0;
		}

		/// <summary> Rotates. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix Rotate(double x, double y)
		{
			_Matrix[0, 1] = DegreesToRadians(x);
			_Matrix[1, 0] = DegreesToRadians(y);
			return this;
		}

		/// <summary> Rotate x coordinate. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix RotateX(double x)
		{
			_Matrix[0, 1] = DegreesToRadians(x);
			return this;
		}

		/// <summary> Rotate y coordinate. </summary>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix RotateY(double y)
		{
			_Matrix[1, 0] = DegreesToRadians(y);
			return this;
		}

		/// <summary> Scales. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix Scale(double x, double y)
		{
			_Matrix[0, 0] = x;
			_Matrix[1, 1] = y;
			return this;
		}

		/// <summary> Scale x coordinate. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix ScaleX(double x)
		{
			_Matrix[0, 0] = x;
			return this;
		}

		/// <summary> Scale y coordinate. </summary>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix ScaleY(double y)
		{
			_Matrix[1, 1] = y;
			return this;
		}

		/// <summary> Translates. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix Translate(double x, double y)
		{
			_Matrix[2, 0] = x;
			_Matrix[2, 1] = y;
			return this;
		}

		/// <summary> Translate x coordinate. </summary>
		/// <param name="x"> The x coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix TranslateX(double x)
		{
			_Matrix[2, 0] = x;
			return this;
		}

		/// <summary> Translate y coordinate. </summary>
		/// <param name="y"> The y coordinate. </param>
		/// <returns> An ImageMatrix. </returns>
		public ImageMatrix TranslateY(double y)
		{
			_Matrix[2, 1] = y;
			return this;
		}

		#endregion

		#region [Private Methods]

		/// <summary> Convert matrix. </summary>
		/// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or
		/// illegal values. </exception>
		/// <param name="matrix"> . </param>
		/// <returns> The matrix converted. </returns>
		private static double[] ConvertMatrix(double[,] matrix)
		{
			if (matrix.LongLength > 6 || matrix.LongLength < 6)
			{
				throw new ArgumentException("Invalid length");
			}
			double[] ret = new double[6];
			Buffer.BlockCopy(matrix, 0, ret, 0, matrix.Length * sizeof(double));
			return ret;
		}

		/// <summary> Convert matrix. </summary>
		/// <exception cref="ArgumentException"> Thrown when one or more arguments have unsupported or
		/// illegal values. </exception>
		/// <param name="matrix"> . </param>
		/// <returns> The matrix converted. </returns>
		private static double[,] ConvertMatrix(double[] matrix)
		{
			if (matrix.Length > 6 || matrix.Length < 6)
			{
				throw new ArgumentException("Invalid length");
			}
			double[,] ret = new double[3, 2];
			Buffer.BlockCopy(matrix, 0, ret, 0, matrix.Length * sizeof(double));
			return ret;
		}

		#endregion

	}
}

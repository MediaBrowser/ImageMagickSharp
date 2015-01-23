using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMagickSharp
{
	/// <summary> A wand. </summary>
	public class Wand
	{

		#region [Singleton]

		/// <summary> The instance. </summary>
		private static readonly Lazy<Wand> _Instance = new Lazy<Wand>(() => new Wand());

		/// <summary> Gets the instance. </summary>
		/// <value> The instance. </value>
		protected static Wand Instance
		{
			get
			{
				return _Instance.Value;
			}
		}

		#endregion

		#region [Wand Initializer]

		/// <summary> The is initialized. </summary>
		private static bool _IsInitialized = false;

		/// <summary> Initializes a new instance of the Wand class. </summary>
		public Wand()
		{
			this.InitializeEnvironment();
		}

		/// <summary> Initializes the environment. </summary>
		protected void InitializeEnvironment()
		{
			if (!_IsInitialized)
			{
				Environment.SetEnvironmentVariable("MAGICK_CODER_MODULE_PATH", "Libraries\\x86\\Coders");
				WandInterop.MagickWandGenesis();
				_IsInitialized = WandInterop.IsMagickWandInstantiated();
				if (!_IsInitialized)
					throw new Exception("Cannot Instantiate Wand");
			}
		}

		/// <summary> Dispose environment. </summary>
		protected void DisposeEnvironment()
		{
			if (IsInitialized)
			{
				WandInterop.MagickWandTerminus();
				_IsInitialized = false;
			}
		}

		/// <summary> Finalizes an instance of the ImageMagickSharp.Wand class. </summary>
		~Wand()
		{
			this.DisposeEnvironment();
		}

		#endregion


		#region [Wand Properties]

		/// <summary> Gets a value indicating whether this object is initialized. </summary>
		/// <value> true if this object is initialized, false if not. </value>
		public static bool IsInitialized
		{
			get
			{
				return _IsInitialized;
			}
		}

		/// <summary> Gets a value indicating whether this object is wand instantiated. </summary>
		/// <value> true if this object is wand instantiated, false if not. </value>
		public static bool IsWandInstantiated
		{
			get
			{
				return WandInterop.IsMagickWandInstantiated();
			}
		}

		/// <summary> Gets the version string. </summary>
		/// <value> The version string. </value>
		public static string VersionString
		{
			get
			{
				EnsureInitialized();
				int version;
				return WandNativeString.Load(WandInterop.MagickGetVersion(out version), false);
			}
		}

		/// <summary> Gets the version number. </summary>
		/// <value> The version number. </value>
		public static int VersionNumber
		{
			get
			{
				EnsureInitialized();
				int version;
				WandInterop.MagickGetVersion(out version);
				return version;
			}
		}

		/// <summary> Gets the version number string. </summary>
		/// <value> The version number string. </value>
		public static string VersionNumberString
		{
			get
			{
				return string.Join(".", VersionNumber.ToString("x").ToArray());
			}
		}

		#endregion

		#region [Wand Methods]

		/// <summary> Opens the environment. </summary>
		public static void OpenEnvironment()
		{
			Wand.Instance.InitializeEnvironment();
		}

		/// <summary> Closes the environment. </summary>
		public static void CloseEnvironment()
		{
			Wand.Instance.DisposeEnvironment();
		}

		/// <summary> Ensures that initialized. </summary>
		public static void EnsureInitialized()
		{
			if (!_IsInitialized)
				Wand.Instance.InitializeEnvironment();
		}
		/// <summary> Gets the handle. </summary>
		/// <returns> The handle. </returns>
		public static IntPtr GetHandle()
		{
			int version;
			return WandInterop.MagickGetVersion(out version);
		}

		/// <summary> Query if 'wand' is magick wand. </summary>
		/// <param name="wand"> The wand. </param>
		/// <returns> true if magick wand, false if not. </returns>
		public static bool IsMagickWand(IntPtr wand)
		{
			return WandInterop.IsMagickWand(wand);
		}
		#endregion

	}
}

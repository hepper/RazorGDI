// Test control fronend for WPF for RazorGDIPainter library
//   (c) Mokrov Ivan
// special for habrahabr.ru
// under MIT license
using System.Runtime.InteropServices;
using System.Windows.Forms.Integration;
using RazorGDIPainter;

namespace RazorGDIControlWPF
{
	public partial class RazorPainterWPFCtl : WindowsFormsHost
	{
		private readonly HandleRef hDCRef;
		private readonly System.Drawing.Graphics hDCGraphics;
		private readonly RazorPainter RP;

		/// <summary>
		/// root Bitmap
		/// </summary>
		public System.Drawing.Bitmap RazorBMP { get; private set; }

		/// <summary>
		/// Graphics object to paint on RazorBMP
		/// </summary>
		public System.Drawing.Graphics RazorGFX { get; private set; }

		/// <summary>
		/// Real per-pixel width of backend Win32 control, w/o DPI resizes of WPF layout
		/// </summary>
		public int RazorWidth { get { return RazorBackend1.Width; } }
		/// <summary>
		/// Real per-pixel height of backend Win32 control, w/o DPI resizes of WPF layout
		/// </summary>
		public int RazorHeight { get { return RazorBackend1.Height; } }

		/// <summary>
		/// Lock it to avoid resize/repaint race
		/// </summary>
		public readonly object RazorLock = new object();

		public RazorPainterWPFCtl()
		{
			InitializeComponent();

			hDCGraphics = RazorBackend1.CreateGraphics();
			hDCRef = new HandleRef(hDCGraphics, hDCGraphics.GetHdc());
			RP = new RazorPainter();

			RazorBMP = new System.Drawing.Bitmap(RazorWidth, RazorHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			RazorGFX = System.Drawing.Graphics.FromImage(RazorBMP);

			RazorBackend1.Resize += (sender, args) =>
			{
				lock (RazorLock)
				{
					if (RazorGFX != null) RazorGFX.Dispose();
					if (RazorBMP != null) RazorBMP.Dispose();
					RazorBMP = new System.Drawing.Bitmap(RazorWidth, RazorWidth, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
					RazorGFX = System.Drawing.Graphics.FromImage(RazorBMP);
				}
			};
		}

		/// <summary>
		/// After all in-memory paint on RazorGFX, call it to display it on control
		/// </summary>
		public void RazorPaint()
		{
			RP.Paint(hDCRef, RazorBMP);
		}

		protected override void Dispose(bool disposing)
		{
			lock (this)
			{
				if (RazorGFX != null) RazorGFX.Dispose();
				if (RazorBMP != null) RazorBMP.Dispose();
				if (hDCGraphics != null) hDCGraphics.Dispose();
				RP.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}

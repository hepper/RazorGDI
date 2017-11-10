// Test control backend for WPF for RazorGDIPainter library
//   (c) Mokrov Ivan
// special for habrahabr.ru
// under MIT license

using System.Windows.Forms;

namespace RazorGDIControlWPF
{
	public partial class RazorBackendCtl : UserControl
	{
		public RazorBackendCtl()
		{
			InitializeComponent();

			SetStyle(ControlStyles.DoubleBuffer, false);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.Opaque, true);

			this.MinimumSize = new System.Drawing.Size(1, 1);
		}
	}
}

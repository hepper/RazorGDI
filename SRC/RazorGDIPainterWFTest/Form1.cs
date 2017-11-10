// Test application for WindowsForms for RazorGDIPainter library
//   (c) Mokrov Ivan
// special for habrahabr.ru
// under MIT license

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace RazorGDIPainterWFTest
{
	public partial class Form1 : Form
	{
		private System.Timers.Timer fpstimer;
		private DispatcherTimer rendertimer;
		private Thread renderthread;
		private int fps;
		private bool drawred;

		public Form1()
		{
			InitializeComponent();
		}

		public void Update(MethodInvoker callback)
		{
			if (IsDisposed || Disposing)
				return;

			try
			{
				if (this.InvokeRequired)
					this.Invoke(callback);
				else
					callback();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			fpstimer = new System.Timers.Timer(1000);
			fpstimer.Elapsed += (sender1, args) =>
			{
				Update(delegate
				{
					Text = "FPS: " + fps; fps = 0;
				});
			};
			fpstimer.Start();

			//// !! uncomment for regular FPS renderloop !!
			//rendertimer = new DispatcherTimer();
			//rendertimer.Interval = TimeSpan.FromMilliseconds(15); /* ~60Hz LCD on my PC */
			//rendertimer.Tick += (o, args) => Render();
			//rendertimer.Start();

			// !! comment for maximum FPS renderloop !!
			renderthread = new Thread(() =>
			{
				while (true)
					Render();
			});
			renderthread.Start();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			renderthread.Abort();
			//rendertimer.Stop();
			fpstimer.Stop();
		}

		private void Render()
		{
			// do lock to avoid resize/repaint race in control
			// where are BMP and GFX recreates
			// better practice is Monitor.TryEnter() pattern, but here we do it simpler
			lock (razorPainterWFCtl1.RazorLock)
			{
				razorPainterWFCtl1.RazorGFX.Clear((drawred = !drawred) ? Color.Red : Color.Blue);
				razorPainterWFCtl1.RazorGFX.DrawString("habrahabr.ru", this.Font, Brushes.Azure, 10, 10);
				razorPainterWFCtl1.RazorPaint();
			}
			fps++;
		}



	}
}

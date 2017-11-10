// Test application for WPF for RazorGDIPainter library
//   (c) Mokrov Ivan
// special for habrahabr.ru
// under MIT license

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using RazorGDIControlWPF;

namespace RazorGDIPainterWPFTest
{

	public partial class MainWindow : Window
	{
		private bool drawred;

		private System.Timers.Timer fpstimer;
		private DispatcherTimer rendertimer;
		private Thread renderthread;
		private int fps;


		public MainWindow()
		{
			InitializeComponent();
		}

		private delegate void fpsdelegate();
		private void showfps()
		{
			this.Title = "FPS: " + fps; fps = 0;
		}

		private void Window_Loaded_1(object sender, RoutedEventArgs e)
		{
			fpstimer = new System.Timers.Timer(1000);
			fpstimer.Elapsed += (sender1, args) =>
			{
				Dispatcher.BeginInvoke(DispatcherPriority.Render, new fpsdelegate(showfps));
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

		private void Render()
		{
			// do lock to avoid resize/repaint race in control
			// where are BMP and GFX recreates
			// better practice is Monitor.TryEnter() pattern, but here we do it simpler
			lock (razorPainterWPFCtl1.RazorLock)
			{
				razorPainterWPFCtl1.RazorGFX.Clear((drawred = !drawred) ? System.Drawing.Color.Red : System.Drawing.Color.Blue);
				razorPainterWPFCtl1.RazorGFX.DrawString("habrahabr.ru", System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Azure, 10, 10);
				razorPainterWPFCtl1.RazorPaint();
			}
			fps++;
		}

		private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
		{
			renderthread.Abort();
			//rendertimer.Stop();
			fpstimer.Stop();
		}


	}
}

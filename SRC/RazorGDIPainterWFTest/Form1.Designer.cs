namespace RazorGDIPainterWFTest
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.razorPainterWFCtl1 = new RazorGDIControlWF.RazorPainterWFCtl();
			this.SuspendLayout();
			// 
			// razorPainterWFCtl1
			// 
			this.razorPainterWFCtl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.razorPainterWFCtl1.Location = new System.Drawing.Point(12, 12);
			this.razorPainterWFCtl1.MinimumSize = new System.Drawing.Size(1, 1);
			this.razorPainterWFCtl1.Name = "razorPainterWFCtl1";
			this.razorPainterWFCtl1.Size = new System.Drawing.Size(318, 215);
			this.razorPainterWFCtl1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 239);
			this.Controls.Add(this.razorPainterWFCtl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);

		}

		#endregion

		private RazorGDIControlWF.RazorPainterWFCtl razorPainterWFCtl1;

	}
}


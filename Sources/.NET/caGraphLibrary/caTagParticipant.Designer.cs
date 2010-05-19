namespace caGraphLibrary
{
	partial class caTagParticipant
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mutat = new System.Windows.Forms.Label();
			this.gViewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
			this.SuspendLayout();
			// 
			// mutat
			// 
			this.mutat.AutoSize = true;
			this.mutat.Location = new System.Drawing.Point(176, 7);
			this.mutat.Name = "mutat";
			this.mutat.Size = new System.Drawing.Size(35, 13);
			this.mutat.TabIndex = 7;
			this.mutat.Text = "label1";
			// 
			// gViewer
			// 
			this.gViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gViewer.AsyncLayout = false;
			this.gViewer.AutoScroll = true;
			this.gViewer.BackwardEnabled = false;
			this.gViewer.ForwardEnabled = false;
			this.gViewer.Graph = null;
			this.gViewer.Location = new System.Drawing.Point(0, 6);
			this.gViewer.MouseHitDistance = 0.05;
			this.gViewer.Name = "gViewer";
			this.gViewer.NavigationVisible = true;
			this.gViewer.PanButtonPressed = false;
			this.gViewer.SaveButtonVisible = true;
			this.gViewer.Size = new System.Drawing.Size(458, 388);
			this.gViewer.TabIndex = 6;
			this.gViewer.ZoomF = 1;
			this.gViewer.ZoomFraction = 0.5;
			this.gViewer.ZoomWindowThreshold = 0.05;
			this.gViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gViewer_MouseClick);
			// 
			// caTagParticipant
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mutat);
			this.Controls.Add(this.gViewer);
			this.Name = "caTagParticipant";
			this.Size = new System.Drawing.Size(458, 394);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label mutat;
		private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
	}
}

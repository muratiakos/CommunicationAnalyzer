namespace caGraphLibrary
{
    partial class caRelationGraph
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
			this.gViewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
			this.mutat = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			this.gViewer.Location = new System.Drawing.Point(6, 4);
			this.gViewer.MouseHitDistance = 0.05;
			this.gViewer.Name = "gViewer";
			this.gViewer.NavigationVisible = true;
			this.gViewer.PanButtonPressed = false;
			this.gViewer.SaveButtonVisible = true;
			this.gViewer.Size = new System.Drawing.Size(588, 336);
			this.gViewer.TabIndex = 4;
			this.gViewer.ZoomF = 1;
			this.gViewer.ZoomFraction = 0.5;
			this.gViewer.ZoomWindowThreshold = 0.05;
			// 
			// mutat
			// 
			this.mutat.AutoSize = true;
			this.mutat.BackColor = System.Drawing.Color.Transparent;
			this.mutat.Location = new System.Drawing.Point(185, 6);
			this.mutat.Name = "mutat";
			this.mutat.Size = new System.Drawing.Size(35, 13);
			this.mutat.TabIndex = 5;
			this.mutat.Text = "label1";
			// 
			// caRelationGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mutat);
			this.Controls.Add(this.gViewer);
			this.Name = "caRelationGraph";
			this.Size = new System.Drawing.Size(594, 359);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
        private System.Windows.Forms.Label mutat;
    }
}

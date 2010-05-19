namespace caGraphLibrary
{
	partial class caCommFlow
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
			this.components = new System.ComponentModel.Container();
			this.lb_info = new System.Windows.Forms.Label();
			this.cb_timemode = new System.Windows.Forms.ComboBox();
			this.lb_timemode = new System.Windows.Forms.Label();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.scroll_panel = new System.Windows.Forms.Panel();
			this.myCanvas = new System.Windows.Forms.PictureBox();
			this.lb_nodemode = new System.Windows.Forms.Label();
			this.cb_nodemode = new System.Windows.Forms.ComboBox();
			this.scroll_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.myCanvas)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_info
			// 
			this.lb_info.AutoSize = true;
			this.lb_info.Location = new System.Drawing.Point(485, 6);
			this.lb_info.Name = "lb_info";
			this.lb_info.Size = new System.Drawing.Size(35, 13);
			this.lb_info.TabIndex = 3;
			this.lb_info.Text = "label1";
			// 
			// cb_timemode
			// 
			this.cb_timemode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_timemode.FormattingEnabled = true;
			this.cb_timemode.Location = new System.Drawing.Point(83, 3);
			this.cb_timemode.Name = "cb_timemode";
			this.cb_timemode.Size = new System.Drawing.Size(121, 21);
			this.cb_timemode.TabIndex = 4;
			this.cb_timemode.SelectedIndexChanged += new System.EventHandler(this.cb_zoom_SelectedIndexChanged);
			// 
			// lb_timemode
			// 
			this.lb_timemode.AutoSize = true;
			this.lb_timemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lb_timemode.Location = new System.Drawing.Point(4, 6);
			this.lb_timemode.Name = "lb_timemode";
			this.lb_timemode.Size = new System.Drawing.Size(73, 13);
			this.lb_timemode.TabIndex = 5;
			this.lb_timemode.Text = "Time Mode:";
			// 
			// scroll_panel
			// 
			this.scroll_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.scroll_panel.AutoScroll = true;
			this.scroll_panel.Controls.Add(this.myCanvas);
			this.scroll_panel.Location = new System.Drawing.Point(3, 30);
			this.scroll_panel.Name = "scroll_panel";
			this.scroll_panel.Size = new System.Drawing.Size(529, 341);
			this.scroll_panel.TabIndex = 6;
			this.scroll_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.scroll_panel_Paint);
			this.scroll_panel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_panel_Scroll);
			this.scroll_panel.Resize += new System.EventHandler(this.scroll_panel_Resize);
			this.scroll_panel.SizeChanged += new System.EventHandler(this.scroll_panel_SizeChanged);
			// 
			// myCanvas
			// 
			this.myCanvas.Location = new System.Drawing.Point(4, 3);
			this.myCanvas.Name = "myCanvas";
			this.myCanvas.Size = new System.Drawing.Size(100, 50);
			this.myCanvas.TabIndex = 0;
			this.myCanvas.TabStop = false;
			this.myCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myCanvas_MouseMove);
			this.myCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.myCanvas_Paint);
			// 
			// lb_nodemode
			// 
			this.lb_nodemode.AutoSize = true;
			this.lb_nodemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lb_nodemode.Location = new System.Drawing.Point(210, 6);
			this.lb_nodemode.Name = "lb_nodemode";
			this.lb_nodemode.Size = new System.Drawing.Size(41, 13);
			this.lb_nodemode.TabIndex = 7;
			this.lb_nodemode.Text = "Node:";
			// 
			// cb_nodemode
			// 
			this.cb_nodemode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_nodemode.FormattingEnabled = true;
			this.cb_nodemode.Location = new System.Drawing.Point(257, 3);
			this.cb_nodemode.Name = "cb_nodemode";
			this.cb_nodemode.Size = new System.Drawing.Size(121, 21);
			this.cb_nodemode.TabIndex = 8;
			this.cb_nodemode.SelectedIndexChanged += new System.EventHandler(this.cb_nodemode_SelectedIndexChanged);
			// 
			// caCommFlow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoScrollMargin = new System.Drawing.Size(5, 5);
			this.AutoScrollMinSize = new System.Drawing.Size(10, 10);
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.cb_nodemode);
			this.Controls.Add(this.lb_nodemode);
			this.Controls.Add(this.scroll_panel);
			this.Controls.Add(this.lb_timemode);
			this.Controls.Add(this.cb_timemode);
			this.Controls.Add(this.lb_info);
			this.Name = "caCommFlow";
			this.Size = new System.Drawing.Size(535, 374);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.caCommFlow_Paint);
			this.scroll_panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.myCanvas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lb_info;
		private System.Windows.Forms.ComboBox cb_timemode;
		private System.Windows.Forms.Label lb_timemode;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.Panel scroll_panel;
		private System.Windows.Forms.PictureBox myCanvas;
		private System.Windows.Forms.Label lb_nodemode;
		private System.Windows.Forms.ComboBox cb_nodemode;


	}
}

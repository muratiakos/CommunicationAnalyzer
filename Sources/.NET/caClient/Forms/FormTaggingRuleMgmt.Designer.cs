namespace caClient.Forms
{
	partial class FormTaggingRuleMgmt
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaggingRuleMgmt));
			this.dgTaggingRules = new System.Windows.Forms.DataGridView();
			this.tsMenu = new System.Windows.Forms.ToolStrip();
			this.tsRefresh = new System.Windows.Forms.ToolStripButton();
			this.tsNew = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dgTaggingRules)).BeginInit();
			this.tsMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgTaggingRules
			// 
			this.dgTaggingRules.AllowUserToAddRows = false;
			this.dgTaggingRules.AllowUserToDeleteRows = false;
			this.dgTaggingRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgTaggingRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgTaggingRules.Location = new System.Drawing.Point(13, 28);
			this.dgTaggingRules.Name = "dgTaggingRules";
			this.dgTaggingRules.ReadOnly = true;
			this.dgTaggingRules.RowHeadersVisible = false;
			this.dgTaggingRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgTaggingRules.Size = new System.Drawing.Size(451, 306);
			this.dgTaggingRules.TabIndex = 0;
			this.dgTaggingRules.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaggingRules_CellDoubleClick);
			// 
			// tsMenu
			// 
			this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh,
            this.tsNew});
			this.tsMenu.Location = new System.Drawing.Point(0, 0);
			this.tsMenu.Name = "tsMenu";
			this.tsMenu.Size = new System.Drawing.Size(476, 25);
			this.tsMenu.TabIndex = 1;
			this.tsMenu.Text = "toolStrip1";
			// 
			// tsRefresh
			// 
			this.tsRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsRefresh.Image")));
			this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsRefresh.Name = "tsRefresh";
			this.tsRefresh.Size = new System.Drawing.Size(66, 22);
			this.tsRefresh.Text = "Refresh";
			this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
			// 
			// tsNew
			// 
			this.tsNew.Image = ((System.Drawing.Image)(resources.GetObject("tsNew.Image")));
			this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNew.Name = "tsNew";
			this.tsNew.Size = new System.Drawing.Size(149, 22);
			this.tsNew.Text = "Add New Tagging Rule";
			this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
			// 
			// FormTaggingRuleMgmt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(476, 346);
			this.Controls.Add(this.tsMenu);
			this.Controls.Add(this.dgTaggingRules);
			this.Name = "FormTaggingRuleMgmt";
			this.Text = "Tagging Management";
			((System.ComponentModel.ISupportInitialize)(this.dgTaggingRules)).EndInit();
			this.tsMenu.ResumeLayout(false);
			this.tsMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgTaggingRules;
		private System.Windows.Forms.ToolStrip tsMenu;
		private System.Windows.Forms.ToolStripButton tsRefresh;
		private System.Windows.Forms.ToolStripButton tsNew;

	}
}
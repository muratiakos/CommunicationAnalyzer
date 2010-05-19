namespace caClient.Forms
{
	partial class FormParticipantMgmt
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParticipantMgmt));
			this.mnuParticipant = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miName = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.miTools = new System.Windows.Forms.ToolStripMenuItem();
			this.identifyAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.participantTable = new caClient.Controls.ParticipantTable();
			this.tsMenu = new System.Windows.Forms.ToolStrip();
			this.tsRefresh = new System.Windows.Forms.ToolStripButton();
			this.tsNew = new System.Windows.Forms.ToolStripButton();
			this.mnuParticipant.SuspendLayout();
			this.tsMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuParticipant
			// 
			this.mnuParticipant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miName,
            this.toolStripMenuItem1,
            this.miTools,
            this.miProperties});
			this.mnuParticipant.Name = "mnuParticipnat";
			this.mnuParticipant.Size = new System.Drawing.Size(128, 76);
			// 
			// miName
			// 
			this.miName.Enabled = false;
			this.miName.Name = "miName";
			this.miName.Size = new System.Drawing.Size(127, 22);
			this.miName.Text = "name";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
			// 
			// miTools
			// 
			this.miTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.identifyAsToolStripMenuItem});
			this.miTools.Name = "miTools";
			this.miTools.Size = new System.Drawing.Size(127, 22);
			this.miTools.Text = "Tools";
			// 
			// identifyAsToolStripMenuItem
			// 
			this.identifyAsToolStripMenuItem.Name = "identifyAsToolStripMenuItem";
			this.identifyAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.identifyAsToolStripMenuItem.Text = "Identify As..";
			this.identifyAsToolStripMenuItem.Click += new System.EventHandler(this.identifyAsToolStripMenuItem_Click);
			// 
			// miProperties
			// 
			this.miProperties.Name = "miProperties";
			this.miProperties.Size = new System.Drawing.Size(127, 22);
			this.miProperties.Text = "Properties";
			this.miProperties.Click += new System.EventHandler(this.miProperties_Click);
			// 
			// participantTable
			// 
			this.participantTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.participantTable.Location = new System.Drawing.Point(12, 28);
			this.participantTable.Name = "participantTable";
			this.participantTable.ParticipantDisplayMode = caCoreLibrary.caParticipantType.UserOrGroup;
			this.participantTable.Size = new System.Drawing.Size(527, 361);
			this.participantTable.TabIndex = 0;
			this.participantTable.RowDoubleClick += new System.EventHandler(this.participantTable1_RowDoubleClick);
			this.participantTable.RowRightClick += new System.Windows.Forms.MouseEventHandler(this.participantTable_RowRightClick);
			// 
			// tsMenu
			// 
			this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh,
            this.tsNew});
			this.tsMenu.Location = new System.Drawing.Point(0, 0);
			this.tsMenu.Name = "tsMenu";
			this.tsMenu.Size = new System.Drawing.Size(551, 25);
			this.tsMenu.TabIndex = 2;
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
			this.tsNew.Size = new System.Drawing.Size(136, 22);
			this.tsNew.Text = "Add New Participant";
			this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
			// 
			// FormParticipantMgmt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(551, 401);
			this.Controls.Add(this.tsMenu);
			this.Controls.Add(this.participantTable);
			this.Name = "FormParticipantMgmt";
			this.Text = "Participant Management";
			this.mnuParticipant.ResumeLayout(false);
			this.tsMenu.ResumeLayout(false);
			this.tsMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private caClient.Controls.ParticipantTable participantTable;
		private System.Windows.Forms.ContextMenuStrip mnuParticipant;
		private System.Windows.Forms.ToolStripMenuItem miName;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem miTools;
		private System.Windows.Forms.ToolStripMenuItem identifyAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miProperties;
		private System.Windows.Forms.ToolStrip tsMenu;
		private System.Windows.Forms.ToolStripButton tsRefresh;
		private System.Windows.Forms.ToolStripButton tsNew;


	}
}
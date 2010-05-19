namespace caClient
{
	partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Participant Relation Analysis");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Flow Analysis");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Subject - Participant Relation Analysis");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Analyze", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Participants");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Tagging Rules");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Manage", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Connection - not established", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tabWindows = new System.Windows.Forms.TabControl();
			this.tvNavigator = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btServerMsg = new System.Windows.Forms.Button();
			this.btMessageClear = new System.Windows.Forms.Button();
			this.lvMessageList = new System.Windows.Forms.ListView();
			this.systemPanel = new System.Windows.Forms.Panel();
			this.tabPanel = new System.Windows.Forms.Panel();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.systemPanel.SuspendLayout();
			this.tabPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.windowsMenu,
            this.helpMenu});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.MdiWindowListItem = this.windowsMenu;
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(803, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(37, 20);
			this.fileMenu.Text = "&File";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
			this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.searchToolStripMenuItem.Text = "&Download service WSDL";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
			// 
			// windowsMenu
			// 
			this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
			this.windowsMenu.Name = "windowsMenu";
			this.windowsMenu.Size = new System.Drawing.Size(68, 20);
			this.windowsMenu.Text = "&Windows";
			// 
			// cascadeToolStripMenuItem
			// 
			this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
			this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.cascadeToolStripMenuItem.Text = "&Cascade";
			this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
			// 
			// tileVerticalToolStripMenuItem
			// 
			this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
			this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
			this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
			// 
			// tileHorizontalToolStripMenuItem
			// 
			this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
			this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
			this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.closeAllToolStripMenuItem.Text = "C&lose All";
			this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
			// 
			// arrangeIconsToolStripMenuItem
			// 
			this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
			this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
			this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(52, 20);
			this.helpMenu.Text = "&About";
			this.helpMenu.Click += new System.EventHandler(this.helpMenu_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
			this.statusStrip.Location = new System.Drawing.Point(0, 528);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(803, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// tsStatus
			// 
			this.tsStatus.Name = "tsStatus";
			this.tsStatus.Size = new System.Drawing.Size(39, 17);
			this.tsStatus.Text = "Status";
			// 
			// tabWindows
			// 
			this.tabWindows.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabWindows.HotTrack = true;
			this.tabWindows.Location = new System.Drawing.Point(0, 0);
			this.tabWindows.Name = "tabWindows";
			this.tabWindows.SelectedIndex = 0;
			this.tabWindows.Size = new System.Drawing.Size(603, 22);
			this.tabWindows.TabIndex = 7;
			this.tabWindows.Visible = false;
			this.tabWindows.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
			// 
			// tvNavigator
			// 
			this.tvNavigator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvNavigator.Enabled = false;
			this.tvNavigator.Location = new System.Drawing.Point(3, 3);
			this.tvNavigator.Name = "tvNavigator";
			treeNode1.Name = "tnRelationAnalysis";
			treeNode1.Text = "Participant Relation Analysis";
			treeNode2.Name = "tnFlowAnalysis";
			treeNode2.Text = "Flow Analysis";
			treeNode3.Name = "tnTagRelationAnalysis";
			treeNode3.Text = "Subject - Participant Relation Analysis";
			treeNode4.Name = "tr_analyze";
			treeNode4.Text = "Analyze";
			treeNode5.Name = "tnParticipantMgmt";
			treeNode5.Tag = "";
			treeNode5.Text = "Participants";
			treeNode6.Name = "tnTagMgmt";
			treeNode6.Text = "Tagging Rules";
			treeNode7.Name = "tmMgmt";
			treeNode7.Text = "Manage";
			treeNode8.Name = "tnConnection";
			treeNode8.Text = "Connection - not established";
			this.tvNavigator.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
			this.tvNavigator.Size = new System.Drawing.Size(186, 472);
			this.tvNavigator.TabIndex = 6;
			this.tvNavigator.DoubleClick += new System.EventHandler(this.tr_menu_DoubleClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(200, 504);
			this.tabControl1.TabIndex = 9;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tvNavigator);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(192, 478);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Navigator";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btServerMsg);
			this.tabPage2.Controls.Add(this.btMessageClear);
			this.tabPage2.Controls.Add(this.lvMessageList);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(192, 478);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Messages";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btServerMsg
			// 
			this.btServerMsg.Location = new System.Drawing.Point(87, 3);
			this.btServerMsg.Name = "btServerMsg";
			this.btServerMsg.Size = new System.Drawing.Size(75, 23);
			this.btServerMsg.TabIndex = 2;
			this.btServerMsg.Text = "Server";
			this.btServerMsg.UseVisualStyleBackColor = true;
			this.btServerMsg.Click += new System.EventHandler(this.btServerMsg_Click);
			// 
			// btMessageClear
			// 
			this.btMessageClear.Location = new System.Drawing.Point(6, 3);
			this.btMessageClear.Name = "btMessageClear";
			this.btMessageClear.Size = new System.Drawing.Size(75, 23);
			this.btMessageClear.TabIndex = 1;
			this.btMessageClear.Text = "Clear";
			this.btMessageClear.UseVisualStyleBackColor = true;
			this.btMessageClear.Click += new System.EventHandler(this.btMessageClear_Click);
			// 
			// lvMessageList
			// 
			this.lvMessageList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvMessageList.Location = new System.Drawing.Point(3, 29);
			this.lvMessageList.Name = "lvMessageList";
			this.lvMessageList.Size = new System.Drawing.Size(186, 406);
			this.lvMessageList.TabIndex = 0;
			this.lvMessageList.UseCompatibleStateImageBehavior = false;
			this.lvMessageList.View = System.Windows.Forms.View.SmallIcon;
			// 
			// systemPanel
			// 
			this.systemPanel.Controls.Add(this.tabControl1);
			this.systemPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.systemPanel.Location = new System.Drawing.Point(0, 24);
			this.systemPanel.Name = "systemPanel";
			this.systemPanel.Size = new System.Drawing.Size(200, 504);
			this.systemPanel.TabIndex = 10;
			// 
			// tabPanel
			// 
			this.tabPanel.Controls.Add(this.tabWindows);
			this.tabPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabPanel.Location = new System.Drawing.Point(200, 24);
			this.tabPanel.Name = "tabPanel";
			this.tabPanel.Size = new System.Drawing.Size(603, 22);
			this.tabPanel.TabIndex = 11;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(803, 550);
			this.Controls.Add(this.tabPanel);
			this.Controls.Add(this.systemPanel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "BME-TMIT Communication Analyzer Client";
			this.Load += new System.EventHandler(this.Main_Load);
			this.MdiChildActivate += new System.EventHandler(this.Main_MdiChildActivate);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.systemPanel.ResumeLayout(false);
			this.tabPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel tsStatus;
		private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem windowsMenu;
		private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TabControl tabWindows;
		private System.Windows.Forms.TreeView tvNavigator;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel systemPanel;
		private System.Windows.Forms.Panel tabPanel;
		private System.Windows.Forms.ListView lvMessageList;
		private System.Windows.Forms.Button btServerMsg;
		private System.Windows.Forms.Button btMessageClear;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
	}
}




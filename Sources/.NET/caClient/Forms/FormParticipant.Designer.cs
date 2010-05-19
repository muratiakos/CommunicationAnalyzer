namespace caClient.Forms
{
	partial class FormParticipant
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("email");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("telefon");
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.lbStatus = new System.Windows.Forms.Label();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.txForeignId = new System.Windows.Forms.TextBox();
			this.lbForeignId = new System.Windows.Forms.Label();
			this.txParticipantId = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			this.lbParticipantId = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.txName = new System.Windows.Forms.TextBox();
			this.lbParticipantType = new System.Windows.Forms.Label();
			this.tpAddress = new System.Windows.Forms.TabPage();
			this.cbCategory = new System.Windows.Forms.ComboBox();
			this.btAddrAdd = new System.Windows.Forms.Button();
			this.lbAddrCategory = new System.Windows.Forms.Label();
			this.btAddrRemove = new System.Windows.Forms.Button();
			this.txAddress = new System.Windows.Forms.TextBox();
			this.lbAddress = new System.Windows.Forms.Label();
			this.lvAddressList = new System.Windows.Forms.ListView();
			this.tpMembers = new System.Windows.Forms.TabPage();
			this.pflMembers = new caClient.Controls.ParticipantFillList();
			this.tpGroups = new System.Windows.Forms.TabPage();
			this.btSetPrimaryGroup = new System.Windows.Forms.Button();
			this.txPrimaryGroup = new System.Windows.Forms.TextBox();
			this.lbPrimaryGroup = new System.Windows.Forms.Label();
			this.pflGroups = new caClient.Controls.ParticipantFillList();
			this.tpTools = new System.Windows.Forms.TabPage();
			this.btToolReplace = new System.Windows.Forms.Button();
			this.cbSync = new System.Windows.Forms.ComboBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btSave = new System.Windows.Forms.Button();
			this.btClose = new System.Windows.Forms.Button();
			this.btReload = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.tpAddress.SuspendLayout();
			this.tpMembers.SuspendLayout();
			this.tpGroups.SuspendLayout();
			this.tpTools.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tpGeneral);
			this.tabControl.Controls.Add(this.tpAddress);
			this.tabControl.Controls.Add(this.tpMembers);
			this.tabControl.Controls.Add(this.tpGroups);
			this.tabControl.Controls.Add(this.tpTools);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(389, 357);
			this.tabControl.TabIndex = 0;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.lbStatus);
			this.tpGeneral.Controls.Add(this.cbStatus);
			this.tpGeneral.Controls.Add(this.txForeignId);
			this.tpGeneral.Controls.Add(this.lbForeignId);
			this.tpGeneral.Controls.Add(this.txParticipantId);
			this.tpGeneral.Controls.Add(this.lbName);
			this.tpGeneral.Controls.Add(this.lbParticipantId);
			this.tpGeneral.Controls.Add(this.cbType);
			this.tpGeneral.Controls.Add(this.txName);
			this.tpGeneral.Controls.Add(this.lbParticipantType);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(381, 331);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "General";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// lbStatus
			// 
			this.lbStatus.AutoSize = true;
			this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbStatus.Location = new System.Drawing.Point(21, 63);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(47, 13);
			this.lbStatus.TabIndex = 12;
			this.lbStatus.Text = "Status:";
			// 
			// cbStatus
			// 
			this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Location = new System.Drawing.Point(126, 60);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(121, 21);
			this.cbStatus.TabIndex = 11;
			// 
			// txForeignId
			// 
			this.txForeignId.Location = new System.Drawing.Point(126, 142);
			this.txForeignId.Name = "txForeignId";
			this.txForeignId.Size = new System.Drawing.Size(239, 20);
			this.txForeignId.TabIndex = 9;
			// 
			// lbForeignId
			// 
			this.lbForeignId.AutoSize = true;
			this.lbForeignId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbForeignId.Location = new System.Drawing.Point(19, 145);
			this.lbForeignId.Name = "lbForeignId";
			this.lbForeignId.Size = new System.Drawing.Size(70, 13);
			this.lbForeignId.TabIndex = 8;
			this.lbForeignId.Text = "Foreign ID:";
			// 
			// txParticipantId
			// 
			this.txParticipantId.Location = new System.Drawing.Point(127, 7);
			this.txParticipantId.Name = "txParticipantId";
			this.txParticipantId.ReadOnly = true;
			this.txParticipantId.Size = new System.Drawing.Size(239, 20);
			this.txParticipantId.TabIndex = 7;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbName.Location = new System.Drawing.Point(19, 117);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(43, 13);
			this.lbName.TabIndex = 6;
			this.lbName.Text = "Name:";
			// 
			// lbParticipantId
			// 
			this.lbParticipantId.AutoSize = true;
			this.lbParticipantId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbParticipantId.Location = new System.Drawing.Point(20, 11);
			this.lbParticipantId.Name = "lbParticipantId";
			this.lbParticipantId.Size = new System.Drawing.Size(89, 13);
			this.lbParticipantId.TabIndex = 5;
			this.lbParticipantId.Text = "Participant ID:";
			// 
			// cbType
			// 
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(126, 33);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(121, 21);
			this.cbType.TabIndex = 4;
			// 
			// txName
			// 
			this.txName.Location = new System.Drawing.Point(126, 114);
			this.txName.Name = "txName";
			this.txName.Size = new System.Drawing.Size(239, 20);
			this.txName.TabIndex = 1;
			// 
			// lbParticipantType
			// 
			this.lbParticipantType.AutoSize = true;
			this.lbParticipantType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbParticipantType.Location = new System.Drawing.Point(20, 36);
			this.lbParticipantType.Name = "lbParticipantType";
			this.lbParticipantType.Size = new System.Drawing.Size(39, 13);
			this.lbParticipantType.TabIndex = 0;
			this.lbParticipantType.Text = "Type:";
			// 
			// tpAddress
			// 
			this.tpAddress.Controls.Add(this.cbCategory);
			this.tpAddress.Controls.Add(this.btAddrAdd);
			this.tpAddress.Controls.Add(this.lbAddrCategory);
			this.tpAddress.Controls.Add(this.btAddrRemove);
			this.tpAddress.Controls.Add(this.txAddress);
			this.tpAddress.Controls.Add(this.lbAddress);
			this.tpAddress.Controls.Add(this.lvAddressList);
			this.tpAddress.Location = new System.Drawing.Point(4, 22);
			this.tpAddress.Name = "tpAddress";
			this.tpAddress.Padding = new System.Windows.Forms.Padding(3);
			this.tpAddress.Size = new System.Drawing.Size(381, 331);
			this.tpAddress.TabIndex = 1;
			this.tpAddress.Text = "Addresses";
			this.tpAddress.UseVisualStyleBackColor = true;
			// 
			// cbCategory
			// 
			this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategory.FormattingEnabled = true;
			this.cbCategory.Location = new System.Drawing.Point(190, 29);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new System.Drawing.Size(104, 21);
			this.cbCategory.TabIndex = 12;
			// 
			// btAddrAdd
			// 
			this.btAddrAdd.Location = new System.Drawing.Point(300, 30);
			this.btAddrAdd.Name = "btAddrAdd";
			this.btAddrAdd.Size = new System.Drawing.Size(75, 23);
			this.btAddrAdd.TabIndex = 5;
			this.btAddrAdd.Text = "Add";
			this.btAddrAdd.UseVisualStyleBackColor = true;
			this.btAddrAdd.Click += new System.EventHandler(this.btAddrAdd_Click);
			// 
			// lbAddrCategory
			// 
			this.lbAddrCategory.AutoSize = true;
			this.lbAddrCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbAddrCategory.Location = new System.Drawing.Point(187, 14);
			this.lbAddrCategory.Name = "lbAddrCategory";
			this.lbAddrCategory.Size = new System.Drawing.Size(57, 13);
			this.lbAddrCategory.TabIndex = 4;
			this.lbAddrCategory.Text = "Category";
			// 
			// btAddrRemove
			// 
			this.btAddrRemove.Location = new System.Drawing.Point(300, 59);
			this.btAddrRemove.Name = "btAddrRemove";
			this.btAddrRemove.Size = new System.Drawing.Size(75, 23);
			this.btAddrRemove.TabIndex = 3;
			this.btAddrRemove.Text = "Remove";
			this.btAddrRemove.UseVisualStyleBackColor = true;
			this.btAddrRemove.Click += new System.EventHandler(this.btAddrRemove_Click);
			// 
			// txAddress
			// 
			this.txAddress.Location = new System.Drawing.Point(9, 30);
			this.txAddress.Name = "txAddress";
			this.txAddress.Size = new System.Drawing.Size(175, 20);
			this.txAddress.TabIndex = 2;
			// 
			// lbAddress
			// 
			this.lbAddress.AutoSize = true;
			this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbAddress.Location = new System.Drawing.Point(6, 14);
			this.lbAddress.Name = "lbAddress";
			this.lbAddress.Size = new System.Drawing.Size(56, 13);
			this.lbAddress.TabIndex = 1;
			this.lbAddress.Text = "Address:";
			// 
			// lvAddressList
			// 
			this.lvAddressList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
			this.lvAddressList.LabelWrap = false;
			this.lvAddressList.Location = new System.Drawing.Point(9, 59);
			this.lvAddressList.MultiSelect = false;
			this.lvAddressList.Name = "lvAddressList";
			this.lvAddressList.Size = new System.Drawing.Size(285, 209);
			this.lvAddressList.TabIndex = 0;
			this.lvAddressList.UseCompatibleStateImageBehavior = false;
			this.lvAddressList.View = System.Windows.Forms.View.List;
			// 
			// tpMembers
			// 
			this.tpMembers.Controls.Add(this.pflMembers);
			this.tpMembers.Location = new System.Drawing.Point(4, 22);
			this.tpMembers.Name = "tpMembers";
			this.tpMembers.Padding = new System.Windows.Forms.Padding(3);
			this.tpMembers.Size = new System.Drawing.Size(381, 331);
			this.tpMembers.TabIndex = 2;
			this.tpMembers.Text = "Members";
			this.tpMembers.UseVisualStyleBackColor = true;
			// 
			// pflMembers
			// 
			this.pflMembers.Label = "Members:";
			this.pflMembers.Location = new System.Drawing.Point(6, 7);
			this.pflMembers.Name = "pflMembers";
			this.pflMembers.Size = new System.Drawing.Size(369, 302);
			this.pflMembers.TabIndex = 0;
			// 
			// tpGroups
			// 
			this.tpGroups.Controls.Add(this.btSetPrimaryGroup);
			this.tpGroups.Controls.Add(this.txPrimaryGroup);
			this.tpGroups.Controls.Add(this.lbPrimaryGroup);
			this.tpGroups.Controls.Add(this.pflGroups);
			this.tpGroups.Location = new System.Drawing.Point(4, 22);
			this.tpGroups.Name = "tpGroups";
			this.tpGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tpGroups.Size = new System.Drawing.Size(381, 331);
			this.tpGroups.TabIndex = 3;
			this.tpGroups.Text = "Groups";
			this.tpGroups.UseVisualStyleBackColor = true;
			// 
			// btSetPrimaryGroup
			// 
			this.btSetPrimaryGroup.Location = new System.Drawing.Point(212, 242);
			this.btSetPrimaryGroup.Name = "btSetPrimaryGroup";
			this.btSetPrimaryGroup.Size = new System.Drawing.Size(156, 23);
			this.btSetPrimaryGroup.TabIndex = 14;
			this.btSetPrimaryGroup.Text = "Set Selected to Primary";
			this.btSetPrimaryGroup.UseVisualStyleBackColor = true;
			this.btSetPrimaryGroup.Click += new System.EventHandler(this.btSetPrimaryGroup_Click);
			// 
			// txPrimaryGroup
			// 
			this.txPrimaryGroup.Enabled = false;
			this.txPrimaryGroup.Location = new System.Drawing.Point(102, 285);
			this.txPrimaryGroup.Name = "txPrimaryGroup";
			this.txPrimaryGroup.Size = new System.Drawing.Size(266, 20);
			this.txPrimaryGroup.TabIndex = 11;
			// 
			// lbPrimaryGroup
			// 
			this.lbPrimaryGroup.AutoSize = true;
			this.lbPrimaryGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbPrimaryGroup.Location = new System.Drawing.Point(6, 288);
			this.lbPrimaryGroup.Name = "lbPrimaryGroup";
			this.lbPrimaryGroup.Size = new System.Drawing.Size(90, 13);
			this.lbPrimaryGroup.TabIndex = 10;
			this.lbPrimaryGroup.Text = "Primary Group:";
			// 
			// pflGroups
			// 
			this.pflGroups.Label = "Member Of:";
			this.pflGroups.Location = new System.Drawing.Point(6, 7);
			this.pflGroups.Name = "pflGroups";
			this.pflGroups.Size = new System.Drawing.Size(369, 272);
			this.pflGroups.TabIndex = 1;
			// 
			// tpTools
			// 
			this.tpTools.Controls.Add(this.btToolReplace);
			this.tpTools.Location = new System.Drawing.Point(4, 22);
			this.tpTools.Name = "tpTools";
			this.tpTools.Padding = new System.Windows.Forms.Padding(3);
			this.tpTools.Size = new System.Drawing.Size(381, 331);
			this.tpTools.TabIndex = 4;
			this.tpTools.Text = "Tools";
			this.tpTools.UseVisualStyleBackColor = true;
			// 
			// btToolReplace
			// 
			this.btToolReplace.Location = new System.Drawing.Point(23, 19);
			this.btToolReplace.Name = "btToolReplace";
			this.btToolReplace.Size = new System.Drawing.Size(327, 29);
			this.btToolReplace.TabIndex = 0;
			this.btToolReplace.Text = "Replace this Participant With ...";
			this.btToolReplace.UseVisualStyleBackColor = true;
			this.btToolReplace.Click += new System.EventHandler(this.btToolReplace_Click);
			// 
			// cbSync
			// 
			this.cbSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSync.Enabled = false;
			this.cbSync.FormattingEnabled = true;
			this.cbSync.Location = new System.Drawing.Point(12, 377);
			this.cbSync.Name = "cbSync";
			this.cbSync.Size = new System.Drawing.Size(121, 21);
			this.cbSync.TabIndex = 13;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(132, 98);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(239, 20);
			this.textBox4.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(17, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Foreign ID:";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(132, 42);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(239, 20);
			this.textBox5.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label6.Location = new System.Drawing.Point(17, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(108, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Participant Name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label7.Location = new System.Drawing.Point(17, 49);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "Participant ID:";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(127, 15);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 4;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(132, 70);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(239, 20);
			this.textBox6.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label8.Location = new System.Drawing.Point(17, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Participant Type:";
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(164, 377);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 23);
			this.btSave.TabIndex = 1;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(245, 377);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(75, 23);
			this.btClose.TabIndex = 2;
			this.btClose.Text = "Close";
			this.btClose.UseVisualStyleBackColor = true;
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// btReload
			// 
			this.btReload.Location = new System.Drawing.Point(326, 377);
			this.btReload.Name = "btReload";
			this.btReload.Size = new System.Drawing.Size(75, 23);
			this.btReload.TabIndex = 3;
			this.btReload.Text = "Revert";
			this.btReload.UseVisualStyleBackColor = true;
			this.btReload.Click += new System.EventHandler(this.btReload_Click);
			// 
			// FormParticipant
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 407);
			this.Controls.Add(this.cbSync);
			this.Controls.Add(this.btReload);
			this.Controls.Add(this.btClose);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.tabControl);
			this.Name = "FormParticipant";
			this.Text = "Participant";
			this.Load += new System.EventHandler(this.FormParticipant_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormParticipant_FormClosed);
			this.tabControl.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.tpGeneral.PerformLayout();
			this.tpAddress.ResumeLayout(false);
			this.tpAddress.PerformLayout();
			this.tpMembers.ResumeLayout(false);
			this.tpGroups.ResumeLayout(false);
			this.tpGroups.PerformLayout();
			this.tpTools.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabPage tpAddress;
		private System.Windows.Forms.TabPage tpMembers;
		private System.Windows.Forms.TabPage tpGroups;
		private System.Windows.Forms.TextBox txName;
		private System.Windows.Forms.Label lbParticipantType;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.TextBox txForeignId;
		private System.Windows.Forms.Label lbForeignId;
		private System.Windows.Forms.TextBox txParticipantId;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbParticipantId;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.ComboBox cbSync;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Button btReload;
		private caClient.Controls.ParticipantFillList pflMembers;
		private caClient.Controls.ParticipantFillList pflGroups;
		private System.Windows.Forms.ListView lvAddressList;
		private System.Windows.Forms.ComboBox cbCategory;
		private System.Windows.Forms.Button btAddrAdd;
		private System.Windows.Forms.Label lbAddrCategory;
		private System.Windows.Forms.Button btAddrRemove;
		private System.Windows.Forms.TextBox txAddress;
		private System.Windows.Forms.Label lbAddress;
		private System.Windows.Forms.TabPage tpTools;
		private System.Windows.Forms.Button btToolReplace;
		private System.Windows.Forms.TextBox txPrimaryGroup;
		private System.Windows.Forms.Label lbPrimaryGroup;
		private System.Windows.Forms.Button btSetPrimaryGroup;
	}
}
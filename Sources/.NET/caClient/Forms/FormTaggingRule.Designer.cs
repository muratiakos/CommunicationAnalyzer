namespace caClient.Forms
{
	partial class FormTaggingRule
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
			this.lbStatus = new System.Windows.Forms.Label();
			this.btClose = new System.Windows.Forms.Button();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.btSave = new System.Windows.Forms.Button();
			this.lbTag = new System.Windows.Forms.Label();
			this.txRuleId = new System.Windows.Forms.TextBox();
			this.lbName = new System.Windows.Forms.Label();
			this.lbParticipantId = new System.Windows.Forms.Label();
			this.btReload = new System.Windows.Forms.Button();
			this.txName = new System.Windows.Forms.TextBox();
			this.chkCustomQuery = new System.Windows.Forms.CheckBox();
			this.txQuery = new System.Windows.Forms.TextBox();
			this.cbTag = new System.Windows.Forms.ComboBox();
			this.btRun = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbStatus
			// 
			this.lbStatus.AutoSize = true;
			this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbStatus.Location = new System.Drawing.Point(12, 68);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(47, 13);
			this.lbStatus.TabIndex = 23;
			this.lbStatus.Text = "Status:";
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(236, 337);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(47, 23);
			this.btClose.TabIndex = 15;
			this.btClose.Text = "Close";
			this.btClose.UseVisualStyleBackColor = true;
			this.btClose.Click += new System.EventHandler(this.btClose_Click);
			// 
			// cbStatus
			// 
			this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Location = new System.Drawing.Point(108, 65);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(121, 21);
			this.cbStatus.TabIndex = 22;
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(176, 337);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(53, 23);
			this.btSave.TabIndex = 13;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// lbTag
			// 
			this.lbTag.AutoSize = true;
			this.lbTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbTag.Location = new System.Drawing.Point(12, 125);
			this.lbTag.Name = "lbTag";
			this.lbTag.Size = new System.Drawing.Size(33, 13);
			this.lbTag.TabIndex = 20;
			this.lbTag.Text = "Tag:";
			// 
			// txRuleId
			// 
			this.txRuleId.Location = new System.Drawing.Point(108, 40);
			this.txRuleId.Name = "txRuleId";
			this.txRuleId.ReadOnly = true;
			this.txRuleId.Size = new System.Drawing.Size(239, 20);
			this.txRuleId.TabIndex = 19;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbName.Location = new System.Drawing.Point(12, 101);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(43, 13);
			this.lbName.TabIndex = 18;
			this.lbName.Text = "Name:";
			// 
			// lbParticipantId
			// 
			this.lbParticipantId.AutoSize = true;
			this.lbParticipantId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbParticipantId.Location = new System.Drawing.Point(12, 43);
			this.lbParticipantId.Name = "lbParticipantId";
			this.lbParticipantId.Size = new System.Drawing.Size(54, 13);
			this.lbParticipantId.TabIndex = 17;
			this.lbParticipantId.Text = "Rule ID:";
			// 
			// btReload
			// 
			this.btReload.Location = new System.Drawing.Point(289, 337);
			this.btReload.Name = "btReload";
			this.btReload.Size = new System.Drawing.Size(58, 23);
			this.btReload.TabIndex = 16;
			this.btReload.Text = "Revert";
			this.btReload.UseVisualStyleBackColor = true;
			this.btReload.Click += new System.EventHandler(this.btReload_Click);
			// 
			// txName
			// 
			this.txName.Location = new System.Drawing.Point(108, 98);
			this.txName.Name = "txName";
			this.txName.Size = new System.Drawing.Size(239, 20);
			this.txName.TabIndex = 14;
			// 
			// chkCustomQuery
			// 
			this.chkCustomQuery.AutoSize = true;
			this.chkCustomQuery.Checked = true;
			this.chkCustomQuery.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCustomQuery.Location = new System.Drawing.Point(13, 156);
			this.chkCustomQuery.Name = "chkCustomQuery";
			this.chkCustomQuery.Size = new System.Drawing.Size(92, 17);
			this.chkCustomQuery.TabIndex = 24;
			this.chkCustomQuery.Text = "Custom Query";
			this.chkCustomQuery.UseVisualStyleBackColor = true;
			this.chkCustomQuery.CheckedChanged += new System.EventHandler(this.chkCustomQuery_CheckedChanged);
			// 
			// txQuery
			// 
			this.txQuery.Location = new System.Drawing.Point(12, 179);
			this.txQuery.Multiline = true;
			this.txQuery.Name = "txQuery";
			this.txQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txQuery.Size = new System.Drawing.Size(335, 152);
			this.txQuery.TabIndex = 25;
			// 
			// cbTag
			// 
			this.cbTag.FormattingEnabled = true;
			this.cbTag.Location = new System.Drawing.Point(108, 122);
			this.cbTag.Name = "cbTag";
			this.cbTag.Size = new System.Drawing.Size(239, 21);
			this.cbTag.TabIndex = 26;
			// 
			// btRun
			// 
			this.btRun.Location = new System.Drawing.Point(121, 337);
			this.btRun.Name = "btRun";
			this.btRun.Size = new System.Drawing.Size(49, 23);
			this.btRun.TabIndex = 27;
			this.btRun.Text = "Run";
			this.btRun.UseVisualStyleBackColor = true;
			this.btRun.Click += new System.EventHandler(this.btRun_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(66, 337);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(49, 23);
			this.button1.TabIndex = 28;
			this.button1.Text = "Delete Tags";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormTaggingRule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 367);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btRun);
			this.Controls.Add(this.cbTag);
			this.Controls.Add(this.txQuery);
			this.Controls.Add(this.chkCustomQuery);
			this.Controls.Add(this.lbStatus);
			this.Controls.Add(this.btClose);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.lbTag);
			this.Controls.Add(this.txRuleId);
			this.Controls.Add(this.lbName);
			this.Controls.Add(this.lbParticipantId);
			this.Controls.Add(this.btReload);
			this.Controls.Add(this.txName);
			this.Name = "FormTaggingRule";
			this.Text = "Tagging Rule";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTaggingRule_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Label lbTag;
		private System.Windows.Forms.TextBox txRuleId;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbParticipantId;
		private System.Windows.Forms.Button btReload;
		private System.Windows.Forms.TextBox txName;
		private System.Windows.Forms.CheckBox chkCustomQuery;
		private System.Windows.Forms.TextBox txQuery;
		private System.Windows.Forms.ComboBox cbTag;
		private System.Windows.Forms.Button btRun;
		private System.Windows.Forms.Button button1;
	}
}
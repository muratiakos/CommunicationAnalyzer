namespace caClient.Controls
{
	partial class SearchBasicForm
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
			this.dtpAfter = new System.Windows.Forms.DateTimePicker();
			this.lbAfter = new System.Windows.Forms.Label();
			this.lbBefore = new System.Windows.Forms.Label();
			this.dtpBefore = new System.Windows.Forms.DateTimePicker();
			this.clTags = new System.Windows.Forms.CheckedListBox();
			this.lbLabels = new System.Windows.Forms.Label();
			this.lvFromList = new System.Windows.Forms.ListView();
			this.lvToList = new System.Windows.Forms.ListView();
			this.cbToIsTheSameAsFrom = new System.Windows.Forms.CheckBox();
			this.lbKeywords = new System.Windows.Forms.Label();
			this.btFromAdd = new System.Windows.Forms.Button();
			this.btToAdd = new System.Windows.Forms.Button();
			this.chkAmong = new System.Windows.Forms.CheckBox();
			this.chkExtendGrp = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// dtpAfter
			// 
			this.dtpAfter.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtpAfter.Location = new System.Drawing.Point(43, 3);
			this.dtpAfter.Name = "dtpAfter";
			this.dtpAfter.Size = new System.Drawing.Size(160, 20);
			this.dtpAfter.TabIndex = 0;
			// 
			// lbAfter
			// 
			this.lbAfter.AutoSize = true;
			this.lbAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbAfter.Location = new System.Drawing.Point(3, 3);
			this.lbAfter.Name = "lbAfter";
			this.lbAfter.Size = new System.Drawing.Size(38, 13);
			this.lbAfter.TabIndex = 1;
			this.lbAfter.Text = "After:";
			// 
			// lbBefore
			// 
			this.lbBefore.AutoSize = true;
			this.lbBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbBefore.Location = new System.Drawing.Point(209, 3);
			this.lbBefore.Name = "lbBefore";
			this.lbBefore.Size = new System.Drawing.Size(48, 13);
			this.lbBefore.TabIndex = 3;
			this.lbBefore.Text = "Before:";
			// 
			// dtpBefore
			// 
			this.dtpBefore.Location = new System.Drawing.Point(255, 3);
			this.dtpBefore.Name = "dtpBefore";
			this.dtpBefore.Size = new System.Drawing.Size(147, 20);
			this.dtpBefore.TabIndex = 2;
			// 
			// clTags
			// 
			this.clTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.clTags.FormattingEnabled = true;
			this.clTags.Location = new System.Drawing.Point(6, 232);
			this.clTags.MultiColumn = true;
			this.clTags.Name = "clTags";
			this.clTags.Size = new System.Drawing.Size(393, 107);
			this.clTags.TabIndex = 5;
			// 
			// lbLabels
			// 
			this.lbLabels.AutoSize = true;
			this.lbLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbLabels.Location = new System.Drawing.Point(8, 216);
			this.lbLabels.Name = "lbLabels";
			this.lbLabels.Size = new System.Drawing.Size(86, 13);
			this.lbLabels.TabIndex = 6;
			this.lbLabels.Text = "Subject Filter:";
			// 
			// lvFromList
			// 
			this.lvFromList.Location = new System.Drawing.Point(6, 58);
			this.lvFromList.Name = "lvFromList";
			this.lvFromList.Size = new System.Drawing.Size(197, 97);
			this.lvFromList.TabIndex = 9;
			this.lvFromList.UseCompatibleStateImageBehavior = false;
			this.lvFromList.View = System.Windows.Forms.View.List;
			this.lvFromList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFromList_KeyDown);
			// 
			// lvToList
			// 
			this.lvToList.Enabled = false;
			this.lvToList.Location = new System.Drawing.Point(209, 58);
			this.lvToList.Name = "lvToList";
			this.lvToList.Size = new System.Drawing.Size(193, 97);
			this.lvToList.TabIndex = 11;
			this.lvToList.UseCompatibleStateImageBehavior = false;
			this.lvToList.View = System.Windows.Forms.View.List;
			this.lvToList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvToList_KeyDown);
			// 
			// cbToIsTheSameAsFrom
			// 
			this.cbToIsTheSameAsFrom.AutoSize = true;
			this.cbToIsTheSameAsFrom.Checked = true;
			this.cbToIsTheSameAsFrom.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbToIsTheSameAsFrom.Location = new System.Drawing.Point(210, 162);
			this.cbToIsTheSameAsFrom.Name = "cbToIsTheSameAsFrom";
			this.cbToIsTheSameAsFrom.Size = new System.Drawing.Size(191, 17);
			this.cbToIsTheSameAsFrom.TabIndex = 12;
			this.cbToIsTheSameAsFrom.Text = "Recipients are the same as Sender";
			this.cbToIsTheSameAsFrom.UseVisualStyleBackColor = true;
			this.cbToIsTheSameAsFrom.CheckedChanged += new System.EventHandler(this.cbToIsSameAsFrom_CheckedChanged);
			// 
			// lbKeywords
			// 
			this.lbKeywords.AutoSize = true;
			this.lbKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbKeywords.Location = new System.Drawing.Point(3, 381);
			this.lbKeywords.Name = "lbKeywords";
			this.lbKeywords.Size = new System.Drawing.Size(65, 13);
			this.lbKeywords.TabIndex = 13;
			this.lbKeywords.Text = "Keywords:";
			this.lbKeywords.Visible = false;
			// 
			// btFromAdd
			// 
			this.btFromAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btFromAdd.Location = new System.Drawing.Point(6, 37);
			this.btFromAdd.Name = "btFromAdd";
			this.btFromAdd.Size = new System.Drawing.Size(45, 20);
			this.btFromAdd.TabIndex = 14;
			this.btFromAdd.Text = "From";
			this.btFromAdd.UseVisualStyleBackColor = true;
			this.btFromAdd.Click += new System.EventHandler(this.bt_from_Click);
			// 
			// btToAdd
			// 
			this.btToAdd.Enabled = false;
			this.btToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btToAdd.Location = new System.Drawing.Point(208, 37);
			this.btToAdd.Name = "btToAdd";
			this.btToAdd.Size = new System.Drawing.Size(48, 20);
			this.btToAdd.TabIndex = 16;
			this.btToAdd.Text = "To";
			this.btToAdd.UseVisualStyleBackColor = true;
			this.btToAdd.Click += new System.EventHandler(this.btToAdd_Click);
			// 
			// chkAmong
			// 
			this.chkAmong.AutoSize = true;
			this.chkAmong.Location = new System.Drawing.Point(6, 160);
			this.chkAmong.Name = "chkAmong";
			this.chkAmong.Size = new System.Drawing.Size(183, 17);
			this.chkAmong.TabIndex = 17;
			this.chkAmong.Text = "Only Among Selected Participans";
			this.chkAmong.UseVisualStyleBackColor = true;
			// 
			// chkExtendGrp
			// 
			this.chkExtendGrp.AutoSize = true;
			this.chkExtendGrp.Checked = true;
			this.chkExtendGrp.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkExtendGrp.Location = new System.Drawing.Point(6, 183);
			this.chkExtendGrp.Name = "chkExtendGrp";
			this.chkExtendGrp.Size = new System.Drawing.Size(151, 17);
			this.chkExtendGrp.TabIndex = 18;
			this.chkExtendGrp.Text = "Expand group membership";
			this.chkExtendGrp.UseVisualStyleBackColor = true;
			// 
			// SearchBasicForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkExtendGrp);
			this.Controls.Add(this.chkAmong);
			this.Controls.Add(this.btToAdd);
			this.Controls.Add(this.btFromAdd);
			this.Controls.Add(this.lbKeywords);
			this.Controls.Add(this.cbToIsTheSameAsFrom);
			this.Controls.Add(this.lvToList);
			this.Controls.Add(this.lvFromList);
			this.Controls.Add(this.lbLabels);
			this.Controls.Add(this.clTags);
			this.Controls.Add(this.lbBefore);
			this.Controls.Add(this.dtpBefore);
			this.Controls.Add(this.lbAfter);
			this.Controls.Add(this.dtpAfter);
			this.Name = "SearchBasicForm";
			this.Size = new System.Drawing.Size(409, 349);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtpAfter;
		private System.Windows.Forms.Label lbAfter;
		private System.Windows.Forms.Label lbBefore;
		private System.Windows.Forms.DateTimePicker dtpBefore;
		private System.Windows.Forms.CheckedListBox clTags;
		private System.Windows.Forms.Label lbLabels;
		private System.Windows.Forms.ListView lvFromList;
		private System.Windows.Forms.ListView lvToList;
		private System.Windows.Forms.CheckBox cbToIsTheSameAsFrom;
		private System.Windows.Forms.Label lbKeywords;
		private System.Windows.Forms.Button btFromAdd;
		private System.Windows.Forms.Button btToAdd;
		private System.Windows.Forms.CheckBox chkAmong;
		private System.Windows.Forms.CheckBox chkExtendGrp;
	}
}

namespace caClient.Controls
{
	partial class ParticipantFillList
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
			this.lbControlLabel = new System.Windows.Forms.Label();
			this.btAdd = new System.Windows.Forms.Button();
			this.lvParticipantList = new System.Windows.Forms.ListView();
			this.btRemove = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbControlLabel
			// 
			this.lbControlLabel.AutoSize = true;
			this.lbControlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbControlLabel.Location = new System.Drawing.Point(0, 5);
			this.lbControlLabel.Name = "lbControlLabel";
			this.lbControlLabel.Size = new System.Drawing.Size(31, 13);
			this.lbControlLabel.TabIndex = 18;
			this.lbControlLabel.Text = "List:";
			// 
			// btAdd
			// 
			this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btAdd.Location = new System.Drawing.Point(4, 199);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(58, 23);
			this.btAdd.TabIndex = 17;
			this.btAdd.Text = "Add...";
			this.btAdd.UseVisualStyleBackColor = true;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// lvParticipantList
			// 
			this.lvParticipantList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvParticipantList.Location = new System.Drawing.Point(3, 24);
			this.lvParticipantList.Name = "lvParticipantList";
			this.lvParticipantList.Size = new System.Drawing.Size(299, 165);
			this.lvParticipantList.TabIndex = 16;
			this.lvParticipantList.UseCompatibleStateImageBehavior = false;
			this.lvParticipantList.View = System.Windows.Forms.View.List;
			this.lvParticipantList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvParticipantList_KeyDown);
			// 
			// btRemove
			// 
			this.btRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btRemove.Location = new System.Drawing.Point(68, 199);
			this.btRemove.Name = "btRemove";
			this.btRemove.Size = new System.Drawing.Size(58, 23);
			this.btRemove.TabIndex = 19;
			this.btRemove.Text = "Remove";
			this.btRemove.UseVisualStyleBackColor = true;
			this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
			// 
			// ParticipantFillList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btRemove);
			this.Controls.Add(this.lbControlLabel);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.lvParticipantList);
			this.Name = "ParticipantFillList";
			this.Size = new System.Drawing.Size(305, 235);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbControlLabel;
		private System.Windows.Forms.Button btAdd;
		private System.Windows.Forms.ListView lvParticipantList;
		private System.Windows.Forms.Button btRemove;
	}
}

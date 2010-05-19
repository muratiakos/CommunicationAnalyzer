namespace caClient.Forms
{
	partial class FormParticipantRelpaceTool
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbFrom = new System.Windows.Forms.Label();
			this.lbArrow = new System.Windows.Forms.Label();
			this.lbTo = new System.Windows.Forms.Label();
			this.ptTo = new caClient.Controls.ParticipantTable();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Replace";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(568, 41);
			this.label2.TabIndex = 2;
			this.label2.Text = "Warning! This tool will delete the mentioned participant from the participant dat" +
				"abase and will replace all references (including addresses) to the selected Part" +
				"icipant below. ";
			// 
			// lbFrom
			// 
			this.lbFrom.AutoSize = true;
			this.lbFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbFrom.ForeColor = System.Drawing.Color.Red;
			this.lbFrom.Location = new System.Drawing.Point(24, 42);
			this.lbFrom.Name = "lbFrom";
			this.lbFrom.Size = new System.Drawing.Size(69, 18);
			this.lbFrom.TabIndex = 4;
			this.lbFrom.Text = "Replace";
			// 
			// lbArrow
			// 
			this.lbArrow.AutoSize = true;
			this.lbArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbArrow.Location = new System.Drawing.Point(256, 42);
			this.lbArrow.Name = "lbArrow";
			this.lbArrow.Size = new System.Drawing.Size(31, 18);
			this.lbArrow.TabIndex = 5;
			this.lbArrow.Text = "TO";
			// 
			// lbTo
			// 
			this.lbTo.AutoSize = true;
			this.lbTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbTo.ForeColor = System.Drawing.Color.ForestGreen;
			this.lbTo.Location = new System.Drawing.Point(305, 42);
			this.lbTo.Name = "lbTo";
			this.lbTo.Size = new System.Drawing.Size(106, 18);
			this.lbTo.TabIndex = 6;
			this.lbTo.Text = "Select Below";
			// 
			// ptTo
			// 
			this.ptTo.Location = new System.Drawing.Point(12, 158);
			this.ptTo.Name = "ptTo";
			this.ptTo.ParticipantDisplayMode = caCoreLibrary.caParticipantType.UserOrGroup;
			this.ptTo.Size = new System.Drawing.Size(607, 249);
			this.ptTo.TabIndex = 0;
			this.ptTo.SelectionChanged += new System.EventHandler(this.ptTo_SelectionChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(544, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Replace";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormParticipantRelpaceTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(631, 419);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbTo);
			this.Controls.Add(this.lbArrow);
			this.Controls.Add(this.lbFrom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ptTo);
			this.Name = "FormParticipantRelpaceTool";
			this.Text = "Participant Replace Tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private caClient.Controls.ParticipantTable ptTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbFrom;
		private System.Windows.Forms.Label lbArrow;
		private System.Windows.Forms.Label lbTo;
		private System.Windows.Forms.Button button1;


	}
}
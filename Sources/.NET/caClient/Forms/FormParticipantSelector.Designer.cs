namespace caClient.Forms
{
	partial class FormParticipantSelector
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("test0");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("test1");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("test2");
			this.lb_listlabel = new System.Windows.Forms.Label();
			this.lvSelected = new System.Windows.Forms.ListView();
			this.btCancel = new System.Windows.Forms.Button();
			this.btOk = new System.Windows.Forms.Button();
			this.participantList = new caClient.Controls.ParticipantTable();
			this.SuspendLayout();
			// 
			// lb_listlabel
			// 
			this.lb_listlabel.AutoSize = true;
			this.lb_listlabel.Location = new System.Drawing.Point(12, 367);
			this.lb_listlabel.Name = "lb_listlabel";
			this.lb_listlabel.Size = new System.Drawing.Size(35, 13);
			this.lb_listlabel.TabIndex = 1;
			this.lb_listlabel.Text = "label1";
			// 
			// lvSelected
			// 
			this.lvSelected.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
			this.lvSelected.Location = new System.Drawing.Point(12, 384);
			this.lvSelected.MultiSelect = false;
			this.lvSelected.Name = "lvSelected";
			this.lvSelected.ShowGroups = false;
			this.lvSelected.Size = new System.Drawing.Size(609, 55);
			this.lvSelected.TabIndex = 2;
			this.lvSelected.UseCompatibleStateImageBehavior = false;
			this.lvSelected.View = System.Windows.Forms.View.List;
			this.lvSelected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSelected_KeyDown);
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(546, 451);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 3;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btOk
			// 
			this.btOk.Location = new System.Drawing.Point(455, 451);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(75, 23);
			this.btOk.TabIndex = 4;
			this.btOk.Text = "OK";
			this.btOk.UseVisualStyleBackColor = true;
			this.btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// participantList
			// 
			this.participantList.Location = new System.Drawing.Point(12, 12);
			this.participantList.Name = "participantList";
			this.participantList.ParticipantDisplayMode = caCoreLibrary.caParticipantType.UserOrGroup;
			this.participantList.Size = new System.Drawing.Size(614, 348);
			this.participantList.TabIndex = 0;
			this.participantList.RowDoubleClick += new System.EventHandler(this.participantList_RowDoubleClick);
			// 
			// FormParticipantSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 486);
			this.Controls.Add(this.btOk);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.lvSelected);
			this.Controls.Add(this.lb_listlabel);
			this.Controls.Add(this.participantList);
			this.Name = "FormParticipantSelector";
			this.Text = "Participant Selector tool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private caClient.Controls.ParticipantTable participantList;
		private System.Windows.Forms.Label lb_listlabel;
		private System.Windows.Forms.ListView lvSelected;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOk;
	}
}
namespace caClient.Controls
{
	partial class ParticipantTable
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgParticipant = new System.Windows.Forms.DataGridView();
			this.lbSearch = new System.Windows.Forms.Label();
			this.txSearch = new System.Windows.Forms.TextBox();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.lbType = new System.Windows.Forms.Label();
			this.lbStatus = new System.Windows.Forms.Label();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgParticipant)).BeginInit();
			this.SuspendLayout();
			// 
			// dgParticipant
			// 
			this.dgParticipant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgParticipant.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgParticipant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgParticipant.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgParticipant.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgParticipant.Location = new System.Drawing.Point(0, 47);
			this.dgParticipant.Name = "dgParticipant";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgParticipant.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgParticipant.RowHeadersVisible = false;
			this.dgParticipant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgParticipant.Size = new System.Drawing.Size(515, 350);
			this.dgParticipant.TabIndex = 0;
			this.dgParticipant.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgParticipant_MouseClick);
			this.dgParticipant.DoubleClick += new System.EventHandler(this.dg_participant_DoubleClick);
			this.dgParticipant.SelectionChanged += new System.EventHandler(this.dgParticipant_SelectionChanged);
			// 
			// lbSearch
			// 
			this.lbSearch.AutoSize = true;
			this.lbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbSearch.Location = new System.Drawing.Point(4, 4);
			this.lbSearch.Name = "lbSearch";
			this.lbSearch.Size = new System.Drawing.Size(51, 13);
			this.lbSearch.TabIndex = 1;
			this.lbSearch.Text = "Search:";
			// 
			// txSearch
			// 
			this.txSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txSearch.Location = new System.Drawing.Point(4, 21);
			this.txSearch.Name = "txSearch";
			this.txSearch.Size = new System.Drawing.Size(289, 20);
			this.txSearch.TabIndex = 2;
			this.txSearch.TextChanged += new System.EventHandler(this.tx_search_TextChanged);
			// 
			// cbType
			// 
			this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(299, 20);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(113, 21);
			this.cbType.TabIndex = 3;
			this.cbType.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
			// 
			// lbType
			// 
			this.lbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbType.AutoSize = true;
			this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbType.Location = new System.Drawing.Point(298, 3);
			this.lbType.Name = "lbType";
			this.lbType.Size = new System.Drawing.Size(39, 13);
			this.lbType.TabIndex = 4;
			this.lbType.Text = "Type:";
			// 
			// lbStatus
			// 
			this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbStatus.AutoSize = true;
			this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbStatus.Location = new System.Drawing.Point(417, 3);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(47, 13);
			this.lbStatus.TabIndex = 6;
			this.lbStatus.Text = "Status:";
			// 
			// cbStatus
			// 
			this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Location = new System.Drawing.Point(418, 20);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(95, 21);
			this.cbStatus.TabIndex = 5;
			this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
			// 
			// ParticipantTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbStatus);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.lbType);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.txSearch);
			this.Controls.Add(this.lbSearch);
			this.Controls.Add(this.dgParticipant);
			this.Name = "ParticipantTable";
			this.Size = new System.Drawing.Size(518, 397);
			((System.ComponentModel.ISupportInitialize)(this.dgParticipant)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgParticipant;
		private System.Windows.Forms.Label lbSearch;
		private System.Windows.Forms.TextBox txSearch;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Label lbType;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.ComboBox cbStatus;
	}
}

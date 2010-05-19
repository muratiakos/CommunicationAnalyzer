namespace caClient.Forms
{
	partial class FormTagParticipantRelationAnalysis
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpSearch = new System.Windows.Forms.TabPage();
			this.numWeight = new System.Windows.Forms.NumericUpDown();
			this.lbCommWeight = new System.Windows.Forms.Label();
			this.btSearch = new System.Windows.Forms.Button();
			this.searchForm = new caClient.Controls.SearchBasicForm();
			this.tpQueryResults = new System.Windows.Forms.TabPage();
			this.btQuery = new System.Windows.Forms.Button();
			this.txQuery = new System.Windows.Forms.TextBox();
			this.dgResults = new System.Windows.Forms.DataGridView();
			this.tpRefine = new System.Windows.Forms.TabPage();
			this.ptCache = new caClient.Controls.ParticipantTable();
			this.btCreateCommModel = new System.Windows.Forms.Button();
			this.tpVisualization = new System.Windows.Forms.TabPage();
			this.caTagParticipant1 = new caGraphLibrary.caTagParticipant();
			this.btUsersOnly = new System.Windows.Forms.Button();
			this.btGroupsOnly = new System.Windows.Forms.Button();
			this.chkDirection = new System.Windows.Forms.CheckBox();
			this.btRedraw = new System.Windows.Forms.Button();
			this.caHeaderControl1 = new caClient.Controls.HeaderControl();
			this.tabControl.SuspendLayout();
			this.tpSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
			this.tpQueryResults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
			this.tpRefine.SuspendLayout();
			this.tpVisualization.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tpSearch);
			this.tabControl.Controls.Add(this.tpQueryResults);
			this.tabControl.Controls.Add(this.tpRefine);
			this.tabControl.Controls.Add(this.tpVisualization);
			this.tabControl.Location = new System.Drawing.Point(12, 67);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(567, 495);
			this.tabControl.TabIndex = 5;
			// 
			// tpSearch
			// 
			this.tpSearch.Controls.Add(this.numWeight);
			this.tpSearch.Controls.Add(this.lbCommWeight);
			this.tpSearch.Controls.Add(this.btSearch);
			this.tpSearch.Controls.Add(this.searchForm);
			this.tpSearch.Location = new System.Drawing.Point(4, 22);
			this.tpSearch.Name = "tpSearch";
			this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
			this.tpSearch.Size = new System.Drawing.Size(559, 469);
			this.tpSearch.TabIndex = 4;
			this.tpSearch.Text = "Search Options";
			this.tpSearch.UseVisualStyleBackColor = true;
			// 
			// numWeight
			// 
			this.numWeight.Location = new System.Drawing.Point(363, 17);
			this.numWeight.Name = "numWeight";
			this.numWeight.Size = new System.Drawing.Size(64, 20);
			this.numWeight.TabIndex = 3;
			this.numWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lbCommWeight
			// 
			this.lbCommWeight.AutoSize = true;
			this.lbCommWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbCommWeight.Location = new System.Drawing.Point(254, 19);
			this.lbCommWeight.Name = "lbCommWeight";
			this.lbCommWeight.Size = new System.Drawing.Size(103, 13);
			this.lbCommWeight.TabIndex = 2;
			this.lbCommWeight.Text = "Minimum Weight:";
			// 
			// btSearch
			// 
			this.btSearch.Location = new System.Drawing.Point(18, 14);
			this.btSearch.Name = "btSearch";
			this.btSearch.Size = new System.Drawing.Size(75, 23);
			this.btSearch.TabIndex = 1;
			this.btSearch.Text = "Search";
			this.btSearch.UseVisualStyleBackColor = true;
			this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
			// 
			// searchForm
			// 
			this.searchForm.After = new System.DateTime(2010, 3, 4, 1, 59, 40, 514);
			this.searchForm.Before = new System.DateTime(2010, 3, 4, 1, 59, 40, 508);
			this.searchForm.Location = new System.Drawing.Point(18, 43);
			this.searchForm.Name = "searchForm";
			this.searchForm.Size = new System.Drawing.Size(409, 383);
			this.searchForm.TabIndex = 0;
			// 
			// tpQueryResults
			// 
			this.tpQueryResults.Controls.Add(this.btQuery);
			this.tpQueryResults.Controls.Add(this.txQuery);
			this.tpQueryResults.Controls.Add(this.dgResults);
			this.tpQueryResults.Location = new System.Drawing.Point(4, 22);
			this.tpQueryResults.Name = "tpQueryResults";
			this.tpQueryResults.Padding = new System.Windows.Forms.Padding(3);
			this.tpQueryResults.Size = new System.Drawing.Size(559, 469);
			this.tpQueryResults.TabIndex = 1;
			this.tpQueryResults.Text = "Query and Results";
			this.tpQueryResults.UseVisualStyleBackColor = true;
			// 
			// btQuery
			// 
			this.btQuery.Location = new System.Drawing.Point(7, 6);
			this.btQuery.Name = "btQuery";
			this.btQuery.Size = new System.Drawing.Size(111, 23);
			this.btQuery.TabIndex = 6;
			this.btQuery.Text = "Execute This Query";
			this.btQuery.UseVisualStyleBackColor = true;
			this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
			// 
			// txQuery
			// 
			this.txQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txQuery.Location = new System.Drawing.Point(7, 35);
			this.txQuery.Multiline = true;
			this.txQuery.Name = "txQuery";
			this.txQuery.Size = new System.Drawing.Size(610, 95);
			this.txQuery.TabIndex = 5;
			// 
			// dgResults
			// 
			this.dgResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgResults.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgResults.Location = new System.Drawing.Point(6, 136);
			this.dgResults.Name = "dgResults";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgResults.Size = new System.Drawing.Size(611, 308);
			this.dgResults.TabIndex = 4;
			// 
			// tpRefine
			// 
			this.tpRefine.Controls.Add(this.ptCache);
			this.tpRefine.Controls.Add(this.btCreateCommModel);
			this.tpRefine.Location = new System.Drawing.Point(4, 22);
			this.tpRefine.Name = "tpRefine";
			this.tpRefine.Padding = new System.Windows.Forms.Padding(3);
			this.tpRefine.Size = new System.Drawing.Size(559, 469);
			this.tpRefine.TabIndex = 2;
			this.tpRefine.Text = "Participant  Cache";
			this.tpRefine.UseVisualStyleBackColor = true;
			// 
			// ptCache
			// 
			this.ptCache.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ptCache.Location = new System.Drawing.Point(6, 35);
			this.ptCache.Name = "ptCache";
			this.ptCache.ParticipantDisplayMode = caCoreLibrary.caParticipantType.UserOrGroup;
			this.ptCache.Size = new System.Drawing.Size(611, 409);
			this.ptCache.TabIndex = 1;
			// 
			// btCreateCommModel
			// 
			this.btCreateCommModel.Location = new System.Drawing.Point(6, 6);
			this.btCreateCommModel.Name = "btCreateCommModel";
			this.btCreateCommModel.Size = new System.Drawing.Size(160, 23);
			this.btCreateCommModel.TabIndex = 0;
			this.btCreateCommModel.Text = "Rebuild Model by Cache";
			this.btCreateCommModel.UseVisualStyleBackColor = true;
			this.btCreateCommModel.Click += new System.EventHandler(this.btCreateCommModel_Click);
			// 
			// tpVisualization
			// 
			this.tpVisualization.Controls.Add(this.caTagParticipant1);
			this.tpVisualization.Controls.Add(this.btUsersOnly);
			this.tpVisualization.Controls.Add(this.btGroupsOnly);
			this.tpVisualization.Controls.Add(this.chkDirection);
			this.tpVisualization.Controls.Add(this.btRedraw);
			this.tpVisualization.Location = new System.Drawing.Point(4, 22);
			this.tpVisualization.Name = "tpVisualization";
			this.tpVisualization.Padding = new System.Windows.Forms.Padding(3);
			this.tpVisualization.Size = new System.Drawing.Size(559, 469);
			this.tpVisualization.TabIndex = 3;
			this.tpVisualization.Text = "Visualization";
			this.tpVisualization.UseVisualStyleBackColor = true;
			// 
			// caTagParticipant1
			// 
			this.caTagParticipant1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.caTagParticipant1.Location = new System.Drawing.Point(7, 36);
			this.caTagParticipant1.Name = "caTagParticipant1";
			this.caTagParticipant1.ShowDirection = true;
			this.caTagParticipant1.Size = new System.Drawing.Size(546, 427);
			this.caTagParticipant1.TabIndex = 8;
			// 
			// btUsersOnly
			// 
			this.btUsersOnly.Location = new System.Drawing.Point(258, 6);
			this.btUsersOnly.Name = "btUsersOnly";
			this.btUsersOnly.Size = new System.Drawing.Size(137, 23);
			this.btUsersOnly.TabIndex = 7;
			this.btUsersOnly.Text = "Show Users Only";
			this.btUsersOnly.UseVisualStyleBackColor = true;
			this.btUsersOnly.Click += new System.EventHandler(this.btUsersOnly_Click);
			// 
			// btGroupsOnly
			// 
			this.btGroupsOnly.Location = new System.Drawing.Point(133, 6);
			this.btGroupsOnly.Name = "btGroupsOnly";
			this.btGroupsOnly.Size = new System.Drawing.Size(119, 23);
			this.btGroupsOnly.TabIndex = 6;
			this.btGroupsOnly.Text = "Show Groups Only";
			this.btGroupsOnly.UseVisualStyleBackColor = true;
			this.btGroupsOnly.Click += new System.EventHandler(this.btGroupsOnly_Click);
			// 
			// chkDirection
			// 
			this.chkDirection.AutoSize = true;
			this.chkDirection.Checked = true;
			this.chkDirection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDirection.Location = new System.Drawing.Point(404, 12);
			this.chkDirection.Name = "chkDirection";
			this.chkDirection.Size = new System.Drawing.Size(98, 17);
			this.chkDirection.TabIndex = 5;
			this.chkDirection.Text = "Show Direction";
			this.chkDirection.UseVisualStyleBackColor = true;
			this.chkDirection.CheckedChanged += new System.EventHandler(this.chkDirection_CheckedChanged);
			// 
			// btRedraw
			// 
			this.btRedraw.Location = new System.Drawing.Point(6, 6);
			this.btRedraw.Name = "btRedraw";
			this.btRedraw.Size = new System.Drawing.Size(121, 23);
			this.btRedraw.TabIndex = 1;
			this.btRedraw.Text = "Redraw";
			this.btRedraw.UseVisualStyleBackColor = true;
			this.btRedraw.Click += new System.EventHandler(this.btRedraw_Click);
			// 
			// caHeaderControl1
			// 
			this.caHeaderControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.caHeaderControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
			this.caHeaderControl1.HeaderText = "Subject-Participant Relation Analysis";
			this.caHeaderControl1.Location = new System.Drawing.Point(0, 0);
			this.caHeaderControl1.Name = "caHeaderControl1";
			this.caHeaderControl1.Size = new System.Drawing.Size(593, 61);
			this.caHeaderControl1.TabIndex = 6;
			// 
			// FormTagParticipantRelationAnalysis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 576);
			this.Controls.Add(this.caHeaderControl1);
			this.Controls.Add(this.tabControl);
			this.Name = "FormTagParticipantRelationAnalysis";
			this.Text = "Basic Subject-Participant Relation Analysis";
			this.tabControl.ResumeLayout(false);
			this.tpSearch.ResumeLayout(false);
			this.tpSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
			this.tpQueryResults.ResumeLayout(false);
			this.tpQueryResults.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
			this.tpRefine.ResumeLayout(false);
			this.tpVisualization.ResumeLayout(false);
			this.tpVisualization.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpSearch;
		private System.Windows.Forms.NumericUpDown numWeight;
		private System.Windows.Forms.Label lbCommWeight;
		private System.Windows.Forms.Button btSearch;
		private caClient.Controls.SearchBasicForm searchForm;
		private System.Windows.Forms.TabPage tpQueryResults;
		private System.Windows.Forms.Button btQuery;
		private System.Windows.Forms.TextBox txQuery;
		private System.Windows.Forms.DataGridView dgResults;
		private System.Windows.Forms.TabPage tpRefine;
		private caClient.Controls.ParticipantTable ptCache;
		private System.Windows.Forms.Button btCreateCommModel;
		private System.Windows.Forms.TabPage tpVisualization;
		private System.Windows.Forms.Button btUsersOnly;
		private System.Windows.Forms.Button btGroupsOnly;
		private System.Windows.Forms.CheckBox chkDirection;
		private System.Windows.Forms.Button btRedraw;
		private caGraphLibrary.caTagParticipant caTagParticipant1;
		private caClient.Controls.HeaderControl caHeaderControl1;

	}
}
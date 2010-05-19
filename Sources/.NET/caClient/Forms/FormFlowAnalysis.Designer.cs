namespace caClient.Forms
{
	partial class FormFlowAnalysis
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tpSearch = new System.Windows.Forms.TabPage();
			this.numWeight = new System.Windows.Forms.NumericUpDown();
			this.lbCommWeight = new System.Windows.Forms.Label();
			this.btSearch = new System.Windows.Forms.Button();
			this.searchForm = new caClient.Controls.SearchBasicForm();
			this.tpQueryResults = new System.Windows.Forms.TabPage();
			this.lbBaseCount = new System.Windows.Forms.Label();
			this.btQuery = new System.Windows.Forms.Button();
			this.txBaseQuery = new System.Windows.Forms.TextBox();
			this.dgBaseResults = new System.Windows.Forms.DataGridView();
			this.tpFlowQuery = new System.Windows.Forms.TabPage();
			this.lbFlowCount = new System.Windows.Forms.Label();
			this.btExecuteFlowQuery = new System.Windows.Forms.Button();
			this.lbLevel = new System.Windows.Forms.Label();
			this.btWidenFlow = new System.Windows.Forms.Button();
			this.txFlowQuery = new System.Windows.Forms.TextBox();
			this.dgFlowResults = new System.Windows.Forms.DataGridView();
			this.tpVisualization = new System.Windows.Forms.TabPage();
			this.caCommFlow1 = new caGraphLibrary.caCommFlow();
			this.btRedraw = new System.Windows.Forms.Button();
			this.caHeaderControl1 = new caClient.Controls.HeaderControl();
			this.tabControl.SuspendLayout();
			this.tpSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
			this.tpQueryResults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgBaseResults)).BeginInit();
			this.tpFlowQuery.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgFlowResults)).BeginInit();
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
			this.tabControl.Controls.Add(this.tpFlowQuery);
			this.tabControl.Controls.Add(this.tpVisualization);
			this.tabControl.Location = new System.Drawing.Point(12, 67);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(578, 573);
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
			this.tpSearch.Size = new System.Drawing.Size(570, 547);
			this.tpSearch.TabIndex = 4;
			this.tpSearch.Text = "Search Options";
			this.tpSearch.UseVisualStyleBackColor = true;
			// 
			// numWeight
			// 
			this.numWeight.Location = new System.Drawing.Point(351, 18);
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
			this.lbCommWeight.Location = new System.Drawing.Point(216, 20);
			this.lbCommWeight.Name = "lbCommWeight";
			this.lbCommWeight.Size = new System.Drawing.Size(129, 13);
			this.lbCommWeight.TabIndex = 2;
			this.lbCommWeight.Text = "Times to Widen Flow:";
			// 
			// btSearch
			// 
			this.btSearch.Location = new System.Drawing.Point(6, 6);
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
			this.searchForm.Location = new System.Drawing.Point(6, 44);
			this.searchForm.Name = "searchForm";
			this.searchForm.Size = new System.Drawing.Size(409, 455);
			this.searchForm.TabIndex = 0;
			// 
			// tpQueryResults
			// 
			this.tpQueryResults.Controls.Add(this.lbBaseCount);
			this.tpQueryResults.Controls.Add(this.btQuery);
			this.tpQueryResults.Controls.Add(this.txBaseQuery);
			this.tpQueryResults.Controls.Add(this.dgBaseResults);
			this.tpQueryResults.Location = new System.Drawing.Point(4, 22);
			this.tpQueryResults.Name = "tpQueryResults";
			this.tpQueryResults.Padding = new System.Windows.Forms.Padding(3);
			this.tpQueryResults.Size = new System.Drawing.Size(619, 505);
			this.tpQueryResults.TabIndex = 1;
			this.tpQueryResults.Text = "Base Query and Results";
			this.tpQueryResults.UseVisualStyleBackColor = true;
			// 
			// lbBaseCount
			// 
			this.lbBaseCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbBaseCount.AutoSize = true;
			this.lbBaseCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbBaseCount.Location = new System.Drawing.Point(565, 9);
			this.lbBaseCount.Name = "lbBaseCount";
			this.lbBaseCount.Size = new System.Drawing.Size(48, 15);
			this.lbBaseCount.TabIndex = 13;
			this.lbBaseCount.Text = "BaseC";
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
			// txBaseQuery
			// 
			this.txBaseQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txBaseQuery.Location = new System.Drawing.Point(7, 35);
			this.txBaseQuery.Multiline = true;
			this.txBaseQuery.Name = "txBaseQuery";
			this.txBaseQuery.Size = new System.Drawing.Size(606, 95);
			this.txBaseQuery.TabIndex = 5;
			// 
			// dgBaseResults
			// 
			this.dgBaseResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgBaseResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgBaseResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgBaseResults.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgBaseResults.Location = new System.Drawing.Point(6, 136);
			this.dgBaseResults.Name = "dgBaseResults";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgBaseResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgBaseResults.Size = new System.Drawing.Size(607, 363);
			this.dgBaseResults.TabIndex = 4;
			// 
			// tpFlowQuery
			// 
			this.tpFlowQuery.Controls.Add(this.lbFlowCount);
			this.tpFlowQuery.Controls.Add(this.btExecuteFlowQuery);
			this.tpFlowQuery.Controls.Add(this.lbLevel);
			this.tpFlowQuery.Controls.Add(this.btWidenFlow);
			this.tpFlowQuery.Controls.Add(this.txFlowQuery);
			this.tpFlowQuery.Controls.Add(this.dgFlowResults);
			this.tpFlowQuery.Location = new System.Drawing.Point(4, 22);
			this.tpFlowQuery.Name = "tpFlowQuery";
			this.tpFlowQuery.Size = new System.Drawing.Size(619, 505);
			this.tpFlowQuery.TabIndex = 5;
			this.tpFlowQuery.Text = "Flow Widen Query";
			this.tpFlowQuery.UseVisualStyleBackColor = true;
			// 
			// lbFlowCount
			// 
			this.lbFlowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbFlowCount.AutoSize = true;
			this.lbFlowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbFlowCount.Location = new System.Drawing.Point(567, 9);
			this.lbFlowCount.Name = "lbFlowCount";
			this.lbFlowCount.Size = new System.Drawing.Size(46, 15);
			this.lbFlowCount.TabIndex = 12;
			this.lbFlowCount.Text = "FlowC";
			// 
			// btExecuteFlowQuery
			// 
			this.btExecuteFlowQuery.Location = new System.Drawing.Point(6, 6);
			this.btExecuteFlowQuery.Name = "btExecuteFlowQuery";
			this.btExecuteFlowQuery.Size = new System.Drawing.Size(111, 23);
			this.btExecuteFlowQuery.TabIndex = 11;
			this.btExecuteFlowQuery.Text = "Execute This Query";
			this.btExecuteFlowQuery.UseVisualStyleBackColor = true;
			this.btExecuteFlowQuery.Click += new System.EventHandler(this.btExecuteFlowQuery_Click);
			// 
			// lbLevel
			// 
			this.lbLevel.AutoSize = true;
			this.lbLevel.Location = new System.Drawing.Point(293, 11);
			this.lbLevel.Name = "lbLevel";
			this.lbLevel.Size = new System.Drawing.Size(45, 13);
			this.lbLevel.TabIndex = 10;
			this.lbLevel.Text = "Level: 1";
			// 
			// btWidenFlow
			// 
			this.btWidenFlow.Location = new System.Drawing.Point(120, 6);
			this.btWidenFlow.Name = "btWidenFlow";
			this.btWidenFlow.Size = new System.Drawing.Size(167, 23);
			this.btWidenFlow.TabIndex = 9;
			this.btWidenFlow.Text = "Widen Flow to Next Level";
			this.btWidenFlow.UseVisualStyleBackColor = true;
			this.btWidenFlow.Click += new System.EventHandler(this.btWidenFlow_Click);
			// 
			// txFlowQuery
			// 
			this.txFlowQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txFlowQuery.Location = new System.Drawing.Point(7, 35);
			this.txFlowQuery.Multiline = true;
			this.txFlowQuery.Name = "txFlowQuery";
			this.txFlowQuery.Size = new System.Drawing.Size(606, 95);
			this.txFlowQuery.TabIndex = 8;
			// 
			// dgFlowResults
			// 
			this.dgFlowResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgFlowResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgFlowResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgFlowResults.DefaultCellStyle = dataGridViewCellStyle5;
			this.dgFlowResults.Location = new System.Drawing.Point(6, 136);
			this.dgFlowResults.Name = "dgFlowResults";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgFlowResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dgFlowResults.Size = new System.Drawing.Size(607, 363);
			this.dgFlowResults.TabIndex = 7;
			// 
			// tpVisualization
			// 
			this.tpVisualization.Controls.Add(this.caCommFlow1);
			this.tpVisualization.Controls.Add(this.btRedraw);
			this.tpVisualization.Location = new System.Drawing.Point(4, 22);
			this.tpVisualization.Name = "tpVisualization";
			this.tpVisualization.Padding = new System.Windows.Forms.Padding(3);
			this.tpVisualization.Size = new System.Drawing.Size(619, 505);
			this.tpVisualization.TabIndex = 3;
			this.tpVisualization.Text = "Visualization";
			this.tpVisualization.UseVisualStyleBackColor = true;
			// 
			// caCommFlow1
			// 
			this.caCommFlow1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.caCommFlow1.AutoScroll = true;
			this.caCommFlow1.AutoScrollMargin = new System.Drawing.Size(5, 5);
			this.caCommFlow1.AutoScrollMinSize = new System.Drawing.Size(10, 10);
			this.caCommFlow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.caCommFlow1.Location = new System.Drawing.Point(6, 35);
			this.caCommFlow1.Name = "caCommFlow1";
			this.caCommFlow1.NodeMode = caGraphLibrary.caCommFlow.caCommFlowNodeType.CommItemNode;
			this.caCommFlow1.Size = new System.Drawing.Size(607, 464);
			this.caCommFlow1.TabIndex = 2;
			this.caCommFlow1.TimeMode = caGraphLibrary.caCommFlow.caCommFlowTimeMode.DateList;
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
			this.caHeaderControl1.HeaderText = "Flow Analysis";
			this.caHeaderControl1.Location = new System.Drawing.Point(0, 0);
			this.caHeaderControl1.Name = "caHeaderControl1";
			this.caHeaderControl1.Size = new System.Drawing.Size(604, 61);
			this.caHeaderControl1.TabIndex = 6;
			// 
			// FormFlowAnalysis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 645);
			this.Controls.Add(this.caHeaderControl1);
			this.Controls.Add(this.tabControl);
			this.Name = "FormFlowAnalysis";
			this.Text = "Basic Flow Analysis";
			this.tabControl.ResumeLayout(false);
			this.tpSearch.ResumeLayout(false);
			this.tpSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
			this.tpQueryResults.ResumeLayout(false);
			this.tpQueryResults.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgBaseResults)).EndInit();
			this.tpFlowQuery.ResumeLayout(false);
			this.tpFlowQuery.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgFlowResults)).EndInit();
			this.tpVisualization.ResumeLayout(false);
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
		private System.Windows.Forms.TextBox txBaseQuery;
		private System.Windows.Forms.DataGridView dgBaseResults;
		private System.Windows.Forms.TabPage tpVisualization;
		private System.Windows.Forms.Button btRedraw;
		private caGraphLibrary.caCommFlow caCommFlow1;
		private System.Windows.Forms.TabPage tpFlowQuery;
		private System.Windows.Forms.Button btWidenFlow;
		private System.Windows.Forms.TextBox txFlowQuery;
		private System.Windows.Forms.DataGridView dgFlowResults;
		private System.Windows.Forms.Label lbLevel;
		private System.Windows.Forms.Button btExecuteFlowQuery;
		private System.Windows.Forms.Label lbBaseCount;
		private System.Windows.Forms.Label lbFlowCount;
		private caClient.Controls.HeaderControl caHeaderControl1;
	}
}
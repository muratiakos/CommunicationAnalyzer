namespace caClient.Forms
{
	partial class FormTest
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
			this.searchForm1 = new caClient.Controls.SearchBasicForm();
			this.SuspendLayout();
			// 
			// searchForm1
			// 
			this.searchForm1.After = new System.DateTime(2010, 3, 18, 6, 43, 7, 852);
			this.searchForm1.Before = new System.DateTime(2010, 3, 18, 6, 43, 7, 852);
			this.searchForm1.Location = new System.Drawing.Point(12, 12);
			this.searchForm1.Name = "searchForm1";
			this.searchForm1.Size = new System.Drawing.Size(409, 429);
			this.searchForm1.TabIndex = 0;
			// 
			// FormTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 620);
			this.Controls.Add(this.searchForm1);
			this.Name = "FormTest";
			this.Text = "FormTest";
			this.ResumeLayout(false);

		}

		#endregion

		private caClient.Controls.SearchBasicForm searchForm1;
	}
}
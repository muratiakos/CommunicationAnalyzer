namespace caClient.Forms
{
	partial class FormConnect
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
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.backgroundConnect = new System.ComponentModel.BackgroundWorker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btDisconnect = new System.Windows.Forms.Button();
			this.btConnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbServerUrl = new System.Windows.Forms.ComboBox();
			this.caHeaderControl1 = new caClient.Controls.HeaderControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(0, 58);
			this.progressBar.MarqueeAnimationSpeed = 0;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(595, 10);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar.TabIndex = 3;
			// 
			// backgroundConnect
			// 
			this.backgroundConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundConnect_DoWork);
			this.backgroundConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundConnect_RunWorkerCompleted);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btDisconnect);
			this.groupBox1.Controls.Add(this.btConnect);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cbServerUrl);
			this.groupBox1.Location = new System.Drawing.Point(107, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(387, 135);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connect to ";
			// 
			// btDisconnect
			// 
			this.btDisconnect.Enabled = false;
			this.btDisconnect.Location = new System.Drawing.Point(134, 83);
			this.btDisconnect.Name = "btDisconnect";
			this.btDisconnect.Size = new System.Drawing.Size(95, 23);
			this.btDisconnect.TabIndex = 8;
			this.btDisconnect.Text = "Disconnect";
			this.btDisconnect.UseVisualStyleBackColor = true;
			this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
			// 
			// btConnect
			// 
			this.btConnect.Location = new System.Drawing.Point(16, 83);
			this.btConnect.Name = "btConnect";
			this.btConnect.Size = new System.Drawing.Size(90, 23);
			this.btConnect.TabIndex = 5;
			this.btConnect.Text = "Connect";
			this.btConnect.UseVisualStyleBackColor = true;
			this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(14, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Server";
			// 
			// cbServerUrl
			// 
			this.cbServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbServerUrl.FormattingEnabled = true;
			this.cbServerUrl.Location = new System.Drawing.Point(14, 46);
			this.cbServerUrl.Name = "cbServerUrl";
			this.cbServerUrl.Size = new System.Drawing.Size(355, 21);
			this.cbServerUrl.TabIndex = 7;
			this.cbServerUrl.Text = "http://localhost:8511/caService";
			// 
			// caHeaderControl1
			// 
			this.caHeaderControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.caHeaderControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
			this.caHeaderControl1.HeaderText = "Connection";
			this.caHeaderControl1.Location = new System.Drawing.Point(0, 0);
			this.caHeaderControl1.Name = "caHeaderControl1";
			this.caHeaderControl1.Size = new System.Drawing.Size(593, 57);
			this.caHeaderControl1.TabIndex = 5;
			// 
			// FormConnect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 314);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.caHeaderControl1);
			this.Controls.Add(this.progressBar);
			this.Name = "FormConnect";
			this.Text = "Connection";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar;
		private System.ComponentModel.BackgroundWorker backgroundConnect;
		private caClient.Controls.HeaderControl caHeaderControl1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btDisconnect;
		private System.Windows.Forms.Button btConnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbServerUrl;
	}
}
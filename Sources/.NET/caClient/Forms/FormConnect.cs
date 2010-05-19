using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using caClient.caServiceReference;
using caCoreLibrary;

namespace caClient.Forms
{
	public partial class FormConnect : Form
	{
		FormMain p;
		bool success = false;
		ServiceClient conn = null;

		public FormConnect(FormMain _p, ServiceClient _conn)
		{
			InitializeComponent();
			p = _p;
			conn = _conn;
			OnlineControl();
		}

		private void btConnect_Click(object sender, EventArgs e)
		{
			progressBar.MarqueeAnimationSpeed = 200;
			btConnect.Enabled = false;
			backgroundConnect.RunWorkerAsync();
		}

		private void backgroundConnect_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				conn = new ServiceClient(); //csalás itt még - nincs más url cbServerUrl.Text);
				conn.Open();
				caMessageService.Add(conn.Connect());
				success = true;
			}
			catch (Exception ex)
			{
				caMessageService.Add(new caMessage() { text = ex.Message, type = caMessageType.Error });
			}
		}

		private void backgroundConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressBar.MarqueeAnimationSpeed = 0;
			progressBar.Value = 0;

			if (success)
			{
				p.OnlineControl(conn);
				this.Close();
				this.Dispose();
			}
			else
			{
				if (!(conn.State == System.ServiceModel.CommunicationState.Opened))
				{
					caMessageService.Add(new caMessage() { text = "Connection failed" });
				}
			}

			OnlineControl();
		}

		private void OnlineControl()
		{
			bool online = (conn.State == System.ServiceModel.CommunicationState.Opened);
			btConnect.Enabled = !online;
			btDisconnect.Enabled = online;

		}

		private void btDisconnect_Click(object sender, EventArgs e)
		{
			try
			{
				conn.Close();
				caMessageService.Add(new caMessage() { text = "Connection closed" });
			}
			catch { }
			OnlineControl();
		}
	}
}

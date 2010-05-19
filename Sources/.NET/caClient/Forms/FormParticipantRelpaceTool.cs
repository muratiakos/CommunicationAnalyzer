using System;
using System.Windows.Forms;
using caClient.caServiceReference;
using caCoreLibrary;
using System.Collections.Generic;

namespace caClient.Forms
{
	public partial class FormParticipantRelpaceTool : Form
	{
		ServiceClient conn;
		caParticipantObject poFrom;
		caParticipantObject poTo;

		public FormParticipantRelpaceTool(ServiceClient _conn, caParticipantObject _po)
		{
			InitializeComponent();
			conn = _conn;
			poFrom = _po;

			RefreshList();
			RefreshUI();
		}

		public void RefreshList()
		{
			List<caParticipant> results = conn.LoadParticipantList();
			ptTo.ParticipantList = new caParticipantObjectList(results);
		}

		private void RefreshUI()
		{
			lbFrom.Text = poFrom.m_name;
			lbTo.Text = "Select from the list below";
			try
			{
				poTo = ptTo.Selection[0];
				lbTo.Text = poTo.m_name;
			}
			catch { }
		}

		private void ptTo_SelectionChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (poTo != null)
			{
				bool success = false;
				try
				{
					caMessageService.Add(conn.ReplaceParticipant(poFrom.m_participantId, poTo.m_participantId));
				}
				catch { }

				MessageBox.Show(success.ToString());
				this.Dispose();
				FormParticipant fp = caForm.OpenParticipantForm(conn, poTo);
			}
			else
			{
				MessageBox.Show("Please select a participant from the list");
			}
		}
	}
}

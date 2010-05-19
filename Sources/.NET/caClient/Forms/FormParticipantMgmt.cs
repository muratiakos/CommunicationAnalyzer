using System;
using System.Drawing;
using System.Windows.Forms;

using caCoreLibrary;
using System.Collections.Generic;
using caClient.caServiceReference;
//using caDataAccessLayer;

namespace caClient.Forms
{
	public partial class FormParticipantMgmt : Form
	{
		private List<caParticipant> results = new List<caParticipant>();
		ServiceClient conn = null;

		public FormParticipantMgmt(ServiceClient _c)
		{
			InitializeComponent();
			conn = _c;
			RefreshList();
		}

		private void participantTable1_RowDoubleClick(object sender, EventArgs e)
		{
			OpenProperties(GetSelected());
		}

		void fp_ObjectChanged(object sender, EventArgs e)
		{
			RefreshList();
		}

		public void RefreshList()
		{
			try
			{
				results = conn.LoadParticipantList();
				participantTable.ParticipantList = new caParticipantObjectList(results);
			}
			catch { caMessageService.Add(new caMessage() {  text="Connection error" }); }
		}

		private void participantTable_RowRightClick(object sender, MouseEventArgs e)
		{
			if (participantTable.Selection.Count > 0)
			{
				miName.Text = participantTable.Selection[0].m_name;
				mnuParticipant.Show(participantTable, e.Location);
			}
		}

		private void miProperties_Click(object sender, EventArgs e)
		{
			OpenProperties(GetSelected());
		}

		private void OpenProperties(caParticipantObject po)
		{
			FormParticipant fp = caForm.OpenParticipantForm(conn, po);
			fp.ObjectChanged += new EventHandler(fp_ObjectChanged);
		}

		private caParticipantObject GetSelected()
		{
			if (participantTable.Selection.Count > 0) return participantTable.Selection[0];
			else return null;
		}

		private void identifyAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			caForm.OpenParticipantReplaceTool(conn, GetSelected());
		}

		private void tsRefresh_Click(object sender, EventArgs e)
		{
			RefreshList();
		}

		private void tsNew_Click(object sender, EventArgs e)
		{
			OpenProperties(null);
		}
	}
}

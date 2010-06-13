using System;
using System.Drawing;
using System.Windows.Forms;

using caCoreLibrary;
using System.Collections.Generic;
using caClient.caServiceReference;
//using caDataAccessLayer;

namespace caClient.Forms
{
	//Résztvevőket listázó kliens oldali ablak
	public partial class FormParticipantMgmt : Form
	{
		//Résztvevők listája
		private List<caParticipant> results = new List<caParticipant>();
		//Kapcsolat objektuma
		ServiceClient conn = null;

		//Konstruktor kapcsolat átadásával
		public FormParticipantMgmt(ServiceClient _c)
		{
			InitializeComponent();
			conn = _c;
			RefreshList();
		}
		//Aktuális résztvevő tulajdonságanak megnyitása duplaklikkre
		private void participantTable1_RowDoubleClick(object sender, EventArgs e)
		{
			OpenProperties(GetSelected());
		}

		//Ha bármi megváltozott a listában, frissíteni a megjelenést
		void fp_ObjectChanged(object sender, EventArgs e)
		{
			RefreshList();
		}

		//Résztvevő lista frissítése
		public void RefreshList()
		{
			try
			{
				results = conn.LoadParticipantList();
				participantTable.ParticipantList = new caParticipantObjectList(results);
			}
			catch { caMessageService.Add(new caMessage() {  text="Connection error" }); }
		}

		//JObb klikkre menü előhozása
		private void participantTable_RowRightClick(object sender, MouseEventArgs e)
		{
			if (participantTable.Selection.Count > 0)
			{
				miName.Text = participantTable.Selection[0].m_name;
				mnuParticipant.Show(participantTable, e.Location);
			}
		}

		//Tulajdonságok menüre kattintva a résztvevő tulajdonsgai nyíljanak meg
		private void miProperties_Click(object sender, EventArgs e)
		{
			OpenProperties(GetSelected());
		}

		//Résztvevő tulajdonságainak megnyitása
		private void OpenProperties(caParticipantObject po)
		{
			FormParticipant fp = caForm.OpenParticipantForm(conn, po);
			fp.ObjectChanged += new EventHandler(fp_ObjectChanged);
		}

		//Választott résztvevő visszaadása
		private caParticipantObject GetSelected()
		{
			if (participantTable.Selection.Count > 0) return participantTable.Selection[0];
			else return null;
		}

		//Cserélő eszköz indítsa aktuális résztvevőn
		private void identifyAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			caForm.OpenParticipantReplaceTool(conn, GetSelected());
		}

		//Frissítésre kattintva
		private void tsRefresh_Click(object sender, EventArgs e)
		{
			RefreshList();
		}

		//Új rsztvevő felvétele
		private void tsNew_Click(object sender, EventArgs e)
		{
			OpenProperties(null);
		}
	}
}

using System;
using System.Windows.Forms;
using caClient.caServiceReference;
using caCoreLibrary;
using System.Collections.Generic;

namespace caClient.Forms
{
	//Résztvevő cserélő osztály
	public partial class FormParticipantRelpaceTool : Form
	{
		//Kapcsolat objektum
		ServiceClient conn;
		//Melyik résztvevőről
		caParticipantObject poFrom;
		//Melyik résztvevőre cserélünk
		caParticipantObject poTo;

		//Konstruktor a kapcsolat objektummal és azzal a résztvevővel, akiről cserélünk
		public FormParticipantRelpaceTool(ServiceClient _conn, caParticipantObject _po)
		{
			InitializeComponent();
			conn = _conn;
			poFrom = _po;

			RefreshList();
			RefreshUI();
		}

		//Cél-résztvevők listájának frissítése
		public void RefreshList()
		{
			List<caParticipant> results = conn.LoadParticipantList();
			ptTo.ParticipantList = new caParticipantObjectList(results);
		}

		//Felület frissítése
		private void RefreshUI()
		{
			lbFrom.Text = poFrom.m_name;
			lbTo.Text = "Select from the list below";
			try
			{
				//Kiválasztott bejelölése
				poTo = ptTo.Selection[0];
				lbTo.Text = poTo.m_name;
			}
			catch { }
		}

		//Kiválasztott cél résztvevő
		private void ptTo_SelectionChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}

		//CSerére kattintás
		private void button1_Click(object sender, EventArgs e)
		{
			if (poTo != null)
			{
				bool success = false;
				try
				{
					//Résztvevők cseréjének megkísérlése
					caMessageService.Add(conn.ReplaceParticipant(poFrom.m_participantId, poTo.m_participantId));
					success = true;
				}
				catch { }

				//MessageBox.Show(success.ToString());
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

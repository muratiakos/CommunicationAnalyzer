using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using caCoreLibrary;

namespace caClient.Controls
{
	/// <summary>
	/// Résztvevők listáját táblázatosan megjelenítő vezérlő
	/// Kattintás és egyéb eseméynkezelőkkel
	/// </summary>

	public partial class ParticipantTable : UserControl
	{
		//Események
		public event EventHandler RowDoubleClick;
		public event EventHandler SelectionChanged;
		public event MouseEventHandler RowRightClick;

		//Változók
		//Résztvevők listája
		private caParticipantObjectList m_participantList = new caParticipantObjectList();
		private List<caParticipantObject> m_participantListFilter = new List<caParticipantObject>();


		//Propertyk
		//Megjelnítési mód property
		public caParticipantType ParticipantDisplayMode
		{
			get
			{
				caParticipantType pt = caParticipantType.UserOrGroup;
				if (cbType.SelectedValue != null) pt = (caParticipantType)cbType.SelectedValue;
				return pt;
			}

			set
			{
				cbType.SelectedValue = (object)value;

				/*switch (value)
								{
									case caParticipantType.User:
										cbType.SelectedIndex = 1;
										DisplayTypeSelect(false);
										break;
									case caParticipantType.Group:
										cbType.SelectedIndex = 2;
										DisplayTypeSelect(false);
										break;
									case caParticipantType.UserOrGroup:
									default:
										cbType.SelectedIndex = 0;
										DisplayTypeSelect(true);
										break;
								} */
			}
		}


		//Réstvevők listája
		public caParticipantObjectList ParticipantList
		{
			get
			{
				return m_participantList;
			}

			set
			{
				dgParticipant.DataSource = null;
				dgParticipant.CancelEdit();

				m_participantList = value;
				m_participantListFilter = m_participantList;

				dgParticipant.DataSource = m_participantListFilter;
				dgParticipant.Refresh();

				FilterResults();
			}
		}

		//Választott érsztvevők property
		public caParticipantObjectList Selection
		{
			get
			{
				caParticipantObjectList pol = new caParticipantObjectList();
				foreach (DataGridViewRow o in dgParticipant.SelectedRows)
				{
					caParticipantObject po = null;
					po = (caParticipantObject)o.DataBoundItem;
					pol.Add(po);
				}
				return pol;
			}
		}

		//KOnstruktorok
		public ParticipantTable()
		{
			InitializeComponent();
			cbType.DataSource = caGlobalList.ParticipantTypeList("Users and Groups");
			cbType.DisplayMember = "Display";
			cbType.ValueMember = "Value";

			cbStatus.DataSource = caGlobalList.RecordStates("");
			cbStatus.DisplayMember = "Display";
			cbStatus.ValueMember = "Value";
			cbStatus.SelectedValue = caRecordStatus.Active;

			ParticipantDisplayMode = caParticipantType.UserOrGroup;
			//cb_type.Items.Add(caGlobalListItem.ParticipantType_Both);

			//cb_type.DataSource = caGlobalList.ParticipantTypeList;

		}

		//Események
		//Beírásra azonnali szűrés
		private void tx_search_TextChanged(object sender, EventArgs e)
		{
			FilterResults();
		}

		//Típus választsra szűrés
		private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterResults();
		}

		//Szűrést végrehajtó LINQ eljárás
		public void FilterResults()
		{
			//Típusok és szűrőfeltételek beállítása
			caParticipantType pt = caParticipantType.UserOrGroup;
			caRecordStatus ps = caRecordStatus.Active;
			string s = txSearch.Text.ToLower();

			try { pt = (caParticipantType)cbType.SelectedValue; }
			catch { }
			try { ps = (caRecordStatus)cbStatus.SelectedValue; }
			catch { }

			//if (cb_type.SelectedValue != null) pt = ((caParticipantType)((caGlobalListItem)cb_type.SelectedItem).m_value);
			{
				m_participantListFilter = m_participantList.FindAll(
					delegate(caParticipantObject po)
					{
						//bool sel = true;
						//Teljes feltétel megadása mindenre
						if (!pt.Equals(caParticipantType.UserOrGroup) && !pt.Equals(po.m_type)) return false;
						if (!ps.Equals(po.m_status)) return false;
						if (!String.IsNullOrEmpty(s) && !po.m_foreignId.ToLower().Contains(s) && !po.m_name.ToLower().Contains(s) && !po.m_participantId.ToLower().Contains(s)) return false;
						return true;
					});
			}
			//else m_participantListFilter = m_participantList;
			dgParticipant.DataSource = null;
			dgParticipant.DataSource = m_participantListFilter;
			dgParticipant.Refresh();
		}

		//Megjelenítési módtól függően milyen vezérlők látszódjanak
		public void DisplayTypeSelect(bool _visible)
		{
			cbType.Visible = _visible;
			lbType.Visible = _visible;
		}

		//Dupla kattintás eseménykiváltója
		private void dg_participant_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				RowDoubleClick.Invoke(sender, e);
			}
			catch (Exception) { }
		}

		//Státusz legördülő változására szűrés
		private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterResults();
		}

		//Kattintásra eseménykiváltás
		private void dgParticipant_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				try
				{
					MouseEventArgs m = new MouseEventArgs(e.Button, 1, e.X + dgParticipant.Left, e.Y + dgParticipant.Top, 0);
					RowRightClick.Invoke(sender, m);
				}
				catch { }
			}
		}

		//Résztvevő kiválasztására eseménykiváltás
		private void dgParticipant_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				SelectionChanged.Invoke(sender, e);
			}
			catch (Exception) { }
		}


	}
}

using System;
using System.Windows.Forms;

using caClient.Forms;
using caCoreLibrary;
using System.Collections.Generic;

namespace caClient.Controls
{
	/// <summary>
	/// Általános keresőűrlap vezérlője
	/// Résztvevő (feladó és/vagy fogadó), időintervallum, címke és csoportkifejtést valósít meg
	/// </summary>

	public partial class SearchBasicForm : UserControl
	{
		//Propertyk

		//Időintervallum kezdete
		public DateTime After
		{
			get { return dtpAfter.Value; }
			set { dtpAfter.Value = value; }
		}

		//Időintervallum vége
		public DateTime Before
		{
			get { return dtpBefore.Value; }
			set { dtpBefore.Value = value; }
		}

		//Csak a megadott szereplők közötti kommunikáció lekérdezése
		public bool AmongFromTo
		{
			get
			{
				return chkAmong.Checked;
			}
		}

		//Csoport kibontását visszaadó property
		public bool ExpandGrp
		{
			get
			{
				return chkExtendGrp.Checked;
			}
		}

		//Feladó listát visszaadó property
		public caParticipantObjectList FromList
		{
			get
			{
				caParticipantObjectList pol = new caParticipantObjectList();
				foreach (ListViewItem item in lvFromList.Items)
				{
					pol.Add((caParticipantObject)item.Tag);
				}
				return pol;
			}
		}

		//Címzett listát visszaadó prop
		public caParticipantObjectList ToList
		{
			get
			{
				if (!cbToIsTheSameAsFrom.Checked)
				{
					caParticipantObjectList pol = new caParticipantObjectList();
					foreach (ListViewItem item in lvToList.Items)
					{
						pol.Add((caParticipantObject)item.Tag);
					}
					return pol;
				}
				else return FromList;
			}
		}

		//Megjelölt címkéket visszaadó lista
		public List<String> Tags
		{
			get
			{
				List<String> tags = new List<String>();
				foreach (Object o in clTags.CheckedItems)
				{
					tags.Add(o.ToString());
				}
				return tags;
			}
		}

		//Konstruktorok
		public SearchBasicForm()
		{
			InitializeComponent();

			//Címke Checklist inicializásás - minden üres
			foreach (caGlobalListItem i in caClientService.glTag)
			{
				clTags.Items.Add(i.m_value, CheckState.Unchecked);
			}
		}


		//Feladó hozzáadása gombnyomásra
		private void bt_from_Click(object sender, EventArgs e)
		{
			FormParticipantSelector psf = new FormParticipantSelector();
			psf.OpenForAdd(this.lvFromList, "From Participant List:");
		}

		//Billentyű kezelése - Feladó listában
		private void lvFromList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb - választott törlése
			{
				if (lvFromList.SelectedItems.Count > 0) lvFromList.Items.Remove(lvFromList.SelectedItems[0]);
			}

		}

		//Címzett lista bővítése gombnyomásra
		private void btToAdd_Click(object sender, EventArgs e)
		{
			FormParticipantSelector psf = new FormParticipantSelector();
			psf.OpenForAdd(this.lvToList, "To Participant List:");
		}

		//Címzett lista billentyűkezelése
		private void lvToList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb - választott résztvevő törlése
			{
				if (lvToList.SelectedItems.Count > 0) lvToList.Items.Remove(lvToList.SelectedItems[0]);
			}
		}

		//Feladó és Címzett felcserélhető
		private void cbToIsSameAsFrom_CheckedChanged(object sender, EventArgs e)
		{
			lvToList.Enabled = !cbToIsTheSameAsFrom.Checked;
			btToAdd.Enabled = lvToList.Enabled;
		}

	}
}

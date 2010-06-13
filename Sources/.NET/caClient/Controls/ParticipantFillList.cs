using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using caClient.Forms;
using caCoreLibrary;

namespace caClient.Controls
{
	/// <summary>
	/// Résztvevő lista osztálya
	/// Egy olyan vezérlő mely több résztvevő tárolására alkalmas és egyszerűen használható
	/// résztvevő kereső eszköz kapcsolódik hozzá
	/// </summary>
	public partial class ParticipantFillList : UserControl
	{
		//Vezérlő címkéje
		public String Label { get { return lbControlLabel.Text; } set { lbControlLabel.Text = value; } }
		//Résztvevők listájának properyje
		public caParticipantObjectList List
		{
			get
			{
				caParticipantObjectList pol = new caParticipantObjectList();
				foreach (ListViewItem item in lvParticipantList.Items)
				{
					pol.Add((caParticipantObject)item.Tag);
				}
				return pol;
			}

			set
			{
				lvParticipantList.Clear();
				foreach (caParticipantObject po in value)
				{
					ListViewItem lvi = new ListViewItem(po.Name);
					lvi.Tag = po;
					lvParticipantList.Items.Add(lvi);
				}
			}
		}

		//Kiválasztott résztvevőkk
		public caParticipantObject Selected
		{
			get
			{
				caParticipantObject s = null;
				try
				{
					s = ((caParticipantObject)lvParticipantList.SelectedItems[0].Tag);
				}
				catch { }
				return s;
			}
		}

		//KOnstruktor
		public ParticipantFillList()
		{
			InitializeComponent();
		}

		//-- Eljárások / események
		//Résztvevő törlése gombnyomásra
		private void btRemove_Click(object sender, EventArgs e)
		{
			DeleteSelected();
		}

		//Résztvevő választó megnyitása hozzáadáshoz - gombnyomásra
		private void btAdd_Click(object sender, EventArgs e)
		{
			FormParticipantSelector psf = new FormParticipantSelector();
			psf.OpenForAdd(this.lvParticipantList, this.Label);
		}

		//Billentyűzet események kezelése
		private void lvParticipantList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb - választott résztvevő törlése
			{
				DeleteSelected();
			}
		}

		//Választott résztvevő törlése
		private void DeleteSelected()
		{
			if (lvParticipantList.SelectedItems.Count > 0) lvParticipantList.Items.Remove(lvParticipantList.SelectedItems[0]);
		}
	}
}

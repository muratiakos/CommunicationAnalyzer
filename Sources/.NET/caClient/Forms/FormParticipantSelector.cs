using System;
using System.Windows.Forms;

using caCoreLibrary;
using System.Collections.Generic;
using caClient.caServiceReference;

namespace caClient.Forms
{
	//Résztvevők kiválasztását segítő párbeszédablak, ami a meghívó objektummak visszaadja a kiválasztott résztvevők istáját
	public partial class FormParticipantSelector : Form
	{
		//Szülő objektum listája
		private object parentList;

		//Konstruktor és résztvevők lekérdezése
		public FormParticipantSelector()
		{
			InitializeComponent();

			//caDatabaseMethod da = new caDatabaseMethod();
            ServiceClient conn = new ServiceClient();
            List<caParticipant> results = conn.LoadParticipantList();
			participantList.ParticipantList = new caParticipantObjectList(results);
		}

		//Meghívás és szülő objektumok betöltése a listába
		public void OpenForAdd(object _parentList, String label)
		{
			lvSelected.Clear();

			parentList = _parentList;
			if (_parentList.GetType() == typeof(ListView))
			{
				foreach (ListViewItem i in ((ListView)_parentList).Items)
				{
					lvSelected.Items.Add((ListViewItem)i.Clone());
				}
			}

			lb_listlabel.Text = label;
			this.Show();
		}

		//Dupla klikkel a választott résztvevők hozzáadása a listához
		private void participantList_RowDoubleClick(object sender, EventArgs e)
		{
			foreach (caParticipantObject po in participantList.Selection)
			{
				ListViewItem lvi = new ListViewItem(po.Name);
				lvi.Tag = po;
				lvSelected.Items.Add(lvi);
			}

		}

		//Ok kattintás - hatására a választott objektumokat visszaadja a hívó listának
		private void btOk_Click(object sender, EventArgs e)
		{
			((ListView)parentList).Clear();
			foreach (ListViewItem i in lvSelected.Items)
			{
				((ListView)parentList).Items.Add((ListViewItem)i.Clone());
			}
			this.Dispose();
		}

		//Mégse katt - bezárás
		private void btCancel_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		//Gombnyomások kezelése
		private void lvSelected_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb  törlés
			{
				if (lvSelected.SelectedItems.Count > 0) lvSelected.Items.Remove(lvSelected.SelectedItems[0]);
			}
		}
	}
}

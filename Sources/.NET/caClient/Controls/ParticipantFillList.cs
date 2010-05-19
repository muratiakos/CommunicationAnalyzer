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
	public partial class ParticipantFillList : UserControl
	{
		//Propertyk
		public String Label { get { return lbControlLabel.Text; } set { lbControlLabel.Text = value; } }
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

		//Eljárások / események
		private void btRemove_Click(object sender, EventArgs e)
		{
			DeleteSelected();
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			FormParticipantSelector psf = new FormParticipantSelector();
			psf.OpenForAdd(this.lvParticipantList, this.Label);
		}

		private void lvParticipantList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb
			{
				DeleteSelected();
			}
		}

		private void DeleteSelected()
		{
			if (lvParticipantList.SelectedItems.Count > 0) lvParticipantList.Items.Remove(lvParticipantList.SelectedItems[0]);
		}
	}
}

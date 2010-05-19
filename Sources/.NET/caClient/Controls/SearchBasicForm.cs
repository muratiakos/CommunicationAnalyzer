using System;
using System.Windows.Forms;

using caClient.Forms;
using caCoreLibrary;
using System.Collections.Generic;

namespace caClient.Controls
{
	public partial class SearchBasicForm : UserControl
	{
		//Propertyk
		public DateTime After
		{
			get { return dtpAfter.Value; }
			set { dtpAfter.Value = value; }
		}
		public DateTime Before
		{
			get { return dtpBefore.Value; }
			set { dtpBefore.Value = value; }
		}

		public bool AmongFromTo
		{
			get
			{
				return chkAmong.Checked;
			}
		}

		public bool ExpandGrp
		{
			get
			{
				return chkExtendGrp.Checked;
			}
		}

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

			//Checklist inicializásás
			foreach (caGlobalListItem i in caClientService.glTag)
			{
				clTags.Items.Add(i.m_value, CheckState.Unchecked);
			}
		}


		//Metódusok
		private void bt_from_Click(object sender, EventArgs e)
		{
			FormParticipantSelector psf = new FormParticipantSelector();
			psf.OpenForAdd(this.lvFromList, "From Participant List:");
		}

		private void lvFromList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb
			{
				if (lvFromList.SelectedItems.Count > 0) lvFromList.Items.Remove(lvFromList.SelectedItems[0]);
			}

		}

		private void btToAdd_Click(object sender, EventArgs e)
		{
			FormParticipantSelector psf = new FormParticipantSelector();
			psf.OpenForAdd(this.lvToList, "To Participant List:");
		}

		private void lvToList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 46) //delete gomb
			{
				if (lvToList.SelectedItems.Count > 0) lvToList.Items.Remove(lvToList.SelectedItems[0]);
			}
		}

		private void cbToIsSameAsFrom_CheckedChanged(object sender, EventArgs e)
		{
			lvToList.Enabled = !cbToIsTheSameAsFrom.Checked;
			btToAdd.Enabled = lvToList.Enabled;
		}

		private void SearchBasicForm_Load(object sender, EventArgs e)
		{

		}
	}
}

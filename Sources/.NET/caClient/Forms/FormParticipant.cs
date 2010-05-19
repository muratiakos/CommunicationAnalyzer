using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using caCoreLibrary;
using caClient.caServiceReference;

namespace caClient.Forms
{
	public partial class FormParticipant : Form
	{
		//Eseménykezelők
		public event EventHandler ObjectChanged;
		private bool changed = false;

		//Változók
		internal caParticipantObject m_po = new caParticipantObject();
		internal ServiceClient conn = null;


		public FormParticipant()
		{
			InitializeComponent();

			cbType.DataSource = caGlobalList.ParticipantTypeList("");
			cbType.DisplayMember = "Display";
			cbType.ValueMember = "Value";


			cbStatus.DataSource = caGlobalList.RecordStates("");
			cbStatus.DisplayMember = "Display";
			cbStatus.ValueMember = "Value";

			cbSync.DataSource = caGlobalList.SyncStates("");
			cbSync.DisplayMember = "Display";
			cbSync.ValueMember = "Value";

			cbCategory.DataSource = caGlobalList.CategoryList("");
			cbCategory.DisplayMember = "Display";
			cbCategory.ValueMember = "Value";

			m_po = new caParticipantObject();
			RefreshUI();
		}

		public FormParticipant(caParticipantObject _po)
			: this()
		{
			m_po = _po;

			RefreshUI();
		}

		public void RefreshUI() { RefreshUI(m_po); }
		public void RefreshUI(caParticipantObject po)
		{
			//Ablak
			Text = "Participant - " + po.m_name;
			tabControl.TabPages.Remove(tpMembers);
			if (po.m_type == caParticipantType.User) tabControl.TabPages.Remove(tpMembers); else tabControl.TabPages.Add(tpMembers);

			//Textek
			txParticipantId.Text = po.m_participantId;
			txName.Text = po.m_name;
			txForeignId.Text = po.m_foreignId;
			txPrimaryGroup.Tag = po.m_primaryGroup;
			txPrimaryGroup.Text = po.m_primaryGroup;

			//Combok
			cbType.SelectedValue = (object)po.m_type;
			cbStatus.SelectedValue = (object)po.m_status;
			cbSync.SelectedValue = (object)po.m_objectState;

			//Listák
			pflMembers.List = po.m_memberList;
			pflGroups.List = po.m_groupList;
			SetAddressList(po.m_addressList);

		}

		public caParticipantObject GetParticipantObject()
		{
			caParticipantObject po = new caParticipantObject();

			//Label
			po.m_participantId = txParticipantId.Text;
			po.m_foreignId = txForeignId.Text;
			po.m_name = txName.Text;
			po.m_primaryGroup = txPrimaryGroup.Tag.ToString();

			//Combok
			po.m_status = (caRecordStatus)cbStatus.SelectedValue;
			po.m_type = (caParticipantType)cbType.SelectedValue;
			//Sync nem töltődik

			//Listák
			po.m_groupList = pflGroups.List;
			po.m_memberList = pflMembers.List;
			po.m_addressList = GetAddressList();

			return po;
		}

		private void btClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btReload_Click(object sender, EventArgs e)
		{
			Revert();
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			caParticipantObject po = GetParticipantObject();
			caClientService.SaveParticipantObject(conn, po);
			changed = true;
			this.Close();
		}

		private void Revert()
		{
			caClientService.LoadParticipantObject(conn, m_po);
			RefreshUI();
		}

		private void FormParticipant_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (changed) this.ObjectChanged.Invoke(this, new EventArgs());
			}
			catch { }
		}

		private void FormParticipant_Load(object sender, EventArgs e)
		{
			Revert();
		}

		private void SetAddressList(List<caParticipantAddress> al)
		{
			lvAddressList.Clear();
			foreach (caParticipantAddress a in al)
			{
				ListViewItem lvi = new ListViewItem();
				lvi.Text = a.m_address;
				lvi.ImageIndex = (int)a.m_category;
				lvi.Tag = a;
				lvAddressList.Items.Add(lvi);
			}
		}

		private List<caParticipantAddress> GetAddressList()
		{
			List<caParticipantAddress> al = new List<caParticipantAddress>();
			foreach (ListViewItem a in lvAddressList.Items)
			{
				al.Add((caParticipantAddress)a.Tag);
			}
			return al;
		}

		private void btAddrAdd_Click(object sender, EventArgs e)
		{
			caCommCategory c = caCommCategory.Email;
			try { c = (caCommCategory)cbCategory.SelectedValue; }
			catch { }

			caParticipantAddress a = new caParticipantAddress();
			a.m_address = txAddress.Text.Trim();
			a.m_category = c;

			if (!String.IsNullOrEmpty(a.m_address)) lvAddressList.Items.Add(new ListViewItem() { Tag = a, Text = a.m_address, ImageIndex = (int)a.m_category });
		}

		private void btAddrRemove_Click(object sender, EventArgs e)
		{
			if (lvAddressList.SelectedItems.Count > 0) lvAddressList.Items.Remove(lvAddressList.SelectedItems[0]);
		}

		private void btToolReplace_Click(object sender, EventArgs e)
		{
			caForm.OpenParticipantReplaceTool(conn, m_po);
			this.Close();
		}

		private void btSetPrimaryGroup_Click(object sender, EventArgs e)
		{
			caParticipantObject p = pflGroups.Selected;
			if (p != null)
			{
				txPrimaryGroup.Tag = p.m_participantId;
				txPrimaryGroup.Text = p.m_name;
			}
		}
	}
}

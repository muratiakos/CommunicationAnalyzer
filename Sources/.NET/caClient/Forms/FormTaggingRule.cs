using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using caCoreLibrary;
using caClient.caServiceReference;

namespace caClient.Forms
{
	public partial class FormTaggingRule : Form
	{
		//Eseménykezelők
		public event EventHandler ObjectChanged;
		private bool changed = false;

		internal ServiceClient conn = null;

		caTaggingRule m_tr = new caTaggingRule();

		public FormTaggingRule()
		{
			InitializeComponent();

			cbStatus.DataSource = caGlobalList.RecordStates("");
			cbStatus.DisplayMember = "Display";
			cbStatus.ValueMember = "Value";

			RefreshUI();
		}

		public FormTaggingRule(caTaggingRule tr)
			: this()
		{
			m_tr = tr;
			RefreshUI();
		}
		public void RefreshUI() { RefreshUI(m_tr); }
		public void RefreshUI(caTaggingRule tr)
		{
			//Ablak
			Text = "Tagging Rule - " + tr.Name + " (" + tr.RuleId + ")";

			//Textek
			txRuleId.Text = tr.RuleId;
			txName.Text = tr.Name;
			cbTag.Text = tr.Tag;
			txQuery.Text = tr.Query;

			//Check
			chkCustomQuery.Checked = tr.Custom_Query;

			//Listák
			cbStatus.SelectedValue = (object)tr.Status;

		}

		private caTaggingRule GetTaggingRule()
		{
			caTaggingRule tr = new caTaggingRule();
			//Textek
			tr.RuleId = txRuleId.Text;
			tr.Name = txName.Text;
			tr.Tag = cbTag.Text;
			tr.Query = txQuery.Text;

			//Check
			tr.Custom_Query = chkCustomQuery.Checked;

			//Listák
			tr.Status = caRecordStatus.Active;
			try
			{
				tr.Status = (caRecordStatus)cbStatus.SelectedValue;
			}
			catch { }

			return tr;
		}

		private void btClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btReload_Click(object sender, EventArgs e)
		{
			caClientService.LoadTaggingRule(conn, m_tr);
			RefreshUI();
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			caTaggingRule tr = GetTaggingRule();
			caClientService.SaveTaggingRule(conn, tr);
			changed = true;
			this.Close();
		}

		private void FormTaggingRule_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (changed) ObjectChanged.Invoke(sender, new EventArgs());
		}

		private void chkCustomQuery_CheckedChanged(object sender, EventArgs e)
		{
			txQuery.Enabled = chkCustomQuery.Checked;
		}

		private void btRun_Click(object sender, EventArgs e)
		{
			caClientService.RunTaggingRule(conn, m_tr.RuleId);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			caClientService.DeleteTag(conn, m_tr.Tag);
		}

	}
}

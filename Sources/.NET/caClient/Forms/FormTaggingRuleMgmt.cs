using System;
using System.Windows.Forms;
using caClient.caServiceReference;
using System.Collections.Generic;
using caCoreLibrary;

namespace caClient.Forms
{
	public partial class FormTaggingRuleMgmt : Form
	{
		ServiceClient conn = null;
		List<caTaggingRule> rules = new List<caTaggingRule>();

		public FormTaggingRuleMgmt(ServiceClient _conn)
		{
			InitializeComponent();
			conn = _conn;

			RefreshUI();
		}

		private void RefreshUI()
		{
			dgTaggingRules.DataSource = null;
			rules = new List<caTaggingRule>();
			try
			{
				rules = conn.LoadTaggingRuleList();
			}
			catch { }
			dgTaggingRules.DataSource = rules;
			dgTaggingRules.Refresh();
		}

		private void tsRefresh_Click(object sender, EventArgs e)
		{
			RefreshUI();
		}

		private void tsNew_Click(object sender, EventArgs e)
		{
			FormTaggingRule ftr = new FormTaggingRule();
			ftr.conn = conn;
			ftr.ObjectChanged += new EventHandler(ftr_ObjectChanged);
			ftr.Show();
		}

		void ftr_ObjectChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}

		private void dgTaggingRules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow row = null;
			caTaggingRule tr = null;
			try
			{
				row = dgTaggingRules.SelectedRows[0];
				tr = (caTaggingRule)row.DataBoundItem;
			}
			catch { }

			if (tr != null)
			{
				FormTaggingRule ftr = new FormTaggingRule(tr);
				ftr.conn = conn;
				ftr.ObjectChanged += new EventHandler(ftr_ObjectChanged);
				ftr.Show();
			}
		}
	}
}

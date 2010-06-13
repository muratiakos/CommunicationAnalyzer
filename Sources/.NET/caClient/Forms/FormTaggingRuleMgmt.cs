using System;
using System.Windows.Forms;
using caClient.caServiceReference;
using System.Collections.Generic;
using caCoreLibrary;

namespace caClient.Forms
{
	//Címkézési szabályok listáját megjelenítő kliens ablak
	public partial class FormTaggingRuleMgmt : Form
	{
		//Kapcsolat objektum
		ServiceClient conn = null;
		//Címkézési szabályok listája
		List<caTaggingRule> rules = new List<caTaggingRule>();

		//Konstruktor a kapcsolat átvételével
		public FormTaggingRuleMgmt(ServiceClient _conn)
		{
			InitializeComponent();
			conn = _conn;

			RefreshUI();
		}

		//Felület frissítése az objektumok állapota alapján
		private void RefreshUI()
		{
			dgTaggingRules.DataSource = null;
			rules = new List<caTaggingRule>();
			try
			{
				//Cjmkézéi szabályok listájának letöltése
				rules = conn.LoadTaggingRuleList();
			}
			catch { }
			dgTaggingRules.DataSource = rules;
			dgTaggingRules.Refresh();
		}

		//Felület frissítése
		private void tsRefresh_Click(object sender, EventArgs e)
		{
			RefreshUI();
		}

		//Új címkézési szabály kattintás
		private void tsNew_Click(object sender, EventArgs e)
		{
			FormTaggingRule ftr = new FormTaggingRule();
			ftr.conn = conn;
			ftr.ObjectChanged += new EventHandler(ftr_ObjectChanged);
			ftr.Show();
		}

		//Ha valami megváltozott, úgy frissítés
		void ftr_ObjectChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}

		//Duplakattintással a címkézési szabály tulajdonságainak megnyitása
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

using System;
using System.Windows.Forms;
using caClient.Forms;
using caClient.caServiceReference;
using caCoreLibrary;
using System.Collections.Generic;

namespace caClient
{
	public partial class FormMain : Form
	{
		//Kapcsolódás példánya
		internal ServiceClient conn = new ServiceClient();

		public FormMain()
		{
			InitializeComponent();
			caMessageService.NewMessage += new EventHandler(caMessageService_NewMessage);
		}

		void caMessageService_NewMessage(object sender, EventArgs e)
		{
			foreach (caMessage m in caMessageService.messageQueue)
			{
				lvMessageList.Items.Add(m.text);
				caMessageService.messageQueue.Remove(m);
				tsStatus.Text = m.text;
			}
		}

		private void OpenFile(object sender, EventArgs e)
		{

		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}

		private void tr_menu_DoubleClick(object sender, EventArgs e)
		{
			if (tvNavigator.SelectedNode != null)
			{
				Form f = null;
				switch (tvNavigator.SelectedNode.Name.ToString())
				{
					case "tnConnection":
						f = new FormConnect(this, conn);
						break;
					case "tnParticipantMgmt":
						f = new FormParticipantMgmt(conn);
						break;
					case "tnTagMgmt":
						f = new FormTaggingRuleMgmt(conn);
						break;
					case "tnRelationAnalysis":
						f = new FormParticipantRelationAnalysis(conn);
						break;
					case "tnFlowAnalysis":
						f = new FormFlowAnalysis(conn);
						break;
					case "tnTagRelationAnalysis":
						f = new FormTagParticipantRelationAnalysis(conn);
						break;
					case "test":
						f = new FormTest();
						break;
					default:
						break;
				}

				//Ha nyitottunk újat, akkor belő mindent
				if (f != null)
				{
					caForm.MakeMDIChild(this,f);
				}
			}
		}

		private void Main_MdiChildActivate(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild == null)
				tabWindows.Visible = false; // If no any child form, hide tabControl
			else
			{
				//this.ActiveMdiChild.WindowState = FormWindowState.Maximized; // Child form always maximized

				// If child form is new and no has tabPage, create new tabPage
				if (this.ActiveMdiChild.Tag == null)
				{
					// Add a tabPage to tabControl with child form caption
					TabPage tp = new TabPage(this.ActiveMdiChild.Text);
					tp.Tag = this.ActiveMdiChild;
					tp.Parent = tabWindows;
					tabWindows.SelectedTab = tp;

					this.ActiveMdiChild.Tag = tp;
					this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
				}

				if (!tabWindows.Visible) tabWindows.Visible = true;
			}
		}

		private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
		{
			((sender as Form).Tag as TabPage).Dispose();
		}

		private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((tabWindows.SelectedTab != null) && (tabWindows.SelectedTab.Tag != null))
				(tabWindows.SelectedTab.Tag as Form).Select();
		}


		private void Main_Load(object sender, EventArgs e)
		{
			FormConnect frmC = new FormConnect(this, conn);
			caForm.MakeMDIChild(this, frmC);
		}

		public void AddMessage(String _text)
		{
			lvMessageList.Items.Add(_text);
		}

		public void OnlineControl(ServiceClient _c)
		{
			try
			{
				conn = _c;
				if (conn.State == System.ServiceModel.CommunicationState.Opened)
				{
					tvNavigator.Nodes[0].Text = conn.Endpoint.Address.ToString() + " - " + conn.State.ToString();
					//AddMessage(conn.Connect());
					tvNavigator.ExpandAll();
					tvNavigator.Enabled = true;

					try
					{
						caClientService.LoadTagList(conn);
						caMessageService.Add(new caMessage() { text = "Tags successfully downloaded" });

					}
					catch (Exception ex)
					{
						caMessageService.Add(new caMessage() { type = caMessageType.Error, text = "Error loading TagList from server" });
						caMessageService.AddException("M.OnlineControl", ex);
					}
				}
				else
				{
					tvNavigator.CollapseAll();
					tvNavigator.Enabled = false;
				}
			}
			catch { }
		}

		private void btMessageClear_Click(object sender, EventArgs e)
		{
			lvMessageList.Clear();
		}

		private void btServerMsg_Click(object sender, EventArgs e)
		{
			List<caMessage> ml = new List<caMessage>();
			try
			{
				ml = conn.GetMessages();
				if (ml.Count > 0)
				{
					caMessageService.Add(new caMessage() { text = "-- Server Messages Start -- " });
					foreach (caMessage m in ml) caMessageService.messageQueue.Add(m);
					caMessageService.Add(new caMessage() { text = "-- Server Messages End -- " });
				}
			}
			catch
			{
				caMessageService.Add(new caMessage() { text = "Unable to download Messages from server", type = caMessageType.Error });
			}
		}

		private void helpMenu_Click(object sender, EventArgs e)
		{
			FormAbout about = new FormAbout();
			about.ShowDialog();
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://localhost:8511/caService?wsdl");
		}
	}
}

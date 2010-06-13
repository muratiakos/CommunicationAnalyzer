using System;
using System.Windows.Forms;
using caClient.Forms;
using caClient.caServiceReference;
using caCoreLibrary;
using System.Collections.Generic;

namespace caClient
{
	/// <summary>
	/// Kliena alkalmazás főablaka
	/// A párbeszédablakok kivételével mInden további ablak ennek a gyermekeként nyílik meg
	/// </summary>
	public partial class FormMain : Form
	{
		//Kapcsolódás példánya
		internal ServiceClient conn = new ServiceClient();

		//Konstruktor
		public FormMain()
		{
			InitializeComponent();
			caMessageService.NewMessage += new EventHandler(caMessageService_NewMessage);
		}

		//Új caMessage kiírása az üzenetablkba
		void caMessageService_NewMessage(object sender, EventArgs e)
		{
			foreach (caMessage m in caMessageService.messageQueue)
			{
				lvMessageList.Items.Add(m.text);
				caMessageService.messageQueue.Remove(m);
				tsStatus.Text = m.text;
			}
		}

		//KIlépés
		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		//Gyermekablakok kaszkádolt megjelenítése
		private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}
		//Függőleges gyermekablak megjelenítés
		private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}
		//Vízszintes gyermekablak megjelenítés
		private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}
		//MInden gyermekablak bezárása
		private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				childForm.Close();
			}
		}
		//Fa menüben egy menüpont megnyitása
		private void tr_menu_DoubleClick(object sender, EventArgs e)
		{
			//Menüpont kiválasztása a neve alapján és a megfelelő ablka példányosítása MDI gyermekablakként
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

				//Ha nyitottunk újat, akkor a tab-ok közé felvenni
				if (f != null)
				{
					caForm.MakeMDIChild(this, f);
				}
			}
		}

		//Ha választunk egy tab-ot, akkor az annak megfelelő MDI gyermekablak jelnjen meg
		private void Main_MdiChildActivate(object sender, EventArgs e)
		{
			if (this.ActiveMdiChild == null)
				tabWindows.Visible = false; // Ha nincs semmi, akkor eltűntetni
			else
			{
				//this.ActiveMdiChild.WindowState = FormWindowState.Maximized; 

				//Ha a gyermek MDI-nek még nem lenne Tabja, akkor létrehozunk egy újat
				if (this.ActiveMdiChild.Tag == null)
				{
					// Tab felvétele az ablak nevével
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

		//Gyermekablak bezázása --> Tab megszűntetése
		private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
		{
			((sender as Form).Tag as TabPage).Dispose();
		}

		//Gyermekablakot választunk --> Akkor a Tab is kiválasztódik
		private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((tabWindows.SelectedTab != null) && (tabWindows.SelectedTab.Tag != null))
				(tabWindows.SelectedTab.Tag as Form).Select();
		}

		//Kliens indításakor a kapcsolódás ablak automatikusan felnyílik
		private void Main_Load(object sender, EventArgs e)
		{
			FormConnect frmC = new FormConnect(this, conn);
			caForm.MakeMDIChild(this, frmC);
		}

		//Új üzenet hozzáadása az azüneteablakhoz
		public void AddMessage(String _text)
		{
			lvMessageList.Items.Add(_text);
		}

		//Csatlakozás kezelő eljárás
		public void OnlineControl(ServiceClient _c)
		{
			try
			{
				conn = _c;
				if (conn.State == System.ServiceModel.CommunicationState.Opened) //Ha a kapcsolat nyitva van
				{
					//Menü engedélyezés és lenyitás					
					tvNavigator.Nodes[0].Text = conn.Endpoint.Address.ToString() + " - " + conn.State.ToString();
					//AddMessage(conn.Connect());
					tvNavigator.ExpandAll();
					tvNavigator.Enabled = true;

					try
					{
						//Címkék letöltésének megkísérlése
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
					//Ha mégsincs nyitva a kapcsolat, akkor menü összecsukása és letiltása
					tvNavigator.CollapseAll();
					tvNavigator.Enabled = false;
				}
			}
			catch { }
		}

		//MInden üzenet törlés gombnyomásra
		private void btMessageClear_Click(object sender, EventArgs e)
		{
			lvMessageList.Clear();
		}
		//Üzenetek lekérdezése a szervertől gombnyomásra
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
		//Kattintás a névjegy menüre
		private void helpMenu_Click(object sender, EventArgs e)
		{
			FormAbout about = new FormAbout();
			about.ShowDialog();
		}
		//Kattintás a WSDL letöltés menüre
		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://localhost:8511/caService?wsdl");
		}
	}
}

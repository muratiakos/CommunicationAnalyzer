using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using caClient.caServiceReference;
using caCoreLibrary;

namespace caClient.Forms
{
	//Csatlakozás kezelő ablak
	public partial class FormConnect : Form
	{
		FormMain p; //Szülő ablak
		bool success = false; //Sikeresség indikátora
		ServiceClient conn = null; //Kliens-Szerver kapcsolat objektuma

		//Kapcsolatablak incializálása		
		public FormConnect(FormMain _p, ServiceClient _conn)
		{
			InitializeComponent();
			p = _p;
			conn = _conn;
			OnlineControl();
		}

		//Kapcsolódás gomb megnyomása
		private void btConnect_Click(object sender, EventArgs e)
		{
			//Animációs csík és aszinkron kapcsolat indítás
			progressBar.MarqueeAnimationSpeed = 200;
			btConnect.Enabled = false;
			backgroundConnect.RunWorkerAsync();
		}

		//Aszinkron kapcsolatfelépítés a háttérben
		private void backgroundConnect_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				//Kapcsolat megnyitás, üzenetek lekérdezése és sikeresség indikátor beállítása
				conn = new ServiceClient(); //iit még van csalás - csak a beégetett url-re cbServerUrl.Text);
				conn.Open();
				caMessageService.Add(conn.Connect());
				success = true;
			}
			catch (Exception ex)
			{
				caMessageService.Add(new caMessage() { text = ex.Message, type = caMessageType.Error });
			}
		}
		//Ha befejeződött a csatlakozás
		private void backgroundConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//Animáció leállítása
			progressBar.MarqueeAnimationSpeed = 0;
			progressBar.Value = 0;

			//Főablaknak a kapcsolat átadása
			if (success)
			{
				p.OnlineControl(conn);
				this.Close();
				this.Dispose();
			}
			else
			{
				//Hiba esetén hibaüzenet, ha nincs nyitva
				if (!(conn.State == System.ServiceModel.CommunicationState.Opened))
				{
					caMessageService.Add(new caMessage() { text = "Connection failed" });
				}
			}

			OnlineControl();
		}

		//Felület beállítása az objektumok állapota alapján
		private void OnlineControl()
		{
			bool online = (conn.State == System.ServiceModel.CommunicationState.Opened);
			btConnect.Enabled = !online;
			btDisconnect.Enabled = online;

		}

		//Kapcsolat bontása kattintásra
		private void btDisconnect_Click(object sender, EventArgs e)
		{
			try
			{
				conn.Close();
				caMessageService.Add(new caMessage() { text = "Connection closed" });
			}
			catch { }
			OnlineControl();
		}
	}
}

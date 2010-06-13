using System;
using System.Windows.Forms;
using caClient.Forms;
using caClient.caServiceReference;
using caCoreLibrary;

namespace caClient
{
	/// <summary>
	/// ÁLtalános kliens oldali közös ablakkezelési eljárások
	/// </summary>

	class caForm
	{
		//Adott ablak beállítása a főablak MDI gyermekének
		public static Form MakeMDIChild(Form parent, Form f)
		{
			f.MdiParent = parent;
			f.WindowState = FormWindowState.Maximized;
			f.Show();
			return f;
		}

		//Résztvevő tulajdonságainak megnyitása	
		public static FormParticipant OpenParticipantForm(ServiceClient conn, caParticipantObject po)
		{
			FormParticipant fp;
			if (po != null) fp = new FormParticipant(po);
			else fp = new FormParticipant();

			fp.conn = conn;
			fp.Show();

			return fp;
		}

		//Résztvevő cserélő eszköz megnyitása
		public static FormParticipantRelpaceTool OpenParticipantReplaceTool(ServiceClient conn, caParticipantObject po)
		{
			if (po != null)
			{
				FormParticipantRelpaceTool fp = new FormParticipantRelpaceTool(conn, po);
				fp.Show();
				return fp;
			}
			else return null;
		}
	}
}

using System;
using System.Windows.Forms;
using caClient.Forms;
using caClient.caServiceReference;
using caCoreLibrary;

namespace caClient
{
	class caForm
	{
		public static Form MakeMDIChild(Form parent, Form f)
		{
			f.MdiParent = parent;
			f.WindowState = FormWindowState.Maximized;
			f.Show();
			return f;
		}

		public static FormParticipant OpenParticipantForm(ServiceClient conn, caParticipantObject po)
		{
			FormParticipant fp;
			if (po != null) fp = new FormParticipant(po);
			else fp = new FormParticipant();

			fp.conn = conn;
			fp.Show();

			return fp;
		}

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

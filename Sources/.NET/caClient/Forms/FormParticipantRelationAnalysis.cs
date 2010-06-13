using System;
using System.Collections.Generic;
using System.Windows.Forms;

using caCoreLibrary;
using caClient;
using caGraphLibrary;
using caClient.caServiceReference;


namespace caClient.Forms
{
	//Kapcsolati háló elemző kliens oldali ablak
	public partial class FormParticipantRelationAnalysis : Form
	{
		//Kapcsolat obj
		ServiceClient conn = null;
		//SQL Lekérdezést tároló string
		String querySql = null;

		//Eredményhalmaz
		public List<caRelationAnalysisResult> queryResults = new List<caRelationAnalysisResult>();
		//Résztvevők gyorsítótárazott listája
		public caParticipantObjectList participantList = new caParticipantObjectList();
		//Ábrázolandó modell
		public caSubCommItemObjectList subcommList = new caSubCommItemObjectList();

		//KOnsruktok a kapcsolat átvételére
		public FormParticipantRelationAnalysis(ServiceClient _conn)
		{
			InitializeComponent();
			conn = _conn;
		}

		//Lekérdezés SQL generálása az űrlap mezők alapján
		public string GenerateQueryFromSearchOptions()
		{
			/*
			 SELECT P0.PARTICIPANT_ID FROM_ID, P0.name FROM_NAME, p0.primary_group FROM_GROUP, P1.PARTICIPANT_ID TO_ID, P1.NAME TO_NAME, p1.primary_group TO_GROUP, count(c.ID) TIMES
			 FROM cad_participant P0, cad_participant P1, cad_subcomm C
			 WHERE  c.from_participant = p0.participant_id and C.to_participant = p1.participant_id and lower(p0.name) like '%kos%' GROUP BY P0.PARTICIPANT_ID, P0.name , p0.primary_group , P1.PARTICIPANT_ID , P1.NAME , p1.primary_group having count(c.id)>1
			 */

			//PF = from, PT = to, SC = subcomm

			//Statikus részek
			String qHeader = "SELECT PF.PARTICIPANT_ID FROM_ID, PF.name FROM_NAME, PF.primary_group FROM_GROUP, PT.PARTICIPANT_ID TO_ID, PT.NAME TO_NAME, PT.primary_group TO_GROUP, count(SC.SUBCOMM_ID) TIMES";
			String qFrom = "FROM cad_participant PF, cad_participant PT, cad_subcomm SC";
			String qWhereSys = "WHERE";
			String qWhereUser = "";
			String qGroupSys = "GROUP BY PF.PARTICIPANT_ID, PF.name , PF.primary_group , PT.PARTICIPANT_ID , PT.NAME , PT.primary_group";
			String qGroupUser = "HAVING count(SC.SUBCOMM_ID)>" + numWeight.Value.ToString();

			//HIerarchikus feltételek felépítése
			caConditionItem c = new caConditionItem("AND", "()");
			c.First = true;
			c.SubCondition.Add(new caConditionItem("AND", "(SC.from_participant = PF.participant_id and SC.to_participant = PT.participant_id)"));
			//c.SubCondition.Add(new caConditionItem("AND", "SC.SENT_TIME>=to_date('" + searchForm.After.ToString("yyyy.MM.dd") + "', 'yyyy.mm.dd')"));
			//c.SubCondition.Add(new caConditionItem("AND", "SC.DATE_KEY>='" + searchForm.After.ToString("yyyyMMdd") + "'"));
			//c.SubCondition.Add(new caConditionItem("AND", "SC.SENT_TIME<=to_date('" + searchForm.Before.ToString("yyyy.MM.dd") + "', 'yyyy.mm.dd')"));
			//c.SubCondition.Add(new caConditionItem("AND", "SC.DATE_KEY<='" + searchForm.Before.ToString("yyyyMMdd") + "'"));

			c.SubCondition.Add(new caConditionItem("AND", "SC.DATE_KEY BETWEEN " + searchForm.After.ToString("yyyyMMdd") + " AND " + searchForm.Before.ToString("yyyyMMdd")));




			//Csoportok kibontása
			caParticipantObjectList expFrom = searchForm.FromList;
			caParticipantObjectList expTo = searchForm.ToList;

			if (searchForm.ExpandGrp)
			{
				expFrom = caClientService.ExpandParticipantGroup(conn, expFrom);
				expTo = caClientService.ExpandParticipantGroup(conn, expTo);
			}

			//Participant feltételek
			caConditionItem cPart = new caConditionItem("AND", "()");
			if (!searchForm.AmongFromTo)
			{
				//Közöttük kapcsolat - bárhogy OR

				caConditionItem cFrom = new caConditionItem("OR", "()");
				foreach (caParticipantObject po in expFrom)
				{
					caConditionItem cf = new caConditionItem();
					cf.Bind = "OR";
					cf.Condition = "SC.FROM_PARTICIPANT='" + po.m_participantId + "'";
					//vagy ide csoportfeltétel - membership dátum alapján
					cFrom.SubCondition.Add(cf);

				}
				cPart.SubCondition.Add(cFrom);

				caConditionItem cTo = new caConditionItem("OR", "()");
				foreach (caParticipantObject po in expTo)
				{
					caConditionItem cf = new caConditionItem();
					cf.Bind = "OR";
					cf.Condition = "SC.TO_PARTICIPANT='" + po.m_participantId + "'";
					cTo.SubCondition.Add(cf);

				}
				cPart.SubCondition.Add(cTo);
			}
			else
			{
				//MInden párosítás csak közöttük AND


				foreach (caParticipantObject pof in expFrom)
				{

					caConditionItem cFr = new caConditionItem();
					cFr.Bind = "AND";
					cFr.Condition = "SC.FROM_PARTICIPANT='" + pof.m_participantId + "'";

					foreach (caParticipantObject pot in expTo)
					{
						caConditionItem cAmong = new caConditionItem("OR", "()");
						caConditionItem cTo = new caConditionItem();
						cTo.Bind = "AND";
						cTo.Condition = "SC.TO_PARTICIPANT='" + pot.m_participantId + "'";

						cAmong.SubCondition.Add(cFr);
						cAmong.SubCondition.Add(cTo);

						cPart.SubCondition.Add(cAmong);
					}

				}

			}

			c.SubCondition.Add(cPart);

			//Tag feltételek hozzáadása
			if (searchForm.Tags.Count > 0) //Ha van kiválasztva
			{
				qFrom += ", CAD_TAG T";
				caConditionItem cTag2Comm = new caConditionItem("AND", "SC.COMM_ID=T.COMM_ID");

				caConditionItem cTags = new caConditionItem("AND", "()");
				foreach (String s in searchForm.Tags)
				{
					caConditionItem cOneTag = new caConditionItem("OR", "T.TAG_ID='" + s + "'");
					cTags.SubCondition.Add(cOneTag);
				}
				c.SubCondition.Add(cTag2Comm);
				c.SubCondition.Add(cTags);
			}

			qWhereUser = c.ToString();

			return qHeader + " " + qFrom + " " + qWhereSys + " " + qWhereUser + " " + qGroupSys + " " + qGroupUser;
		}

		//Lekérdezés futtatása és eredményhalmaz lekérése
		private void GenerateResultsFromQuery(String _querySql)
		{
			queryResults.Clear();
			dgResults.DataSource = null;
			//dg_results.Invalidate();

			try
			{
				//caDatabaseService dm = new caDatabaseService();
				//queryResults = dm.GetParticipantRelationAnalysisResultList(_querySql);
				queryResults = caClientService.GetParticipantRelationAnalysisResultList(conn, _querySql);
				dgResults.DataSource = queryResults;

				//cache_part = new caParticipantObjectList();
				subcommList = new caSubCommItemObjectList();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		//Eredményhalmazból ábrázolható osztállyá alakítás
		private void GenerateCommModelFromResults(List<caRelationAnalysisResult> rl)
		{
			foreach (caRelationAnalysisResult r in rl)
			{
				//Felhasználók beolvasása gyorsítóttárból, vagy használat a cache-ből
				caParticipantObject from = caClientService.UseOrLoadParticipant(conn, participantList, r.m_fromId);
				caParticipantObject to = caClientService.UseOrLoadParticipant(conn, participantList, r.m_toId);

				//Gorupok a cache-be
				caParticipantObject fromGroup = caClientService.UseOrLoadParticipant(conn, participantList, r.m_fromGroup);
				from.m_groupList.AddIdentical(fromGroup);
				caParticipantObject toGroup = caClientService.UseOrLoadParticipant(conn, participantList, r.m_toGroup);
				to.m_groupList.AddIdentical(toGroup);

				//konverzáció felépítése
				caSubCommItemObject c = new caSubCommItemObject();
				c.m_fromParticipant = from;
				c.m_toParticipant = to;
				c.m_times = r.m_times;

				subcommList.Add(c);
			}
		}

		//Ábrázolás a komm. modellből
		private void DrawGraphFromCommModel()
		{
			caRelationGraph1.m_commItemObjectList = subcommList;
			caRelationGraph1.createGraph();
		}
		//Résztvevők listájának frissítése a gyorsítótárból
		private void RefreshCacheUI()
		{
			ptCache.ParticipantList = participantList;
		}
		//Kattintás a keresés gombra
		private void bt_search_Click(object sender, EventArgs e)
		{
			//Query összeállítás és kiírás
			querySql = GenerateQueryFromSearchOptions();
			txQuery.Text = querySql;

			//Lefuttatás és eredmény kiírása és cache frissítése
			GenerateResultsFromQuery(querySql);

			//Comm Modell generálása
			GenerateCommModelFromResults(queryResults);
			RefreshCacheUI();

			//Vizualizálás
			tabControl.SelectTab(tpVisualization);
			tpVisualization.Show();
			DrawGraphFromCommModel();

		}

		//Kattintás a lekérdezés gombra - manuálisan megadott lekérdezésekhez
		private void btQuery_Click(object sender, EventArgs e)
		{
			//SAját query futtatása kírása és cache
			GenerateResultsFromQuery(querySql);
			RefreshCacheUI();

			//Manuális innentől
		}

		//Ábrázolható objektum generálása az eredményhalmazból
		private void btCreateCommModel_Click(object sender, EventArgs e)
		{
			GenerateCommModelFromResults(queryResults);
		}
		
		//Irányítás ki- és bekapcsolása
		private void chkDirection_CheckedChanged(object sender, EventArgs e)
		{
			caRelationGraph1.ShowDirection = chkDirection.Checked;
			caRelationGraph1.createGraph();
		}

		//Csak csoportok mutatása
		private void btGroupsOnly_Click(object sender, EventArgs e)
		{
			caRelationGraph1.DisplayAllNodeAs(caRelationGraphNodeTypeDisplayMode.GroupsOnly);
		}

		//Csak felhasználók mutatása
		private void btUsersOnly_Click(object sender, EventArgs e)
		{
			caRelationGraph1.DisplayAllNodeAs(caRelationGraphNodeTypeDisplayMode.UsersOnly);
		}

		//Újra kirajzolás kattintásra
		private void btRedraw_Click(object sender, EventArgs e)
		{
			DrawGraphFromCommModel();
		}


	}
}

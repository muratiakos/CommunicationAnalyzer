using System;
using System.Windows.Forms;
using caClient.caServiceReference;
using System.Collections.Generic;
using caCoreLibrary;
//using caDataAccessLayer;

namespace caClient.Forms
{
	//Ügymenet felderítés kliens osztálya
	public partial class FormFlowAnalysis : Form
	{
		//Kapcsolat objektuma
		ServiceClient conn = null;

		//Alap-  és szintnként bővülő SQL lekérdezés
		String queryBase = null;
		String queryFlow = null;

		//Éppen aktuális folyamszint
		Int32 flowLevel = 0;

		//Gyorsítótárazott Kommunikációs tények
		public List<String> cacheCommId = new List<String>();
		public List<String> cachePreviousCommId = new List<String>();

		//Alap- és szintenként bővített eredménylisták
		public List<caFlowAnalysisResult> resultsBase = new List<caFlowAnalysisResult>();
		public List<caFlowAnalysisResult> resultsFlow = new List<caFlowAnalysisResult>();

		//Ábrázolandó kommunikációs modell (kézbesítések tényei)
		public caSubCommItemObjectList model = new caSubCommItemObjectList();


		//Alap SQL lekérdezések stringje
		String qHeader = "SELECT DISTINCT SC.SUBCOMM_ID, SC.SENT_TIME, SC.RECEIVED_TIME, SC.COMM_ID, SC.PREV_COMM_ID,  PF.PARTICIPANT_ID FROM_ID, PF.name FROM_NAME, PT.PARTICIPANT_ID TO_ID, PT.NAME TO_NAME";
		String qFrom = "FROM cad_participant PF, cad_participant PT, cad_subcomm SC";
		String qWhereSys = "WHERE";
		String qGroupSys = "ORDER BY SC.RECEIVED_TIME";

		//Inicializáló konstruktor - kapcsolat átvétele a fő formtól
		public FormFlowAnalysis(ServiceClient _conn)
		{
			InitializeComponent();
			conn = _conn;
		}

		//Felület frissítése az objektumok állapota alapján
		private void RefreshUI()
		{
			//Textbox
			txFlowQuery.Text = queryFlow;

			//Labelek
			lbBaseCount.Text = resultsBase.Count.ToString();
			lbLevel.Text = "Result Level: " + (flowLevel - 1).ToString();
			lbFlowCount.Text = resultsFlow.Count.ToString();

			//Datagridek
			dgBaseResults.DataSource = resultsBase;
			dgBaseResults.Refresh();

			dgFlowResults.DataSource = resultsFlow;
			dgFlowResults.Refresh();

			//Vizualizáció
			GenerateCommModelFromFlowResults(resultsFlow);
			caCommFlow1.CommList = model;
			caCommFlow1.DrawGraph();
		}

		//Alap lekérdezés generálása a keresőfelület alapján
		public string GenerateBaseQuery()
		{
			flowLevel = 0;
			//PF = from, PT = to, SC = subcomm, T = tag

			String qWhereUser = "";
			String qGroupUser = "";

			//Hierarchikus feltétel felépítés
			caConditionItem c = new caConditionItem("AND", "()");
			c.First = true;
			c.SubCondition.Add(new caConditionItem("AND", "(SC.from_participant = PF.participant_id and SC.to_participant = PT.participant_id)"));
			c.SubCondition.Add(new caConditionItem("AND", "SC.DATE_KEY BETWEEN " + searchForm.After.ToString("yyyyMMdd") + " AND " + searchForm.Before.ToString("yyyyMMdd")));
			//c.SubCondition.Add(new caConditionItem("AND", "SC.SENT_TIME>=to_date('" + searchForm.After.ToString("yyyy.MM.dd") + "', 'yyyy.mm.dd')"));			
			//c.SubCondition.Add(new caConditionItem("AND", "SC.SENT_TIME<=to_date('" + searchForm.Before.ToString("yyyy.MM.dd") + "', 'yyyy.mm.dd')"));



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
				//Közöttük lévő kapcsolat feltételek - bárhogy OR

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

		//Következő szintű bővítő SQL lekérdezés generálása
		public string GenerateNextFlowWidenQueryFromCache()
		{
			//PF = from, PT = to, SC = subcomm, T = tag
			flowLevel++;

			String qWhereUser = "";
			String qGroupUser = "";

			//Csak dátumintervallumra szűrünk
			caConditionItem c = new caConditionItem("AND", "()");
			c.First = true;
			c.SubCondition.Add(new caConditionItem("AND", "(SC.from_participant = PF.participant_id and SC.to_participant = PT.participant_id)"));
			c.SubCondition.Add(new caConditionItem("AND", "SC.SENT_TIME>=to_date('" + searchForm.After.ToString("yyyy.MM.dd") + "', 'yyyy.mm.dd')"));
			c.SubCondition.Add(new caConditionItem("AND", "SC.SENT_TIME<=to_date('" + searchForm.Before.ToString("yyyy.MM.dd") + "', 'yyyy.mm.dd')"));

			//Feltételek Tágítása - további lehetőség felvétele
			caConditionItem cBasePrePost = new caConditionItem("AND", "()");

			//Előzmények betöltése
			foreach (String s in cachePreviousCommId)
			{
				if (!String.IsNullOrEmpty(s))
				{
					caConditionItem cPre = new caConditionItem("OR", "SC.COMM_ID='" + caConvert.ManyToOneMessageId(s) + "'");
					cBasePrePost.SubCondition.Add(cPre);
				}
			}

			//Eddigiek és az azt Követők betöltése
			foreach (String s in cacheCommId)
			{
				if (!String.IsNullOrEmpty(s))
				{
					caConditionItem cBase = new caConditionItem("OR", "SC.COMM_ID='" + caConvert.ManyToOneMessageId(s) + "'");
					cBasePrePost.SubCondition.Add(cBase);

					caConditionItem cPost = new caConditionItem("OR", "SC.PREV_COMM_ID='" + caConvert.ManyToOneMessageId(s) + "'");
					cBasePrePost.SubCondition.Add(cPost);
				}
			}

			c.SubCondition.Add(cBasePrePost);
			qWhereUser = c.ToString();

			//Összes feltétel összefűzése
			return qHeader + " " + qFrom + " " + qWhereSys + " " + qWhereUser + " " + qGroupSys + " " + qGroupUser;
		}

		//Gyorsítótár építése
		private void BuildCache(List<caFlowAnalysisResult> resultList)
		{
			cacheCommId = new List<string>();
			cachePreviousCommId = new List<string>();
			
			//Casche bővítése az új tételekkel
			cacheCommId = resultList.ConvertAll(new Converter<caFlowAnalysisResult, String>(delegate(caFlowAnalysisResult r) { return r.m_commId; }));
			cachePreviousCommId = resultList.ConvertAll(new Converter<caFlowAnalysisResult, String>(delegate(caFlowAnalysisResult r) { return r.m_previousCommId; }));

			cacheCommId.Remove("");
			cachePreviousCommId.Remove("");
		}

		//Lekérdezés futtatása és eredmnyek lekérdezése a szervertől
		private List<caFlowAnalysisResult> GenerateResultsAndRebuildCache(String query)
		{
			List<caFlowAnalysisResult> rl = new List<caFlowAnalysisResult>();
			try
			{
				rl = caClientService.GetFlowAnalysisResultList(conn, query);
			}
			catch { }

			BuildCache(rl);
			return rl;
		}

		//Ábrázolandó kommunikációs kapcsolatok generálása
		private void GenerateCommModelFromFlowResults(List<caFlowAnalysisResult> ar)
		{
			model = new caSubCommItemObjectList();
			caParticipantObjectList participantList = new caParticipantObjectList();

			foreach (caFlowAnalysisResult r in ar)
			{
				caParticipantObject _from = new caParticipantObject(r.m_fromId, r.m_fromName);
				caParticipantObject _to = new caParticipantObject(r.m_toId, r.m_toName);

				//Group-okat is kreálni kell!!

				//felhasználókat cache-be
				caParticipantObject from = participantList.AddIdentical(_from);
				caParticipantObject to = participantList.AddIdentical(_to);

				//konverzáció felépítése
				caSubCommItemObject c = new caSubCommItemObject();
				c.m_subcommId = r.m_subcommId;
				c.m_commId = r.m_commId;
				c.m_previousCommId = r.m_previousCommId;
				c.m_times = 1;
				c.m_delay = 0; // adatbázis vagy objektum

				c.m_fromParticipant = from;
				c.m_toParticipant = to;

				c.m_sentTime = r.m_sentTime;
				c.m_receivedTime = r.m_receivedTime;

				model.Add(c);
			}
		}

		//Kattintás a keresés gombra
		private void btSearch_Click(object sender, EventArgs e)
		{
			//1A lépés első keresés Query generálása
			queryBase = GenerateBaseQuery();
			txBaseQuery.Text = queryBase;

			//1B Basequery futtatása, cache legenerálása
			resultsBase = GenerateResultsAndRebuildCache(queryBase);

			//2A - első flowbővítés query-je előkészítés
			queryFlow = GenerateNextFlowWidenQueryFromCache();

			//2B Flow mélyítés a következő generálás query generálása annyiszor, ahányszor kérjük
			for (int i = 0; i < numWeight.Value; i++)
			{
				resultsFlow = GenerateResultsAndRebuildCache(queryFlow);
				queryFlow = GenerateNextFlowWidenQueryFromCache();

			}

			RefreshUI();

			tabControl.SelectTab(tpQueryResults);
		}


		//Lekérdezés gomb megnyomása - ha kézzel megadott SQL futtatna
		private void btQuery_Click(object sender, EventArgs e)
		{
			//1A - Saját generálás
			flowLevel = 0;

			//1B - futtatás
			resultsBase = GenerateResultsAndRebuildCache(txBaseQuery.Text);
			queryFlow = GenerateNextFlowWidenQueryFromCache();

			//... Manuális

			RefreshUI();
		}

		//Lekérdezés bővítése egy újabb szinttel
		private void btWidenFlow_Click(object sender, EventArgs e)
		{
			//2B - Manuális bővítés
			if (!String.IsNullOrEmpty(queryFlow))
			{
				resultsFlow = GenerateResultsAndRebuildCache(queryFlow);
				queryFlow = GenerateNextFlowWidenQueryFromCache();
			}

			RefreshUI();
		}

		//Lekérdezés futtatása és felület frissítése
		private void btExecuteFlowQuery_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(queryFlow))
			{
				resultsFlow = GenerateResultsAndRebuildCache(queryFlow);
			}
			RefreshUI();
		}

		//Felület frissítése gombnyomásra
		private void btRedraw_Click(object sender, EventArgs e)
		{
			RefreshUI();
		}



	}
}

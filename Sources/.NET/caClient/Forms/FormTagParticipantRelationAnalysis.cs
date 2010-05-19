﻿using System;
using caClient.caServiceReference;
using caCoreLibrary;
using System.Collections.Generic;
using caGraphLibrary;
using System.Windows.Forms;

namespace caClient.Forms
{
	public partial class FormTagParticipantRelationAnalysis : Form
	{

		ServiceClient conn = null;
		String querySql = null;

		public List<caTagParticipantAnalysisResult> queryResults = new List<caTagParticipantAnalysisResult>();
		public caParticipantObjectList participantList = new caParticipantObjectList();
		public caSubCommItemObjectList subcommList = new caSubCommItemObjectList();

		public FormTagParticipantRelationAnalysis(ServiceClient _conn)
		{
			InitializeComponent();
			conn = _conn;
		}

		public string GenerateQueryFromSearchOptions()
		{
			/*

			SELECT DISTINCT
		T.TAG_ID, 
		P0.PARTICIPANT_ID FROM_ID, p0.primary_group FROM_GROUP,
		P1.PARTICIPANT_ID TO_ID, p1.primary_group TO_GROUP

		FROM cad_participant P0, cad_participant P1, cad_subcomm SC, cad_tag T

		WHERE
		SC.from_participant = p0.participant_id
		and SC.to_participant = p1.participant_id
		and SC.COMM_ID = T.COMM_ID			 */

			//PF = from, PT = to, SC = subcomm



			String qHeader = "SELECT COUNT(T.TAG_ID) TIMES,  T.TAG_ID, PF.PARTICIPANT_ID FROM_ID, PF.primary_group FROM_GROUP, PT.PARTICIPANT_ID TO_ID, PT.primary_group TO_GROUP";
			String qFrom = "FROM cad_participant PF, cad_participant PT, cad_subcomm SC, cad_tag T";
			String qWhereSys = "WHERE";
			String qWhereUser = "";
			String qGroupSys = "GROUP BY T.TAG_ID, PF.PARTICIPANT_ID, PF.primary_group, PT.PARTICIPANT_ID, PT.primary_group";
			String qGroupUser = "HAVING count(T.TAG_ID)>" + numWeight.Value.ToString();


			caConditionItem c = new caConditionItem("AND", "()");
			c.First = true;
			c.SubCondition.Add(new caConditionItem("AND", "(SC.from_participant = PF.participant_id and SC.to_participant = PT.participant_id and SC.COMM_ID = T.COMM_ID)"));
			c.SubCondition.Add(new caConditionItem("AND", "SC.DATE_KEY BETWEEN " + searchForm.After.ToString("yyyyMMdd") + " AND " + searchForm.Before.ToString("yyyyMMdd")));




			//Expand group
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
				//Közöttük bárhogy OR

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
				//qFrom += ", CAD_TAG T";
				//caConditionItem cTag2Comm = new caConditionItem("AND", "SC.COMM_ID=T.COMM_ID");

				caConditionItem cTags = new caConditionItem("AND", "()");
				foreach (String s in searchForm.Tags)
				{
					caConditionItem cOneTag = new caConditionItem("OR", "T.TAG_ID='" + s + "'");
					cTags.SubCondition.Add(cOneTag);
				}
				//c.SubCondition.Add(cTag2Comm);
				c.SubCondition.Add(cTags);
			}

			qWhereUser = c.ToString();

			return qHeader + " " + qFrom + " " + qWhereSys + " " + qWhereUser + " " + qGroupSys + " " + qGroupUser;
		}

		private void GenerateResultsFromQuery(String _querySql)
		{
			queryResults.Clear();
			dgResults.DataSource = null;
			//dg_results.Invalidate();

			try
			{
				//caDatabaseService dm = new caDatabaseService();
				//queryResults = dm.GetTagParticipantRelationAnalysisResultList(_querySql);
				queryResults = caClientService.GetTagParticipantAnalysisResultList(conn, _querySql);
				dgResults.DataSource = queryResults;

				//cache_part = new caParticipantObjectList();
				subcommList = new caSubCommItemObjectList();

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void GenerateCommModelFromResults(List<caTagParticipantAnalysisResult> rl)
		{
			foreach (caTagParticipantAnalysisResult r in rl)
			{
				//caParticipantObject _from = new caParticipantObject(r.m_fromId, r.m_fromId);
				//caParticipantObject _to = new caParticipantObject(r.m_toId, r.m_toId);

				//felhasználókat cache-be
				//caParticipantObject from = participantList.AddIdentical(_from);
				//caParticipantObject to = participantList.AddIdentical(_to);

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
				c.m_threadId = r.m_tagId;

				subcommList.Add(c);
			}
		}

		private void DrawGraphFromCommModel()
		{
			caTagParticipant1.m_commItemObjectList = subcommList;
			caTagParticipant1.createGraph();
		}
		private void RefreshCacheUI()
		{
			ptCache.ParticipantList = participantList;
		}

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

		private void btQuery_Click(object sender, EventArgs e)
		{
			//SAját query futtatása kírása és cache
			GenerateResultsFromQuery(querySql);
			RefreshCacheUI();

			//Manuális innentől
		}

		private void btCreateCommModel_Click(object sender, EventArgs e)
		{
			GenerateCommModelFromResults(queryResults);
		}

		private void chkDirection_CheckedChanged(object sender, EventArgs e)
		{
			caTagParticipant1.ShowDirection = chkDirection.Checked;
			caTagParticipant1.createGraph();
		}

		private void btGroupsOnly_Click(object sender, EventArgs e)
		{
			caTagParticipant1.DisplayAllNodeAs(caRelationGraphNodeTypeDisplayMode.GroupsOnly);
		}

		private void btUsersOnly_Click(object sender, EventArgs e)
		{
			caTagParticipant1.DisplayAllNodeAs(caRelationGraphNodeTypeDisplayMode.UsersOnly);
		}

		private void btRedraw_Click(object sender, EventArgs e)
		{
			DrawGraphFromCommModel();
		}

		private void btSearch_Click(object sender, EventArgs e)
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
	}
}

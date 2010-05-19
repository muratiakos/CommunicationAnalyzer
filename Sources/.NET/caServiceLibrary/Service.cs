using System;
using System.Runtime.Serialization;
using System.ServiceModel;

using caDataAccessLayer;
using caCoreLibrary;
using System.Collections.Generic;
using System.Threading;

namespace caServiceLibrary
{
	public class Service : IService
	{
		#region IService Members

		public caMessage Connect()
		{
			try
			{
				caDatabaseService ds = new caDatabaseService();
				Thread.Sleep(2000);
			}
			catch (Exception ex)
			{
				return new caMessage() { type = caMessageType.Error, text = ex.Message };

			}

			return new caMessage() { text = "Successfully connected" };
		}

		public List<caParticipant> LoadParticipantList()
		{
			caDatabaseService dm = new caDatabaseService();
			List<caParticipant> results = dm.LoadParticipantRecordList("");
			return results;
		}

		public caParticipant LoadParticipant(string _participantId)
		{
			caDatabaseService dm = new caDatabaseService();
			caParticipant p = dm.LoadParticipantRecord(_participantId);
			return p;
		}

		public List<caParticipant> LoadParticipantGroups(string _participantId)
		{
			caDatabaseService dm = new caDatabaseService();
			List<caParticipant> results = dm.LoadParticipantRecordList(", CAD_PARTICIPANTRELATION R WHERE P.PARTICIPANT_ID=R.GROUP_ID AND R.USER_ID='" + _participantId + "'");
			return results;
		}

		public List<caParticipant> LoadParticipantMembers(string _participantId)
		{
			caDatabaseService dm = new caDatabaseService();
			List<caParticipant> results = dm.LoadParticipantRecordList(", CAD_PARTICIPANTRELATION R WHERE P.PARTICIPANT_ID=R.USER_ID AND R.GROUP_ID='" + _participantId + "'");
			return results;
		}

		public caParticipant SaveParticipant(caParticipant actualP)
		{
			caDatabaseService dm = new caDatabaseService();
			caParticipant results = dm.SaveParticipantRecord(actualP);
			return results;
		}

		public List<caParticipant> SaveParticipantGroups(string _participantId, List<string> groups)
		{
			caDatabaseService dm = new caDatabaseService();
			dm.SaveParticipantRelationRecordList(_participantId, groups, caParticipantType.User);

			return null;
		}

		public List<caParticipant> SaveParticipantMembers(string _participantId, List<string> members)
		{
			caDatabaseService dm = new caDatabaseService();
			dm.SaveParticipantRelationRecordList(_participantId, members, caParticipantType.Group);

			return null;
		}

		public List<caParticipantAddress> LoadParticipantAddress(string _participantId)
		{
			caDatabaseService dm = new caDatabaseService();
			return dm.LoadParticipantAddressRecordList(_participantId);
		}

		public List<caParticipantAddress> SaveParticipantAddress(string _participantId, List<caParticipantAddress> address)
		{
			caDatabaseService dm = new caDatabaseService();
			dm.SaveParticipantAddressRecordList(_participantId, address);

			return null;
		}


		public List<caTaggingRule> LoadTaggingRuleList()
		{
			caDatabaseService dm = new caDatabaseService();
			return dm.LoadTaggingRuleRecordList("");
		}

		public caTaggingRule LoadTaggingRule(string _ruleId)
		{
			caDatabaseService dm = new caDatabaseService();
			List<caTaggingRule> trl = new List<caTaggingRule>();
			try
			{
				trl = dm.LoadTaggingRuleRecordList("WHERE RULE_ID='" + _ruleId + "'");
			}
			catch { }

			if (trl.Count > 0) return trl[0];
			else return null;

		}

		public caTaggingRule SaveTaggingRule(caTaggingRule tr)
		{
			caDatabaseService dm = new caDatabaseService();
			if (dm.SaveTaggingRuleRecord(tr)) return tr;
			else return null;
		}

		public caMessage RunTaggingRule(string _ruleId)
		{
			caMessage feedback = new caMessage();
			caTaggingRule tr = LoadTaggingRule(_ruleId);
			if (tr != null)
			{
				String innerSql = "";
				if (tr.Custom_Query) innerSql = String.Format(tr.Query, tr.Tag);
				else innerSql = String.Format("SELECT DISTINCT C.COMM_ID, '{0}' as tag FROM CAD_COMM C WHERE {1}", tr.Tag, tr.Query);

				String sql = String.Format("INSERT INTO CAD_TAG (COMM_ID, TAG_ID) ( {0} )", innerSql);

				caDatabaseService ds = new caDatabaseService();
				int i = ds.ExecuteNonQuery(sql);

				feedback = new caMessage() { text = i.ToString() + " communication item have been tagged with " + tr.Tag };
			}
			else feedback = new caMessage() { text = "Tagging rule doesn't exist " + _ruleId, type = caMessageType.Warning };
			return feedback;
		}


		public caMessage DeleteTag(string _tag)
		{
			caMessage feedback = new caMessage();
			String sql = String.Format("DELETE FROM CAD_TAG WHERE TAG_ID='{0}'", _tag);
			caDatabaseService ds = new caDatabaseService();
			int i = ds.ExecuteNonQuery(sql);
			feedback = new caMessage() { text = i.ToString() + " " + _tag + " tags have been deleted." };
			//HIbavizsgálat
			return feedback;
		}


		public caMessage ReplaceParticipant(string _fromPID, string _toPID)
		{
			caMessage feedback = new caMessage();

			caParticipant pFrom = LoadParticipant(_fromPID);
			caParticipant pTo = LoadParticipant(_toPID);

			if (pFrom != null && pTo != null)
			{

				String rP = String.Format("UPDATE CAD_PARTICIPANT SET STATUS='3' WHERE PARTICIPANT_ID='{0}'", _fromPID);
				String rPAddress = String.Format("UPDATE CAD_PARTICIPANTADDRESS SET PARTICIPANT_ID='{1}' WHERE PARTICIPANT_ID='{0}'", _fromPID, _toPID);
				String rPGroups = String.Format("UPDATE CAD_PARTICIPANTRELATION SET USER_ID='{1}' WHERE USER_ID='{0}'", _fromPID, _toPID);
				String rPMembers = String.Format("UPDATE CAD_PARTICIPANTRELATION SET GROUP_ID='{1}' WHERE GROUP_ID='{0}'", _fromPID, _toPID);
				String rSubCommFrom = String.Format("UPDATE CAD_SUBCOMM SET FROM_PARTICIPANT='{1}' WHERE FROM_PARTICIPANT='{0}'", _fromPID, _toPID);
				String rSubCommTo = String.Format("UPDATE CAD_SUBCOMM SET TO_PARTICIPANT='{1}' WHERE TO_PARTICIPANT='{0}'", _fromPID, _toPID);

				try
				{
					caDatabaseService ds = new caDatabaseService();
					ds.ExecuteNonQuery(rP);
					ds.ExecuteNonQuery(rPAddress);
					ds.ExecuteNonQuery(rPGroups);
					ds.ExecuteNonQuery(rPMembers);
					ds.ExecuteNonQuery(rSubCommFrom);
					ds.ExecuteNonQuery(rSubCommTo);
				}
				catch (Exception ex)
				{ feedback = new caMessage() { text = "Replace Error:" + ex.Message, type = caMessageType.Error }; }

			}
			else feedback = new caMessage() { text = "Replace failed: Participant doesn't exist.", type = caMessageType.Warning };
			return feedback;
		}

		public List<string> LoadTagList()
		{
			caDatabaseService ds = new caDatabaseService();
			return ds.LoadTagList();
		}


		public List<caMessage> GetMessages()
		{

			List<caMessage> ml = caMessageService.messageQueue;
			caMessageService.messageQueue.Clear();
			return ml;
		}

		public List<caRelationAnalysisResult> GetParticipantRelationAnalysisResultList(string query)
		{
			List<caRelationAnalysisResult> results = new List<caRelationAnalysisResult>();

			try
			{
				caDatabaseService dm = new caDatabaseService();
				results = dm.GetParticipantRelationAnalysisResultList(query);
			}
			catch (Exception ex) { caMessageService.AddException(ex); }

			return results;
		}

		public List<caFlowAnalysisResult> GetFlowAnalysisResultList(string query)
		{
			List<caFlowAnalysisResult> results = new List<caFlowAnalysisResult>();

			try
			{
				caDatabaseService dm = new caDatabaseService();
				results = dm.GetFlowAnalysisResultList(query);
			}
			catch (Exception ex) { caMessageService.AddException(ex); }

			return results;
		}

		public List<caTagParticipantAnalysisResult> GetTagParticipantAnalysisResultList(string query)
		{
			List<caTagParticipantAnalysisResult> results = new List<caTagParticipantAnalysisResult>();

			try
			{
				caDatabaseService dm = new caDatabaseService();
				results = dm.GetTagParticipantRelationAnalysisResultList(query);
			}
			catch (Exception ex) { caMessageService.AddException(ex); }

			return results;
		}

		#endregion
	}
}

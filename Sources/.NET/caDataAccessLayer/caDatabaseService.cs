using System;
using caCoreLibrary;
using Oracle.DataAccess.Client;
using System.Data;
using System.Collections.Generic;

namespace caDataAccessLayer
{
	public class caDatabaseService
	{
		//Változók
		private OracleConnection conn;

		//Konstruktor - destruktor
		public caDatabaseService()
		{
			String[] dbParams = new String[5];


			try
			{
				dbParams[0] = Properties.Settings.Default.dbHost;
				dbParams[1] = Properties.Settings.Default.dbPort;
				dbParams[2] = Properties.Settings.Default.dbSID;
				dbParams[3] = Properties.Settings.Default.dbUser;
				dbParams[4] = Properties.Settings.Default.dbPass;

				string connStr = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST="
											+ "(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))"
											+ "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));"
											+ "User Id={3};Password={4};", dbParams);

				conn = new OracleConnection(connStr);
				conn.Open();
			}
			catch (Exception ex)
			{
				caMessageService.AddException("constructor", ex);
			}
		}
		~caDatabaseService()
		{
			try
			{
				conn.Close();
				conn.Dispose();
			}
			catch (Exception ex)
			{
				caMessageService.AddException("destructor", ex);
			}
		}

		//Eljárások
		public int ExecuteNonQuery(String sql)
		{
			int retVal = 0;
			OracleCommand cmd = new OracleCommand();
			try
			{
				cmd.Connection = conn;
				cmd.CommandText = sql;
				cmd.CommandType = CommandType.Text;
				retVal = cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				retVal = -1;
				caMessageService.AddException("execute:" + sql, ex);
			}

			cmd.Dispose();
			return retVal;
		}

		public caParticipant LoadParticipantRecord(string _participantId)
		{
			caParticipant p = null;


			OracleCommand cmd = new OracleCommand();
			try
			{
				cmd.Connection = conn;
				cmd.CommandText = "SELECT * FROM CAD_PARTICIPANT WHERE PARTICIPANT_ID= :PID";
				cmd.CommandType = CommandType.Text;

				OracleParameter pid = new OracleParameter("PID", _participantId);
				pid.DbType = DbType.String;

				cmd.Parameters.Add(pid);

				OracleDataReader dr = cmd.ExecuteReader();
				if (dr.Read())
				{
					p = new caParticipant();

					p.m_participantId = dr["PARTICIPANT_ID"].ToString();
					p.m_name = dr["NAME"].ToString();
					p.m_foreignId = dr["FOREIGN_ID"].ToString();
					p.m_type = caConvert.StringToParticipantType(dr["TYPE"].ToString());
					p.m_status = caConvert.StringToRecordStatus(dr["STATUS"].ToString());
					p.m_primaryGroup = dr["PRIMARY_GROUP"].ToString();
				}

				dr.Dispose();
			}
			catch (Exception ex) { caMessageService.AddException(ex); }
			finally { cmd.Dispose(); }

			return p; //.ToArray();
		}

		public caParticipant SaveParticipantRecord(caParticipant actualP)
		{
			//Létezik-e?
			caParticipant oldP = null;
			try { oldP = LoadParticipantRecord(actualP.m_participantId); }
			catch { }
			bool update = (oldP != null);
			//Oracle conn.BeginTransaction();

			OracleCommand cmd = new OracleCommand();
			try
			{
				cmd.Connection = conn;
				if (update)
				{
					cmd.CommandText = "UPDATE CAD_PARTICIPANT SET NAME=:NAME, FOREIGN_ID=:FOREIGN_ID, TYPE=:TYPE, STATUS=:STATUS, PRIMARY_GROUP=:PRIMARY_GROUP WHERE PARTICIPANT_ID=:PARTICIPANT_ID";
				}
				else
				{
					cmd.CommandText = "INSERT INTO CAD_PARTICIPANT (PARTICIPANT_ID, NAME, FOREIGN_ID, TYPE, STATUS, PRIMARY_GROUP ) VALUES ( :PARTICIPANT_ID, :NAME, :FOREIGN_ID, :TYPE, :STATUS, :PRIMARY_GROUP )";
				}

				cmd.CommandType = CommandType.Text;
				cmd.BindByName = true;

				cmd.Parameters.Add(new OracleParameter() { ParameterName = "NAME", DbType = DbType.String, Value = actualP.m_name });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "FOREIGN_ID", DbType = DbType.String, Value = actualP.m_foreignId });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "TYPE", DbType = DbType.Int32, Value = (int)actualP.m_type });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "STATUS", DbType = DbType.Int32, Value = (int)actualP.m_status });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "PRIMARY_GROUP", DbType = DbType.String, Value = actualP.m_primaryGroup });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "PARTICIPANT_ID", DbType = DbType.String, Value = actualP.m_participantId });
				int i = cmd.ExecuteNonQuery();

				//cmd.CommandText = "COMMIT";
				//cmd.Parameters.Clear();
				//cmd.ExecuteNonQuery();
				//cmd.
			}
			catch { }

			cmd.Dispose();
			return actualP;

		}

		public List<caParticipant> LoadParticipantRecordList(string query)
		{
			List<caParticipant> results = new List<caParticipant>();

			OracleCommand cmd = new OracleCommand();
			try
			{
				cmd.Connection = conn;
				cmd.CommandText = "SELECT P.PARTICIPANT_ID, P.NAME, P.FOREIGN_ID, P.TYPE, P.STATUS, P.PRIMARY_GROUP FROM CAD_PARTICIPANT P " + query;
				cmd.CommandType = CommandType.Text;

				results.Clear();

				OracleDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					caParticipant p = new caParticipant();

					p.m_participantId = dr["PARTICIPANT_ID"].ToString();
					p.m_name = dr["NAME"].ToString();
					p.m_foreignId = dr["FOREIGN_ID"].ToString();
					p.m_type = caConvert.StringToParticipantType(dr["TYPE"].ToString());
					p.m_status = caConvert.StringToRecordStatus(dr["STATUS"].ToString());
					p.m_primaryGroup = dr["PRIMARY_GROUP"].ToString();

					results.Add(p);
				}

				dr.Dispose();
			}
			catch (Exception ex) { caMessageService.AddException(ex); }
			finally { cmd.Dispose(); }

			return results;
		}

		public List<caParticipant> SaveParticipantRelationRecordList(String _participantId, List<String> pl, caParticipantType pt)
		{
			OracleTransaction txn = conn.BeginTransaction(IsolationLevel.ReadCommitted);

			try
			{
				//Korábbiak törlése
				OracleCommand deleteOld = new OracleCommand();
				deleteOld.Connection = conn;
				deleteOld.CommandType = CommandType.Text;

				if (pt == caParticipantType.User)
				{ //Felhasználóként, azaz a csoportfeliratkozásait kell törölni
					deleteOld.CommandText = "DELETE FROM CAD_PARTICIPANTRELATION WHERE USER_ID=:USER_ID";
					deleteOld.Parameters.Add(new OracleParameter() { ParameterName = "USER_ID", DbType = DbType.String, Value = _participantId });
				}
				else
				{  //Csoportként, azaz a tagsági feliratkozásait kell törölni
					deleteOld.CommandText = "DELETE FROM CAD_PARTICIPANTRELATION WHERE GROUP_ID=:GROUP_ID";
					deleteOld.Parameters.Add(new OracleParameter() { ParameterName = "GROUP_ID", DbType = DbType.String, Value = _participantId });
				}
				deleteOld.ExecuteNonQuery();
				deleteOld.Dispose();

				//Őjak felvétele
				foreach (String p in pl)
				{
					OracleCommand insertRelation = new OracleCommand();
					insertRelation.Connection = conn;

					insertRelation.CommandText = "INSERT INTO CAD_PARTICIPANTRELATION (USER_ID, GROUP_ID ) VALUES ( :USER_ID, :GROUP_ID)";
					insertRelation.CommandType = CommandType.Text;
					insertRelation.BindByName = true;

					if (pt == caParticipantType.User)
					{ //Felhasználóként, azaz a csoportfeliratkozást adunk hozzá
						insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "USER_ID", DbType = DbType.String, Value = _participantId });
						insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "GROUP_ID", DbType = DbType.String, Value = p });
					}
					else
					{  //Csoportként, azaz a tagsági feliratkozást adunk hozzá
						insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "USER_ID", DbType = DbType.String, Value = p });
						insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "GROUP_ID", DbType = DbType.String, Value = _participantId });
					}

					insertRelation.ExecuteNonQuery();
					insertRelation.Dispose();
				}

				txn.Commit();
			}
			catch (Exception ex)
			{
				txn.Rollback();
				caMessageService.AddException("participant-relation-save", ex);
			}
			finally
			{
				txn.Dispose();
			}


			return null;
		}

		public List<caRelationAnalysisResult> GetParticipantRelationAnalysisResultList(string query)
		{
			List<caRelationAnalysisResult> results = new List<caRelationAnalysisResult>();

			OracleCommand cmd = new OracleCommand();
			cmd.Connection = conn;
			cmd.CommandText = query;
			cmd.CommandType = CommandType.Text;
			OracleDataReader dr = cmd.ExecuteReader();

			try
			{
				while (dr.Read())
				{
					caRelationAnalysisResult r = new caRelationAnalysisResult();
					r.m_fromId = caConvert.DBTypeToString(dr["FROM_ID"]);
					r.m_fromName = caConvert.DBTypeToString(dr["FROM_NAME"]);
					r.m_fromGroup = caConvert.DBTypeToString(dr["FROM_GROUP"]);

					r.m_toId = caConvert.DBTypeToString(dr["TO_ID"]);
					r.m_toName = caConvert.DBTypeToString(dr["TO_NAME"]);
					r.m_toGroup = caConvert.DBTypeToString(dr["TO_GROUP"]);

					r.m_times = Convert.ToInt32(dr["TIMES"]);

					results.Add(r);
				}
			}
			catch (Exception ex)
			{
				caMessageService.AddException("relationanalysis", ex);
			}
			finally
			{
				dr.Dispose();
				cmd.Dispose();
			}

			return results;
		}

		public List<caFlowAnalysisResult> GetFlowAnalysisResultList(string query)
		{
			List<caFlowAnalysisResult> results = new List<caFlowAnalysisResult>();

			OracleCommand cmd = new OracleCommand();
			cmd.Connection = conn;
			cmd.CommandText = query;
			cmd.CommandType = CommandType.Text;
			OracleDataReader dr = cmd.ExecuteReader();

			try
			{
				while (dr.Read())
				{
					caFlowAnalysisResult r = new caFlowAnalysisResult();
					r.m_commId = caConvert.DBTypeToString(dr["COMM_ID"]);
					r.m_subcommId = caConvert.DBTypeToString(dr["SUBCOMM_ID"]);
					r.m_previousCommId = caConvert.DBTypeToString(dr["PREV_COMM_ID"]);

					r.m_sentTime = dr.GetDateTime(1); //vigyázni, hogy mindig itt legyen
					r.m_receivedTime = dr.GetDateTime(2);

					r.m_fromId = caConvert.DBTypeToString(dr["FROM_ID"]);
					r.m_fromName = caConvert.DBTypeToString(dr["FROM_NAME"]);

					r.m_toId = caConvert.DBTypeToString(dr["TO_ID"]);
					r.m_toName = caConvert.DBTypeToString(dr["TO_NAME"]);

					results.Add(r);
				}
			}
			catch (Exception ex)
			{
				caMessageService.AddException("flowanalysis", ex);
			}
			finally
			{
				dr.Dispose();
				cmd.Dispose();
			}

			return results;
		}

		public List<caTagParticipantAnalysisResult> GetTagParticipantRelationAnalysisResultList(string query)
		{
			List<caTagParticipantAnalysisResult> results = new List<caTagParticipantAnalysisResult>();

			OracleCommand cmd = new OracleCommand();
			cmd.Connection = conn;
			cmd.CommandText = query;
			cmd.CommandType = CommandType.Text;
			OracleDataReader dr = cmd.ExecuteReader();

			try
			{
				while (dr.Read())
				{
					caTagParticipantAnalysisResult r = new caTagParticipantAnalysisResult();
					r.m_fromId = caConvert.DBTypeToString(dr["FROM_ID"]);
					r.m_fromGroup = caConvert.DBTypeToString(dr["FROM_GROUP"]);

					r.m_toId = caConvert.DBTypeToString(dr["TO_ID"]);
					r.m_toGroup = caConvert.DBTypeToString(dr["TO_GROUP"]);

					r.m_tagId = caConvert.DBTypeToString(dr["TAG_ID"]);
					//r.m_times = Convert.ToInt32(dr["TIMES"]);

					results.Add(r);
				}
			}
			catch (Exception ex)
			{
				caMessageService.AddException("tagrelation", ex);
			}
			finally
			{
				dr.Dispose();
				cmd.Dispose();
			}

			return results;
		}

		public List<caParticipantAddress> LoadParticipantAddressRecordList(String _participantId)
		{
			List<caParticipantAddress> addresses = new List<caParticipantAddress>();

			OracleCommand cmd = new OracleCommand();
			try
			{
				cmd.Connection = conn;
				cmd.CommandText = "SELECT PARTICIPANT_ID, ADDRESS, CATEGORY FROM CAD_PARTICIPANTADDRESS WHERE PARTICIPANT_ID=:PARTICIPANT_ID";
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "PARTICIPANR_ID", DbType = DbType.String, Value = _participantId });

				addresses.Clear();

				OracleDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					caParticipantAddress a = new caParticipantAddress();

					a.m_address = dr["ADDRESS"].ToString();
					a.m_category = caConvert.StringToCategory(dr["CATEGORY"].ToString());
					addresses.Add(a);
				}
				dr.Dispose();
			}
			catch (Exception ex) { caMessageService.AddException(ex); }
			finally { cmd.Dispose(); }



			return addresses; //.ToArray();
		}

		public bool SaveParticipantAddressRecordList(String _participantID, List<caParticipantAddress> al)
		{
			OracleTransaction txn = conn.BeginTransaction(IsolationLevel.ReadCommitted);

			try
			{
				//Korábbiak törlése
				OracleCommand deleteOld = new OracleCommand();
				deleteOld.Connection = conn;
				deleteOld.CommandType = CommandType.Text;
				deleteOld.CommandText = "DELETE FROM CAD_PARTICIPANTADDRESS WHERE PARTICIPANT_ID=:PARTICIPANT_ID";
				deleteOld.Parameters.Add(new OracleParameter() { ParameterName = "PARTICIPANT_ID", DbType = DbType.String, Value = _participantID });
				deleteOld.ExecuteNonQuery();
				deleteOld.Dispose();

				//Őjak felvétele
				foreach (caParticipantAddress a in al)
				{
					OracleCommand insertRelation = new OracleCommand();
					insertRelation.Connection = conn;

					insertRelation.CommandText = "INSERT INTO CAD_PARTICIPANTADDRESS(PARTICIPANT_ID, ADDRESS, CATEGORY) VALUES ( :PARTICIPANT_ID, :ADDRESS, :CATEGORY)";
					insertRelation.CommandType = CommandType.Text;
					insertRelation.BindByName = true;

					insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "PARTICIPANT_ID", DbType = DbType.String, Value = _participantID });
					insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "ADDRESS", DbType = DbType.String, Value = a.m_address });
					insertRelation.Parameters.Add(new OracleParameter() { ParameterName = "CATEGORY", DbType = DbType.Int32, Value = (int)a.m_category });

					insertRelation.ExecuteNonQuery();
					insertRelation.Dispose();
				}

				txn.Commit();
			}
			catch (Exception ex)
			{
				txn.Rollback();
				caMessageService.AddException("participant-address-save", ex);
			}
			finally
			{
				txn.Dispose();
			}


			return true;
		}


		public List<caTaggingRule> LoadTaggingRuleRecordList(String _where)
		{
			List<caTaggingRule> rules = new List<caTaggingRule>();

			OracleCommand cmd = new OracleCommand();
			cmd.Connection = conn;
			cmd.CommandText = "SELECT RULE_ID, STATUS, NAME, TAG, QUERY, CUSTOM FROM CAS_TAGGINGRULE " + _where;
			cmd.CommandType = CommandType.Text;

			OracleDataReader dr = cmd.ExecuteReader();
			while (dr.Read())
			{
				caTaggingRule tr = new caTaggingRule();

				tr.RuleId = dr["RULE_ID"].ToString();
				tr.Status = caConvert.StringToRecordStatus(dr["STATUS"].ToString());
				tr.Name = dr["NAME"].ToString();
				tr.Tag = dr["TAG"].ToString();
				tr.Query = dr["QUERY"].ToString();
				tr.Custom_Query = caConvert.StringToBool(dr["CUSTOM"].ToString());

				rules.Add(tr);
			}

			dr.Dispose();
			cmd.Dispose();

			return rules; //.ToArray();
		}

		public bool SaveTaggingRuleRecord(caTaggingRule tr)
		{
			bool success = true;
			//Megnézni létezik-e már
			List<caTaggingRule> oldTR = new List<caTaggingRule>();
			try { oldTR = LoadTaggingRuleRecordList("WHERE RULE_ID='" + tr.RuleId + "'"); }
			catch { }
			bool update = (oldTR.Count > 0);

			OracleCommand cmd = new OracleCommand();
			cmd.CommandType = CommandType.Text;
			cmd.BindByName = true;

			if (update)
			{
				cmd.CommandText = "UPDATE CAS_TAGGINGRULE SET STATUS=:STATUS, NAME=:NAME, TAG=:TAG, QUERY=:QUERY, CUSTOM=:CUSTOM WHERE RULE_ID=:RULE_ID";
			}
			else
			{
				cmd.CommandText = "INSERT INTO CAS_TAGGINGRULE (RULE_ID, STATUS, NAME, TAG, QUERY, CUSTOM) VALUES (:RULE_ID, :STATUS, :NAME, :TAG, :QUERY, :CUSTOM)";
			}

			try
			{
				cmd.Connection = conn;

				cmd.Parameters.Add(new OracleParameter() { ParameterName = "RULE_ID", DbType = DbType.String, Value = tr.RuleId });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "STATUS", DbType = DbType.Int32, Value = (int)tr.Status });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "NAME", DbType = DbType.String, Value = tr.Name });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "TAG", DbType = DbType.String, Value = tr.Tag });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "QUERY", DbType = DbType.String, Value = tr.Query });
				cmd.Parameters.Add(new OracleParameter() { ParameterName = "CUSTOM", DbType = DbType.Int32, Value = Convert.ToInt32(tr.Custom_Query) });

				int i = cmd.ExecuteNonQuery();
			}
			catch
			{
				success = false;
			}
			finally
			{
				cmd.Dispose();
			}

			return success;
		}

		public List<string> LoadTagList()
		{
			List<string> tags = new List<string>();

			OracleCommand cmd = new OracleCommand();
			try
			{
				cmd.Connection = conn;
				cmd.CommandText = "SELECT DISTINCT TAG_ID FROM CAD_TAG";
				cmd.CommandType = CommandType.Text;

				OracleDataReader dr = cmd.ExecuteReader();
				while (dr.Read()) tags.Add(caConvert.DBTypeToString(dr["TAG_ID"]));

				dr.Dispose();
			}
			catch { }
			finally
			{
				cmd.Dispose();
			}

			return tags; //.ToArray();
		}
	}
}

using System;
using System.Runtime.Serialization;


namespace caCoreLibrary
{
	[DataContract]
	public class caRelationAnalysisResult
	{
		/*
		SELECT P0.PARTICIPANT_ID FROM_ID, P0.name FROM_NAME, p0.primary_group FROM_GROUP,P1.PARTICIPANT_ID TO_ID, P1.NAME TO_NAME, p1.primary_group TO_GROUP FROM cad_participant P0, cad_participant P1, cad_comm C WHERE  c.from_participant = p0.participant_id and C.to_participant = p1.participant_id
		SELECT P0.PARTICIPANT_ID FROM_ID, P0.name FROM_NAME, p0.primary_group FROM_GROUP, P1.PARTICIPANT_ID TO_ID, P1.NAME TO_NAME, p1.primary_group TO_GROUP, count(c.ID) TIMES FROM cad_participant P0, cad_participant P1, cad_comm C WHERE  c.from_participant = p0.participant_id and C.to_participant = p1.participant_id and lower(p0.name) like '%kos%' GROUP BY P0.PARTICIPANT_ID, P0.name , p0.primary_group , P1.PARTICIPANT_ID , P1.NAME , p1.primary_group
			 
		*/
		[DataMember]
		public string m_fromId;
		[DataMember]
		public string m_fromName;
		[DataMember]
		public string m_fromGroup;

		[DataMember]
		public string m_toId;
		[DataMember]
		public string m_toName;
		[DataMember]
		public string m_toGroup;

		[DataMember]
		public int m_times;


		//Property-k Vizualizációhoz - Datargrid-be
		public string From_User_ID { get { return m_fromId; } }
		public string From_User_Name { get { return m_fromName; } }
		public string From_Group { get { return m_fromGroup; } }

		public int Times { get { return m_times; } }

		public string To_User_ID { get { return m_toId; } }
		public string To_User_Name { get { return m_toName; } }
		public string To_Group { get { return m_toGroup; } }
	}

	[DataContract]
	public class caFlowAnalysisResult
	{
		//SELECT SC.SUBCOMM_ID, PF.PARTICIPANT_ID FROM_ID, PF.name FROM_NAME, PT.PARTICIPANT_ID TO_ID, PT.NAME TO_NAME, SC.SENT_TIME, SC.RECEIVED_TIME, SC.COMM_ID, SC.PREV_COMM_ID";

		[DataMember]
		public string m_subcommId;
		[DataMember]
		public DateTime m_sentTime;
		[DataMember]
		public DateTime m_receivedTime;
		[DataMember]
		public string m_commId;
		[DataMember]
		public string m_previousCommId;


		[DataMember]
		public string m_fromId;
		[DataMember]
		public string m_fromName;
		[DataMember]
		public string m_toId;
		[DataMember]
		public string m_toName;

		//Propertyk - vizualizációhoz
		public string SubComm_ID { get { return m_subcommId; } }
		public string Comm_ID { get { return m_commId; } }
		public string Previous_Comm_ID { get { return m_previousCommId; } }

		public DateTime Sent { get { return m_sentTime; } }
		public DateTime Received { get { return m_receivedTime; } }

		public string From_User_ID { get { return m_fromId; } }
		public string From_User_Name { get { return m_fromName; } }

		public string To_User_ID { get { return m_toId; } }
		public string To_User_Name { get { return m_toName; } }
	}

	[DataContract]
	public class caTagParticipantAnalysisResult
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
		and SC.COMM_ID = T.COMM_ID
		 * 
		 */

		[DataMember]
		public string m_tagId;
		[DataMember]
		public int m_times = 1;
		[DataMember]
		public string m_fromId;
		[DataMember]
		public string m_fromGroup;
		[DataMember]
		public string m_toId;
		[DataMember]
		public string m_toGroup;

		//Property-k Vizualizációhoz - Datargrid-be
		public string Tag_ID { get { return m_tagId; } }
		public int Times { get { return m_times; } }
		public string From_User_ID { get { return m_fromId; } }
		public string From_Group_ID { get { return m_fromGroup; } }
		public string To_User_ID { get { return m_toId; } }
		public string To_Group_ID { get { return m_toGroup; } }
	}
}

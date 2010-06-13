using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using caCoreLibrary;

namespace caServiceLibrary
{
	/// <summary>
	/// WebService hívások eljárásait és függvényeit leíró interface 
	///	Az egyes OP-ok magyarázatai az implementált osztályban - Service.cs
	/// </summary>
	[ServiceContract]
	public interface IService
	{

		[OperationContract]
		caMessage Connect();

		[OperationContract]
		List<caMessage> GetMessages();

		[OperationContract]
		List<caRelationAnalysisResult> GetParticipantRelationAnalysisResultList(string query);

		[OperationContract]
		List<caFlowAnalysisResult>  GetFlowAnalysisResultList(string query);

		[OperationContract]
		List<caTagParticipantAnalysisResult> GetTagParticipantAnalysisResultList(string query);

		//GetParticipantTagAnalysisResulList

		[OperationContract]
		caParticipant LoadParticipant(string _participantId);

		[OperationContract]
		caParticipant SaveParticipant(caParticipant actualP);

		[OperationContract]
		List<caParticipant> LoadParticipantGroups(string _participantId);

		[OperationContract]
		List<caParticipant> SaveParticipantGroups(string _participantId, List<string> groups);

		[OperationContract]
		List<caParticipant> LoadParticipantMembers(string _participantId);

		[OperationContract]
		List<caParticipant> SaveParticipantMembers(string _participantId, List<string> members);

		[OperationContract]
		List<caParticipantAddress> LoadParticipantAddress(string _participantId);

		[OperationContract]
		List<caParticipantAddress> SaveParticipantAddress(string _participantId, List<caParticipantAddress> address);

		[OperationContract]
		List<caParticipant> LoadParticipantList();

		[OperationContract]
		caMessage ReplaceParticipant(string _fromPID, string _toPID);


		#region Tagging

		[OperationContract]
		List<string> LoadTagList();
	
		[OperationContract]
		caMessage RunTaggingRule(string _ruleId);

		[OperationContract]
		caMessage DeleteTag(string _tag);

		[OperationContract]
		caTaggingRule LoadTaggingRule(string _ruleId);

		[OperationContract]
		List<caTaggingRule> LoadTaggingRuleList();

		[OperationContract]
		caTaggingRule SaveTaggingRule(caTaggingRule tr);

		#endregion 		

	}
}

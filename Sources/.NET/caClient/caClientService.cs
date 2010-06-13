using System;
using caClient.caServiceReference;
using caCoreLibrary;
using System.Collections.Generic;
using System.Windows.Forms;
using caClient.Forms;

namespace caClient
{
/// <summary>
/// Kliens és szerver közötti eljárások, valamint az általános kliens funkciókat
/// megvalósító osztály
/// </summary>
	
class caClientService
	{
		//Globális címkelista
		public static caGlobalList glTag = new caGlobalList();

		//Címkéket letöltő eljárás
		public static caGlobalList LoadTagList(ServiceClient conn)
		{
			caGlobalList gl = new caGlobalList();
			List<string> tags = new List<string>();
			try
			{
				tags = conn.LoadTagList();
			}
			catch { }

			foreach (string s in tags) gl.Add(new caGlobalListItem(s, s));

			glTag = gl;

			return gl;
		}

		//Résztvevőket betöltő eljárás - Cache-ből vagy szerverről
		public static caParticipantObject UseOrLoadParticipant(ServiceClient conn, caParticipantObjectList pol, string _pId)
		{
			//Beállítás megkísérlése a gyorsítótárból
			caParticipantObject rP = pol.IsIn(_pId);

			if (rP == null) //Amennyiben a résztvevő még nincs a cache-ben
			{
				//Letöltés a szerverről
				rP = caClientService.LoadParticipantObject(conn, new caParticipantObject(_pId, _pId));
				if (String.IsNullOrEmpty(rP.m_name)) rP = caClientService.LoadParticipantObject(conn, new caParticipantObject(_pId, _pId)); ;
				pol.AddIdentical(rP);
				caMessageService.Add(new caMessage() { text = "Load Participant: " + rP.m_name });
			}

			return rP;
		}

		//Csoport tagjait kifejtő eljárás
		public static caParticipantObjectList ExpandParticipantGroup(ServiceClient conn, caParticipantObjectList pol)
		{
			//KIválasztott résztvevők közül csoportok lekérése LINQ-val
			caParticipantObjectList expL = pol;
			List<caParticipantObject> expP = expL.FindAll(delegate(caParticipantObject po) { return po.m_type == caParticipantType.Group; });

			//MInden csoporttagság letöltése egyenként
			foreach (caParticipantObject po in expP)
			{
				caParticipantObject pg = caClientService.LoadParticipantObject(conn, po);
				foreach (caParticipantObject pgm in pg.m_memberList) expL.Add(pgm);
				caMessageService.Add(new caMessage() { text = "Group loaded: " + pg.m_name });
			}
			return expL;
		}

		//Teljes résztvevő obejtum letöltése szereverről
		public static caParticipantObject LoadParticipantObject(ServiceClient conn, caParticipantObject po)
		{
			try
			{
				caParticipant p = conn.LoadParticipant(po.m_participantId);
				caParticipantObject _po = new caParticipantObject(p);
				po.Copy(_po);

				//Tagságok, tagok és elérhetőségek letöltése
				po.m_memberList = new caParticipantObjectList(conn.LoadParticipantMembers(po.m_participantId));
				po.m_groupList = new caParticipantObjectList(conn.LoadParticipantGroups(po.m_participantId));
				po.m_addressList = conn.LoadParticipantAddress(po.m_participantId);

				po.m_objectState = caObjectState.Syncronized;
			}
			catch (Exception ex) { caMessageService.AddException("Load PO", ex); }
			return po;
		}

		//Teljes résztvevő objektum mentése
		public static caParticipantObject SaveParticipantObject(ServiceClient conn, caParticipantObject actualPo)
		{
			//SendTimeOut error lehet...
			caParticipant newP = conn.SaveParticipant(actualPo.GetParticipant());
			//Tagságok, tagok és elérhetőségek mentése
			newP.m_groupList = conn.SaveParticipantGroups(actualPo.m_participantId, actualPo.m_groupList.GetParticipantStringList());
			newP.m_memberList = conn.SaveParticipantMembers(actualPo.m_participantId, actualPo.m_memberList.GetParticipantStringList());
			newP.m_addressList = conn.SaveParticipantAddress(actualPo.m_participantId, actualPo.m_addressList);

			caParticipantObject newPo = new caParticipantObject(newP);
			newPo.m_objectState = caObjectState.Syncronized;

			return newPo;
		}

		//Címkézési szabály letöltése a szerverről
		public static caTaggingRule LoadTaggingRule(ServiceClient conn, caTaggingRule actualTr)
		{
			caTaggingRule newTr = null;
			try
			{
				newTr = conn.LoadTaggingRule(actualTr.RuleId);
			}
			catch { }

			return newTr;
		}

		//Cjmkézési szabály mentése a szerverre
		public static caTaggingRule SaveTaggingRule(ServiceClient conn, caTaggingRule actualTr)
		{
			caTaggingRule newTr = null;
			try
			{
				newTr = conn.SaveTaggingRule(actualTr);
			}
			catch { }

			return newTr;
		}


		//Címkézési szabály futtatása és kommunikáció címkézése
		public static bool RunTaggingRule(ServiceClient conn, string _ruleId)
		{
			bool retVal = false; // newTr = null;
			try
			{
				caMessageService.Add(conn.RunTaggingRule(_ruleId));
				retVal = true;
			}
			catch { }

			return retVal;
		}

		//Adott címke eltávolítása a rendszerből
		public static bool DeleteTag(ServiceClient conn, string _tag)
		{
			bool retVal = false; // newTr = null;
			try
			{
				caMessageService.Add(conn.DeleteTag(_tag));
				retVal = true;
			}
			catch { }

			return retVal;
		}

		//Kapcsolati háló elemzés futtatása és eredmények lekérése a szerverről
		public static List<caRelationAnalysisResult> GetParticipantRelationAnalysisResultList(ServiceClient conn, string query)
		{
			List<caRelationAnalysisResult> results = new List<caRelationAnalysisResult>();

			try
			{
				results = conn.GetParticipantRelationAnalysisResultList(query);
			}
			catch (Exception ex) { caMessageService.AddException(ex); }

			return results;
		}

		//Ügymenet elemzés futtatása és eredmények lekérése a szerverről
		public static List<caFlowAnalysisResult> GetFlowAnalysisResultList(ServiceClient conn, string query)
		{
			List<caFlowAnalysisResult> results = new List<caFlowAnalysisResult>();

			try
			{
				results = conn.GetFlowAnalysisResultList(query);
			}
			catch (Exception ex) { caMessageService.AddException(ex); }

			return results;
		}

		//Résztvevő-téma elemzés futtatása és eredmények lekérdezése a szerverről
		public static List<caTagParticipantAnalysisResult> GetTagParticipantAnalysisResultList(ServiceClient conn, string query)
		{
			List<caTagParticipantAnalysisResult> results = new List<caTagParticipantAnalysisResult>();

			try
			{
				results = conn.GetTagParticipantAnalysisResultList(query);
			}
			catch (Exception ex) { caMessageService.AddException(ex); }

			return results;
		}
	}
}

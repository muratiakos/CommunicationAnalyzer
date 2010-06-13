using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace caCoreLibrary
{
	//Globális listaelem osztály megjelenítésekhez, gyórsítótárakhoz és előre generált listákhoz
	[DataContract]
	public class caGlobalListItem
	{
		//Statikus listaelemek listákhoz és szűrésekhez

		//Rekordstátusz
		public static caGlobalListItem syncUnknown = new caGlobalListItem("sync", "Any state", caObjectState.Unknown);
		public static caGlobalListItem syncNo = new caGlobalListItem("sync", "Not Syncronized", caObjectState.NotSyncronized);
		public static caGlobalListItem syncYes = new caGlobalListItem("sync", "Syncronized", caObjectState.Syncronized);

		//ObjektumStátusz
		public static caGlobalListItem rsUnknown = new caGlobalListItem("RS", "Any state", caRecordStatus.Unknown);
		public static caGlobalListItem rsRegistered = new caGlobalListItem("RS", "Registered", caRecordStatus.Registered);
		public static caGlobalListItem rsActive = new caGlobalListItem("RS", "Active", caRecordStatus.Active);
		public static caGlobalListItem rsInactive = new caGlobalListItem("RS", "Inactive", caRecordStatus.InActive);
		public static caGlobalListItem rsDeleted = new caGlobalListItem("RS", "Deleted", caRecordStatus.Deleted);

		//Csatorna kódok
		public static caGlobalListItem c_All = new caGlobalListItem("CATEGORY", "Any category", caCommCategory.Unknown);
		public static caGlobalListItem c_Email = new caGlobalListItem("CATEGORY", "E-mail", caCommCategory.Email);
		public static caGlobalListItem c_Voice = new caGlobalListItem("CATEGORY", "Voice", caCommCategory.Voice);
		public static caGlobalListItem c_Text = new caGlobalListItem("CATEGORY", "Text", caCommCategory.Text);

		//Kézbesítési módok
		public static caGlobalListItem sc_Email_To = new caGlobalListItem("SUBCATEGORY", "TO", caCommSubCategory.TO, ((int)caCommCategory.Email).ToString());
		public static caGlobalListItem sc_Email_Cc = new caGlobalListItem("SUBCATEGORY", "CC", caCommSubCategory.CC, ((int)caCommCategory.Email).ToString());
		public static caGlobalListItem sc_Email_Bcc = new caGlobalListItem("SUBCATEGORY", "BCC", caCommSubCategory.BCC, ((int)caCommCategory.Email).ToString());

		//Felhasználó típusok
		public static caGlobalListItem pt_ParticipantType_Both = new caGlobalListItem("PARTICIPANTTYPE", "Users and Groups", caParticipantType.UserOrGroup);
		public static caGlobalListItem pt_ParticipantType_User = new caGlobalListItem("PARTICIPANTTYPE", "User", caParticipantType.User);
		public static caGlobalListItem pt_ParticipantType_Group = new caGlobalListItem("PARTICIPANTTYPE", "Group", caParticipantType.Group);


		//Változók
		[DataMember]
		public string m_listId = null;
		[DataMember]
		public string m_name = null;
		[DataMember]
		public object m_value = null;
		[DataMember]
		public string m_parentValue = null;

		//Propertyk - Megjelenítés és tárolás
		public string Display { get { return m_name; } }
		public object Value { get { return m_value; } }

		//KOnstruktorok
		public caGlobalListItem(string _name, object _value)
		{
			m_value = _value;
			m_name = _name;
		}

		public caGlobalListItem(string _listId, string _name, object _value)
			: this(_name, _value)
		{
			m_listId = _listId;
		}

		public caGlobalListItem(string _listId, string _name, object _value, string _parentValue)
			: this(_listId, _name, _value)
		{
			m_parentValue = _parentValue;
		}
	}

	//Globális lista osztályok
	public class caGlobalList : List<caGlobalListItem>
	{
		//Statikusok listák

		//Rekordstátusz
		public static caGlobalList RecordStates(string unknown)
		{
			caGlobalList gl = new caGlobalList();
			if (!String.IsNullOrEmpty(unknown)) gl.Add(caGlobalListItem.rsUnknown);
			gl.Add(caGlobalListItem.rsRegistered);
			gl.Add(caGlobalListItem.rsActive);
			gl.Add(caGlobalListItem.rsInactive);
			gl.Add(caGlobalListItem.rsDeleted);
			return gl;
		}

		//Objektumstátusz
		public static caGlobalList SyncStates(string unknown)
		{
			caGlobalList gl = new caGlobalList();
			if (!String.IsNullOrEmpty(unknown)) gl.Add(caGlobalListItem.syncUnknown);
			gl.Add(caGlobalListItem.syncNo);
			gl.Add(caGlobalListItem.syncYes);
			return gl;
		}

		//Csatornák
		public static caGlobalList CategoryList(string unknown)
		{
			caGlobalList gl = new caGlobalList();
			if (!String.IsNullOrEmpty(unknown)) gl.Add(caGlobalListItem.c_All);
			gl.Add(caGlobalListItem.c_Email);
			gl.Add(caGlobalListItem.c_Voice);
			gl.Add(caGlobalListItem.c_Text);
			return gl;
		}

		//Kézbesítési módok
		public static caGlobalList SubcategoryList(string unknown)
		{
			caGlobalList gl = new caGlobalList();
			//if (!String.IsNullOrEmpty(unknown)) gl.Add(caGlobalListItem.c_All);
			gl.Add(caGlobalListItem.sc_Email_To);
			gl.Add(caGlobalListItem.sc_Email_Cc);
			gl.Add(caGlobalListItem.sc_Email_Bcc);
			return gl;
		}

		//Résztvevő típus
		public static caGlobalList ParticipantTypeList(string unknown)
		{
			caGlobalList gl = new caGlobalList();
			if (!String.IsNullOrEmpty(unknown)) gl.Add(caGlobalListItem.pt_ParticipantType_Both);
			gl.Add(caGlobalListItem.pt_ParticipantType_User);
			gl.Add(caGlobalListItem.pt_ParticipantType_Group);
			return gl;
		}

		//Lista lekérdezése a globális listahalomból
		public caGlobalListItem GetList(string _listId)
		{
			return this.Find(
				delegate(caGlobalListItem gli)
				{
					if (
						gli.m_listId == _listId
					)
						return true;
					else return false;
				});
		}

		//Adott szülőhöz tartozó lista lekérdezése
		public caGlobalListItem GetListWithParent(string _listId, string _parentValue)
		{
			return this.Find(
				delegate(caGlobalListItem gli)
				{
					if (
						gli.m_listId == _listId &&
						gli.m_parentValue == _parentValue
					)
						return true;
					else return false;
				});
		}
	}
}

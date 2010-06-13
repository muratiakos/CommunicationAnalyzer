using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

//Résztvevővel kapcsolatos osztályok és eljárársok modulja
namespace caCoreLibrary
{
	//Résztvevő típusok enumerációja
	public enum caParticipantType
	{
		UserOrGroup = -1,
		User = 0,
		Group = 1
	}

	//Résztvevő típus osztály
	[DataContract]
	public class caParticipant
	{
		//Változók
		[DataMember]
		public string m_participantId;
		[DataMember]
		public string m_name;
		[DataMember]
		public string m_foreignId;
		[DataMember]
		public caParticipantType m_type = caParticipantType.User;
		[DataMember]
		public caRecordStatus m_status = caRecordStatus.Active;
		[DataMember]
		public string m_primaryGroup;

		[DataMember]
		public List<caParticipant> m_groupList = new List<caParticipant>();
		[DataMember]
		public List<caParticipant> m_memberList = new List<caParticipant>();
		[DataMember]
		public List<caParticipantAddress> m_addressList = new List<caParticipantAddress>();

		//Konstruktorok
		public caParticipant()
		{
			m_participantId = System.Guid.NewGuid().ToString();
			m_primaryGroup = "G0";
		}

		//Másoló konstruktor
		public caParticipant(caParticipant _p)
			: this()
		{
			if (_p != null)
			{
				m_foreignId = _p.m_foreignId;
				m_participantId = _p.m_participantId;
				m_groupList = _p.m_groupList;
				m_memberList = _p.m_memberList;
				m_name = _p.m_name;
				m_type = _p.m_type;
				m_status = _p.m_status;
			}
		}

		//Egyszerű felhasználó konstruktor
		public caParticipant(String _id, String _name)
			: this()
		{
			m_participantId = _id;
			m_name = _name;
		}

		//Egyszerű Csoportok definiáló konstruktor
		public caParticipant(String _id, String _name, caParticipantType _pt)
			: this(_id, _name)
		{
			m_type = _pt;
		}
	}

	//Résztvevő elérését prezentáló osztály
	[DataContract]
	public class caParticipantAddress
	{
		[DataMember]
		public string m_address;
		[DataMember]
		public caCommCategory m_category;
	}


	//Résztvevő objektum osztálya megjelenést támogató funkciókkal
	public class caParticipantObject : caParticipant
	{
		//Statikus
		//Ismeretlen csoport, mint statikus elem
		public static caParticipantObject UnknownGroup = new caParticipantObject("G0", "Unknown Group", caParticipantType.Group);


		//Változók
		public caParticipantType m_showAs = caParticipantType.User;
		public caObjectState m_objectState = caObjectState.NotSyncronized;

		public new caParticipantObjectList m_groupList = new caParticipantObjectList();
		public new caParticipantObjectList m_memberList = new caParticipantObjectList();
		public new caParticipantObjectList m_shownIn = new caParticipantObjectList();



		//Propertyk
		public string Participant_ID { get { return m_participantId; } }
		public string Name { get { return m_name; } }
		public string Foreign_ID { get { return m_foreignId; } }
		public caParticipantType Type { get { return m_type; } }
		public caRecordStatus Status { get { return m_status; } }
		public string Primary_Group { get { return m_primaryGroup; } }
		public caObjectState Sync_Status { get { return m_objectState; } }

		//RÉsztvevő csoportjai
		public caParticipantObjectList GroupList
		{
			get
			{
				if (m_groupList.Count == 0)
				{
					caParticipantObjectList pol = new caParticipantObjectList();
					pol.Add(caParticipantObject.UnknownGroup);
					return pol;
				}
				else return m_groupList;
			}
			set
			{
				m_groupList = value;
			}
		}

		//Résztvevő tagjai
		public caParticipantObjectList MemberList
		{
			get
			{
				return m_memberList;
			}
			set
			{
				m_memberList = value;
			}
		}


		//Konstruktorok
		public caParticipantObject() : base() { }

		//Copy konstruktor
		public caParticipantObject(caParticipant _p)
			: base(_p)
		{
			if (_p != null)
			{
				m_showAs = m_type;

				m_memberList = new caParticipantObjectList(_p.m_memberList);
				m_groupList = new caParticipantObjectList(_p.m_groupList);
			}
		}
		//Felhasználó gyors felvétel
		public caParticipantObject(String _id, String _name)
			: base(_id, _name)
		{
			m_showAs = m_type;
		}

		//Csoport gyors felvétel
		public caParticipantObject(String _id, String _name, caParticipantType _pt)
			: base(_id, _name, _pt)
		{
			m_showAs = m_type;
		}


		//Eljárások
		public void Copy(caParticipantObject _po)
		{
			m_foreignId = _po.m_foreignId;
			m_groupList = _po.m_groupList;
			m_memberList = _po.m_memberList;
			m_name = _po.m_name;
			m_objectState = _po.m_objectState;
			m_participantId = _po.m_participantId;
			m_primaryGroup = _po.m_primaryGroup;
			m_showAs = _po.m_showAs;
			m_status = _po.m_status;
			m_type = _po.m_type;
		}

		//Obejktumból sima résztvevő példány kinyerése
		public caParticipant GetParticipant()
		{
			return new caParticipant()
			{
				m_foreignId = base.m_foreignId,
				m_participantId = base.m_participantId,
				m_primaryGroup = base.m_primaryGroup,
				m_groupList = base.m_groupList,
				m_memberList = base.m_memberList,
				m_name = base.m_name,
				m_type = base.m_type,
				m_status = base.m_status
			};
		}

		//Nézet váltás csoport és személy között
		public void ShowAs(caParticipantType _pt)
		{
			if (m_showAs != _pt) //Ha már nem lett beállítva egyszer erre a felhasználóra
			{
				m_showAs = _pt;

				foreach (caParticipantObject g in m_groupList)
				{
					if (_pt == caParticipantType.Group)
					{
						this.m_shownIn.AddIdentical(g);
						g.m_memberList.AddIdentical(this); //saját magát hozzáadjuk az összes csoportjához
					}
					else
					{
						//g.m_memberList.Remove(this);
						g.m_shownIn.Remove(this);
					}
				}
			}
			else
			{
				//Group-ot usereként kell megjeleníteni

				//TODO-CACHE
				foreach (caParticipantObject g in m_groupList)
				{
					if (_pt == caParticipantType.Group)
						g.m_memberList.AddIdentical(this); //saját magát hozzáadjuk az összes csoportjához
					else
						g.m_memberList.Remove(this);
				}
			}
		}

		//Egyszerű megjelnítéshez
		public override String ToString()
		{
			return String.Format("{0} \n ({1})", m_name, m_participantId);
		}
	}

	//Résztvevő objektumok listája
	public class caParticipantObjectList : List<caParticipantObject>
	{
		//Globális gyorsítótár
		public List<caParticipantObject> localCache = new List<caParticipantObject>();

		//Konstruktorok
		public caParticipantObjectList() { }
		public caParticipantObjectList(List<caParticipant> _pl)
		{
			if (_pl != null)
			{
				foreach (caParticipant _p in _pl)
				{
					this.AddAndCache(new caParticipantObject(_p));
				}
			}
		}

		//Eljárások
		//Add and cache - Globális cache építése és ha már bennevan, akkor a referenciát szúrjuk be mégegyszer
		public caParticipantObject AddAndCache(caParticipantObject _new)
		{
			caParticipantObject _old = null;
			try
			{
				_old = localCache.Find(
					delegate(caParticipantObject po)
					{
						return po.m_participantId == _new.m_participantId;
					});
			}
			catch { }
			if (_old == null)
			{
				localCache.Add(_new);
				this.Add(_new);
				return _new;
			}
			else
			{
				this.Add(_old);
				return _old;
			}
		}

		//Lekérdezi, hogy egy adott azonosítójú résztvevő már szerepel-e a lsitában
		public caParticipantObject IsIn(String _po)
		{
			caParticipantObject _old = null;
			try
			{
				_old = localCache.Find(
					delegate(caParticipantObject po)
					{
						return po.m_participantId == _po;
					});
			}
			catch { }
			return _old;
		}

		//Add Identical - Globális lista építés és ha már bent van, akkor a listába sem tesszük be mégegyszer eldobjuk
		public caParticipantObject AddIdentical(caParticipantObject _new)
		{
			caParticipantObject _old = null;
			try
			{
				_old = localCache.Find(
					delegate(caParticipantObject po)
					{
						return po.m_participantId == _new.m_participantId;
					});
			}
			catch { }
			if (_old == null)
			{
				localCache.Add(_new);
				this.Add(_new);
				return _new;
			}
			else
			{
				return _old;
			}
		}

		//Egyszerű résztvevőlista visszaadása
		public List<caParticipant> GetParticipantList()
		{
			List<caParticipant> pl = new List<caParticipant>();
			foreach (caParticipantObject po in this)
			{
				pl.Add(po.GetParticipant());
			}
			return pl;
		}

		//Résztvevők azonosítóinak visszaadása listaként
		public List<String> GetParticipantStringList()
		{
			List<String> pl = new List<String>();
			foreach (caParticipantObject po in this)
			{
				pl.Add(po.m_participantId);
			}
			return pl;
		}
	}
}

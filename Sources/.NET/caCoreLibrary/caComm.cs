using System;
using System.Collections.Generic;

namespace caCoreLibrary
{
	public enum caCommSubCategory
	{
		TO, CC, BCC
	}

	public enum caCommCategory
	{
		Unknown = -1,
		Email = 0,
		Voice = 1,
		Text = 2
	}

	public class caSubCommItem
	{
		//Változók
		
		public string m_subcommId;
		public string m_commId;
		public int m_times = 1;
		
		public caCommCategory m_category = caCommCategory.Email;
		public caCommSubCategory m_subcategory = caCommSubCategory.TO;

		public caParticipant m_fromParticipant;
		public caParticipant m_toParticipant;

		public long m_delay;

		public DateTime m_sentTime;
		public DateTime m_receivedTime;

		public string m_previousCommId;
		public string m_threadId;

		//Konstruktorok
		public caSubCommItem() { }
		public caSubCommItem(caSubCommItem _ci)
		{
			m_category = _ci.m_category;
			m_delay = _ci.m_delay;
			m_fromParticipant = _ci.m_fromParticipant;
			m_subcommId = _ci.m_subcommId;
			m_commId = _ci.m_commId;
			m_previousCommId = _ci.m_previousCommId;
			m_receivedTime = _ci.m_receivedTime;
			m_sentTime = _ci.m_sentTime;
			m_subcategory = _ci.m_subcategory;
			m_times = _ci.m_times;
			m_toParticipant = _ci.m_toParticipant;
		}
	}

	public class caSubCommItemList : List<caSubCommItem> { }

	public class caSubCommItemObject : caSubCommItem
	{
		//Változók
		public new caParticipantObject m_fromParticipant;
		public new caParticipantObject m_toParticipant;

		//Konstruktorok
		public caSubCommItemObject() { }
		public caSubCommItemObject(caSubCommItem _ci)
			: base(_ci)
		{
			m_fromParticipant = new caParticipantObject(_ci.m_fromParticipant);
			m_toParticipant = new caParticipantObject(_ci.m_toParticipant);
		}
	}
	public class caSubCommItemObjectList : List<caSubCommItemObject>
	{
		//Statikusok
		public static caSubCommItemObjectList CreateCommItemObjectList(caSubCommItemList cil)
		{
			//Builder mechanism
			caSubCommItemObjectList ciol = new caSubCommItemObjectList();
			caParticipantObjectList cache_po = new caParticipantObjectList();

			foreach (caSubCommItem ci in cil)
			{
				caParticipantObject po_from = cache_po.AddAndCache(new caParticipantObject(ci.m_fromParticipant));
				caParticipantObject po_to = cache_po.AddAndCache(new caParticipantObject(ci.m_toParticipant));

				caSubCommItemObject cio = new caSubCommItemObject(ci);
				cio.m_toParticipant = po_to;
				cio.m_fromParticipant = po_from;

				ciol.Add(cio);
			}

			return ciol;
		}
		//Változók
		public caParticipantObjectList m_cacheParticipant = new caParticipantObjectList();

		//KOnstruktorok
		public caSubCommItemObjectList() { }

		//Eljárások
		public caSubCommItemObject AddIdentical(caSubCommItemObject _new)
		{
			caSubCommItemObject _old = null;
			try
			{
				_old = this.Find(
					delegate(caSubCommItemObject cio)
					{
						return cio.m_subcommId == _new.m_subcommId;
					});
			}
			catch { }
			if (_old == null)
			{
				this.Add(_new);
				return _new;
			}
			else return _old;
		}
	}


}

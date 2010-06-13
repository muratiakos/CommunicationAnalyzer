using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace caCoreLibrary
{
	/// <summary>
	/// SQL lekérdezéseket generálós hierarchikus feltételosztály
	/// </summary>
	public class caConditionItem
	{
		public bool First;
		public string Bind = "";
		public string Condition = "1=1";
		public caConditionItemList SubCondition = new caConditionItemList();

		public caConditionItem() { }
		public caConditionItem(String _c)
		{
			Condition = _c.Trim();
		}
		public caConditionItem(String _b, String _c)
			: this(_c)
		{
			Bind = _b.Trim();
		}

		public override string ToString()
		{
			String full = "";

			if (SubCondition.Count > 0) //Ha többminden van benne
			{
				full = SubCondition.ToString();
			}
			else //Ha csak egyke feltétel
			{
				full = Condition;
			}

			if (full.Equals("()")) full = "";
			if (!First && !String.IsNullOrEmpty(full)) full = " " + Bind + " " + full;

			return full;
		}
	}

	//Feltételek listája
	public class caConditionItemList : List<caConditionItem>
	{
		public override string ToString()
		{
			String full = "";
			int db = 0;
			foreach (caConditionItem ci in this)
			{
				ci.First = (db == 0);
				full += " " + ci.ToString();
				db++;
			}
			full = "(" + full.Trim() + ")";
			return full;
		}
	}


}

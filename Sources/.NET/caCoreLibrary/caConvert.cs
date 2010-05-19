using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace caCoreLibrary
{
	//Metódusok
	public class caConvert
	{
		public static string DBTypeToString(object o, bool canBeNull)
		{
			String retVal;
			if (canBeNull) retVal = null;
			else retVal = "";

			try
			{
				retVal = (string)o;
			}
			catch { }
			return retVal;
		}

		public static string DBTypeToString(object o)
		{
			return DBTypeToString(o, false);
		}

		public static bool StringToBool(string s)
		{
			if (s.Equals("0")) return false;
			else return true;
		}

		public static caCommCategory StringToCategory(string s)
		{
			caCommCategory cc = caCommCategory.Unknown;
			try
			{
				cc = (caCommCategory)Enum.ToObject(typeof(caCommCategory), Convert.ToInt32(s));
			}
			catch (Exception) { }
			return cc;
		}

		public static caParticipantType StringToParticipantType(string s)
		{
			caParticipantType pt = caParticipantType.UserOrGroup;
			try
			{
				pt = (caParticipantType)Enum.ToObject(typeof(caParticipantType), Convert.ToInt32(s));
			}
			catch (Exception) { }
			return pt;
		}

		public static caRecordStatus StringToRecordStatus(string s)
		{
			caRecordStatus ps = caRecordStatus.Unknown;
			try
			{
				ps = (caRecordStatus)Enum.ToObject(typeof(caRecordStatus), Convert.ToInt32(s));
			}
			catch (Exception) { }
			return ps;
		}

		public static string ManyToOneMessageId(string Many)
		{
			String retVal = Many;
			String[] ms = Many.Split(">".ToCharArray());
			if (ms.Length > 0) retVal = ms[0].Trim() + ">";
			return retVal;
		}
	}
}

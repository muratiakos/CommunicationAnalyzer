using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Résztvevők kapcsolatainak leíró osztályainak modulja
namespace caCoreLibrary
{
	public class caIndirectRelation
	{
		//Kapcsolattípusok enumerációja
		public enum caRelationType
		{
			UserToUser,
			UserToGroup,
			GroupToUser,
			GroupToGroup
		}

		public caParticipant srcObject { get; set; }
		public caParticipant dstObject { get; set; }

		public String srcID
		{
			get
			{
				return srcObject.m_participantId;
			}
		}

		public String dstID
		{
			get
			{
				return dstObject.m_participantId;
			}
		}

		public String srcLabel
		{
			get
			{
				return srcObject.m_name;
			}
		}

		public String dstLabel
		{
			get
			{
				return dstObject.m_name;
			}
		}

		//Kapcsolattítpus visszaadása a feladó és címzett között
		public caRelationType getRelationType
		{
			get
			{
				if (srcObject.m_type == caParticipantType.User) //User TO
				{
					if (dstObject.m_type == caParticipantType.User) return caRelationType.UserToUser;
					else return caRelationType.UserToGroup;
				}
				else //Group TO
				{
					if (dstObject.m_type == caParticipantType.User) return caRelationType.GroupToUser;
					else return caRelationType.GroupToGroup;
				}
			}
		}

		//A feladó és címzett között az össszes lehetséges kapcsolat visszaadása
		public static List<caIndirectRelation> getIndirectRelation(caParticipantObject _from, caParticipantObject _to)
		{
			List<caIndirectRelation> ir = new List<caIndirectRelation>();

			if (_from.m_showAs == caParticipantType.Group) //több forrás lehet
			{
				if (_to.m_showAs == caParticipantType.Group) //több cél lehet
				{
					foreach (caParticipantObject src in _from.GroupList)
						foreach (caParticipantObject dst in _to.GroupList)
							ir.Add(new caIndirectRelation() { srcObject = src, dstObject = dst });
				}
				else //csak 1 cél lehet
				{
					foreach (caParticipantObject src in _from.GroupList)
						ir.Add(new caIndirectRelation() { srcObject = src, dstObject = _to });
				}
			}
			else  //csak egy forrás
			{
				if (_to.m_showAs == caParticipantType.Group) //több cél lehet
				{
					foreach (caParticipantObject dst in _to.GroupList)
						ir.Add(new caIndirectRelation() { srcObject = _from, dstObject = dst });
				}
				else //csak 1 cél lehet
				{
					ir.Add(new caIndirectRelation() { srcObject = _from, dstObject = _to });
				}
			}

			return ir;
		}
	}
}

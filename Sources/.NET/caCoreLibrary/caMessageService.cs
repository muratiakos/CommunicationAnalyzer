using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace caCoreLibrary
{
	public enum caMessageType
	{
		Information,
		Warning,
		Error
	}

	[DataContract]
	public class caMessage
	{
		[DataMember]
		public caMessageType type = caMessageType.Information;
		[DataMember]
		public string code = "";
		[DataMember]
		public string text = "Nothing";
	}

	public class caMessageService
	{
		public static event EventHandler NewMessage;
		public static List<caMessage> messageQueue = new List<caMessage>();
		public static void Add(caMessage m)
		{
			messageQueue.Add(m);
			try
			{
				NewMessage.Invoke(m, new EventArgs());
			}
			catch { }
		}
		public static void AddException(string module, Exception ex)
		{
			caMessage m = new caMessage()
			{
				type = caMessageType.Error,
				code = module,
				text = ex.Message
			};

			Add(m);
		}

		public static void AddException(Exception ex)
		{
			AddException(ex.GetType().ToString(), ex);
		}

	}
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace caCoreLibrary
{
	//RendszerÜzenet osztály típusait tartalmazó enumeráció
	public enum caMessageType
	{
		Information,
		Warning,
		Error
	}

	/// <summary>
	/// RendszerÜzenetet megvalósító osztály kliens, szerver és hálózati üzenethordozáshoz
	/// </summary>
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

	/// <summary>
	/// RendszerÜzenetezelő modul
	/// RendszerÜzenetek fogadása, lekérdezése és eseménykezelése
	/// </summary>
	public class caMessageService
	{
		//Új üzenet eseménykezelője
		public static event EventHandler NewMessage;
		//Mg le nem kérdezett üzenetek várakozási sora
		public static List<caMessage> messageQueue = new List<caMessage>();

		//Új üzenet hozzáadása a várakozási sorhoz
		public static void Add(caMessage m)
		{
			messageQueue.Add(m);
			try
			{
				NewMessage.Invoke(m, new EventArgs());
			}
			catch { }
		}

		//Kivétel, mint hiba hozzáadása a várakozási sorhoz egy adott modulból
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

		//Általános kivétel, mint hiba felvétele az üzenetsorba
		public static void AddException(Exception ex)
		{
			AddException(ex.GetType().ToString(), ex);
		}

	}
}

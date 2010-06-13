using System;
using System.ServiceModel;
using caServiceLibrary;
using System.ServiceModel.Description;

namespace caServiceHost
{
	/// <summary>
	/// WCF Service hostolását megvalósító futtatható osztály
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			//HOst szolgáltatás indítása
			ServiceHost caServiceHost = new ServiceHost(typeof(Service));
			try
			{
				//Kapcsolat megnyitása
				caServiceHost.Open();

				Console.WriteLine("caServiceHost is running...");
				foreach (ServiceEndpoint sep in caServiceHost.Description.Endpoints)
					Console.WriteLine(sep.Address.ToString());

				Console.WriteLine("Press Enter to shut down Service");
				Console.ReadLine();

				caServiceHost.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Error: caServiceHost is not running! Press Enter to exit!");
				Console.ReadLine();
			}

		}
	}
}

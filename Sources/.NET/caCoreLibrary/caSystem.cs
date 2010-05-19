using System;
using System.Runtime.Serialization;

namespace caCoreLibrary
{
	public enum caObjectState
	{
		Unknown,
		NotSyncronized,
		Syncronized
	}

	public enum caRecordStatus
	{
		Unknown = -1,
		Registered = 0,
		Active = 1,
		InActive = 2,
		Deleted = 3
	}

	[DataContract]
	public class caTaggingRule
	{
		[DataMember]
		public String RuleId { get; set; }
		[DataMember]
		public caRecordStatus Status { get; set; }
		[DataMember]
		public String Name { get; set; }
		[DataMember]
		public String Tag { get; set; }
		[DataMember]
		public String Query { get; set; }
		[DataMember]
		public bool Custom_Query { get; set; }

		public caTaggingRule()
		{
			RuleId = System.Guid.NewGuid().ToString();
			Status = caRecordStatus.Registered;
			Custom_Query = true;
		}

	}


}

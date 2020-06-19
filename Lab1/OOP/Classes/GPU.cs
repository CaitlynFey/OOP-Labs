using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class GPU : SystemDevice
	{
		private string Architecture { get; set; }
		private string Type { get; set; }
	}
}
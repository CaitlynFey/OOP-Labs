using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class CPU : SystemDevice
	{
		private int Cores { get; set; }
		private int Caches { get; set; }
	}
}
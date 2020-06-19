using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Memory : SystemDevice
	{
		private int Size { get; set; }
	}
}
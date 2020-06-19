using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class SystemDevice : Device
	{
		public float Clock { get; set; }
	}
}
using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Soundcard : SystemDevice
	{
		private string DAC { get; set; }
	}
}
using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Microphone : InputDevice
	{
		private string Type { get; set; }
	}
}
using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Keyboard : InputDevice
	{
		private string Layout { get; set; }
	}
}
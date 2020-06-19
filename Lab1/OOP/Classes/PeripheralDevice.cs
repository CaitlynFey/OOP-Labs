using System;
using System.Drawing;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class PeripheralDevice : Device
	{
		public string PlugType { get; set; }
		public string Power { get; set; }
		public string colour { get; set; }
	}
}
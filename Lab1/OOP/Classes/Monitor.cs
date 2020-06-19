using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Monitor : OutputDevice
	{
		private long Resolution { get; set; }
		private float Dimentions { get; set; }
		private float PixelPitch { get; set; }
	}
}
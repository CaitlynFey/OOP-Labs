using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Headphones : OutputDevice
	{
		private float FrequencyResponse { get; set; }
	}
}
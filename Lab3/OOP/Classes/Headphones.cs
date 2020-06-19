using System;

namespace OOP.Classes
{
	[Serializable]
	public class Headphones : OutputDevice
	{
		private float frequencyResponse;

		private float FrequencyResponse
		{
			get => frequencyResponse;
			set => frequencyResponse = value;
		}
	}
}
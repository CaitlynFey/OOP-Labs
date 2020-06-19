using System;

namespace OOP.Classes
{
	[Serializable]
	public class Soundcard : SystemDevice
	{
		private string dAC;

		public string DAC
		{
			get => dAC;
			set => dAC = value;
		}
	}
}
using System;

namespace OOP.Classes
{
	[Serializable]
	public class Speakers : PeripheralDevice
	{
		private string type;

		public string Type
		{
			get => type;
			set => type = value;
		}
	}
}
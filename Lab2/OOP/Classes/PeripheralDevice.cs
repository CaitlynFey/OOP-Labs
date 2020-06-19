using System;

namespace OOP.Classes
{
	[Serializable]
	public abstract class PeripheralDevice : Device
	{
		private string plugType;
		private string power;
		private string colour;

		public string PlugType
		{
			get => plugType;
			set => plugType = value;
		}
		public string Power
		{
			get => power;
			set => power = value;
		}
		public string Colour
		{
			get => colour;
			set => colour = value;
		}
	}
}
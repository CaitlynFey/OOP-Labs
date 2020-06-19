using System;

namespace OOP.Classes
{
	[Serializable]
	public class Mouse : InputDevice
	{
		private int buttons;
		private int scrollWheels;

		public int Buttons
		{
			get => buttons;
			set => buttons = value;
		}
		public int ScrollWheels
		{
			get => scrollWheels;
			set => scrollWheels = value;
		}
	}
}
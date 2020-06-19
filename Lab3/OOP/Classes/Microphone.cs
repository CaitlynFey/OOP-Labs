using System;

namespace OOP.Classes
{
	[Serializable]
	public class Microphone : InputDevice
	{
		private string type;

		public string Type
		{
			get => type;
			set => type = value;
		}
	}
}
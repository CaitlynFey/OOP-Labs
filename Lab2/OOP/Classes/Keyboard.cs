using System;

namespace OOP.Classes
{
	[Serializable]
	public class Keyboard : InputDevice
	{
		private string layout;

		public string Layout
		{
			get => layout;
			set => layout = value;
		}
	}
}
using System;

namespace OOP.Classes
{
	[Serializable]
	public abstract class SystemDevice : Device
	{
		private float clock;

		public float Clock
		{
			get => clock;
			set => clock = value;
		}
	}
}
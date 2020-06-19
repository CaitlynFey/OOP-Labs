using System;

namespace OOP.Classes
{
	[Serializable]
	public class Memory : SystemDevice
	{
		private int size;

		public int Size
		{
			get => size;
			set => size = value;
		}
	}
}
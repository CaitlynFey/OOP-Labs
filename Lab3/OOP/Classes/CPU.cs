using System;

namespace OOP.Classes
{
	[Serializable]
	public class CPU : SystemDevice
	{
		private int cores;
		private int caches;

		public int Cores
		{
			get => cores;
			set => cores = value;
		}
		public int Caches
		{
			get => caches;
			set => caches = value;
		}
	}
}
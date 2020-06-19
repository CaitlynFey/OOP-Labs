using System;

namespace OOP.Classes
{
	[Serializable]
	public class GPU : SystemDevice
	{
		private string architecture;
		private string type;

		public string Architecture
		{
			get => architecture;
			set => architecture = value;
		}
		public string Type
		{
			get => type;
			set => type = value;
		}
	}
}
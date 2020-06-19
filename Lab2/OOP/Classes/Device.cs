using System;

namespace OOP.Classes
{
	[Serializable]
	public abstract class Device
	{
		private string productName;
		private string manufacturerName;

		public string ProductName
		{
			get => productName;
			set => productName = value;
		}
		public string ManufacturerName
		{
			get => manufacturerName;
			set => manufacturerName = value;
		}
	}
}
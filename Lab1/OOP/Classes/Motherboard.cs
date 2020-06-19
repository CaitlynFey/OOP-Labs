using System;

namespace OOP.Classes
{
	[Serializable()]
	[System.Runtime.Serialization.DataContract]
	public class Motherboard : SystemDevice
	{
		private int PCIePorts { get; set; }
		private string PCHName { get; set; }
		private bool UEFIBoot { get; set; }
		private int BIOSVersion { get; set; }

		public CPU cpu { get; set; }
		public Memory memory { get; set; }
	}
}
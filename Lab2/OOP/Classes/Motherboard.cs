using System;

namespace OOP.Classes
{
	[Serializable]
	public class Motherboard : SystemDevice
	{
		private int pCIePorts;
		private string pCHName;
		private bool uEFIBoot;
		private int bIOSVersion;
		private CPU cpu;
		private Memory memory;

		public int PCIePorts
		{
			get => pCIePorts;
			set => pCIePorts = value;
		}
		public string PCHName
		{
			get => pCHName;
			set => pCHName = value;
		}
		public bool UEFIBoot
		{
			get => uEFIBoot;
			set => uEFIBoot = value;
		}
		public int BIOSVersion
		{
			get => bIOSVersion;
			set => bIOSVersion = value;
		}
		public CPU Cpu
		{
			get => cpu;
			set => cpu = value;
		}
		public Memory Memory
		{
			get => memory;
			set => memory = value;
		}
	}
}
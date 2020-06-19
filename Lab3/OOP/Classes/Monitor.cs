using System;

namespace OOP.Classes
{
	[Serializable]
	public class Monitor : OutputDevice
	{
		private long resolution;
		private float dimensions;
		private float pixelPitch;

		public long Resolution
		{
			get => resolution;
			set => resolution = value;
		}
		public float Dimentions
		{
			get => dimensions;
			set => dimensions = value;
		}
		public float PixelPitch
		{
			get => pixelPitch;
			set => pixelPitch = value;
		}
	}
}
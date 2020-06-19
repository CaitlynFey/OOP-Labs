using System.IO;

namespace OOP.Serialization
{
	public class CustomSerializer
	{

		private string fileName;

		public CustomSerializer(string fileName)
		{
			this.fileName = fileName;
		}

		public T LoadCUS<T>() where T : class
		{
			using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				return null;
			}
		}

		public void SaveCUS<T>(T obj) where T : class
		{
			using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				
			}
		}

	}
}
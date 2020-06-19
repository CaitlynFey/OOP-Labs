using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP.Serialization
{
	public class BINSerializer
	{

		private string fileName;

		public BINSerializer(string fileName)
		{
			this.fileName = fileName;
		}

		public T LoadBIN<T>() where T : class
		{
			using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				var serializer = new BinaryFormatter();
				return serializer.Deserialize(fs) as T;
			}
		}

		public void SaveBIN<T>(T obj) where T : class
		{
			using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				var serializer = new BinaryFormatter();
				serializer.Serialize(fs, obj);
			}
		}

	}
}
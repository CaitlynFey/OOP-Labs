using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Plugin;

namespace OOP.Serialization
{
	public class BINSerializer : AbstractSerializer
	{

		private string fileName;

		public BINSerializer(string fileName)
		{
			this.fileName = fileName;
		}

		public override T Load<T>(AbstractPlugin plugin)
		{
			using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				var serializer = new BinaryFormatter();
				return serializer.Deserialize(fs) as T;
			}
		}

		public override void Save<T>(AbstractPlugin plugin, T obj)
		{
			using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				var serializer = new BinaryFormatter();
				serializer.Serialize(fs, obj);
			}
		}

	}
}
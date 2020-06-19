using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace OOP.Serialization
{
	public class JSONSerializer
	{

		private string fileName;

		public JSONSerializer(string fileName)
		{
			this.fileName = fileName;
		}

		public T LoadJSON<T>() where T : class
		{
			using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				int length = (int)fs.Length;
				byte[] buffer = new byte[length];
				fs.Read(buffer, 0, length);
				string text = Encoding.ASCII.GetString(buffer);
				return JsonConvert.DeserializeObject<T>(text);
			}
		}

		public void SaveJSON<T>(T obj) where T : class
		{
			using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				string text = JsonConvert.SerializeObject(obj);
				byte[] buffer = Encoding.ASCII.GetBytes(text);
				fs.Write(buffer, 0, buffer.Length);
				fs.Flush();
			}
		}

	}
}
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Plugin;

namespace OOP.Serialization
{
	public class JSONSerializer : AbstractSerializer
	{

		private string fileName;

		public JSONSerializer(string fileName)
		{
			this.fileName = fileName;
		}

		public override T Load<T>(AbstractPlugin plugin)
		{
			using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				int length = (int)fs.Length;
				byte[] buffer = new byte[length];
				fs.Read(buffer, 0, length);
				if (plugin != null)
				{
					buffer = plugin.Decrypt(buffer);
				}
				string text = Encoding.ASCII.GetString(buffer);
				return JsonConvert.DeserializeObject<T>(text);
			}
		}

		public override void Save<T>(AbstractPlugin plugin, T obj)
		{
			using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				string text = JsonConvert.SerializeObject(obj);
				byte[] buffer = Encoding.ASCII.GetBytes(text);
				if (plugin != null)
				{
					buffer = plugin.Encrypt(buffer);
				}
				fs.Write(buffer, 0, buffer.Length);
				fs.Flush();
			}
		}

	}
}
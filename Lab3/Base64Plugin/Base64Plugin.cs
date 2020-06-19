using System;
using System.Text;
using Plugin;

namespace Base64Plugin
{
    public class Base64Plugin : AbstractPlugin
    {

		public override string GetName()
		{
            return "Base64";
		}
		public override byte[] Encrypt(byte[] data)
        {
            try
            {
                string text = Convert.ToBase64String(data);
                return Encoding.ASCII.GetBytes(text);
            }
            catch (Exception error)
            {
                throw new Exception("Ошибка при попытке закодировать информация кодированием Base64\n" + error.Message);
            }
        }

        public override byte[] Decrypt(byte[] data)
        {
            try
            {
                string text = Encoding.ASCII.GetString(data);
                return Convert.FromBase64String(text);
            }
            catch (Exception error)
            {
                throw new Exception("Ошибка при попытке раскодировать информацию кодированием Base64\n" + error.Message);
            }
        }
    }
}
namespace Plugin
{
	public abstract class AbstractPlugin
	{

		public abstract string GetName();

		public abstract byte[] Encrypt(byte[] data);
		
		public abstract byte[] Decrypt(byte[] data);

	}
}
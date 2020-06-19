using Plugin;

namespace OOP.Serialization
{
	public abstract class AbstractSerializer
	{

		public abstract T Load<T>(AbstractPlugin plugin) where T : class;

		public abstract void Save<T>(AbstractPlugin plugin, T obj) where T : class;

	}
}
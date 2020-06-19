using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using OOP.Classes;
using OOP.Serialization;
using Plugin;

namespace OOP
{
	public partial class MainForm : Form
	{

		public static Dictionary<string, Type> typeDictionary = new Dictionary<string, Type>()
		{
			{ "CPU",            typeof(CPU) },
			{ "GPU",            typeof(GPU) },
			{ "Headphones",     typeof(Headphones) },
			{ "Keyboard",       typeof(Keyboard) },
			{ "Memory",         typeof(Memory) },
			{ "Microphone",     typeof(Microphone) },
			{ "Monitor",        typeof(Monitor) },
			{ "Motherboard",    typeof(Motherboard) },
			{ "Mouse",          typeof(Mouse) },
			{ "Soundcard",      typeof(Soundcard) },
			{ "Speakers",       typeof(Speakers) }
		};

		public static Dictionary<string, AbstractSerializer> serializers = new Dictionary<string, AbstractSerializer>()
		{
			{ "JSON", new JSONSerializer("objects.JSON") },
			{ "BIN", new BINSerializer("objects.BIN") }
		};

		public static Dictionary<string, AbstractPlugin> plugins = new Dictionary<string, AbstractPlugin>();

		List<Device> objects = new List<Device>();

		public MainForm()
		{
			InitializeComponent();
			foreach (KeyValuePair<string, Type> pair in typeDictionary)
			{
				classBox.Items.Add(pair.Key);
			}
			foreach (KeyValuePair<string, AbstractSerializer> pair in serializers)
			{
				serList.Items.Add(pair.Key);
			}
			string[] files = Directory.GetFiles(".", "*.dll");
			foreach (string path in files)
			{
				Type[] types = null;

				var assembly = Assembly.LoadFrom(path);
				if (assembly != null)
				{
					types = assembly.GetTypes();
					foreach (Type type in types)
					{
						if (type.IsSubclassOf(typeof(AbstractPlugin)))
						{
							AbstractPlugin plugin = Activator.CreateInstance(type) as AbstractPlugin;
							string name = plugin.GetName();
							plugins.Add(name, plugin);
							pluginsList.Items.Add(name);
						}
					}
				}
			}
		}

		private bool CreateCRUD(ref object writeBack)
		{
			return (new CRUD(ref writeBack, null)).ShowDialog() == DialogResult.OK;
		}

		private void createButton_Click(object sender, EventArgs e)
		{
			int index = classBox.SelectedIndex;
			object o;
			string text = classBox.Text;
			typeDictionary.TryGetValue(text, out Type t);
			if (t != null)
			{
				o = t.GetConstructors()[0].Invoke(null);
				if (CreateCRUD(ref o))
				{
					objects.Add((Device)o);
					objectsList.Items.Add(o.GetType().Name);
				}
			}
		}

		private void Edit()
		{
			if (objectsList.SelectedItem != null)
			{
				int index = objectsList.SelectedIndex;
				object o = objects[index];
				if (CreateCRUD(ref o))
				{
					objects[index] = (Device)o;
				}
			}
		}

		private void Delete()
		{
			if (objectsList.SelectedItem != null)
			{
				int index = objectsList.SelectedIndex;
				objects.RemoveAt(index);
				objectsList.Items.RemoveAt(index);
			}
		}

		private void Serialize()
		{
			if (serializers.TryGetValue(serList.SelectedItem.ToString(), out AbstractSerializer ser))
			{
				AbstractPlugin plugin = null;
				object o = pluginsList.SelectedItem;
				if (o != null)
				{
					string pluginName = o.ToString();
					plugin = plugins[pluginName];
				}
				ser.Save(plugin, objects);
			}
		}

		private void Deserialize()
		{
			if (serializers.TryGetValue(serList.SelectedItem.ToString(), out AbstractSerializer ser))
			{
				AbstractPlugin plugin = null;
				object o = pluginsList.SelectedItem;
				if (o != null)
				{
					string pluginName = o.ToString();
					plugin = plugins[pluginName];
				}
				objects = ser.Load<List<Device>>(plugin);
				FillList();
			}
		}

		private void FillList()
		{
			objectsList.Items.Clear();
			foreach (object obj in objects)
			{
				objectsList.Items.Add(obj.GetType().Name);
			}
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			Edit();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void objectsList_DoubleClick(object sender, EventArgs e)
		{
			Edit();
		}

		private void loadBtn_Click(object sender, EventArgs e)
		{
			Deserialize();
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			Serialize();
		}
	}
}
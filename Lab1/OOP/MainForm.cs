using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OOP.Classes;

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

		List<object> objects = new List<object>();

		CRUD crud;

		public MainForm()
		{
			InitializeComponent();
			foreach (KeyValuePair<string, Type> pair in typeDictionary)
			{
				classBox.Items.Add(pair.Key);
			}
		}

		private bool CreateCRUD(ref object writeBack)
		{
			return (crud = new CRUD(ref writeBack, null)).ShowDialog() == DialogResult.OK;
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
					objects.Add(o);
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
					objects[index] = o;
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

	}
}
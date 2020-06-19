using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace OOP
{
	public partial class CRUD : Form
	{

		const int controlHeight = 25;
		const int controlWidth = 250;

		Type type;
		TypeInfo typeInfo;
		PropertyInfo info;

		PropertyInfo[] fields;

		List<Control> controls = new List<Control>();

		private object writeBack;

		public CRUD(ref object writeBack, PropertyInfo info)
		{
			InitializeComponent();
			this.writeBack = writeBack;
			this.info = info;
			Setup();
		}

		public void Setup()
		{
			type = writeBack.GetType();
			typeInfo = type.GetTypeInfo();
			fields = typeInfo.GetProperties();
			for (int i = 0; i < fields.Length; i++)
			{
				Label label = new Label()
				{
					Left = 0,
					Top = i * controlHeight * 2,
					Width = controlWidth,
					Height = controlHeight,
					Text = fields[i].PropertyType.Name + " " + fields[i].Name
				};
				Control control;
				Type t = fields[i].PropertyType;
				if (t.IsPrimitive || t.Equals(typeof(string)))
				{
					controls.Add(control = new TextBox());
					object o = fields[i].GetValue(writeBack);
					control.Text = o != null ? o.ToString() : "";
				}
				else
				{
					controls.Add(control = new Button());
					control.Text = "object";
					(control as Button).Click += ObjectEditor;
				}
				control.Left = 0;
				control.Top = i * controlHeight * 2 + controlHeight;
				control.Width = controlWidth;
				control.Height = controlHeight;
				this.Controls.Add(label);
				this.Controls.Add(control);
			}

			Button deleteButton = new Button()
			{
				Left = 0,
				Top = (controlHeight) * controls.Count * 2 + 40,
				Text = "Delete!",
				Width = controlWidth,
				Height = controlHeight
			};
			deleteButton.Click += DeleteButtonClick;
			this.Controls.Add(deleteButton);

			Button saveButton = new Button()
			{
				Left = 0,
				Top = (controlHeight + 1) * controls.Count * 2,
				Text = "Save!",
				Width = controlWidth,
				Height = controlHeight
			};
			saveButton.Click += SaveButtonClick;
			this.Controls.Add(saveButton);
			this.Height = (controls.Count + 3) * (controlHeight) * 2;
		}

		private void ObjectEditor(object sender, EventArgs ae)
		{
			int index = controls.IndexOf((Control)sender);
			PropertyInfo fieldInfo = fields[index];
			object value = fieldInfo.GetValue(writeBack);
			object field;
			if (value == null)
			{
				field = fieldInfo.PropertyType.GetConstructors()[0].Invoke(null);
				fieldInfo.SetValue(writeBack, field);
			}
			else
			{
				field = fieldInfo.GetValue(writeBack);
			}
			if ((new CRUD(ref field, fieldInfo)).ShowDialog() == DialogResult.OK)
			{
				field = fieldInfo.PropertyType.GetConstructors()[0].Invoke(null);
				fieldInfo.SetValue(writeBack, field);
			}
		}

		private void DeleteButtonClick(object sender, EventArgs ea)
		{
			if (info != null)
			{
				info = null;
			}
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void SaveButtonClick(object sender, EventArgs ea)
		{
			int index = 0;
			bool problems = false;
			foreach (Control control in controls)
			{
				control.BackColor = Color.White;

				PropertyInfo fieldInfo = fields[index];
				TypeInfo typeInfo = fieldInfo.PropertyType.GetTypeInfo();
				string value = control.Text;

				if (typeInfo.IsPrimitive)
				{
					MethodInfo methodInfo = typeInfo.GetMethod("Parse", new Type[] { typeof(string) });
					try
					{
						object result = methodInfo.Invoke(writeBack, new object[] { value });
						fieldInfo.SetValue(writeBack, result);
					}
					catch (Exception)
					{
						control.BackColor = Color.Red;
						problems = true;
					}
				}
				else if (typeInfo.Equals(typeof(string)))
				{
					fields[index].SetValue(writeBack, value);
				}
				index++;
			}
			if (!problems)
			{
				if (info != null)
				{
					info = null;
				}
				DialogResult = DialogResult.OK;
				Close();
			}
		}

	}
}
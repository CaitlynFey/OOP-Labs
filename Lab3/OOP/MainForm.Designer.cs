﻿namespace OOP
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.classBox = new System.Windows.Forms.ComboBox();
			this.createButton = new System.Windows.Forms.Button();
			this.objectsList = new System.Windows.Forms.ListBox();
			this.editButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.loadBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.serList = new System.Windows.Forms.ListBox();
			this.pluginsList = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// classBox
			// 
			this.classBox.FormattingEnabled = true;
			this.classBox.Location = new System.Drawing.Point(22, 21);
			this.classBox.Name = "classBox";
			this.classBox.Size = new System.Drawing.Size(217, 21);
			this.classBox.TabIndex = 0;
			// 
			// createButton
			// 
			this.createButton.Location = new System.Drawing.Point(22, 48);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(217, 26);
			this.createButton.TabIndex = 1;
			this.createButton.Text = "CREATE!!!";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.createButton_Click);
			// 
			// objectsList
			// 
			this.objectsList.FormattingEnabled = true;
			this.objectsList.Location = new System.Drawing.Point(22, 80);
			this.objectsList.Name = "objectsList";
			this.objectsList.Size = new System.Drawing.Size(217, 186);
			this.objectsList.TabIndex = 2;
			this.objectsList.DoubleClick += new System.EventHandler(this.objectsList_DoubleClick);
			// 
			// editButton
			// 
			this.editButton.Location = new System.Drawing.Point(22, 278);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(94, 24);
			this.editButton.TabIndex = 3;
			this.editButton.Text = "edit";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(145, 278);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(94, 24);
			this.deleteButton.TabIndex = 4;
			this.deleteButton.Text = "delete";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// loadBtn
			// 
			this.loadBtn.Location = new System.Drawing.Point(263, 80);
			this.loadBtn.Name = "loadBtn";
			this.loadBtn.Size = new System.Drawing.Size(109, 29);
			this.loadBtn.TabIndex = 13;
			this.loadBtn.Text = "Load";
			this.loadBtn.UseVisualStyleBackColor = true;
			this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(405, 80);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(109, 29);
			this.saveBtn.TabIndex = 14;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// serList
			// 
			this.serList.FormattingEnabled = true;
			this.serList.Location = new System.Drawing.Point(263, 21);
			this.serList.Name = "serList";
			this.serList.Size = new System.Drawing.Size(251, 43);
			this.serList.TabIndex = 15;
			// 
			// pluginsList
			// 
			this.pluginsList.FormattingEnabled = true;
			this.pluginsList.Location = new System.Drawing.Point(263, 137);
			this.pluginsList.Name = "pluginsList";
			this.pluginsList.Size = new System.Drawing.Size(251, 43);
			this.pluginsList.TabIndex = 16;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 314);
			this.Controls.Add(this.pluginsList);
			this.Controls.Add(this.serList);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.loadBtn);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.objectsList);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.classBox);
			this.Name = "MainForm";
			this.Text = "CRUD OOP";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox classBox;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.ListBox objectsList;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button loadBtn;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.ListBox serList;
		private System.Windows.Forms.ListBox pluginsList;
	}
}


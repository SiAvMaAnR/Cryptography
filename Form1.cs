using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography_1
{
	public partial class Form1 : Form
	{
		private byte RadioButtonState;
		
		public Form1()
		{
			InitializeComponent();
		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			
			for (Opacity = 0; Opacity < 1; Opacity += 0.02)
			{
				await Task.Delay(10);
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape: Close();break;
			}
		}//Системные клавиши

		private void label1_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(label1.Text))
				if (MessageBox.Show("Скопировать данные в буфер обмена?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					Clipboard.SetText(label1.Text, TextDataFormat.UnicodeText);
		}//Копировать текст в буфер обмена

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			(textBox1.Text,label1.Text) = (label1.Text,textBox1.Text);
		}//Сменить местамитекст ввода и вывода

		private void radioButton1_CheckedChanged(object sender, EventArgs e)//Система цезаря с ключевым словом
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				RadioButtonState = 1;
			}
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)//Аффинная система подстановки Цезаря
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				RadioButtonState = 2;
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)//Двойной квадрат Уитстона
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				RadioButtonState = 3;
			}
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)//Шифр двойной перестановки
		{
			RadioButton radioButton = (RadioButton)sender;
			if (radioButton.Checked)
			{
				RadioButtonState = 4;
			}
		}

		private void FirstEncrypt()//Шифрование 1 методом
		{
			try
			{
				int.TryParse(textBox2.Text, out int KeyNumber);
				if(textBox3.Text.Length>=30)
				{
					throw new Exception("Длина ключевого слова выходит за пределы!");
				}
				FirstCipher firstcipher = new FirstCipher(textBox3.Text, KeyNumber, textBox1.Text);
				label1.Text = firstcipher.Encode();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FirstDecrypt()//Шифрование 1 методом
		{
			try
			{
				int.TryParse(textBox2.Text, out int KeyNumber);
				if (textBox3.Text.Length >= 30)
				{
					throw new Exception("Длина ключевого слова выходит за пределы!");
				}
				FirstCipher firstcipher = new FirstCipher(textBox3.Text, KeyNumber, textBox1.Text);
				label1.Text = firstcipher.Decode();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void encrypt_Click(object sender, EventArgs e)//Зашифровать
		{
			switch (RadioButtonState)
			{
				case 1: FirstEncrypt(); break;
				case 2: break;
				case 3: break;
				case 4: break;
				default: MessageBox.Show("Выберите тип шифра!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);break;
			}
			
		}

		private void decrypt_Click(object sender, EventArgs e)//Дешифровать
		{
			switch (RadioButtonState)
			{
				case 1: FirstDecrypt(); break;
				case 2: break;
				case 3: break;
				case 4: break;
				default: MessageBox.Show("Выберите тип шифра!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
			}
		}

	}
}

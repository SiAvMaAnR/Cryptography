using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_1
{
	class FourthCipher
	{
		private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";//Набор сиволов
		public string text = "";
		private string firstKey = "";
		private string secondKey = "";

		private string encrypt;//Зашифрованные данные
		private string decrypt;//Дешифрованные данные

		public int height;//Высота
		private int width;//Широта

		private char [,] Table;//Таблица

		public FourthCipher(string text, string firstKey, string secondKey, out int Height)
		{
			this.text = text;//Исходный текст
			this.firstKey = firstKey;//Первый ключ
			this.secondKey = secondKey;//Второй ключ
			this.width = firstKey.Length;//Ширина таблицы
			this.height = (int)Math.Ceiling(Convert.ToDouble(text.Length) / Convert.ToDouble(width));//Высота таблицы
			this.Table = new char[height,width];//Таблица
			Height = height;//Возвращаем высоту таблицы
		}

		//Заполнение Таблицы
		private void FillTable()
		{
			for (int i = 0, n = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Table[i, j] = (text.Length == n) ?' ': text[n++];
				}
			}
		}

		//Корректировка горизонтальных индексов
		private void CorrectWidth()
		{

		}

		//Корректировка вертикальных индексов
		private void CorrectHeight()
		{

		}

		//Основные действия
		private void CipherDerivation()
		{

		}
	}
}

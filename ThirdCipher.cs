using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_1
{
	class ThirdCipher
	{
		private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789.,?!*/+-=_()%;:#";//Набор сиволов
		private static int length = 12;//Ширина квадрата
		private static int height = 12;//Высота квадрата

		public char[,] FirstSquare = new char[height, length];//Первый квадрат Уитстона
		public char[,] SecondSquare = new char[height, length];//Второй квадрат Уитстона 

		private string firstKey = "";
		private string secondKey = "";

		private string text = "";

		public ThirdCipher(string firstKey,string secondKey,string text)
		{
			//Удаление повторяющихся символов из первого ключа
			this.firstKey = new string(firstKey.Distinct().ToArray()).Replace(" ", "");
			//Удаление повторяющихся символов из второго ключа
			this.secondKey = new string(secondKey.Distinct().ToArray()).Replace(" ", "");
			this.text = text;
		}

		private string GetKeyLess(string _Key)//Вернуть алфавит без указанного ключа
		{
			string ResidualAlphabet = Alphabet;
			for (int i = 0; i < _Key.Length; i++)//Алфавит без Ключевого слова
			{
				ResidualAlphabet = ResidualAlphabet.Replace(_Key[i].ToString(), "");
			}
			return ResidualAlphabet;
		}


		public void SetFirstSquare()
		{
			string KeyLess = GetKeyLess(firstKey);
			int index = 0, k = 0;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < length; j++)
				{
					if (index < firstKey.Length)
					{
						FirstSquare[i, j] = firstKey[index];
						index++;
					}
					else
					{
						FirstSquare[i, j] = KeyLess[k];
						k++;
					}
				}
			}
		}
		

		public void SetSecondSquare()
		{
			string KeyLess = GetKeyLess(secondKey);
			int index = 0, k = 0;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < length; j++)
				{
					if (index < secondKey.Length)
					{
						SecondSquare[i, j] = secondKey[index];
						index++;
					}
					else
					{
						SecondSquare[i, j] = KeyLess[k];
						k++;
					}
				}
			}
		}


		public char[,] Length()
		{
			//return Alphabet.Length;
			return FirstSquare;
		}
	}
}

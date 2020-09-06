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

		private static int columns = 12;//Столбцы
		private static int rows = 12;//Ряды

		public char[,] FirstSquare = new char[columns, rows];//Первый квадрат Уитстона
		public char[,] SecondSquare = new char[columns, rows];//Второй квадрат Уитстона 

		private string firstKey = "";
		private string secondKey = "";

		public string encrypt = "";
		private string decrypt = "";

		public string text = "";

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

		//Первый квадрат
		public void SetFirstSquare()
		{
			string KeyLess = GetKeyLess(firstKey);
			int index = 0, k = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
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
		//Второй квадрат
		public void SetSecondSquare()
		{
			string KeyLess = GetKeyLess(secondKey);
			int index = 0, k = 0;
			for (int i = 0; i < columns; i++)
			{
				for (int j = 0; j < rows; j++)
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

		//Создание двух квадратов и замена пробелов на подчеркивания
		public void CipherDerivation()
		{
			SetFirstSquare();
			SetSecondSquare();
			text = text.Replace(" ","_");
			if(text.Length%2==1)
				text += "_";
		}

		//Зашифровка
		public string Encode()
		{
			CipherDerivation();
			string Pair ="";
			for (int i = 0; i < text.Length; i++)
			{
				Pair += text[i];
				if (i % 2 == 1)
				{
					encrypt += ElementPairCipher(Pair) + " ";
					Pair = "";
				}
			}
			return encrypt;
		}

		//Дешифровка путем замены засположения квадратов - пробуем
		public string Decode()
		{
			CipherDerivation();
			string Pair = "";
			for (int i = 0; i < text.Length; i++)
			{
				Pair += text[i];
				if (i % 2 == 0)
				{
					decrypt += ElementPairCipher(Pair) + " ";
					Pair = "";
				}
			}
			return decrypt;
		}


		//Поиск позиции элемента в таблице
		private void SearchIndexToArray(char [,] Square, char SearchChar, out int TableRows, out int TableColumns)
		{
			TableRows = -1;
			TableColumns = -1;
			int Rows = Square.GetUpperBound(0);//Ряды
			int Columns = Square.GetUpperBound(1);//Колонки

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					if (Square[i, j].Equals(SearchChar))
					{
						TableRows = i;
						TableColumns = j;
					}
				}
			}
		}


		//Замена пары символов на зашифрованную пару
		private string ElementPairCipher(string StrPair)
		{
			string Pair = "";
			SearchIndexToArray(FirstSquare, StrPair[0], out int Rows_0, out int Columns_0);//Позиция 1 символа в 1 квадрате
			SearchIndexToArray(SecondSquare, StrPair[1], out int Rows_1, out int Columns_1);//Позиция 2 символа в 2 квадрате


			return Pair;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography_1
{
	class SecondCipher
	{
		private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";//Набор сиволов
		private int[] ArrNumber = new int[Alphabet.Length];//Массив чисел, соответствующих алфавиту
		private string Text;

		//=====================================================================================
		private int n = Alphabet.Length;//Количество элементов в алфавите
		private int K;//Первый ключ
		private int A;//Второй ключ
		//x - Позиция шифруемого символа
		//Шифрование -->  y = (Kx + A) % n
		//=====================================================================================

		public SecondCipher(int K,int A, string Text, out int a)
		{
			a = n;
			this.K = K;
			this.A = A;
			this.Text=Text;
		}

		public void AlphabetNumber()//Задаем массиву ArrNumber значения
		{
			for (int i = 0; i < ArrNumber.Length; i++)
				ArrNumber[i] = i;
		}

		private string CipherDerivation()
		{

			return "";
		}

		public string TestPrintArray()//Массив в виде строки
		{
			string str="";
			foreach (var item in ArrNumber)
			{
				str += item.ToString();
			}
			return str;
		}
	}
}

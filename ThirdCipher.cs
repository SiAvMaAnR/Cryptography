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

		private string[,] FirstSquare = new string[length,height];//Первый квадрат Уитстона
		private string[,] SecondSquare = new string[length, height];//Второй квадрат Уитстона 

		private string firstKey = "";
		private string secondKey = "";

		private string text = "";

		public ThirdCipher(string firstKey,string secondKey,string text)
		{
			this.firstKey = firstKey;
			this.secondKey = secondKey;
			this.text = text;
		}

		private void SetFirstSquare()
		{

		}
		
		private void SetSecondSquare()
		{

		}

		public int Length()
		{
			return Alphabet.Length;
		}
	}
}

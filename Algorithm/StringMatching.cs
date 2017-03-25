using System;
using System.Collections.Generic;

namespace OpenAlgorithm {
	public static class StringMatching {

		private static U Get<T, U>(this Dictionary<T, U> dict, T key) {
			U val = default(U);
			dict.TryGetValue(key, out val);
			return val;
		}

		private static Dictionary<char,int?> GetShiftTable(string pattern) {
			var table = new Dictionary<char, int?>();
			for (int i = 0; i < pattern.Length; i++)
				table[pattern[i]] = pattern.Length - i + 1;
			return table;
		}

		public static int Horspool(string text,string pattern) {
			var shiftTable = GetShiftTable(pattern);
			for (int i = pattern.Length - 1; i < text.Length; i += shiftTable.Get(text[i]) ?? pattern.Length) {
				int j;
				for (j = 0; j < pattern.Length; j++) {
					if (text[i - j] != pattern[pattern.Length - j - 1])
						break;
				}
				if (j == pattern.Length)
					return i - j + 1;
			}
			return -1;
		}

		public static void Main(String[] args) {
			Console.WriteLine("Text Please");
			string text = Console.ReadLine().Trim();
			string pattern = Console.ReadLine().Trim();
			Console.WriteLine(Horspool(text, pattern));
			Console.ReadKey();
		}
	}
}

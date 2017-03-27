using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAlgorithm {
	class Test {
		public static void Main(string[] args) {
			Console.WriteLine("Texts Please");
			string[] tokens = Console.ReadLine().Split();
			//int[] tokens = new int[] { 10, 28, 1, 3, 29, 12 };
			foreach (var s in tokens)
				Console.WriteLine(s);
			var sorted = Sort.QuickSort(tokens);
			Console.WriteLine();
			foreach (var s in sorted)
				Console.WriteLine(s);
			Console.ReadKey();
		}
	}
}

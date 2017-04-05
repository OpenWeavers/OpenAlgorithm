using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAlgorithm {
	class Test {
		public static void Main(string[] args) {
			Console.WriteLine("How many elements");
			int n = int.Parse(Console.ReadLine().Split()[0]);
			Console.WriteLine("Enter elements");
			string resonse = Console.ReadLine();
			int[] array = new int[n];
			int k = 0;
			foreach (string s in resonse.Split())
				array[k++] = int.Parse(s);
			var bst = new BinarySearchTree<int>();
			foreach (var item in array) {
				bst.Add(item);
			}
			foreach (var item in bst) {
				Console.Write($"{item} ");
			}
			Console.WriteLine();
			Console.ReadKey();
		}
	}
}

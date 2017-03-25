using System;

namespace OpenAlgorithm {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("How many elements");
			int n = int.Parse(Console.ReadLine().Split()[0]);
			Console.WriteLine("Enter elements");
			string resonse = Console.ReadLine();
			int[] array = new int[n];
			int k = 0;
			foreach (string s in resonse.Split())
				array[k++] = int.Parse(s);
			int[] deleted = Sort.HeapSort(array);
			Console.WriteLine();
			foreach (int a in deleted)
				Console.Write($"{a}\t");
			Console.WriteLine();
			Console.ReadKey();
		}
	}
}

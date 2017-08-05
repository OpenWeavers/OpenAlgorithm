using static System.Console;

namespace OpenAlgorithm {
	class Program {
		static void Main(string[] args) {
			WriteLine("How many elements");
			int n = int.Parse(ReadLine().Split()[0]);
			WriteLine("Enter elements");
			string resonse = ReadLine();
			int[] array = new int[n];
			int k = 0;
			foreach (string s in resonse.Split())
				array[k++] = int.Parse(s);
			int[] deleted = Sort.HeapSort(array);
			WriteLine();
			foreach (int a in deleted)
				Write($"{a}\t");
			WriteLine();
			ReadKey();
		}
	}
}

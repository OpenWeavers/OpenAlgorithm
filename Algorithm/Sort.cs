using System;

namespace OpenAlgorithm {
	public static class Sort {

		private static int[] Merge(int[] A, int[] B) {
			int[] merged = new int[A.Length + B.Length];
			int i = 0, j = 0, k = 0;
			while (i < A.Length && j < B.Length)
				if (A[i] <= B[j])
					merged[k++] = A[i++];
				else
					merged[k++] = B[j++];
			while (i < A.Length)
				merged[k++] = A[i++];
			while (j < B.Length)
				merged[k++] = B[j++];
			return merged;
		}

		public static int[] MergeSort(int[] A) {
			if (A.Length <= 1)
				return A;
			int[] left = new int[A.Length / 2];
			for (int i = 0; i < A.Length / 2; i++)
				left[i] = A[i];
			int[] right = new int[A.Length - A.Length / 2];
			for (int i = 0; i < A.Length - A.Length / 2; i++)
				right[i] = A[A.Length / 2 + i];
			left = MergeSort(left);
			right = MergeSort(right);
			return Merge(left, right);
		}

		private static void Swap(ref int a, ref int b) {
			int temp = a;
			a = b;
			b = temp;
		}

		private static int Split(int[] A, int left, int right) {
			int pivot = A[left];
			int i = left + 1, j = right;
			while (i < j) {
				while (i < right && A[i] <= pivot)
					i++;
				while (j > left && A[j] > pivot)
					j--;
				Swap(ref A[i], ref A[j]);
			}
			Swap(ref A[i], ref A[j]);
			Swap(ref A[left], ref A[j]);
			return j;
		}

		private static void QuickSort(int[] A, int left, int right) {
			if (left >= right)
				return;
			int splitPos = Split(A, left, right);
			QuickSort(A, left, splitPos - 1);
			QuickSort(A, splitPos + 1, right);
		}

		public static int[] QuickSort(int[] A) {
			int[] B = new int[A.Length];
			A.CopyTo(B, 0);
			QuickSort(B, 0, B.Length - 1);
			return B;
		}

		public static int[] HeapSort(int[] A) {
			BinaryHeap<int> heap = new BinaryHeap<int>(A, HeapType.Max);
			Console.WriteLine(heap.Contains(8));
			Console.WriteLine();
			int[] sorted = new int[heap.Count];
			int i = 0;
			while (heap.Count != 0)
				sorted[i++] = heap.Remove();
			return sorted;
		}

	}
}

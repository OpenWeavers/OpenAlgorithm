using System;

namespace OpenAlgorithm {
	public static class Sort {

		private static T[] Merge<T>(T[] A, T[] B) where T : IComparable<T> {
			T[] merged = new T[A.Length + B.Length];
			int i = 0, j = 0, k = 0;
			while (i < A.Length && j < B.Length)
				if (A[i].CompareTo(B[j]) <= 0)
					merged[k++] = A[i++];
				else
					merged[k++] = B[j++];
			while (i < A.Length)
				merged[k++] = A[i++];
			while (j < B.Length)
				merged[k++] = B[j++];
			return merged;
		}

		public static T[] MergeSort<T>(T[] A) where T : IComparable<T> {
			if (A.Length <= 1)
				return A;
			T[] left = new T[A.Length / 2];
			for (int i = 0; i < A.Length / 2; i++)
				left[i] = A[i];
			T[] right = new T[A.Length - A.Length / 2];
			for (int i = 0; i < A.Length - A.Length / 2; i++)
				right[i] = A[A.Length / 2 + i];
			left = MergeSort(left);
			right = MergeSort(right);
			return Merge(left, right);
		}

		private static void Swap<T>(ref T a, ref T b) {
			T temp = a;
			a = b;
			b = temp;
		}

		private static int Split<T>(T[] A, int left, int right) where T : IComparable<T> {
			T pivot = A[left];
			int i = left + 1, j = right;
			while (i < j) {
				while (i < right && A[i].CompareTo(pivot) <= 0)
					i++;
				while (j > left && A[j].CompareTo(pivot) > 0)
					j--;
				Swap(ref A[i], ref A[j]);
			}
			Swap(ref A[i], ref A[j]);
			Swap(ref A[left], ref A[j]);
			return j;
		}

		private static void QuickSort<T>(T[] A, int left, int right) where T : IComparable<T> {
			if (left >= right)
				return;
			int splitPos = Split(A, left, right);
			QuickSort(A, left, splitPos - 1);
			QuickSort(A, splitPos + 1, right);
		}

		public static T[] QuickSort<T>(T[] A) where T : IComparable<T> {
			T[] B = new T[A.Length];
			A.CopyTo(B, 0);
			QuickSort(B, 0, B.Length - 1);
			return B;
		}

		public static T[] BubbleSort<T>(T[] arr) where T : IComparable<T> {
			var sorted = new T[arr.Length];
			Array.Copy(arr, sorted, arr.Length);
			for (int i = 0; i < arr.Length; i++) {
				int swaps = 0;
				for (int j = 0; j < arr.Length - i - 1; j++) 
					if (sorted[j + 1].CompareTo(sorted[j]) < 0) {
						T temp = sorted[j];
						sorted[j] = sorted[j + 1];
						sorted[j + 1] = temp;
					}
				if (swaps == 0)
					break;
			}
			return sorted;
		}

		public static T[] HeapSort<T>(T[] A) where T : IComparable<T> {
			BinaryHeap<T> heap = new BinaryHeap<T>(A);
			Console.WriteLine();
			T[] sorted = new T[heap.Count];
			int i = 0;
			while (heap.Count != 0)
				sorted[i++] = heap.Remove();
			return sorted;
		}

	}
}

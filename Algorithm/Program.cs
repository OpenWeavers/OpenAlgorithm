using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm {

	public sealed class HeapNode<T> : IComparable<HeapNode<T>> where T : IComparable<T> {

		public T data { get; }

		public HeapNode(T data) {
			this.data = data;
		}

		public int CompareTo(HeapNode<T> other) {
			return data.CompareTo(other.data);
		}

		public static implicit operator HeapNode<T>(T data) {
			return new HeapNode<T>(data);
		}
		
		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}
			return data.CompareTo((obj as HeapNode<T>).data)==0;
		}

		public override int GetHashCode() {
			return data.GetHashCode();
		}
	}

	public class Heap<T> : IEnumerable<T> where T : IComparable<T> {

		public enum HeapType { Max, Min };
		private HeapNode<T>[] elements;		
		private HeapType type;
		private Func<HeapNode<T>, HeapNode<T>, bool> comparer; //returns parent>child or parent<child

		private int count = 0;
		public int Count {
			get {
				return count;
			}
			private set {
				if (Math.Abs(count - value) != 1)
					throw new InvalidOperationException("Atomic Operation Excepted");
				count = value;
			}
		}

		private int capacity;
		public int Capacity {
			get {
				return capacity;
			}
			set {
				if (value <= 0)
					throw new InvalidOperationException("Invalid Capacity");
				if (value <= capacity)
					throw new InvalidOperationException("Attempt to Resize Heap below it's current size");
				HeapNode<T>[] newElements = new HeapNode<T>[value];
				elements.CopyTo(newElements, 0);
				elements = newElements;
			}
		}

		public Heap(int capacity, HeapType type) {
			this.capacity = capacity;
			this.elements = new HeapNode<T>[capacity + 1];
			this.type = type;
			comparer = (parent, child) => type == HeapType.Max ? (parent.CompareTo(child) > 0) : (parent.CompareTo(child) < 0);
		}

		public Heap(T[] elements, HeapType type) : this(elements.Length, type) {
			foreach (T element in elements)
				Add(element);
		}

		public Heap() : this(10, HeapType.Max) { }

		public Heap(T[] elements) : this(elements, HeapType.Min) { }

		public void Add(T ele) {
			//Top down Insertion
			if (Count == Capacity)
				Capacity = 2 * Capacity; //Ensure the capacity
			int insertPosition = ++Count;
			while (insertPosition > 1 && !comparer(elements[insertPosition / 2], ele)) {
				elements[insertPosition] = elements[insertPosition / 2];
				insertPosition = insertPosition / 2;
			}
			elements[insertPosition] = ele;
		}

		public T Remove() {
			if (Count == 0)
				throw new InvalidOperationException("No Items to Delete");
			var root = elements[1];
			var item = elements[Count--]; //Last Node of tree
			elements[1] = item;
			//Now Heapify!
			int insertPosition = 1;
			bool isHeap = false;
			while (insertPosition <= Count / 2 && !isHeap) {
				//has children ... Select extreme one
				int extremeChildPosition = 2 * insertPosition;
				if (extremeChildPosition < Count) {
					//has another child
					int anotherChildPosition = extremeChildPosition + 1;
					extremeChildPosition = comparer(elements[extremeChildPosition], elements[anotherChildPosition]) ? extremeChildPosition : anotherChildPosition;
				}
				//Compare it with current element
				if (comparer(item, elements[extremeChildPosition]))
					isHeap = true;
				else {
					elements[insertPosition] = elements[extremeChildPosition];
					insertPosition = extremeChildPosition;
				}
			}
			elements[insertPosition] = item;
			return root.data;
		}

		public bool Contains(T element) {
			for (int i = 1; i <= Count; i++)
				if (elements[i].CompareTo(element)==0)
					return true;
			return false;
		}

		public IEnumerator<T> GetEnumerator() {
			for (int i = 1; i <= Count; i++)
				yield return elements[i].data;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

	}

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
			Heap<int> heap = new Heap<int>(A,Heap<int>.HeapType.Max);
			Console.WriteLine(heap.Contains(8));
			Console.WriteLine();
			int[] sorted = new int[heap.Count];
			int i = 0;
			while (heap.Count != 0)
				sorted[i++] = heap.Remove();
			return sorted;
		}

	}

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

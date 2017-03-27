using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenAlgorithm {

	public enum HeapType { Max, Min };

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
			return data.CompareTo((obj as HeapNode<T>).data) == 0;
		}

		public override int GetHashCode() {
			return data.GetHashCode();
		}
	}

	public class BinaryHeap<T> : IEnumerable<T> where T : IComparable<T> {

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

		public BinaryHeap(int capacity, HeapType type) {
			this.capacity = capacity;
			this.elements = new HeapNode<T>[capacity + 1];
			this.type = type;
			comparer = (parent, child) => type == HeapType.Max ? (parent.CompareTo(child) > 0) : (parent.CompareTo(child) < 0);
		}

		public BinaryHeap(ICollection<T> elements,HeapType type) : this(elements.Count, type) {
			foreach (T element in elements)
				Add(element);
		}

		public BinaryHeap() : this(10, HeapType.Min) { }

		public BinaryHeap(ICollection<T> elements) : this(elements, HeapType.Min) { }

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
}

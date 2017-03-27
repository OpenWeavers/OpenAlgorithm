using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAlgorithm {
	internal sealed class BinarySearchTreeNode<T> : IComparable<BinarySearchTreeNode<T>>  where T:IComparable<T> {
		internal T data;
		internal BinarySearchTreeNode<T> left, right;

		public BinarySearchTreeNode(T data) {
			this.data = data;
		}

		public int CompareTo(BinarySearchTreeNode<T> other) {
			return data.CompareTo(other.data);
		}

	}
	public class BinarySearchTree<T> where T:IComparable<T> {
		BinarySearchTreeNode<T> root;
		int count;

		public BinarySearchTree() {
			root = null;
			count = 0;
		}

		public void Add(T element) {
			var newNode = new BinarySearchTreeNode<T>(element);

		}
	}
}

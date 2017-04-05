using System;
using System.Collections;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
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
	public class BinarySearchTree<T> :IEnumerable<T> where T:IComparable<T> {
		BinarySearchTreeNode<T> root;
		int count;

		public BinarySearchTree() {
			root = null;
			count = 0;
		}

		public void Add(T element) {
			var newNode = new BinarySearchTreeNode<T>(element);
			var insNode = root;
			var parent = (BinarySearchTreeNode<T>) null; 
			while (insNode != null) {
				parent = insNode;
				if (insNode.CompareTo(newNode) > 0)
					insNode = insNode.left;
				else
					insNode = insNode.right;
			}
			if (parent == null)
				root = newNode;
			else {
				if (parent.CompareTo(newNode) > 0)
					parent.left = newNode;
				else
					parent.right = newNode;
			}
			count++;
		}

		public IEnumerator<T> GetEnumerator() {
			//Returns Inorder traversal of tree
			//Left root right
			var node = root;
			var stack = new Stack<BinarySearchTreeNode<T>>();
			int _count = 0;
			while(_count < count) {
				while (node != null) {
					stack.Push(node);
					node = node.left;
				}
				if (node == null && stack.Count != 0) {
					yield return stack.Peek().data;
					_count++;
					node = stack.Pop().right;
				}
			} 
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}

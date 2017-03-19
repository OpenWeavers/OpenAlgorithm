# Binary Heap
A binary heap is a complete binary tree which satisfies the heap ordering property. The ordering can be one of two types:


* *the min-heap property*: the value of each node is greater than or equal to the value of its parent, with the minimum-value element at the root.

* *the max-heap property*: the value of each node is less than or equal to the value of its parent, with the maximum-value element at the root.

For more information about Binary Heap, visit [Wikipedia](https://en.wikipedia.org/wiki/Binary_heap "Binary Heap")

## UML Class Diagram
|         Class : BinaryHeap                |
|-------------------------------------------|
|**Description**: Binary Heap of Orderable Elements |
| `-elements` : Array of Items                  |
| `-capacity` : Maximum Number of items         |
| `-count`    : Current Number of items         |
| `-type`     : Type of Heap (Min or Max)       |
| `+BinaryHeap()` : Construct Empty Binary Heap |
| `+BinaryHeap(t : HeapType)` : Construct Binary Heap of type `t` |
| `+BinaryHeap(c : Collection)` : Construct Binary Heap from Collection `c` |
| `+BinaryHeap(c : Collection , t: HeapType)` : Construct Binary Heap of type `t` from Collection `c` |
| `+getCount() : int` : Get Number of elements |
| `+getCapacity() : int ` : Get Max Number of elements |
| `+setCapacity(capacity : int) ` : Set Max Number of elements |
| `+add(ele : Comparable)` : Inserts comparable `ele` to Heap |
| `+remove() : Comparable` : Deletes a element from Heap |
| Make the Collection Iterable using `foreach` like Language Constructs|

## Implementations
 * [C#](../CSharp/Algorithm/Program.cs)
 * Java (Comming Soon ...)
 * Python (Comming Soon ...)

## Note
You are free to add more methods, if you feel that it should be reflected here, Modify this file!
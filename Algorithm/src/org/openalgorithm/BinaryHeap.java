package org.openalgorithm;

class HeapNode   {
    public int data;

    public HeapNode(int data)   {
        this.data = data;
    }

    public int compareTo(HeapNode heapNode) {
        if(data == heapNode.data)
            return 0;
        else if (data > heapNode.data)
            return 1;
        else
            return -1;
    }
}

public class BinaryHeap {
    private int capacity;
    private int count;
    private HeapNode[] elements;

    public long getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public BinaryHeap(int capacity) {
        count = 0;
        this.capacity = capacity;
        elements = new HeapNode[capacity+1];
    }

    public BinaryHeap() {
        count = 0;
        this.capacity = 100;
        elements = new HeapNode[101];
    }

    public BinaryHeap(int[] collection) {
        count = 0;
        elements = new HeapNode[collection.length+1];
        for(int x : collection) {
            this.add(x);
        }
    }

    public void add(int item)   {
        HeapNode heapNode = new HeapNode(item);
        if(count == capacity)
            capacity = capacity*2;
        int insertPosition = ++count;
        while(insertPosition > 1 && (heapNode.compareTo(elements[insertPosition/2]) == 1))   {
            elements[insertPosition] = elements[insertPosition/2];
            insertPosition = insertPosition/2;
        }
        elements[insertPosition] = heapNode;
    }

    public int remove() throws InvalidOperationException   {
        if(count == 0)
            throw new InvalidOperationException("No items to remove");
        HeapNode removedItem = elements[1];
        int insertPosition = 1;
        HeapNode lastNode = elements[count--];
        boolean isHeap = false;
        while (2*insertPosition <= count && !isHeap)   {
            int extremeChildPosition = 2*insertPosition;
            if (extremeChildPosition < count)   {
                int secondChildPosition = extremeChildPosition + 1;
                extremeChildPosition = elements[extremeChildPosition].compareTo(elements[secondChildPosition]) == 1 ? extremeChildPosition : secondChildPosition;
            }
            if (lastNode.compareTo(elements[extremeChildPosition]) == 1)
                isHeap = true;
            else    {
                elements[insertPosition] = elements[extremeChildPosition];
                insertPosition = extremeChildPosition;
            }
        }
        elements[insertPosition] = lastNode;
        return removedItem.data;
    }
}
package org.openalgorithm;

import java.util.function.BiFunction;

final class HeapNode<T extends Comparable<T>> implements Comparable<HeapNode<T>>   {
    T data;

    public HeapNode(T data)   {
        this.data = data;
    }

    @Override
    public int compareTo(HeapNode<T> tHeapNode) {
        return data.compareTo(tHeapNode.data);
    }
}

public class BinaryHeap<T extends Comparable<T>> {
    private BiFunction<HeapNode<T>,HeapNode<T>,Boolean> comparer;
    private HeapType heapType;
    private int capacity;
    private int count;
    private HeapNode<T>[] elements;

    public long getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public BinaryHeap(int capacity,HeapType heapType) {
        count = 0;
        this.heapType = heapType;
        this.capacity = capacity;
        elements = new HeapNode[capacity+1];
        comparer = (parent,child) -> heapType == HeapType.maxHeap ? parent.compareTo(child) > 0 : parent.compareTo(child) < 0;
    }

    public BinaryHeap(T[] collection,HeapType heapType) {
        this(collection.length,heapType);
        for(T x : collection) {
            this.add(x);
        }
    }

    public BinaryHeap() {
        this(100,HeapType.maxHeap);
    }

    public void add(T item)   {
        HeapNode<T> heapNode = new HeapNode<>(item);
        if(count == capacity)
            capacity = capacity*2;
        int insertPosition = ++count;
        while(insertPosition > 1 && (comparer.apply(heapNode,elements[insertPosition/2])))   {
            elements[insertPosition] = elements[insertPosition/2];
            insertPosition = insertPosition/2;
        }
        elements[insertPosition] = heapNode;
    }

    public T remove() throws InvalidOperationException   {
        if(count == 0)
            throw new InvalidOperationException("No items to remove");
        HeapNode<T> removedItem = elements[1];
        int insertPosition = 1;
        HeapNode<T> lastNode = elements[count--];
        boolean isHeap = false;
        while (2*insertPosition <= count && !isHeap)   {
            int extremeChildPosition = 2*insertPosition;
            if (extremeChildPosition < count)   {
                int secondChildPosition = extremeChildPosition + 1;
                extremeChildPosition = comparer.apply(elements[extremeChildPosition],elements[secondChildPosition]) ? extremeChildPosition : secondChildPosition;
            }
            if (comparer.apply(lastNode,elements[extremeChildPosition]))
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
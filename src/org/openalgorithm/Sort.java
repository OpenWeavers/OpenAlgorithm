package org.openalgorithm;

public class Sort {
    public static Integer[] heapSort(Integer[] array, HeapType heapType)    {
        BinaryHeap<Integer> binaryHeap = new BinaryHeap<>(array, heapType);
        Integer[] sorted = new Integer[array.length];
        for (int i = 0;i < array.length;i++)  {
            try {
                sorted[i] = binaryHeap.remove();
            }
            catch (InvalidOperationException e) {
                System.out.println(e.getMessage());
            }
        }
        return sorted;
    }
}

package org.openalgorithm;

import java.util.Arrays;

public final class Sort {
    public static <T extends Comparable<T>> T[] heapSort(T[] array, HeapType heapType)    {
        T[] dArray = Arrays.copyOf(array,array.length);
        BinaryHeap<T> binaryHeap = new BinaryHeap<>(dArray, heapType);
        for (int i = 0;i < array.length;i++)  {
            try {
                dArray[i] = binaryHeap.remove();

            }
            catch (InvalidOperationException e) {
                System.out.println(e.getMessage());
            }
        }
        return dArray;
    }

    private static double[] merge(double[] a, double[] b) {
        double[] merged = new double[a.length + b.length];
        int i = 0, j = 0, k = 0;
        while (i < a.length && j < b.length)
            if (a[i] <= b[j])
                merged[k++] = a[i++];
            else
                merged[k++] = b[j++];
        while (i < a.length)
            merged[k++] = a[i++];
        while (j < b.length)
            merged[k++] = b[j++];
        return merged;
    }

    public static double[] mergeSort(double[] array)  {
        if(array.length == 1)
            return array;
        double[] left = new double[array.length / 2];
        //for (int i = 0; i < array.length / 2; i++)
        //	left[i] = array[i];
        System.arraycopy(array,0,left,0,array.length / 2);
        double[] right = new double[array.length - array.length / 2];
        //for (int i = 0; i < array.length - array.length / 2; i++)
        //	right[i] = array[array.length / 2 + i];
        System.arraycopy(array,array.length / 2,right,0,array.length - array.length / 2);
        left = mergeSort(left);
        right = mergeSort(right);
        return merge(left, right);
    }
}

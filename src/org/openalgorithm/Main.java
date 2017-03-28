package org.openalgorithm;

import java.util.Scanner;

public class Main { //Testing mergeSort!
    public static void main(String[] args)  {
        System.out.println("Enter number of items : ");
        int size = new Scanner(System.in).nextInt();
        System.out.println("Enter items : ");
        double[] arr = new double[size];
        int i = 0;
        String string = new Scanner(System.in).nextLine();
        for(String s : string.split("\\s+"))    {
            arr[i++] = Double.parseDouble(s);
        }
        double[] sorted = Sort.heapSort(arr,HeapType.maxHeap);
        for(double x : sorted)
            System.out.println(x);

    }
}
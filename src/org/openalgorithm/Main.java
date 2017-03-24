package org.openalgorithm;

import java.util.Scanner;

public class Main { //Testing HeapSort!
    public static void main(String[] args)  {
        System.out.println("Enter number of items : ");
        int size = new Scanner(System.in).nextInt();
        System.out.println("Enter items : ");
        Integer[] arr = new Integer[size];
        int i = 0;
        String string = new Scanner(System.in).nextLine();
        for(String s : string.split("\\s+"))    {
            arr[i++] = Integer.parseInt(s);
        }
        BinaryHeap<Integer> binaryHeap = new BinaryHeap<>(arr,HeapType.maxHeap);
        System.out.println("BinaryHeap traversal :");
        for(Integer t : binaryHeap)   {
            System.out.println(t);
        }
        System.out.println("HeapSort : ");
        Integer[] sorted = Sort.heapSort(arr,HeapType.maxHeap);
        for(Integer x : sorted)
            System.out.println(x);

    }
}
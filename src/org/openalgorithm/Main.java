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
        for (i = 0;i < arr.length;i++)  {
            try {
                System.out.println(binaryHeap.remove());
            }
            catch (InvalidOperationException e) {
                System.out.println(e.getMessage());
                System.exit(0);
            }
        }
    }
}
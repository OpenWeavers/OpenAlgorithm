package org.openalgorithm;

import java.util.Scanner;
import java.util.concurrent.ForkJoinPool;

public class Main { //Testing mergeSort!
    public static void main(String[] args)  {
        System.out.println("Enter number of items : ");
        int size = new Scanner(System.in).nextInt();
        System.out.println("Enter items : ");
        Float[] arr = new Float[size];
        int i = 0;
        String string = new Scanner(System.in).nextLine();
        for(String s : string.split("\\s+"))    {
            arr[i++] = Float.parseFloat(s);
        }
        Float[] sorted = Sort.mergeSort(arr);
        for(Float x : sorted)
            System.out.println(x);

    }
}
package org.openalgorithm;

import java.util.Scanner;

public class Main { //Testing mergeSort!
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
        Integer[] sorted = Sort.mergeSort(arr);
        for(Integer x : sorted)
            System.out.println(x);

    }
}
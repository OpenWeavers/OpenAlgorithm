package org.openalgorithm;

import java.util.HashMap;
import java.util.Scanner;

public class StringMatch {

    public static int horspool(String text, String pattern) {
        HashMap<Character, Integer> hashMap = getShiftTable(pattern);
        int patternLength = pattern.length();
        int textLength = text.length();
        int i, j;
        Integer shift;
        for (i = patternLength - 1; i < textLength; shift =hashMap.get(text.charAt(i)),  i += shift != null? shift: patternLength ) {
            for (j = 0; (j < patternLength) && (text.charAt(i - j) == pattern.charAt(patternLength - 1 - j)); j++) ;
            if (j == patternLength)
                return i - patternLength + 1;
        }
        return -1;
    }

    private static HashMap<Character, Integer> getShiftTable(String pattern) {
        HashMap<Character, Integer> hashMap = new HashMap<>();
        int len = pattern.length();
        for (int i = 0; i < len - 1; i++)
            hashMap.put(pattern.charAt(i), len - 1 - i);
        return hashMap;
    }

    public static void main(String[] args) {
        System.out.print("Enter the String : ");
        String text = new Scanner(System.in).nextLine();
        System.out.print("Enter the pattern : ");
        String pattern = new Scanner(System.in).nextLine();
        int position = horspool(text, pattern);
        if (position != -1)
            System.out.println("Pattern " + pattern + " found at location index " + position);
        else
            System.out.println("Pattern " + pattern + " not found!");
    }
}
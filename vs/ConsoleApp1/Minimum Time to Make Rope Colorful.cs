﻿using System;
public class Solution
{
    private int removeColors(int[] matchingIndices, int totalTime, int[] neededTime, int currentIndex)
    {
        int highestTime = 0;
        int highestIndex = 0;
        for (int i = 0; i < currentIndex; i++)
        {
            int index = matchingIndices[i];
            int currentTime = neededTime[index];
            if (currentTime > highestTime)
            {
                highestTime = currentTime;
                highestIndex = index;
            }
            totalTime += currentTime;
        }

        totalTime -= highestTime;

        return totalTime;
    }
    public int MinCost(string colors, int[] neededTime)
    {
        char last = ' ';
        int totalTime = 0;
        int maxLength = neededTime.Length;
        int[] matchingIndices = new int[maxLength]; // List of indices of matching colors in a row
        int currentIndex = 0;

        for (int i = 0; i < maxLength; i++)
        {
            //   Console.WriteLine(i);
            char currentColor = colors[i];
            if (currentColor == last)
            {
                if (currentIndex == 0)
                {
                    matchingIndices[currentIndex++] = (i - 1);
                }
                matchingIndices[currentIndex++] = i;


            } else if (currentIndex > 0) {
                totalTime = removeColors(matchingIndices, totalTime, neededTime, currentIndex);
                last = currentColor;
                currentIndex = 0;
            }

            else
            {
                last = currentColor;
            }


        }

        if (currentIndex > 0)
        {
            totalTime = removeColors(matchingIndices, totalTime, neededTime, currentIndex);
        }

        return totalTime;
    }
}
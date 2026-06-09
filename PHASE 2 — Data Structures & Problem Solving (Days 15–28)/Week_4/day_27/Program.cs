// • Find max sum of any k consecutive elements in array.
using System;
// Find smallest subarray with sum ≥ target.

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5, 6 };
        int k = 3;
        int maxSum = FindMaxSum(arr, k);
        Console.WriteLine("Max sum of any " + k + " consecutive elements is: " + maxSum);

        int target = 7;
        int minLength = FindMinSubarrayLength(arr, target);
        Console.WriteLine("Smallest subarray length with sum ≥ " + target + " is: " + minLength);
    }

    static int FindMaxSum(int[] arr, int k)
    {
        if (arr.Length < k)
            return -1; // Not enough elements

        int maxSum = 0;
        for (int i = 0; i < k; i++)
            maxSum += arr[i];

        int currentSum = maxSum;
        for (int i = k; i < arr.Length; i++)
        {
            currentSum += arr[i] - arr[i - k];
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    static int FindMinSubarrayLength(int[] arr, int target)
    {
        int minLength = int.MaxValue;
        int currentSum = 0;
        int left = 0;

        for (int right = 0; right < arr.Length; right++)
        {
            currentSum += arr[right];

            while (currentSum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                currentSum -= arr[left];
                left++;
            }
        }

        return minLength == int.MaxValue ? -1 : minLength; // what this does is it checks if minLength was updated, if not it returns -1 indicating no valid subarray was found
    }
}
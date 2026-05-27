
Console.WriteLine(TwoSum(new int[] { 1, 2, 3, 4, 5 }, 10)); // Output: True (4 + 5 = 9)
//mplement two-pointer:

Console.WriteLine(FindPrefix(new int[] { 1, 2, 3, 4, 5 }, 1, 3)); // Output: 9 (2 + 3 + 4 = 9)


bool TwoSum(int[] list, int target)
{
    list.Sort(); // Sort the list first
    int left = 0;
    int right = list.Length - 1;

    while (left < right)
    {
        int sum = list[left] + list[right];

        if (sum == target)
        {
            return true; // Found a pair that sums to the target
        }
        else if (sum < target)
        {
            left++; // Move the left pointer to the right to increase the sum
        }
        else
        {
            right--; // Move the right pointer to the left to decrease the sum
        }
    }

    return false; // No pair found that sums to the target
}
//Implement prefix sum: precompute prefix, then answer range-sum queries in O(1).
int FindPrefix(int[] nums, int left, int right)
{
    int[] prefix = new int[nums.Length];
    prefix[0] = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
        prefix[i] = prefix[i - 1] + nums[i];
    }

    if (left == 0)
    {
        return prefix[right];
    }
    else
    {
        return prefix[right] - prefix[left - 1];
    }
}
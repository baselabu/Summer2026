int BinarySearch(int[] nums, int target)
{
    int left = 0;
    int right = nums.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (nums[mid] == target)
            return mid;

        if (nums[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return -1;
}

// Example usage
int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int target = 5;
int result = BinarySearch(nums, target);
if (result != -1)
    Console.WriteLine($"Target found at index: {result}");
else
    Console.WriteLine("Target not found in the array.");   

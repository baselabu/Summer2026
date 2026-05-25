using System;

namespace day_4.Methods;

public class LargestNumberInArray
{
    public static int FindMax(int[] numbers)
    {
        int largest = 0;
        foreach(int number in numbers)
        {
            if(number > largest)
            {
                largest = number;
            }
        }
        return largest;
    }
}

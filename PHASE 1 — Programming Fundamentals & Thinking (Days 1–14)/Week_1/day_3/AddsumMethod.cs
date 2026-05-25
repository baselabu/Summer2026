using System;


public class MathtMethods
{
    public int AddSum(params int[] numbers)
    {
        int resultSum = 0;
        
        foreach (int number in numbers)
        {
            resultSum += number;

        }
        return resultSum;
    }


    public bool EvenChek(int number)
    {
        return number % 2 == 0;
    }


}

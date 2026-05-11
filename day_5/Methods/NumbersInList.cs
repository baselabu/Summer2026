using System;

namespace day_4.Methods;

public class NumbersInList
{
    public static void PrintNumbers(List<string> Alist)
    {
        for (int i = 0; i < Alist.Count; i++)
        {
            System.Console.WriteLine(Alist[i]);
        }
    }

}

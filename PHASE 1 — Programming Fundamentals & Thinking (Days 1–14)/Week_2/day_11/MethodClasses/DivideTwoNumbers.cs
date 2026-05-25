using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_11.Interfaces;

namespace Day_11.MethodClasses
{
    public class DivideTwoNumbers : IMath
    {
        public int Divide(int a, int b)
        {
            try
            {
                int result = a / b;
                return result;
            }
            catch (DivideByZeroException e)
            {
                System.Console.WriteLine("you cannot divide by zero Idiot");
                return 0;
            }
        }
    }
}
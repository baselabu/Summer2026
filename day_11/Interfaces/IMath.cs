using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day_11.Interfaces
{
    public interface IMath
    {
        int Divide(int a, int b);
    }
    public interface IParser
    {
        int Parse(string input);
    }
}
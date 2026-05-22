using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_11.Interfaces;

namespace Day_11.MethodClasses
{
    public class ParseAge : IParser
    {
        public int Parse(string input)
        {
            try
            {
                int ParsedNumber = int.Parse(input);
                return ParsedNumber;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                return 0;
            }

        }
        
    }
}
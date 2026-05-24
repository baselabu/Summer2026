using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Security.Cryptography;
List<int> numbers = new List<int>{1, 34, 3, 4, 5};
var EvenNumbers = numbers.Where(x => x % 2 == 0);
var MaxNumber = numbers.Max();
var sumNumbers = numbers.Sum();
System.Console.WriteLine(MaxNumber);
System.Console.WriteLine(sumNumbers);
foreach(int number in EvenNumbers)
{
    System.Console.WriteLine(number);
}
Console.WriteLine(FactorialRecursive(5));
Console.WriteLine(FactorialIterative(5));
Console.WriteLine(FibonacciRecursive(3));
Console.WriteLine(FibonacciIterative(10));
Console.WriteLine(PowerRecursive(2, 3));
Console.WriteLine(string.Join(", ", Flatten(new List<object> { 1, new List<object> { 2, 3 }, 4 })));



int FactorialRecursive(int n)
{
    if (n == 0)
        return 1;
    else
        return n * FactorialRecursive(n - 1);
}
int FactorialIterative(int n)
{
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
        result *= i;
    }
    return result;
}
int FibonacciRecursive(int n)
{
    if (n <= 1)
        return n;
    else
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}
int FibonacciIterative(int n)
{
    if (n <= 1)        return n;
    int a = 0, b = 1, c = 0;
    for (int i = 2; i <= n; i++)
    {        c = a + b;
        a = b;
        b = c;
    }
    return c;
}


int PowerRecursive(int baseNumber, int exp)
{
    if (exp == 0)
        return 1;
    else
        return baseNumber * PowerRecursive(baseNumber, exp - 1);
}

//Flatten a nested list recursively. 
List<int> Flatten(List<object> nestedList)
{
    List<int> flatList = new List<int>();
    foreach (var item in nestedList)
    {
        if (item is int)
        {
            flatList.Add((int)item);
        }
        else if (item is List<object>)
        {
            flatList.AddRange(Flatten((List<object>)item));
        }
    }
    return flatList;
}
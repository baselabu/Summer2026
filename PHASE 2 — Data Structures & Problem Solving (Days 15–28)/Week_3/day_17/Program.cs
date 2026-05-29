string word = "Hello, World!";

Dictionary<string, int> letterCounts = new Dictionary<string, int>();
foreach (char letter in word)
{
    string letterStr = letter.ToString();
    if (letterCounts.ContainsKey(letterStr))
    {
        letterCounts[letterStr]++;
    }
    else
    {
        letterCounts[letterStr] = 1;
    }
}
Console.WriteLine("Letter counts:");
foreach (var kvp in letterCounts)
{    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
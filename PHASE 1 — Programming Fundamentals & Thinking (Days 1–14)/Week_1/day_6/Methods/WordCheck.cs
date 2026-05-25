using System;
using System.Text;

namespace day_6.Methods;

public class WordCheck
{
    public static bool IsPalindrome(string word)
    {
        StringBuilder ReversedWord = new StringBuilder();
        foreach (char c in word.Reverse())
        {
            ReversedWord.Append(c);
        }
        System.Console.WriteLine(ReversedWord.ToString());
        return word == ReversedWord.ToString();
    }
    public static int VowelCheck(string word)
    {
        string vowels = "auiyeo";
        int vowelsCounter = 0;
        foreach (char letter in word)
        {
            if (vowels.Contains(letter))
            {
                vowelsCounter++;
            }
        }
        return vowelsCounter;
    }
}

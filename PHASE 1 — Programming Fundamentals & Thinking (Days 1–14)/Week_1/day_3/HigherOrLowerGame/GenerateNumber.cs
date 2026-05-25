using System;

namespace day_3.HigherOrLowerGame;

public class NumberToGuess
{
    public static int GenerateNumberToGuess()
    {
        Random random = new Random();
        return random.Next(1, 101);
    }

}

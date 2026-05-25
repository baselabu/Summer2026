using System;

namespace day_3.HigherOrLowerGame;

public class HigherLowerGame
{
    public static string CheckGuess(int guess, int numberToGuess)
    {
        if (guess > numberToGuess)
        {
            return "Lower";
        }
        else if (guess < numberToGuess)
        {
            return "Higher";
        }
        else
        {
            return "Correct!";
        }
    }

}

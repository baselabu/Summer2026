using System;

namespace day_3.HigherOrLowerGame;

public class PlayHigherOrLower
{
    public static void PlayGame()
    {
        int numberToGuess = NumberToGuess.GenerateNumberToGuess();
        List<int> UserGuessList = new List<int>();
        System.Console.WriteLine("Welcome to the Higher or Lower Game!");
        System.Console.WriteLine("I have selected a number between 1 and 100. Can you guess it?");
        while (true)
        {
            Console.Write("Enter your guess: ");
            int guess = int.Parse(Console.ReadLine());
            UserGuessList.Add(guess);

            string resultGame = HigherLowerGame.CheckGuess(guess, numberToGuess);
            Console.WriteLine(resultGame);

            if (resultGame == "Correct!")
            {
                break;
            }
        }
        System.Console.WriteLine($"guess history: {string.Join(", ",UserGuessList)}");
    }

}

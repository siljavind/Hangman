﻿using System.Text.RegularExpressions;
using Hangman;

class Program // TODO Clean up and put into separate classes
              // TODO Implement visual element(s)
{
    public static void Main()
    {
        Console.CursorVisible = false; // Hides blinking cursor position
        List<char> charList = new(Finder.Word()); //Random word from textfile "EnglishDictionary.txt" into char list
        List<char> guessList = new();

        string welcome = "Welcome to pacific Hangman";
        char userGuess;
        int lives = 5;
        int[] positionWord = { Tools.ToMiddle(charList.Count), 15 },
              positionWelcome = { Tools.ToMiddle(welcome.Length), 2 },
              positionError = { 5, 22 },
              positionLives = { 5, 25 },
              positionGuess = { 50, 25 };

        Tools.SetPosition(positionWelcome);
        Console.WriteLine(welcome);

        Tools.SetPosition(positionWord);
        List<char> underscoreList = new(Finder.Underscore(charList)); //New list where charList is converted to underscores

        do
        {
            do
            {
                userGuess = Char.ToUpper(Console.ReadKey(true).KeyChar);
                Tools.SetPosition(positionError);
                Console.Write(new string(' ', Console.WindowWidth)); // TODO Change position

            } while (guessList.Contains(userGuess));

            if (!guessList.Contains(userGuess))
            {
                if (charList.Contains(userGuess))
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                else if (!charList.Contains(userGuess))
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                guessList.Add(userGuess);
                Tools.SetPosition(positionGuess);
                Console.WriteLine(userGuess);
                positionGuess[0] += 2;

                Console.ResetColor();
            }

            Regex regexAZ = new(@"[A-Z]");
            Match isValid = regexAZ.Match(userGuess.ToString());

            if (charList.Contains(userGuess) && isValid.Success)
            {
                Tools.SetPosition(positionWord);

                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i].Equals(userGuess))
                    {
                        underscoreList[i] = charList[i];
                    }

                    Console.Write($"{underscoreList[i]} ");
                }
            }

            else if (!charList.Contains(userGuess) && isValid.Success)
            {
                lives--;
                Tools.SetPosition(positionLives);
                Console.WriteLine($"{lives} out of 5 lives left");
            }

            else if (!isValid.Success)
            {
                Tools.SetPosition(positionError);
                Console.WriteLine("Please enter a valid character (A-Z)");
            }

        } while (underscoreList.Contains('_') && lives != 0);

        bool check = lives != 0; // Checks win conditions to set background color
        Tools.BackgroundColor(check);

        Tools.SetPosition(positionWord);

        for (int i = 0; i < charList.Count; i++)
        {
            Console.Write($"{charList[i]} ");
            Thread.Sleep(50);
        }

        Console.ReadKey(true);
    }
}

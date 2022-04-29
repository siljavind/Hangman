﻿using System.Text.RegularExpressions;
using Hangman;

public class Program // TODO Clean up and put into separate classes
                     // TODO Implement visual element(s)
{
    public static void Main(string[] args)
    {
        char userGuess;
        int lives = 5, counter = 0;
        string positionWord = "5,20", positionError = "5, 22", positionLives = "5,25";

        Console.WriteLine("o shit waddup");

        TinyTools.SetPosition(positionWord);

        List<char> charList = new(Finder.Word()); //Puts random word from textfile "EnglishDictionary.txt" into char list
        List<char> underscoreList = new(Finder.Underscore(charList)); //Creates new list where each char is converted to underscores
        List<char> guessList = new();

        do
        {
            do
            {
                userGuess = Char.ToUpper(Console.ReadKey(true).KeyChar);

            } while (guessList.Contains(userGuess));

            if (!guessList.Contains(userGuess))
            {
                guessList.Add(userGuess);
                Console.SetCursorPosition(50 + (counter), 25); //Placement of already used char      
                Console.WriteLine(userGuess);
                counter += 2;
            }

            Regex regexAZ = new(@"[A-Z]");
            Match isValid = regexAZ.Match(userGuess.ToString());

            if (charList.Contains(userGuess) && isValid.Success)
            {
                TinyTools.SetPosition(positionWord);

                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i].Equals(userGuess))
                    {
                        underscoreList[i] = charList[i];
                    }

                    Console.Write(underscoreList[i].ToString().PadRight(2));
                }
            }

            if (!charList.Contains(userGuess) && isValid.Success)
            {
                lives--;
                TinyTools.SetPosition(positionLives);
                Console.WriteLine($"{lives} out of 5 lives left");
            }

            if (!isValid.Success)
            {
                TinyTools.SetPosition(positionError);
                Console.WriteLine("Please enter a valid character (A-Z)");
            }

        } while (underscoreList.Contains('_') && lives != 0);

        TinyTools.SetPosition(positionWord);

        for (int i = 0; i < charList.Count; i++)
        {
            Console.Write(charList[i].ToString().PadRight(2));
        }

        Console.ReadKey(true);
    }
}

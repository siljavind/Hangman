using System.Text.RegularExpressions; //Regex
using System.Drawing; //Allows the use of Point for SetCursorPosition

namespace Hangman
{
    public class Program // TODO Clean up and put into separate classes
                         // TODO Implement visual element(s)
    {
        public static void Main(string[] args)
        {
            char userGuess;
            int lives = 5, counter = 0;
            string posWord = "5,20", posLives = "5,25";

            Console.WriteLine("Waddup\n");

            Methods.SetPosition(posWord);

            List<char> charList = new(Finder.Word()); //Puts random word from textfile "EnglishDictionary.txt" in a char list
            List<char> underscoreList = new(Finder.Underscore(charList)); //Creates new list where each char is converted to underscores and printed

            do //TODO Implement start screen
            {
                Methods.SetPosition(posLives);

                Console.WriteLine($"{lives} out of 5 lives left\n");

                //Methods.SetPosition(50 + (counter), 25);
                counter += 2;

                userGuess = Char.ToUpper(Console.ReadKey().KeyChar);

                Regex regexAZ = new(@"[A-Z]");
                Match isValid = regexAZ.Match(userGuess.ToString());

                if (charList.Contains(userGuess) && isValid.Success)
                {
                    Methods.SetPosition(posWord);

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
                    Methods.SetPosition(posLives);
                    Console.WriteLine($"{lives} out of 5 lives left\n"); //TODO Same code is used twice. Maybe don't.
                }

                if (!isValid.Success)
                {
                    Methods.SetPosition(posWord);
                    Console.WriteLine("Please enter a valid character (a-z)\n");
                }

            } while (underscoreList.Contains('_') && lives != 0);

            Methods.SetPosition(posWord);

            for (int i = 0; i < charList.Count; i++)
            {
                Console.Write(charList[i].ToString().PadRight(2));
            }

        }
    }

    internal class Methods //Methods that are not necessary, but makes the code more "clean(/prettier)"
    {
        internal static void NewLine() //Adds a new line (outside of already established CW).
        {
            Console.WriteLine(Environment.NewLine);
        }

        internal static void SetPosition(string x) // "Cleaner" way of setting same position. Mostly just to try it out
        {
            int[] intArray = Array.ConvertAll(x.Split(','), int.Parse);
            Point points = new(intArray[0], intArray[1]);
            Console.SetCursorPosition(points.X, points.Y);
        }
    }
}
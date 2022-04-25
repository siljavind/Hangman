﻿using System.Text.RegularExpressions;
// using System.Drawing;

namespace Hangman
{
    public class Program // TODO everything
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Waddup\n");

            List<char> charList = new List<char>(Finder.Word());
            List<char> underscoreList = new List<char>(Finder.Underscore(charList));

            int counter = 1;

            do
            {
                Methods.NewLine();
                char userGuess = Console.ReadKey().KeyChar;
                Methods.NewLine();

                bool doesContain = charList.Contains(userGuess);

                Regex regexCheck = new Regex(@"/[a-z]||[A-Z]/gi");
                Match isValid = regexCheck.Match(userGuess.ToString());

                if (doesContain && isValid.Success)
                {
                    for (int i = 0; i < charList.Count; i++)
                    {
                        if (charList[i].Equals(userGuess))
                        {
                            underscoreList[i] = charList[i];
                        }

                        Console.Write(underscoreList[i].ToString().ToUpper().PadRight(2));
                    }
                }

                if (!doesContain && isValid.Success)
                {
                    Console.WriteLine("Used " + counter + " out of 5 lives");
                    counter++;
                }

                if (!isValid.Success)
                {
                    Console.WriteLine("Enter valid character\n");
                }

            } while (underscoreList.Contains('_') && counter <= 5);

            foreach (var i in charList)
            {
                Console.Write(i.ToString().ToUpper());
            }

            Methods.NewLine();

            //Point location = new Point(10, 10);
            //Size imageSize = new Size(20, 10);

            //Console.SetCursorPosition(location.X - 1, location.Y);
            //Console.Write(">");
            //Console.SetCursorPosition(location.X + imageSize.Width, location.Y);
            //Console.Write("<");
            //Console.SetCursorPosition(location.X - 1, location.Y + imageSize.Height - 1);
            //Console.Write(">");
            //Console.SetCursorPosition(location.X + imageSize.Width, location.Y + imageSize.Height - 1);
            //Console.Write("<");

        }
    }

    public class Methods
    {
        public static void NewLine()
        {
            Console.WriteLine(Environment.NewLine);
        }
    }
}
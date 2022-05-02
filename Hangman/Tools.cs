using System.Drawing;

namespace Hangman
{
    internal class Tools
    {
        internal static void SetPosition(int[] position) // "Cleaner" way of setting same position. Mostly just to try it out
        {
            Point points = new(position[0], position[1]);
            Console.SetCursorPosition(points.X, points.Y);
        }

        internal static int ToMiddle(int wordLength) // TODO Almost to middle. Uneven numbers? Honest to God, wat? Ask Henrik.
        {
            int position = (Console.WindowWidth / 2) - (wordLength /* ?? / 2 ?? */);
            return position;
        }

        internal static void BackgroundColor(bool win) // Two different ways of setting background color on win/lose screen
        {

            if (win) // "Classic"
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
            }

            else if (!win) // Another way
            {
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.DarkRed;

                for (int i = 0; i < Console.WindowHeight; i++) // Prints color as wide and tall as screen
                {
                    Console.Write(new string(' ', Console.WindowWidth));
                }
            }

        }

        //internal static void NewLine() // "Cleaner" way of adding a new line (outside of CW).
        //{
        //    Console.WriteLine(Environment.NewLine);
        //}
    }
}

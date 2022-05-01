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

        internal static int ToMiddle(int wordLength) // Almost to middle. Honest to God, it's too late for this
        {
            int position = (Console.WindowWidth / 2) - (wordLength / 2);
            return position;
        }

        internal static void BackgroundColor(bool win) // Background color on win screen
        {
            Console.SetCursorPosition(0, 0);
            if (win)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            else
                Console.BackgroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }

        //internal static void NewLine() //Adds a new line (outside of already established CW).
        //{
        //    Console.WriteLine(Environment.NewLine);
        //}
    }
}

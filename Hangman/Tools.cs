using System.Drawing;

namespace Hangman
{
    internal class Tools
    {
        internal static void SetPosition(int[] position) // "Cleaner" way of setting same position. Mostly just to try Drawing.Points out
        {
            //Point points = new(position[0], position[1]);
            Console.SetCursorPosition(position[0], position[1]);
        }

        internal static int ToMiddle(int wordLength)
        {
            int position = (Console.WindowWidth / 2) - (wordLength / 2);
            return position;
        }

        internal static void BackgroundColor(bool win) // Sets background color on win/lose screen
        {
            Console.SetCursorPosition(0, 0);

            if (win)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            else
                Console.BackgroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i < Console.WindowHeight; i++) // Prints colored whitespaces as wide and tall as screen
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }

        //internal static void NewLine() // "Cleaner" way of adding a new line (outside of CW).
        //{
        //    Console.WriteLine(Environment.NewLine);
        //}
    }
}
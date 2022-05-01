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

        //internal static void NewLine() //Adds a new line (outside of already established CW).
        //{
        //    Console.WriteLine(Environment.NewLine);
        //}
    }
}

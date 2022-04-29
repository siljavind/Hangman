using System.Drawing;

namespace Hangman
{
    internal class TinyTools
    {
        //internal static void NewLine() //Adds a new line (outside of already established CW).
        //{
        //    Console.WriteLine(Environment.NewLine);
        //}

        internal static void SetPosition(string x) // "Cleaner" way of setting same position. Mostly just to try it out
        {
            int[] intArray = Array.ConvertAll(x.Split(','), int.Parse);
            Point points = new(intArray[0], intArray[1]);
            Console.SetCursorPosition(points.X, points.Y);
        }
    }
}

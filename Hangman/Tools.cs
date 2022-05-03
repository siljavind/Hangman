using System.Drawing;

namespace Hangman
{
    internal class Tools
    {
        static int[] //positionWord = { ToMiddle(_charList.Count * 2 - 1), 15 }, // (charList.Count * 2 - 1) to account for whitespaces later
                     //positionWelcome = { ToMiddle(welcome.Length), 2 },
                     positionLives = { Console.WindowWidth - 31, Console.WindowHeight - 3 },
                     positionError = { 10, Console.WindowHeight - 2 };
        //positionGuess = { 10, Console.WindowHeight - 3 };

        static int lives = 5;
        static List<char> _charList;

        const string welcome = "Welcome to pacifist Hangman", errorMessage = "Please enter a valid character (A-Z)";
        public Tools(List<char> charList)
        {
            _charList = charList;
        }
        public Tools()
        {

        }

        internal static void Lives()
        {
            lives--;
            SetPosition(positionLives);
            Console.WriteLine($"{lives} out of 5 lives left");
        }

        internal static void Error()
        {
            SetPosition(positionError);
            Console.WriteLine(errorMessage);

            switch (Console.ReadKey())
            {
                default:
                    SetPosition(positionError);
                    Console.Write(new string(' ', Console.WindowWidth)); // TODO Change position?
                    break;
            }

        }

        internal static void SetTextColor()
        {
            if (_charList.Contains(userGuess))
                Console.ForegroundColor = ConsoleColor.DarkGreen; //Sets textcolor based on correctness

            else if (!_charList.Contains(userGuess))
                Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        internal static void SetPosition(int[] position) // "Cleaner" way of setting same position. Mostly just to try it out
        {
            Point points = new(position[0], position[1]);
            Console.SetCursorPosition(points.X, points.Y);
        }

        internal static int ToMiddle(int wordLength) // Determines the center position of element
        {
            int position = (Console.WindowWidth / 2) - (wordLength / 2);
            return position;
        }

        internal static void BackgroundColor(bool win) // Two different ways of setting background color on win/lose screen
        {

            if (win) // Classic. Colors more than visible area
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
            }

            else if (!win) // Another way, that only covers seen area
            {
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.DarkRed;

                for (int i = 0; i < Console.WindowHeight; i++) // Prints color as wide and tall as screen
                {
                    Console.Write(new string(' ', Console.WindowWidth));
                }
            }
        }

        internal static void Print() //Final printing of word, when game is won or lost
        {
            for (int i = 0; i < _charList.Count; i++)
            {
                Console.Write($"{_charList[i]} ");
                Thread.Sleep(50);
            }
        }

        //internal static void NewLine() // "Cleaner" way of adding a new line (outside of CW).
        //{
        //    Console.WriteLine(Environment.NewLine);
        //}
    }
}

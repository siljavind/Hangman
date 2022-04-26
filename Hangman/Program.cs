using System.Text.RegularExpressions; //Regex
using System.Drawing; //Allows the use of Point for SetCursorPosition

namespace Hangman
{
    public class Program // TODO Clean up and put into separate classes
                         // Implement visual element(s)
    {
        public static void Main(string[] args)
        {
            char userGuess;
            int lives = 5, counter = 0;

            Console.WriteLine("Waddup\n"); //Welcome to the Wild West

            Methods.SetPosition(5, 20);

            List<char> charList = new(Finder.Word()); //Puts random word from textfile "EnglishDictionary.txt" in a char list
            List<char> underscoreList = new(Finder.Underscore(charList)); //Creates new list where each char is converted to underscores and printed

            do //TODO start screen
            {
                Methods.SetPosition(5, 25);
                Console.WriteLine($"{lives} out of 5 lives left\n");

                Methods.SetPosition(50 + (counter), 25);
                counter += 2;

                userGuess = Char.ToUpper(Console.ReadKey().KeyChar);

                Regex regexAZ = new(@"[A-Z]");
                Match isValid = regexAZ.Match(userGuess.ToString());

                if (charList.Contains(userGuess) && isValid.Success)
                {
                    Methods.SetPosition(5, 20);

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
                    Methods.SetPosition(5, 25);
                    Console.WriteLine($"{lives} out of 5 lives left\n"); //TODO Same code is used twice. Don't.
                }

                if (!isValid.Success)
                {
                    Methods.SetPosition(5, 20);
                    Console.WriteLine("Please enter a valid character (a-z)\n");
                }

            } while (underscoreList.Contains('_') && lives != 0);

            Methods.SetPosition(5, 20);

            for (int i = 0; i < charList.Count; i++)
            {
                Console.Write(charList[i].ToString().PadRight(2));
            }

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

    public class Methods //Methods that are not necessary, but makes the code more "clean(/prettier)"
    {
        internal static void NewLine() //Adds a new line (outside of already established CW).
        {
            Console.WriteLine(Environment.NewLine);
        }

        internal static void SetPosition(int x, int y) // "Cleaner" way of setting position.
        {
            Point local = new(x, y);
            Console.SetCursorPosition(local.X, local.Y);
        }
    }
}
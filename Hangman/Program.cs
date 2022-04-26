using System.Text.RegularExpressions;
using System.Drawing;

namespace Hangman
{
    public class Program // TODO everything
    {
        public static void Main(string[] args)
        {
            int lives = 5, counter = 0;


            Console.WriteLine("Waddup\n");

            List<char> charList = new(Finder.Word());
            Methods.SetLocation(5, 22);
            List<char> underscoreList = new(Finder.Underscore(charList));


            do //TODO start screen
            {
                Methods.SetLocation(5, 25);
                Console.WriteLine($"{lives} out of 5 lives\n");

                Methods.SetLocation(50 + (counter), 25);
                counter = counter + 2;

                char userGuess = Char.ToUpper(Console.ReadKey().KeyChar);

                Regex regexAZ = new(@"[A-Z]");
                Match isValid = regexAZ.Match(userGuess.ToString());

                if (charList.Contains(userGuess) && isValid.Success)
                {
                    Methods.SetLocation(5, 22);

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
                }

                if (!isValid.Success)
                {
                    Methods.SetLocation(5, 20);
                    Console.WriteLine("Please enter a valid character\n");
                }

            } while (underscoreList.Contains('_') && lives != 0);

            for (int i = 0; i < charList.Count; i++)
            {
                Methods.SetLocation(5, 20);
                Console.Write(charList[i].ToString().PadRight(2));
            }

            Console.ReadKey();

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
        internal static void NewLine()
        {
            Console.WriteLine(Environment.NewLine);
        }

        internal static void SetLocation(int x, int y)
        {
            Point local = new(x, y);
            Console.SetCursorPosition(local.X, local.Y);
        }
    }
}
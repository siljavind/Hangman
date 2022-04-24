using System.Text.RegularExpressions;

namespace Hangman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello motherfucker\n");

            List<char> charList = new List<char>(Finder.Word());
            List<char> underscoreList = new List<char>(Finder.Underscore(charList));

            Methods.NewLine();

            do
            {
                char userGuess = Console.ReadKey().KeyChar;
                //Thread.Sleep(100);

                Methods.NewLine();

                bool doesContain = charList.Contains(userGuess);

                Regex regexCheck = new Regex(@"[a-z]");
                Match isValid = regexCheck.Match(userGuess.ToString());

                if (doesContain && isValid.Success)
                {
                    for (int i = 0; i < charList.Count; i++)
                    {
                        if (charList[i].Equals(userGuess))
                        {
                            underscoreList[i] = charList[i];
                        }

                        Console.Write(underscoreList[i]);
                    }
                }
                if (!isValid.Success)
                {
                    Console.WriteLine("Enter valid character\n");
                }

            } while (underscoreList.Contains('_'));

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
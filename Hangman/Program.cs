using System.Text.RegularExpressions;
using Hangman;

class Program // TODO Clean up and put into separate classes
              // TODO Implement visual element(s)
{
    public static void Main()
    {
        char userGuess;
        int lives = 5;
        int[] positionWord = { 5, 20 }, positionError = { 5, 22 }, positionLives = { 5, 25 }, positionGuess = { 50, 25 };

        Console.WriteLine("o shit waddup");

        Tools.SetPosition(positionWord);

        List<char> charList = new(Finder.Word()); //Random word from textfile "EnglishDictionary.txt" into char list
        List<char> underscoreList = new(Finder.Underscore(charList)); //New list where charList is converted to underscores
        List<char> guessList = new();

        do
        {
            do
            {
                userGuess = Char.ToUpper(Console.ReadKey(true).KeyChar);
                Tools.SetPosition(positionError);
                Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");

            } while (guessList.Contains(userGuess));

            if (!guessList.Contains(userGuess))
            {
                if (charList.Contains(userGuess))
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                else if (!charList.Contains(userGuess))
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                guessList.Add(userGuess);
                Tools.SetPosition(positionGuess);
                Console.WriteLine(userGuess);
                positionGuess[0] += 2;

                Console.ForegroundColor = ConsoleColor.White;
            }

            Regex regexAZ = new(@"[A-Z]");
            Match isValid = regexAZ.Match(userGuess.ToString());

            if (charList.Contains(userGuess) && isValid.Success)
            {
                Tools.SetPosition(positionWord);

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
                Tools.SetPosition(positionLives);
                Console.WriteLine($"{lives} out of 5 lives left");
            }

            if (!isValid.Success)
            {
                Tools.SetPosition(positionError);
                Console.WriteLine("Please enter a valid character (A-Z)");
            }

        } while (underscoreList.Contains('_') && lives != 0);

        Tools.SetPosition(positionWord);

        for (int i = 0; i < charList.Count; i++)
        {
            Console.Write(charList[i].ToString().PadRight(2));
            Thread.Sleep(10);
        }

        Console.ReadKey(true);
    }
}

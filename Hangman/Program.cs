using System.Text.RegularExpressions;
using Hangman;

class Program // TODO Clean up and put into separate classes - another day. Problems.
              // TODO Implement visual element(s)?
{
    public static void Main()
    {
        List<char> charList = new(Finder.FindWord()); //Random word from textfile "EnglishDictionary.txt" into char list
        List<char> guessList = new();



        string welcome = "Welcome to pacifist Hangman";
        string errorMessage = "Please enter a valid character (A-Z)";
        char userGuess;
        int lives = 5;
        Tools tools = new Tools(charList);

        int[] positionWord = { Tools.ToMiddle(charList.Count * 2 - 1), 15 }, // (charList.Count * 2 - 1) to account for whitespaces later
              positionWelcome = { Tools.ToMiddle(welcome.Length), 2 },
              positionLives = { Console.WindowWidth - 31, Console.WindowHeight - 3 },
              positionError = { 10, Console.WindowHeight - 2 },
              positionGuess = { 10, Console.WindowHeight - 3 };

        Console.CursorVisible = false; // Hides blinking cursor position
        Tools.SetPosition(positionWelcome);
        Console.WriteLine(welcome);

        Tools.SetPosition(positionWord);
        List<char> underscoreList = new(Finder.ConvertToUnderscore(charList)); //New list where charList is converted to underscores

        do
        {
            do
            {
                userGuess = char.ToUpper(Console.ReadKey(true).KeyChar);

            } while (guessList.Contains(userGuess));

            if (!guessList.Contains(userGuess)) // Handles unused guesess
            {
                if (charList.Contains(userGuess))
                    Console.ForegroundColor = ConsoleColor.DarkGreen; //Sets textcolor based on correctness

                else if (!charList.Contains(userGuess))
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                guessList.Add(userGuess); // Adds guess to list, sets cursorposition, prints and adds to new position
                Tools.SetPosition(positionGuess);
                Console.WriteLine(userGuess);
                positionGuess[0] += 2;

                Console.ResetColor();
            }

            Regex regexAZ = new(@"[A-Z]");
            Match isValid = regexAZ.Match(userGuess.ToString());

            if (charList.Contains(userGuess) && isValid.Success) // Guess is valid and correct
            {
                Tools.SetPosition(positionWord);

                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i].Equals(userGuess))
                    {
                        underscoreList[i] = charList[i];
                    }

                    Console.Write($"{underscoreList[i]} ");
                }
            }

            else if (!charList.Contains(userGuess) && isValid.Success) // Guess is valid, but incorrect
            {
                lives--;
                Tools.SetPosition(positionLives);
                Console.WriteLine($"{lives} out of 5 lives left");
            }

            else if (!isValid.Success) // Guess is invalid (not A-Z)            
                Tools.Error();


        } while (underscoreList.Contains('_') && lives != 0);

        bool check = lives != 0; // Checks win/lose condition to set background color
        Tools.BackgroundColor(check);

        Tools.SetPosition(positionWord);
        Tools.Print();

        Console.ReadKey(true);
    }
}

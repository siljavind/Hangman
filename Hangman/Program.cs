using System.Text.RegularExpressions;
using Hangman;

public class Program // TODO Clean up and put into separate classes
                     // TODO Implement visual element(s)
{
    public static void Main(string[] args)
    {
        char userGuess;
        int lives = 5, counter = 0;
        string positionWord = "5,20", positionLives = "5,25";

        Console.WriteLine("Waddup\n");

        TinyTools.SetPosition(positionWord);

        List<char> charList = new(Finder.Word()); //Puts random word from textfile "EnglishDictionary.txt" into char list
        List<char> underscoreList = new(Finder.Underscore(charList)); //Creates new list where each char is converted to underscores


        do
        {
            TinyTools.SetPosition(positionLives);
            Console.WriteLine($"{lives} out of 5 lives left\n");

            List<char> guessList = new();
            do
            {
                userGuess = Char.ToUpper(Console.ReadKey(true).KeyChar);

            } while (guessList.Contains(userGuess));

            if (!guessList.Contains(userGuess))
            {
                guessList.Add(userGuess);
                Console.SetCursorPosition(50 + (counter), 25); //Placement of already used char      
                Console.WriteLine(userGuess);
                counter += 2;
            }

            Regex regexAZ = new(@"[A-Z]");
            Match isValid = regexAZ.Match(userGuess.ToString());

            if (charList.Contains(userGuess) && isValid.Success)
            {
                TinyTools.SetPosition(positionWord);

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
                TinyTools.SetPosition(positionLives);
                Console.WriteLine($"{lives} out of 5 lives left\n"); //TODO Same code is used twice. Maybe don't.
            }

            if (!isValid.Success)
            {
                TinyTools.SetPosition(positionWord);
                Console.WriteLine("Please enter a valid character (a-z)\n");
            }

        } while (underscoreList.Contains('_') && lives != 0);

        TinyTools.SetPosition(positionWord);

        for (int i = 0; i < charList.Count; i++)
        {
            Console.Write(charList[i].ToString().PadRight(2));
        }

    }
}

////internal class TinyTools //Methods that are not necessary, but makes the code more "clean(/prettier)"
//{
//    //internal static void NewLine() //Adds a new line (outside of already established CW).
//    //{
//    //    Console.WriteLine(Environment.NewLine);
//    //}

//    //internal static void SetPosition(string x) // "Cleaner" way of setting same position. Mostly just to try it out
//    //{
//    //    int[] intArray = Array.ConvertAll(x.Split(','), int.Parse);
//    //    Point points = new(intArray[0], intArray[1]);
//    //    Console.SetCursorPosition(points.X, points.Y);
//    //}
//}

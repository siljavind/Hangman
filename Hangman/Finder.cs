using Hangman;

internal class Finder
{
    internal static List<char> Word()
    {
        List<string> wordList = new(File.ReadAllLines(@"EnglishDictionary.txt"));

        Random randomGenerator = new();
        int randomNumber = randomGenerator.Next(0, wordList.Count);
        string randomWord = wordList[randomNumber];

        List<char> charList = new();

        charList.AddRange(randomWord);

        return charList;
    }

    internal static List<char> Underscore(List<char> charList)
    {
        List<char> underscoreList = new();

        for (int i = 0; i < charList.Count; i++)
        {
            underscoreList.Add('_');
            Console.Write(underscoreList[i].ToString().PadRight(2));
        }

        return underscoreList;
    }
}


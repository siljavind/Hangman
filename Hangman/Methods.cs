namespace Hangman
{
    internal class Methods
    {
        internal static List<char> Word() //Random word from textfile "EnglishDictionary.txt" into char list
        {
            int randomNumber;
            string randomWord;

            List<string> wordList = new(File.ReadAllLines(@"EnglishDictionary.txt"));

            Random randomGenerator = new();
            randomNumber = randomGenerator.Next(wordList.Count);
            randomWord = wordList[randomNumber];

            List<char> charList = new();
            charList.AddRange(randomWord);

            return charList;
        }

        internal static List<char> Underscore(List<char> charList) //New list where charList is converted to underscores
        {
            List<char> underscoreList = new();

            for (int i = 0; i < charList.Count; i++)
            {
                underscoreList.Add('_');
                Console.Write($"{underscoreList[i]} "); //ToString().PadRight(2);
            }

            return underscoreList;
        }
    }

}
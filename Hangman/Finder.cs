namespace Hangman
{
    internal class Finder
    {
        internal static List<char> FindWord() //Random word from textfile "EnglishDictionary.txt" into char list
        {
            int randomNumber;
            string randomWord;

            List<string> wordList = new(File.ReadAllLines(@"EnglishDictionary.txt"));

            Random randomGenerator = new();
            randomNumber = randomGenerator.Next(wordList.Count); // Picks random number from list as long as wordList
            randomWord = wordList[randomNumber]; // Selects the randomNumber position from wordList

            List<char> charList = new();
            charList.AddRange(randomWord); // Adds randomWord as separate chars to list

            return charList;
        }

        internal static List<char> ConvertToUnderscore(List<char> charList) //New list where charList is converted to underscores
        {
            List<char> underscoreList = new();

            for (int i = 0; i < charList.Count; i++) // Converts charList to underscores and adds to list. Prints formatted underscores
            {
                underscoreList.Add('_');
                Console.Write(underscoreList[i].ToString().PadRight(2));
            }

            return underscoreList;
        }
    }

}
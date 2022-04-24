using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Finder
    {
        internal static List<char> Word()
        {
            List<string> wordList = new List<string>(File.ReadAllLines(@"EnglishDictionary.txt"));

            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(0, wordList.Count);
            string randomWord = wordList[randomNumber];

            Console.WriteLine(randomWord);

            List<char> charList = new List<char>();

            charList.AddRange(randomWord);

            return charList;
        }

        internal static List<char> Underscore(List<char> charList)
        {
            List<char> underscoreList = new List<char>();

            for (int i = 0; i < charList.Count; i++)
            {
                underscoreList.Add('_');
                Console.Write(underscoreList[i]);
            }

            return underscoreList;
        }
    }
}

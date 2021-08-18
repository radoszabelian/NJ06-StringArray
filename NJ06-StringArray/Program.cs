using System;
using System.Linq;

namespace NJ06_StringArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings =
            {
              "You only live forever in the lights you make",
              "When we were young we used to say",
              "That you only hear the music when your heart begins to break",
              "Now we are the kids from yesterday"
            };

            WriteWordCountOfEachSentences(strings);
            WriteWordsStartWithVowel(strings);
            WriteTheLongestWord(strings);
            WriteAverageWordCountOfSentences(strings);
            WriteWordsAlphabeticalWithoutDuplicates(strings);
        }

        static void WriteWordCountOfEachSentences(string[] sentences)
        {
            Console.WriteLine("--WriteWordCountOfEachSentences--");
            var query = sentences.Select(s => s.Count());

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void WriteWordsStartWithVowel(string[] sentences)
        {
            Console.WriteLine("--WriteWordsStartWithVowel--");
            var query = from sentence in sentences
                        select sentence.Split(' ') into words
                        select (from w in words where IsWordStartsWithVowel(w) select w);

            var result = query.SelectMany(w => w);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static bool IsWordStartsWithVowel(String word)
        {
            if (word.Length > 0)
            {
                if (word[0] == 'a' || word[0] == 'e' || word[0] == 'u' || word[0] == 'i' || word[0] == 'o')
                {
                    return true;
                } 
            }
            return false;
        }

        static void WriteTheLongestWord(string[] sentences)
        {
            Console.WriteLine("--WriteTheLongestWord--");

            var query = from sentence in sentences
                        select sentence.Split(' ') into words
                        select (from w in words orderby w.Length select new { word = w, length = w.Length });

            var result = query.SelectMany(w => w).OrderByDescending(w => w.length).First();

            Console.WriteLine($"The word {result.word} is {result.length} long.");
        }

        static void WriteAverageWordCountOfSentences(string[] sentences)
        {
            Console.WriteLine("--WriteAverageWordCountOfSentences--");
            var query = from sentence in sentences
                        select sentence.Split(' ') into words
                        select (from w in words select w.Length).Average();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }

        static void WriteWordsAlphabeticalWithoutDuplicates(string[] sentences)
        {
            Console.WriteLine("--WriteWordsAlphabeticalWithoutDuplicates--");
            var query = from sentence in sentences
                        select sentence.Split(' ') into words
                        select (from w in words orderby w group w.ToLower() by w.ToLower());

            var result = query.SelectMany(w => w);
            foreach (var item in result)
            {
                Console.WriteLine(item.First());
            }
        }
    }
}

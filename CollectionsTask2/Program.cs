using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до текстового файла");
            string path = Console.ReadLine();
            string text = File.ReadAllText(path);
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] delimiters = new char[] { ' ', '\r', '\n', '\t' };
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var keys = new HashSet<string>(words);
            var wordNum = new Dictionary<string, int>();

            foreach (var word in keys)
            {
                wordNum[word] = 0;
            }

            foreach (var word in words)
            {
                if (wordNum.ContainsKey(word))
                {
                    wordNum[word] += 1;
                }
            }

            var textNumwords = words.Length;
            var maxWords = new Dictionary<string, int>();

            int count = 0;
            for (int i = textNumwords; i > 0 && count < 10; i--)
            {
                foreach (var word in wordNum)
                {
                    var index = word.Value;
                    if (index == i)
                    {
                        maxWords.Add(word.Key, word.Value);
                        count++;
                    }

                }
            }

            Console.WriteLine("10 слов чаще всего встречаются в тексте: ");
            foreach (var word in maxWords)
            {
                Console.WriteLine(word.Key + " - слово в тексте встречается: " + word.Value + " раз");
            }


        }
    }
}

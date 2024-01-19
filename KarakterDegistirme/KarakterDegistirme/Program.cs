using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KarakterDegistirme
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Lütfen bir cümle giriniz:");
            string input = Console.ReadLine();

            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = IlkveSonKarakteriDegistir(words[i]);
            }

            string output = String.Join(" ", words);
            Console.WriteLine("Output: " + output);
            Console.Read();
        }

        static string IlkveSonKarakteriDegistir(string word)
        {
            if (word.Length > 1)
            {
                char firstChar = word[0];
                char lastChar = word[word.Length - 1];
                return lastChar + word.Substring(1, word.Length - 2) + firstChar;
            }
            return word;
        }
    }
}


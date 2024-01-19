using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessizHarf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir ifade giriniz (örn: Merhaba Umut Arya):");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');

            foreach (var word in words)
            {
                Console.Write(SessizHarfKontrol(word) + " ");
            }

            Console.Read();
        }

        static bool SessizHarfKontrol(string word)
        {
            string consonants = "bcçdfgğhjklmnprsştvyzBCÇDFGĞHJKLMNPRSŞTVYZ";
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (consonants.Contains(word[i]) && consonants.Contains(word[i + 1]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakterTerstenYazdırma
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Lütfen bir metin giriniz:");
            string input = Console.ReadLine();

            string output = KarakterlerinYerleriniDegistir(input);

            Console.WriteLine("Sonuç:");
            Console.WriteLine(output);
            Console.Read();
        }

        static string KarakterlerinYerleriniDegistir(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 1)
                {
                    words[i] = words[i].Substring(1) + words[i][0];
                }
            }
            return String.Join(" ", words);
        }
    }
}

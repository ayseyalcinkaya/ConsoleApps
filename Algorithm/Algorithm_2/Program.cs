using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen tam sayı ikililerini giriniz (örn: 2 3 1 5 2 5 3 3):");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            for (int i = 0; i < numbers.Length; i += 2)
            {
                int num1 = int.Parse(numbers[i]);
                int num2 = int.Parse(numbers[i + 1]);

                if (num1 == num2)
                {
                    Console.Write((num1 + num2) * (num1 + num2) + " ");
                }
                else
                {
                    Console.Write((num1 + num2) + " ");
                }
            }
            Console.ReadLine();
        }
    }
}

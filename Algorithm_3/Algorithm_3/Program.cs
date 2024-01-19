using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen sayıları giriniz (örn: 56 45 68 77):");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            int küçükToplam = 0;
            int büyükToplam = 0;

            foreach (var number in numbers)
            {
                int num = int.Parse(number);

                if (num < 67)
                {
                    küçükToplam += 67 - num;
                }
                else if (num > 67)
                {
                    büyükToplam += (num - 67) * (num - 67);
                }
            }

            Console.WriteLine($"67 Sayısından küçük olanların Toplam Farkı: {küçükToplam}");
            Console.WriteLine($"67 Sayısından büyük olanların Farklarının Kareler Toplamı: {büyükToplam}");


            Console.Read();



        }
    }
}

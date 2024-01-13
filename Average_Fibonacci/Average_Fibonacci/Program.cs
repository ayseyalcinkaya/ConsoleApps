using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average_Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fibonacci serisinin derinliğini girin: ");
            int derinlik = int.Parse(Console.ReadLine());

            List<int> fibonacciSeries = FibonacciHesapla.SeriHesapla(derinlik);

            Console.WriteLine("Fibonacci Serisi:");
            foreach (var number in fibonacciSeries)
            {
               
                Console.Write(number+ " ");
            }

            double average = OrtalamaHesapla.Ortalama(fibonacciSeries);
            Console.WriteLine("\nFibonacci serisinin ortalaması: " + average);
            Console.ReadLine();
        }
    }

}



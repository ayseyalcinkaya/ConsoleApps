using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleksiyonlar_Soru_2
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[20];

            // Kullanıcıdan 20 sayı alınıyor
            Console.WriteLine("Lütfen 20 adet sayı giriniz: ");
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"{i + 1}. sayıyı giriniz: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(numbers); //Girilen sayıları sıraladık

            // En küçük ve en büyük 3 sayı seçiliyor
            int[] smallest = new int[3] { numbers[0], numbers[1], numbers[2] };
            int[] largest = new int[3] { numbers[17], numbers[18], numbers[19] };

            // Ortalamalar hesaplanıyor
            double averageSmallest = (smallest[0] + smallest[1] + smallest[2]) / 3.0;
            double averageLargest = (largest[0] + largest[1] + largest[2]) / 3.0;

            // Sonuçlar yazdırılıyor
            Console.WriteLine("\nEn küçük 3 sayı: {0}, {1}, {2}", smallest[0], smallest[1], smallest[2]);
            Console.WriteLine("En büyük 3 sayı: {0}, {1}, {2}", largest[0], largest[1], largest[2]);
            Console.WriteLine("En küçük 3 sayının ortalaması: " + averageSmallest);
            Console.WriteLine("En büyük 3 sayının ortalaması: " + averageLargest);
            Console.WriteLine("Ortalamaların Toplamı: " + (averageSmallest + averageLargest));

            Console.ReadLine();
        }
    }
}



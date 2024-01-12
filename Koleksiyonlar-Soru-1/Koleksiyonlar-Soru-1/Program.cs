using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleksiyonlar_Soru_1
{
  
    // Klavyeden girilen 20 adet pozitif sayının asal ve asal olmayan olarak 2 ayrı listeye atın. (ArrayList sınıfını kullanarak yazınız.)
    //Negatif ve numeric olmayan girişleri engelleyin.
    //Her bir dizinin elemanlarını büyükten küçüğe olacak şekilde ekrana yazdırın.
    //Her iki dizinin eleman sayısını ve ortalamasını ekrana yazdırın.

    public class Program
    {
        static void Main(string[] args)
        {
            ArrayList asalSayilar = new ArrayList();
            ArrayList asalOlmayanlar = new ArrayList();

            int count = 0;
            while (count < 20)
            {
                Console.Write("Lütfen bir pozitif sayı girin:");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number > 0)
                    {
                        if (IsAsal(number))
                        {
                            asalSayilar.Add(number);
                        }
                        else
                        {
                            asalOlmayanlar.Add(number);
                        }
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen pozitif bir sayı girin.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçerli bir sayı girin.");
                }
            }

            DisplayResults(asalSayilar, "Asal Sayılar");
            DisplayResults(asalOlmayanlar, "Asal Olmayan Sayılar");
            Console.WriteLine("Programı kapatmak için herhangi bir tuşa basınız.");
            Console.ReadLine();
        }

        static bool IsAsal(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static void DisplayResults(ArrayList numbers, string title)
        {
            numbers.Sort();
            numbers.Reverse(); 

            Console.WriteLine($"\n{title}:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine($"\n{title} Sayısı: {numbers.Count}");
            if (numbers.Count > 0)
            {
                double average = OrtalamaHesapla(numbers);
                Console.WriteLine($"{title} Ortalaması: {average}");
            }
        }

        static double OrtalamaHesapla(ArrayList numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        }
    }
}
    


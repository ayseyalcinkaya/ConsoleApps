using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleksiyonlar_Soru_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Klavyeden girilen cümle içerisindeki sesli harfleri bir dizi içerisinde saklayan ve dizinin elemanlarını sıralayan programı yazınız.
            {
                Console.WriteLine("Bir cümle giriniz:");
                string cumle = Console.ReadLine().ToLower(); 

                char[] sesliHarfler = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
                List<char> bulunanSesliler = new List<char>();

                foreach (char harf in cumle)
                {
                    if (Array.IndexOf(sesliHarfler, harf) >= 0)
                    {
                        bulunanSesliler.Add(harf);
                    }
                }

                bulunanSesliler.Sort(); 

                Console.WriteLine("Cümledeki sesli harfler:");
                foreach (char sesli in bulunanSesliler)
                {
                    Console.Write(sesli + " ");
                }

                Console.ReadLine();
            }
        }
    }
}

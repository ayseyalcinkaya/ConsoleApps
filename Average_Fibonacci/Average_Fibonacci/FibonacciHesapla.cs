using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average_Fibonacci
{
    public class FibonacciHesapla
    {
        public static List<int> SeriHesapla(int derinlik)
        {
            List<int> series = new List<int>();
            int first = 1, second = 1, next;

            for (int i = 0; i < derinlik; i++)
            {
                if (i < 2)
                    next = 1;
                else
                {
                    next = first + second;
                    first = second;
                    second = next;
                }
                series.Add(next);
            }

            return series;
        }
    }
}

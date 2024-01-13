using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Average_Fibonacci
{
    public class OrtalamaHesapla
    {
        public static double Ortalama(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return (double)sum / numbers.Count;
        }
    }
}

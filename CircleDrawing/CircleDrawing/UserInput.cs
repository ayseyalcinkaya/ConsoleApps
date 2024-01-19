using System;

namespace CircleDrawing
{
    public class UserInput
    {
        public static int GetValidRadius()
        {
            int radius;
            Console.Write("Lütfen dairenin yarıçapını giriniz: ");
            while (!int.TryParse(Console.ReadLine(), out radius) || radius <= 0)
            {
                Console.Write("Geçersiz değer. Lütfen pozitif bir tam sayı giriniz: ");
            }
            return radius;
        }
    }
}
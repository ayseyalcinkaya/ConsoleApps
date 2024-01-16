using System;

namespace Triangle
{
    public class UserInput
    {
        public int GetSizeFromUser()
        {
            Console.Write("Lütfen üçgenin boyutunu girin: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
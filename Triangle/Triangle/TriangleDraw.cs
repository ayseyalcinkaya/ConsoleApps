using System;

namespace Triangle
{
    public class TriangleDraw
    {

        public void DrawTriangle(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

    }
}
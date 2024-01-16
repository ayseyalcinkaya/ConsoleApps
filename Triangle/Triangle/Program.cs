using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInput input = new UserInput();
            int size = input.GetSizeFromUser();

            TriangleDraw draw = new TriangleDraw();
            draw.DrawTriangle(size);
            Console.ReadLine();
        }
    }
}

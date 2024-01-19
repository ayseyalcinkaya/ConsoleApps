using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleDrawing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int radius = UserInput.GetValidRadius();
            CircleDrawer circle = new CircleDrawer(radius);
            circle.Draw();

            Console.Read();
        }
    }
}

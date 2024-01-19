using System;

namespace CircleDrawing
{
    public class CircleDrawer
    {
        private int radius;

        public CircleDrawer(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double aspectRatio = 2.0; 
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if ((x * x) + (y * y * aspectRatio * aspectRatio) <= (radius * radius))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

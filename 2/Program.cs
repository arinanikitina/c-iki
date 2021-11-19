using System;

namespace ConsoleApp9
{

    struct Point
    {
        int x, y;

        public void SetXY(int nx, int ny)
        {
            x = nx;
            y = ny;
        }

        // свойство X
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        // свойство Y
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Point[] MP; 
            int maxi = -9999;
            int b = 0;
      
            MP = new Point[10];

            for (int i = 0; i < 10; i++)
            {
                MP[i].X = i * 2;
                MP[i].Y = i + 1;
            }

            for (int i = 0; i < 10; i++)
            {
                if (MP[i].Y > maxi) { maxi = MP[i].Y; b = MP[i].X; }
            }

            Console.WriteLine("Maximum: (" + b + ", " + maxi + ')');
        }
    }
}

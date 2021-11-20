//Дан массив структур {x:int, y:double} -- отсортировать его в порядке возрастания Y и преобразовать в массив элементов {x:double, y:int}


using System;

namespace ConsoleApp9
{

    struct Point
    {
        int x;
        double y;

        public void SetXY(int nx, double ny)
        {
            x = nx;
            y = ny;
        }

        //свойство X
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        // свойство Y
        public double Y
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
            int b = 0;
            double a = 3.14;
            MP = new Point[10];

            for (int i = 9; i > -1; i--)
            {
                MP[i].X = b;
                MP[i].Y = a;
                a++;
                b++;
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (MP[j].Y > MP[j + 1].Y)
                    {
                        a = MP[j].Y;
                        b = MP[j].X;
                        MP[j].Y = MP[j + 1].Y;
                        MP[j].X = MP[j + 1].X;
                        MP[j + 1].Y = a;
                        MP[j + 1].X = b;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Convert.ToDouble(MP[i].X);
                Convert.ToInt32(MP[i].Y);
                Console.WriteLine(MP[i].X + "      " + MP[i].Y);
            }



        }
    }
}

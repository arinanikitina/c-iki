using System.Threading;
using System;
using System.Diagnostics;
class Program
{

    static float x = 0; //Число пи для метода
    static float t = 1;//Знаменатель дроби в методе
    static int y = 1;//Знак для метода
    static AutoResetEvent waitHandler = new AutoResetEvent(true); //объект ожидания событий, по сути то же самое что и locker

    struct Counter //структура для корректной работы threadpool
        {
            private uint n; //Кол-во потоков
            private uint p; //Кол-во итераций на один поток
            private float e; //Значение пи при текущем кол-ве итераций
            private uint k; //Кол-во итераций в целом

            public Counter(uint n, uint p, float e, uint k)
            {
                this.n = n;
                this.p = p;
                this.e = e;
                this.k = k;
            }
            public uint N
            {
                get { return n; }
            }
            public uint P
            {
                get { return p; }
            }
            public float E
            {
                get { return e; }
            }
            public uint K
            {
                get { return k; }
            }
        }


            static void Count(object counter)
        
            {
            Counter cnt = (Counter)counter;
            Stopwatch stopWatch = new Stopwatch();
        
            waitHandler.WaitOne(); // по сути то же самое что и locker
            stopWatch.Start();

                int i = 0;

                while (i < cnt.P) //пока количество итераций меньше кол-ва итераций на поток
                {
                    x = x + 4 * (1 / t) * y;
                    t = t + 2;
                    y = y * (-1);
                    i++;
                    //Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                }

                //вывод можно раскомментить, чтобы посмотреть, как работает

                if ((x < cnt.E) && (cnt.K % cnt.N != 0)) //если нечетное кол-во потоков (и итоговое число меньше того, что должно получиться)
                {
                    x = x + 4 * (1 / t) * y;
                    t = t + 2;
                    y = y * (-1);
                    //Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);

                }

                if (x == cnt.E) //если итоговое получившееся число равно тому, что должно получиться
                {
                    stopWatch.Stop();
                    Console.WriteLine("Elapsed time: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
                    Environment.Exit(0);
                }
        waitHandler.Set();
        
    }
    

    static void Main(string[] args)
    {
        float l = 1;
        float q = 0;
        int c = 1;
        Console.WriteLine("How many threads do you need?");

        uint m = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine("How many iterations do you need?");

        uint r = Convert.ToUInt32(Console.ReadLine());

        uint f = r / m; //кол-во итераций на поток

        for (int i = 0; i < r; i++) //для проверки значения в методе посчитаем, чему должно быть равно пи при таком кол-ве итераций
        {
            q = q + 4 * (1 / l) * c;
            l = l + 2;
            c = c * (-1);
        }
        //Console.WriteLine(q + "  то, что должно получиться");
        object cnt = new Counter(m, f, q, r);

        for (int i = 0; i < m; i++)
            ThreadPool.QueueUserWorkItem(new WaitCallback(Count), cnt);
       
        Console.WriteLine("Количество потоков: " + m);
        Console.WriteLine("Количество итераций: " + r);
        Console.ReadLine();

    }


}
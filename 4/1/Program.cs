using System;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp16
{
    class Program
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(true); //то же самое, что и lock
        static int x = 1;
        public static void Something(object m) //с параметром, потому что без него (почему-то) никак (в случае с threadpool)
        {
            waitHandler.WaitOne();
            for (int i = 0; i < 10; i++)
                {
                    //Console.WriteLine(x); можно посмотреть вывод
                    x++;
                }
            waitHandler.Set();
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();


            stopwatch.Start();
            //ctrl c ctrl v любое кол-во пулов
            ThreadPool.QueueUserWorkItem(Something);  //можем не передавать параметр в метод, он просто будет равен null
            ThreadPool.QueueUserWorkItem(Something);
            ThreadPool.QueueUserWorkItem(Something);
            stopwatch.Stop();
            Console.WriteLine("Время создания пулов: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
            Thread.Sleep(1000); //иначе некорректно работает threadpool (из документации)

            stopwatch.Reset();

            stopwatch.Start();
            //ctrl c ctrl v любое кол-во тредов + thread.start()
            Thread mama = new Thread(new ParameterizedThreadStart(Something));
            Thread mama1 = new Thread(new ParameterizedThreadStart(Something));
            stopwatch.Stop();
            Console.WriteLine("Время создания потоков: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
            mama.Start();
            mama1.Start(); //можем не передавать параметр в метод, он просто будет равен null
            



        }
    }
}

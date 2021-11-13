using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp8
{

    class Program
    {
        public static void Define<T>(object save, T check)
        {
            Console.WriteLine("Structure: " + check.GetType());
            Console.WriteLine("Type: " + save.GetType() + "\n");
        }
        public void Reset() { }
        static void Main(string[] args)
        {

            ArrayList list = new ArrayList();
            List<int> numbers = new List<int>() { };
            ArrayList list2 = new ArrayList();
            List<string> strings = new List<string>() { };


            //Хранение intов

            Stopwatch stopWatch = new Stopwatch();

           

            stopWatch.Start();
            for (int i = 0; i < 1000000; i++) numbers.Add(i); //List
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Reset();
            Define<List<int>>(numbers[0], numbers);

            stopWatch.Start();
            for (int i = 0; i < 1000000; i++) list.Add(i); //ArrayList
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Reset();
            Define<ArrayList>(list[0], list);

            //Хранение string

            stopWatch.Start();
            for (int i = 0; i < 1000000; i++) list2.Add("hello"); //ArrayList
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Reset();
            Define<ArrayList>(list2[0], list2);

            stopWatch.Start();
            for (int i = 0; i < 1000000; i++) strings.Add("hello"); //List
            stopWatch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Reset();
            Define<List<string>>(strings[0], strings);


            Console.ReadKey();
        }
    }
}

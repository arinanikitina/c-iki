using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] arr = { "ответ", "коТ", "отрада", "Отомстить", "mama" };
            List<string> final = new List<string>() { };
            char[] help;
            for (int i = 0; i < arr.Length; i++)
            {
                help = arr[i].ToCharArray();           

            for (int j = 0; j < help.Length; j++)

                    if ((help[j] == 'о' || help[j] == 'О') && (help[j + 1] == 'т' || help[j + 1] == 'Т')) final.Add(arr[i]);

            }

            final.Sort();
            for (int i = 0; i < final.Count; i++) Console.WriteLine(final[i]);
            
        }
    }
}

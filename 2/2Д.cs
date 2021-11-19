using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1, 2, 3, 4, 5};
            int[] numbers2 = {6, 7, 8, 9, 10};
            string a;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    a = numbers[i].ToString() + numbers2[j].ToString();
                    if (Convert.ToInt32(a) % 5 == 0) Console.WriteLine(Convert.ToInt32(a));

                }
            }

        }
    }
}

using System;

namespace ConsoleApp10
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string s1 = "beatiful sea";
            string s2 = "aes lufitaeb";
            string s3 = "Beatiful beach";
            int m = 1;
            char[] arr = s1.ToCharArray();
            char[] arr2 = s3.ToCharArray();
            Array.Reverse(arr2);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr2[i])
                {
                    Console.WriteLine("False");
                    m = 0;
                    break;
                }
            }

            if (m == 1) Console.WriteLine("Vse ok");
        }
    }
}

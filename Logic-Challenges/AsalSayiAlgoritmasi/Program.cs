using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsalSayiAlgoritmasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("5");
            Console.WriteLine("7");
            int flag;
            for (int i = 2; i < 100; i++)
            {
                int a, b, c, d;
                flag = 0;
                for (a = 0; a <= i; a += 2)
                {
                    for (b = 0; b <= i; b += 3)
                    {
                        for (c = 0; c <= 100; c += 5)
                        {
                            for (d = 0; d <= 100; d += 7)
                            {
                                if (i == a || i == b || i == c || i == d)
                                    flag = 1;
                            }
                        }
                    }
                }
                if (flag == 0)
                    Console.WriteLine(i);
            }
        }
    }
}

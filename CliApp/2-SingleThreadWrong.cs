using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CliApp
{
    class _2_SingleThreadWrong
    {
        public static void Run()
        {
            Console.WriteLine($"init: {Counter}");
            new Thread(() => Increment(10)).Start();
            Console.WriteLine($"exit: {Counter}");
        }

        static int Counter = 0;
        static void Increment(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                Counter += 1;
            }
        }
    }
}

using System;
using System.Threading;

namespace CliApp
{
    class _3_SingleThread
    {
        public static void Run()
        {
            Console.WriteLine($"init: {Counter}");
            var thread = new Thread(() => Increment(10));
            thread.Start();
            thread.Join();
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

using System;
using System.Linq;
using System.Threading;

namespace CliApp
{
    class _6_MultiThreadsLock
    {
        public static void Run()
        {
            Run(1000);
            Run(10000);
            Run(100000);
            Run(1000000);
            Run(10000000);
        }
        public static void Run(int times)
        {
            Counter = 0;
            Console.WriteLine($"init: {Counter}");
            const int threadsCount = 10;

            var threads = Enumerable.Range(0, threadsCount)
                .Select((_) => new Thread(() => Increment(times)))
                .ToArray();

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"exit: {Counter}");
            Console.WriteLine($"rate: {threadsCount * times - Counter}");
        }

        static int Counter = 0;
        static void Increment(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                lock (typeof(_6_MultiThreadsLock))
                {
                    Counter += 1;
                }
            }
        }
    }
}

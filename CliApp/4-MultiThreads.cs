using System;
using System.Linq;
using System.Threading;

namespace CliApp
{
    class _4_MultiThreads
    {
        public static void Run()
        {
            Console.WriteLine($"init: {Counter}");
            const int threadsCount = 10;
            const int times = 100; // increase x10 several times

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
                Counter += 1;
            }
        }
    }
}

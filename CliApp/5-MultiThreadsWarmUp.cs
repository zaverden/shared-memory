using System;
using System.Linq;
using System.Threading;

namespace CliApp
{
    class _5_MultiThreadsWarmUp
    {
        public static void Run()
        {
            Run(1000);
            Run(10000); // we have 10 prepared threads, so this works as expected
            Run(100000);
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
                Counter += 1;
            }
        }
    }
}

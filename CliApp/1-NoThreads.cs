using System;

namespace CliApp
{
    class _1_NoThreads
    {
        public static void Run()
        {
            Console.WriteLine($"init: {Counter}");
            Increment(10);
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

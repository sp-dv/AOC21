using System;

namespace AOC21
{
    class Day1
    {
        public static void Run()
        {
            Console.WriteLine($"Day 1, part 1: {Part1()}");
            Console.WriteLine($"Day 1, part 2: {Part2()}");
        }

        private static int[] inputs = Common.GiveMeIntegers(1);

        public static string Part1()
        {
            return MagicCount(1).ToString();
        }

        public static string Part2()
        {
            // Use the fact that we don't have to compare the elements common to both
            // windows; simply compare the elements which are not common i.e. the head
            // (which is in the new window) and the tail (which is in the old window).
            return MagicCount(3).ToString();
        }

        private static int MagicCount(int gap)
        {
            var counter = 0;

            // Start counting from the first element that has a sufficently large gap to 
            // the first element as to not underrun the array.
            for (int i = gap; i < inputs.Length; i++)
            {
                if (inputs[i] > inputs[i - gap]) { counter++; }
            }

            return counter;
        }
    }
}

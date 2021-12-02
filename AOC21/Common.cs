using System;
using System.IO;
using System.Linq;

namespace AOC21
{
    static class Common
    {
        const string InputDir = "../../../input/";

        public static int[] GiveMeIntegers(int day)
        {
            try
            {
                return GiveMeLines(day).Select(line => Int32.Parse(line)).ToArray();
            }
            catch (FormatException)
            {
                throw new Exception($"Bad data in input for day {day}");
            }
        }

        public static string[] GiveMeLines(int day)
        {
            return File.ReadAllLines(InputDir + day + ".txt");
        }
    }
}

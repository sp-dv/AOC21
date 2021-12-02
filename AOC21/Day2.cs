using System;
using System.Linq;

namespace AOC21
{
    static class Day2
    {
        private static SubmarineInstruction[] inputs = 
            Common.GiveMeLines(2).Select(line => new SubmarineInstruction(line)).ToArray();

        public static void Run()
        {
            Console.WriteLine($"Day 2, part 1: {Part1()}");
            Console.WriteLine($"Day 2, part 2: {Part2()}");
        }

        private static string Part1()
        {
            var submarine = new Submarine();

            foreach (var instruction in inputs)
            {
                submarine.ExcecuteInstruction(instruction);
            }

            return (submarine.HorizontalPosition * submarine.VerticalPosition).ToString();
        }

        private static string Part2()
        {
            var submarine = new SubmarineV2();

            foreach (var instruction in inputs)
            {
                submarine.ExcecuteInstruction(instruction);
            }

            return (submarine.HorizontalPosition * submarine.VerticalPosition).ToString();
        }
    }

    class Submarine
    {
        public int HorizontalPosition { get; private set; }
        public int VerticalPosition { get; private set; }

        public void ExcecuteInstruction(SubmarineInstruction instruction)
        {
            switch (instruction.Direction)
            {
                case SubmarineDirection.Forward: HorizontalPosition += instruction.Value; break;
                case SubmarineDirection.Down: VerticalPosition += instruction.Value; break;
                case SubmarineDirection.Up: VerticalPosition -= instruction.Value; break;
            }

            if (VerticalPosition < 0) { throw new Exception("Your submarine is flying. Please stop."); }
        }
    }

    class SubmarineV2
    {
        public int HorizontalPosition { get; private set; }
        public int VerticalPosition { get; private set; }
        private int Aim { get; set; }

        public void ExcecuteInstruction(SubmarineInstruction instruction)
        {
            switch (instruction.Direction)
            {
                case SubmarineDirection.Forward:
                {
                    HorizontalPosition += instruction.Value;
                    VerticalPosition += instruction.Value * Aim;
                } break;

                case SubmarineDirection.Down: Aim += instruction.Value; break;
                case SubmarineDirection.Up: Aim -= instruction.Value; break;
            }

            if (VerticalPosition < 0) { throw new Exception("Your submarine is flying. Please stop."); }
        }
    }

    class SubmarineInstruction
    {

        public SubmarineDirection Direction { get; }
        public int Value { get; }

        public SubmarineInstruction(string raw)
        {
            var splits = raw.Split(' ');
            if (splits.Length != 2) { throw new FormatException("Bad submarine instruction format."); }

            var instructionString = splits[0];
            var valueString = splits[1];

            switch (instructionString)
            {
                case "forward": Direction = SubmarineDirection.Forward; break;
                case "down": Direction = SubmarineDirection.Down; break;
                case "up": Direction = SubmarineDirection.Up; break;
                default: throw new FormatException("Bad submarine instruction direction.");
            }

            try
            {
                Value = Int32.Parse(valueString);
            }
            catch (FormatException)
            {
                throw new FormatException("Bad submarine instruction value.");
            }
        }
    }

    enum SubmarineDirection { Forward, Down, Up };
}

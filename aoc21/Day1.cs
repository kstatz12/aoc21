namespace aoc21
{
    public class Day1 : IDay<int>
    {
        public int Exec()
        {
            var lines = File.ReadLines("data/day1.txt")
                .Select(x => int.Parse(x))
                .ToArray();
            int count = 0;
            int prev = Int32.MaxValue;
            foreach(var curr in lines)
            {
                count += curr > prev ? 1 : 0;
                prev = curr;
            }
            return count;
        }
    }

}

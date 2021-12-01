namespace aoc21
{
    public class Day1Two : IDay<int>
    {
        public int Exec()
        {
            var lines = File.ReadLines("data/day1.txt")
                .Select(x => int.Parse(x))
                .ToArray();
            int count = 0;

            for(int i = 3; i < lines.Count(); i++)
            {
                count += lines[i] > lines[i - 3] ? 1 : 0;
            }
            return count;
        }
    }
}

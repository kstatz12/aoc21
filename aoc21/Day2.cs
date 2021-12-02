namespace aoc21
{


    public class Position
    {

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public void MoveUp(int magnitude)
        {
           Y -= magnitude;
        }

        public void MoveDown(int magnitude)
        {
            Y += magnitude;
        }

        public void MoveForward(int magnitude)
        {
            X += magnitude;
        }

        public void MoveForward2(int magnitude)
        {
            MoveForward(magnitude);
            Y += Z * magnitude;
        }

        public void AimUp(int magnitude)
        {
            Z -= magnitude;
        }

        public void AimDown(int magnitude)
        {
            Z += magnitude;
        }

        public int Calculate()
        {
            return X * Y;
        }
    }

    public class Command
    {

        public Command(string direction, int magnitude)
        {
            Direction = direction;
            Magnitude = magnitude;
        }
        public string Direction { get; }
        public int Magnitude { get; }
    }

    public class Day2 : IDay<int>
    {
        const string FORWARD = "forward";
        const string DOWN = "down";
        const string UP = "up";


        public int Exec()
        {
            var commands = File.ReadLines("data/day2.txt")
                .Select(x =>
                {
                    var parts = x.Split(' ');
                    return new Command(parts[0], int.Parse(parts[1]));
                });

            var pos = new Position(0, 0);

            foreach(var c in commands)
            {
                switch(c.Direction)
                {
                    case FORWARD :
                        pos.MoveForward(c.Magnitude);
                        break;
                    case DOWN :
                        pos.MoveDown(c.Magnitude);
                        break;
                    case UP :
                        pos.MoveUp(c.Magnitude);
                        break;
                }
            }
            return pos.Calculate();
        }

        public int Exec2()
        {
            var commands = File.ReadLines("data/day2.txt")
                .Select(x =>
                {
                    var parts = x.Split(' ');
                    return new Command(parts[0], int.Parse(parts[1]));
                });

            var pos = new Position(0, 0, 0);

            foreach(var c in commands)
            {
                switch(c.Direction)
                {
                    case FORWARD :
                        pos.MoveForward2(c.Magnitude);
                        break;
                    case DOWN :
                        pos.AimDown(c.Magnitude);
                        break;
                    case UP :
                        pos.AimUp(c.Magnitude);
                        break;
                }
            }
            return pos.Calculate();
        }
    }

}

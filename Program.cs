namespace StackAndQueue
{
    internal class Program
    {
        private const int DISCS_COUNT = 5;
        private const int DELAYS_MS = 250;
        private static int _columnSize = 30;

        static void Main(string[] args)
        {
            // Stack example - reversing words
            //Stack<char> word = new Stack<char>();
            //string name = "davido";
            //foreach (char c in name)
            //{
            //    word.Push(c);
            //}

            //while (word.Count > 0)
            //{
            //    Console.Write(word.Pop());
            //}
            //Console.WriteLine();

            // Stack example - Tower of Hanoi
            _columnSize = Math.Max(6, GetDiscWidth(DISCS_COUNT) + 2);
            HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
            algorithm.MoveCompleted += Algorithm_Visualize;
            Algorithm_Visualize(algorithm, EventArgs.Empty);
            algorithm.Start();
        }

        private static void Algorithm_Visualize(object? sender, EventArgs e)
        {
            Console.Clear();

            HanoiTower algorithm = (HanoiTower)sender;
            if (algorithm.DiscCount <= 0)
            {
                return;
            }

            char[][] visualization = InitializeVisualization(algorithm);
            PrepareColumn(visualization, 1, algorithm.DiscCount, algorithm.From);
            PrepareColumn(visualization, 2, algorithm.DiscCount, algorithm.To);
            PrepareColumn(visualization, 3, algorithm.DiscCount, algorithm.Auxiliary);

            Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILIARY"));
            DrawVisualization(visualization);
            Console.WriteLine();
            Console.WriteLine($"Number of moves: {algorithm.MovesCount}");
            Console.WriteLine($"Number of discs: {algorithm.DiscCount}");

            Thread.Sleep(DELAYS_MS);
        }

        private static string? Center(string v)
        {
            int margin = (_columnSize - v.Length) / 2;
            return v.PadLeft(margin + v.Length)
                .PadRight(_columnSize);
        }

        private static void DrawVisualization(char[][] visualization)
        {
            for (int i = 0; i < visualization.Length; i++)
            {
                Console.WriteLine(visualization[i]);
            }
        }

        private static void PrepareColumn(char[][] visualization, int column, int discCount, Stack<int> stack)
        {
            int margin = _columnSize * (column - 1);
            for (int i = 0; i < stack.Count; i++)
            {
                int size = stack.ElementAt(i);
                int row = discCount - (stack.Count - i);
                int columnStart = margin + discCount - size;
                int columnEnd = columnStart + GetDiscWidth(size);
                for (int j = columnStart; j <= columnEnd; j++)
                {
                    visualization[row][j] = '=';
                }
            }
        }

        private static char[][] InitializeVisualization(HanoiTower algorithm)
        {
            char[][] visualization = new char[algorithm.DiscCount][];

            for (int i = 0; i < visualization.Length; i++)
            {
                visualization[i] = new char[_columnSize * 3];
                for (int j = 0; j < _columnSize * 3; j++)
                {
                    visualization[i][j] = ' ';
                }
            }
            return visualization;
        }

        private static int GetDiscWidth(int size)
        {
            return 2 * size - 1;
        }
    }
}
namespace StackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Stack example - reversing words
            Stack<char> word = new Stack<char>();
            string name = "davido";
            foreach (char c in name)
            {
                word.Push(c);
            }

            while (word.Count > 0)
            {
                Console.Write(word.Pop());
            }
            Console.WriteLine();

            // Stack example - Tower of Hanoi

        }
    }
}
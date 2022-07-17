namespace StackAndQueue
{
    internal class HanoiTower
    {
        public int DiscCount { get; private set; }
        public int MovesCount { get; private set; }
        public Stack<int> From { get; private set; }
        public Stack<int> To { get; private set; }
        public Stack<int> Auxiliary { get; private set; }
        public event EventHandler<EventArgs> MoveCompleted;
    }
}

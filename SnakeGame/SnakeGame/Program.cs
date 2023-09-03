namespace SnakeGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Board board = new Board(20, 20);
            var taskKeys = new Task(() => board.Read());
            taskKeys.Start();
            board.Play();
        }
    }
}
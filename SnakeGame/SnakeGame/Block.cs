using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Block
    {
        public int x, y;
        public char ch;
        public ConsoleColor color;

        public Block(int x, int y, char ch, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
            this.color = color;
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void Print()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(ch);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

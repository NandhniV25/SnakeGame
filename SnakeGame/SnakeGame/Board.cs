using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Board
    {
        public int width, height, points;
        public ConsoleKey direction = ConsoleKey.RightArrow;
        char snakeChar = '$';
        char foodChar = '@';
        Random random = new Random();
        List<Block> snake = new List<Block>();
        Block food;

        public Board(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.food = new Block(random.Next(width), random.Next(height), foodChar, ConsoleColor.DarkRed);
            this.snake.Add(new Block(width / 2, height / 2, snakeChar, ConsoleColor.DarkGreen));
            this.snake.Add(new Block((width / 2) - 1, height / 2, snakeChar, ConsoleColor.DarkGreen));
        }
        public void Read()
        {
            while (true)
            {
                var input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.LeftArrow && direction != ConsoleKey.RightArrow)
                    direction = ConsoleKey.LeftArrow;
                else if (input == ConsoleKey.RightArrow && direction != ConsoleKey.LeftArrow)
                    direction = ConsoleKey.RightArrow;
                else if (input == ConsoleKey.UpArrow && direction != ConsoleKey.DownArrow)
                    direction = ConsoleKey.UpArrow;
                else if (input == ConsoleKey.DownArrow && direction != ConsoleKey.UpArrow)
                    direction = ConsoleKey.DownArrow;
            }
        }
        public void Play()
        {
            snake.ForEach(item => item.Print());
            food.Print();
            var isGameOver = false;
            while (!isGameOver)
            {
                Console.SetCursorPosition(0, height + 2);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Points = " + points);
                Console.ForegroundColor = ConsoleColor.White;

                var head = snake.First();
                var tail = snake.Last();
                var newHead = CreateNewHead(head);

                //cond1: empty space => newHead.print, tail.clear
                //cond2: food => newHead.print
                //cond3: snake => game over
                if (newHead.x == food.x && newHead.y == food.y)
                {
                    snake.Insert(0, newHead);
                    newHead.Print();
                    points += 10;
                    food = new Block(random.Next(width), random.Next(height), foodChar, ConsoleColor.DarkRed);
                    food.Print();
                }
                else if (snake.Any(item => item.x == newHead.x && item.y == newHead.y))
                {
                    Console.SetCursorPosition(0, height + 4);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("GameOver");
                    Console.ForegroundColor = ConsoleColor.White;
                    isGameOver = true;
                    break;
                }
                else
                {
                    snake.Insert(0, newHead);
                    newHead.Print();
                    tail.Clear();
                    snake.Remove(tail);
                }
                Thread.Sleep(100);
            }
        }
        public Block CreateNewHead(Block head)
        {
            Block newHead = new Block(head.x, head.y, head.ch, head.color);

            if (direction == ConsoleKey.LeftArrow)
            {
                if (newHead.x == 0)
                    newHead.x = width - 1;
                else if (newHead.x > 0)
                    newHead.x -= 1;
            }
            else if (direction == ConsoleKey.RightArrow)
            {
                if (newHead.x == width - 1)
                    newHead.x = 0;
                else if (newHead.x < width - 1)
                    newHead.x += 1;
            }
            else if (direction == ConsoleKey.UpArrow)
            {
                if (newHead.y == 0)
                    newHead.y = height - 1;
                else if (newHead.y > 0)
                    newHead.y -= 1;
            }
            else if (direction == ConsoleKey.DownArrow)
            {
                if (newHead.y == height - 1)
                    newHead.y = 0;
                else if (newHead.y < height - 1)
                    newHead.y += 1;
            }
            return newHead;
        }
    }
}

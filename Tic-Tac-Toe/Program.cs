using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void DrawCross(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i - j == x - y || i + j == y + x + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }
        static void DrawRectangle(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i == x || i == x + size || j == y || j == y + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }
        static void DrawField(int width, int height, int cellSize)
        {
            for (int y = 0; y <= height; y += cellSize)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }
            for (int x = 0; x <= height; x += cellSize)
            {
                for (int y = 0; y < width; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("█");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);
            DrawField(33, 33, 11);
            Console.SetCursorPosition(5, 1); Console.Write(1);
            Console.SetCursorPosition(16, 1); Console.Write(2);
            Console.SetCursorPosition(27, 1); Console.Write(3);
            Console.SetCursorPosition(5, 12); Console.Write(4);
            Console.SetCursorPosition(16, 12); Console.Write(5);
            Console.SetCursorPosition(27, 12); Console.Write(6);
            Console.SetCursorPosition(5, 23); Console.Write(7);
            Console.SetCursorPosition(16, 23); Console.Write(8);
            Console.SetCursorPosition(27, 23); Console.Write(9);

            int input;
            int c1, c2, c3, c4, c5, c6, c7, c8, c9;
            c1 = -1; c2 = -2; c3 = -3; c4 = -4; c5 = -5; c6 = -6; c7 = -7; c8 = -8; c9 = -9;
            int win = -1;

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(35, 0);
                Console.Write("                                                     ");
                Console.SetCursorPosition(35, 0);
                Console.Write("Введите номер клетки: ");
                bool errorInput = !int.TryParse(Console.ReadLine(), out input);
                if (input < 1 || input > 9) errorInput = true;
                if (input == 1 && c1 >= 0) errorInput = true;
                if (input == 2 && c2 >= 0) errorInput = true;
                if (input == 3 && c3 >= 0) errorInput = true;
                if (input == 4 && c4 >= 0) errorInput = true;
                if (input == 5 && c5 >= 0) errorInput = true;
                if (input == 6 && c6 >= 0) errorInput = true;
                if (input == 7 && c7 >= 0) errorInput = true;
                if (input == 8 && c8 >= 0) errorInput = true;
                if (input == 9 && c9 >= 0) errorInput = true;

                if (errorInput == true)
                {
                    i--;
                    continue;
                }

                if (input == 1) c1 = i % 2;
                if (input == 2) c2 = i % 2;
                if (input == 3) c3 = i % 2;
                if (input == 4) c4 = i % 2;
                if (input == 5) c5 = i % 2;
                if (input == 6) c6 = i % 2;
                if (input == 7) c7 = i % 2;
                if (input == 8) c8 = i % 2;
                if (input == 9) c9 = i % 2;

                int x = (input - 1) % 3 * 11 + 2;
                int y = (input - 1) / 3 * 11 + 2;

                if (i % 2 == 0)
                {
                    DrawCross(x, y, 7);
                }
                else
                {
                    DrawRectangle(x, y, 7);
                }

                if (c1 == c2 && c2 == c3) win = c1;
                if (c4 == c5 && c5 == c6) win = c4;
                if (c7 == c8 && c8 == c9) win = c7;
                if (c1 == c4 && c4 == c7) win = c1;
                if (c2 == c5 && c5 == c8) win = c2;
                if (c3 == c6 && c6 == c9) win = c3;
                if (c1 == c5 && c5 == c9) win = c1;
                if (c3 == c5 && c5 == c7) win = c3;

                if (win == 0)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победили крестики");
                    break;
                }
                if (win == 1)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победили нолики");
                    break;
                }
            }
            Console.SetCursorPosition(35, 3);
            if (win == -1) Console.WriteLine("Ничья");
            Console.ReadKey();
        }
    }
}

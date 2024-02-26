using System;
using System.Linq;

class Program
{
    static string[] grid;

    static void PrintGrid(string[] grid) 
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // print grid element 
                Console.Write(" " + grid[i * 3 + j] + " ");

                // add vertical separator if not last column
                if (j < 2)
                {
                    Console.Write("|");
                }
            }
            // move to next line after each row
            Console.WriteLine();

            // add horizontal separator if not last row
            if (i < 2)
            {
                Console.WriteLine("-----------");
            }
        }
    }

    static void Main(string[] args)
    {
        grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        bool firstPlayerTurn = true;

        while (true) 
        {
            PrintGrid(grid);

            if (firstPlayerTurn) 
                Console.WriteLine("First player's turn");
            else
                Console.WriteLine("Second player's turn");

            string move = Console.ReadLine();

            if (grid.Contains(move) && move != "X" && move != "O")
            {
                int gridIndex = Convert.ToInt32(move) - 1;
                
                if (firstPlayerTurn)
                    grid[gridIndex] = "X";
                else
                    grid[gridIndex] = "O";
            }

            // toggle turn btwn first and second players
            firstPlayerTurn = !firstPlayerTurn;
        }
    }
}

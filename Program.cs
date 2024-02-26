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
                int index = i * 3 + j;

                // set default console color
                Console.ForegroundColor = ConsoleColor.White;

                // print X as blue and O as green
                if (grid[index] == "X")
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (grid[index] == "O")
                    Console.ForegroundColor = ConsoleColor.Green;

                // print grid element 
                Console.Write(" " + grid[index] + " ");

                // add vertical separator if not last column
                if (j < 2)
                {
                    Console.ForegroundColor = ConsoleColor.White; // reset color to default
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
        int turnCount = 0;

        while (!HasWinner() && turnCount != 9) 
        {
            PrintGrid(grid);

            Console.ForegroundColor = ConsoleColor.White; // reset color to default
            
            if (firstPlayerTurn) 
                Console.WriteLine("First player's turn");
            else
                Console.WriteLine("Second player's turn");

            string move = Console.ReadLine();

            if (grid.Contains(move) && move != "X" && move != "O")
            {
                int gridIndex = Convert.ToInt32(move) - 1;
                
                if (firstPlayerTurn)
                {
                    grid[gridIndex] = "X";
                }   
                else
                    grid[gridIndex] = "O";

                turnCount++;
            }

            // toggle turn btwn first and second players
            firstPlayerTurn = !firstPlayerTurn;
        }

        if(HasWinner()) 
            Console.WriteLine("We have a winner!");
        else
            Console.WriteLine("Tie!");

        bool HasWinner()
        {
            // checking for all Xs or all Os
            // rows
            bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
            bool row2 = grid[3] == grid[4] && grid[4] == grid[5]; 
            bool row3 = grid[6] == grid[7] && grid[7] == grid[8]; 
            // columns
            bool col1 = grid[0] == grid[3] && grid[3] == grid[6]; 
            bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
            bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
            // diagonals
            bool diagDown = grid[0] == grid[4] && grid[4] == grid[8]; 
            bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

            return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
        }
    }
}

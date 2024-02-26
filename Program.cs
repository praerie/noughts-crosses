using System;
using System.Linq;

class Program
{
    static string[] grid;

    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain) 
        {
            grid = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
            bool firstPlayerTurn = true;
            int turnCount = 0;

            while (!HasWinner() && turnCount != 9) 
            {
                PrintGrid(grid);

                if (firstPlayerTurn) 
                    Console.Write("\nCROSS player's turn\n> ");
                else
                    Console.Write("\nNOUGHT player's turn\n> ");

                string move = Console.ReadLine();

                if (int.TryParse(move, out int moveInt) && moveInt >= 1 && moveInt <= 9)
                {
                    move = moveInt.ToString();
                    int gridIndex = moveInt - 1;
                    
                    if (grid.Contains(move) && grid[gridIndex] != "X" && grid[gridIndex] != "O")
                    {
                        if (firstPlayerTurn)
                        {
                            grid[gridIndex] = "X";
                        }
                        else
                        {
                            grid[gridIndex] = "O";
                        }

                        turnCount++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[!] Invalid move! Please choose an empty cell.");
                        continue;
                    }

                    // toggle turn if the move is valid
                    firstPlayerTurn = !firstPlayerTurn;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Invalid input! Please enter a number between 1 and 9.");
                }    
            }

            if(HasWinner()) 
                Console.WriteLine("\n~* We have a winner! *~");
            else
                Console.WriteLine("\n> It's a tie! <"); 
            
            PrintGrid(grid);

            bool validInput = false;
            while (!validInput)
            {
                Console.Write("\nDo you want to play again? (Y/N)> ");
                string playAgainInput = Console.ReadLine().ToLower();

                try
                {
                    if (playAgainInput == "y")
                        validInput = true;
                    else if (playAgainInput == "n") 
                    {
                        playAgain = false;
                        validInput = true;
                        Console.WriteLine("\nThank you for playing!\n");
                    }
                    else
                        throw new Exception("Invalid input! Please enter Y or N.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    static bool HasWinner()
    {
        // checking for all Xs or all Os across rows, columns, and diagonals 
        bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
        bool row2 = grid[3] == grid[4] && grid[4] == grid[5]; 
        bool row3 = grid[6] == grid[7] && grid[7] == grid[8]; 
        bool col1 = grid[0] == grid[3] && grid[3] == grid[6]; 
        bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
        bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
        bool diagDown = grid[0] == grid[4] && grid[4] == grid[8]; 
        bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

        return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
    }

    static void PrintGrid(string[] grid) 
    {
        Console.WriteLine("");
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

                Console.ForegroundColor = ConsoleColor.White; // reset color to default

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
                Console.WriteLine(new string('-', 11));
            }
        }
    }
}
